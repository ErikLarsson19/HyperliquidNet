using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services
{
    public class WebSocketBaseService
    {
        protected readonly HyperliquidWebsocketClient _client;

        protected WebSocketBaseService(HyperliquidWebsocketClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        protected async Task Subscribe(object subscriptionData)
        {
            var request = new
            {
                method = "subscribe",
                subscription = subscriptionData
            };

            await _client.SubscribeAsync(JsonSerializer.Serialize(request));
        }
    }
}
