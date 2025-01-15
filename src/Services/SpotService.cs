using HyperliquidNet.src.Models.Responses;
using HyperliquidNet.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<SpotBalanceResponse> GetSpotBalanceAsync(string address)
        {
            var requestBody = new
            {
                type = "spotClearinghouseState",
                user = address
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/info", content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SpotBalanceResponse>(responseContent);
        }
    }
}
