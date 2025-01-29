using HyperliquidNet.src.Models.MarketModels;
using HyperliquidNet.src.Models.Responses.MarketInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services.Interfaces
{
    public interface IMarketInfoService
    {
        /// <summary>
        /// Retrieve a users open orders with additonal frontend info
        /// </summary>
        /// <param name="address">A valid wallet address</param>
        /// <returns></returns>
        Task<MarketOpenOrderFrontendResponse> GetMarketOpenOrdersAsync(string address);

        /// <summary>
        /// Retrieve a shorter version of the above call, no additional frontend info
        /// </summary>
        /// <param name="address">A valid wallet address</param>
        /// <returns></returns>
        Task<MarketOpenOrderResponse> GetMarketOpenOrdersTinyAsync(string address);


        Task<MarketUserFillsFrontendResponse> GetMarketUserFillsFrontendAsync(string address);

        Task<MarketUserFillsResponse> GetMarketUserFillsAsync(string address, bool? aggregateByTime = null);

        Task<MarketUserFillsByTimeResponse> GetMarketUserFillsByTimeAsync(
            string user, int startTime, int? endTime = null, bool? aggregateByTime = null);

        Task<MarketUserRateLimitResponse> GetMarketUserRateLimit(string address);

        Task<L2BookResponse> GetMarketL2Book(string coin, int? nSigFigs = null, int? mantissa = null);

        Task<MarketCandleSnapshotResponse> GetMarketCandleSnapshot(
            string coin, string interval, long startTime, long endTime);


        Task<int> GetMaxBuilderFeeAsync(string user, string builder);


        Task<MarketUserHistoricalOrdersResponse> GetUserHistoricalOrders(string address);

        Task<MarketUserTwapSliceFillsResponse> GetUserTwapSliceFills(string address);

        Task<MarketSubAccountsResponse> GetSubAccounts(string address);


        Task<VaultDetailResponse> GetVaultDetails(
            string vaultAddress, string? user = null);

    }
}
