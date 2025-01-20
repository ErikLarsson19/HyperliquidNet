using HyperliquidNet.src.Models.Responses.MarketInfo;
using HyperliquidNet.src.Models.Responses.Perp;
using HyperliquidNet.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services
{
    public class MarketInfoService : BaseService, IMarketInfoService
    {
        public MarketInfoService(HttpClient httpClient) : base(httpClient) { }


        public async Task<MarketOpenOrderResponse> GetMarketOpenOrdersAsync(string address)
        {
            return await SendHyperliquidRequestAsync<MarketOpenOrderResponse>(
                "frontendOpenOrders",
                new { user = address }
                );
        }
    }
}
