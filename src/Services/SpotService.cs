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
    public class SpotService : BaseService, ISpotService
    {
        public SpotService(HttpClient httpClient) : base(httpClient) { }

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
