﻿using HyperliquidNet.src.Models.Responses.Spot;
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

        public async Task<SpotMetaResponse> GetSpotMetadataAsync()
        {
            return await SendHyperliquidRequestAsync<SpotMetaResponse>(
                "spotMeta");
        }

        public async Task<SpotAssetContextResponse> GetSpotAssetContextsAsync()
        {
            return await SendHyperliquidRequestAsync<SpotAssetContextResponse>(
                "spotMetaAndAssetCtxs");
        }

        public async Task<SpotTokenInformationResponse> GetSpotTokenDetailsAsync(string id)
        {
            return await SendHyperliquidRequestAsync<SpotTokenInformationResponse>(
                "tokenDetails",
                new { tokenId = id }
                );
        }
    }
}
