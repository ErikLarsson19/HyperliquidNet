using HyperliquidNet.src.Models.Responses.Perp;
using HyperliquidNet.src.Models.Responses.Spot;
using HyperliquidNet.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services
{
    public class PerpService : BaseService, IPerpService
    {

        public PerpService(HttpClient httpClient) : base(httpClient) { }


        public async Task<PerpMetadataResponse> GetPerpMetadataAsync()
        {
            return await SendHyperliquidRequestAsync<PerpMetadataResponse>(
                "meta");
        }

        public async Task<AssetContextResponse> GetPerpAssetContextsAsync()
        {
            return await SendHyperliquidRequestAsync<AssetContextResponse>(
                "metaAndAssetCtxs"
                );
        }

        public async Task<PerpAccountSummaryResponse> GetPerpAccountSummaryAsync(string address)
        {
            return await SendHyperliquidRequestAsync<PerpAccountSummaryResponse>(
                "clearinghouseState",
                new {user = address}
                );
        }

        public async Task<HistoricalFundingRateResponse> GetCoinHistoricalFundingRateAsync(string coin, int startTime, int? endTime = null) 
        {
            dynamic requestObj = new
            {
                coin,
                startTime
            };

            if (endTime.HasValue)
            {
                requestObj = new
                {
                    coin,
                    startTime,
                    endTime = endTime.Value
                };
            }

            return await SendHyperliquidRequestAsync<HistoricalFundingRateResponse>(
                "fundingHistory",
                requestObj
                );
        }
    }
}


