using HyperliquidNet.src.Models.Responses;
using HyperliquidNet.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services
{
    public class SpotService : ISpotService
    {
        private readonly HttpClient _httpClient;


        public SpotService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        private async Task<T> SendHyperliquidRequestAsync<T>(string type, object parameters = null)
        {
            // Start with the type
            var requestDict = new Dictionary<string, object> { { "type", type } };

            // If we have additional parameters, add them all to the dictionary
            if (parameters != null)
            {
                var paramProperties = parameters.GetType().GetProperties();
                foreach (var prop in paramProperties)
                {
                    var value = prop.GetValue(parameters);
                    if (value != null)
                    {
                        requestDict.Add(prop.Name.ToLower(), value);
                    }
                }
            }

            var content = new StringContent(
                JsonSerializer.Serialize(requestDict),
                Encoding.UTF8,
                MediaTypeHeaderValue.Parse("application/json"));

            var response = await _httpClient.PostAsync("/info", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent);
        }

        public async Task<SpotBalanceResponse> GetSpotBalanceAsync(string address)
        {
            return await SendHyperliquidRequestAsync<SpotBalanceResponse>(
                "spotClearinghouseState",
                new { user = address }
                );
        }

        public async Task<SpotDeployAuctionResponse> GetSpotDeployAuctionAsync(string address)
        {
            return await SendHyperliquidRequestAsync<SpotDeployAuctionResponse>(
                "spotDeployState",
                new { user = address }
                );
        }
    }
}
