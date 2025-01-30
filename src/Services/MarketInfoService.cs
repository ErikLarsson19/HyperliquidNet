using HyperliquidNet.src.Models.MarketModels;
using HyperliquidNet.src.Models.Responses.MarketInfo;
using HyperliquidNet.src.Models.Responses.Perp;
using HyperliquidNet.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<int> GetMaxBuilderFeeAsync(string user, string builder)
        {
            var request = new
            {
                user,
                builder
            };

            return await SendHyperliquidRequestAsync<int>(
                "maxBuilderFee",
                request
                );
        }

        public async Task<MarketUserHistoricalOrdersResponse> GetUserHistoricalOrders(string address)
        {
            return await SendHyperliquidRequestAsync<MarketUserHistoricalOrdersResponse>(
                "historicalOrders",
                new { user = address }
                );
        }

        public async Task<MarketUserTwapSliceFillsResponse> GetUserTwapSliceFills(string address)
        {
            return await SendHyperliquidRequestAsync<MarketUserTwapSliceFillsResponse>(
                "userTwapSliceFills",
                new { user = address }
                );
        }

        public async Task<MarketSubAccountsResponse> GetSubAccounts(string address)
        {
            try
            {
                var response = await SendHyperliquidRequestAsync<MarketSubAccountsResponse>(
                    "subAccounts",
                    new { user = address }
                    );

                return response ?? new MarketSubAccountsResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
        }

        public async Task<VaultDetailResponse> GetVaultDetails(
            string vaultAddress, string? user = null)
        {
            var request = new
            {
                vaultAddress,
                user
            };
            return await SendHyperliquidRequestAsync<VaultDetailResponse>(
                "vaultDetails",
                request
                );
        }

        public async Task<MarketUserVaultDepositionsResponse> GetUserVaultDepositions(string address)
        {
            return await SendHyperliquidRequestAsync<MarketUserVaultDepositionsResponse>(
                "userVaultEquities",
                new { user = address }
                );
        }

        public async Task<MarketUserRole> GetUserRole(string address)
        {
            return await SendHyperliquidRequestAsync<MarketUserRole>(
                "userRole",
                new { user = address }
                );
        }

        public async Task<MarketUserStakingDelegationsResponse> GetUserStakingDelegations(string address)
        {
            return await SendHyperliquidRequestAsync<MarketUserStakingDelegationsResponse>(
                "delegations",
                new { user = address }
                );
        }

        public async Task<MarketUserStakingHistoryResponse> GetUserStakingHistory(string address)
        {
            return await SendHyperliquidRequestAsync<MarketUserStakingHistoryResponse>(
                "delegatorHistory",
                new { user = address }
                );
        }

    }
}




