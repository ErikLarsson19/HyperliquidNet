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
    public class BaseService
    {

        protected readonly HttpClient _httpClient;

        protected BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        protected async Task<T> SendHyperliquidRequestAsync<T>(string type, object parameters = null)
        {
            var requestDict = new Dictionary<string, object> { { "type", type } };

            if (parameters != null)
            {
                var paramProperties = parameters.GetType().GetProperties();
                foreach (var prop in paramProperties)
                {
                    var value = prop.GetValue(parameters);
                    if (value != null)
                    {
                        requestDict.Add(prop.Name, value);
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
    }
}
