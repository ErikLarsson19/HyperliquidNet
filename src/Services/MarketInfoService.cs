using HyperliquidNet.src.Models.Responses.MarketInfo;
using HyperliquidNet.src.Models.Responses.Perp;
using HyperliquidNet.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services
{
    public class MarketInfoService : BaseService, IMarketInfoService
    {
        public MarketInfoService(HttpClient httpClient) : base(httpClient) { }


        public async Task<MarketOpenOrderFrontendResponse> GetMarketOpenOrdersAsync(string address)
        {
            return await SendHyperliquidRequestAsync<MarketOpenOrderFrontendResponse>(
                "frontendOpenOrders",
                new { user = address }
                );
        }

        public async Task<MarketOpenOrderResponse> GetMarketOpenOrdersTinyAsync(string address)
        {
            return await SendHyperliquidRequestAsync<MarketOpenOrderResponse>(
                "openOrders",
                new { user = address }
                );
        }

        public async Task<MarketUserFillsFrontendResponse> GetMarketUserFillsFrontendAsync(string address)
        {
            return await SendHyperliquidRequestAsync<MarketUserFillsFrontendResponse>(
                "frontendOpenOrders",
                new { user = address }
                );
        }

        public async Task<MarketUserFillsResponse> GetMarketUserFillsAsync(string user, bool? aggregateByTime = null)
        {
            dynamic requestObj = new
            {
                user
            };

            if (aggregateByTime.HasValue)
            {
                requestObj = new
                {
                    user,
                    aggregateByTime = aggregateByTime.Value
                };
            }
            return await SendHyperliquidRequestAsync<MarketUserFillsResponse>(
                "userFills",
                requestObj
                );
        }


        public async Task<MarketUserFillsByTimeResponse> GetMarketUserFillsByTimeAsync(
            string user, int startTime, int? endTime = null, bool? aggregateByTime = null)
        {
            dynamic requestObj = new
            {
                user,
                startTime,
                endTime,
                aggregateByTime
            };

            return await SendHyperliquidRequestAsync<MarketUserFillsByTimeResponse>(
                "userFillsByTime",
                requestObj
                );
        }


        public async Task<MarketUserRateLimitResponse> GetMarketUserRateLimit(string address)
        {
            return await SendHyperliquidRequestAsync<MarketUserRateLimitResponse>(
                "userRateLimit",
                new { user = address }
                );
        }

        public async Task<L2BookResponse>GetMarketL2Book(string coin, int? nSigFigs = null, int? mantissa = null)
        {
            var requestObj = new
            {
                coin,
                nSigFigs,
                mantissa
            };

            return await SendHyperliquidRequestAsync<L2BookResponse>(
                "l2Book",
                requestObj
            );
        }

        public async Task<MarketCandleSnapshotResponse> GetMarketCandleSnapshot(
            string coin, string interval, long startTime, long endTime)
        {
            var request = new
            {
                req = new
                {
                    coin,
                    interval,
                    startTime,
                    endTime
                }
            };

            return await SendHyperliquidRequestAsync<MarketCandleSnapshotResponse>(
                "candleSnapshot",
                request
            );
        }
    }
}
