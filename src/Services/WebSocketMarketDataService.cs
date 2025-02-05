using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services
{
    public class WebSocketMarketDataService : WebSocketBaseService
    {

        public WebSocketMarketDataService(HyperliquidWebsocketClient client)
            : base(client) { }
        public async Task SubscribeToTradesAsync(string coin)
        {
            await Subscribe(new
            {
                type = "trades",
                coin = coin
            });
        }

        public async Task SubscribeAllMids()
        {
            await Subscribe(new
            {
                type = "allMids"
            });
        }

        public async Task SubscribeNotification(string address)
        {
            await Subscribe(new
            {
                type = "notification",
                user = address
            });
        }

        public async Task SubscribeWebData2(string address)
        {
            await Subscribe(new
            {
                type = "webData2",
                user = address
            });
        }

        //candle l2book missing

        public async Task SubscribeOrderUpdates(string address)
        {
            await Subscribe(new
            {
                type = "orderUpdates",
                user = address
            });
        }


    }
}
