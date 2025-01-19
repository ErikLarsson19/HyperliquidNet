using HyperliquidNet.src.Models.Responses.Perp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services.Interfaces
{
    /// <summary>
    /// Provides access to perp market data 
    /// </summary>
    public interface IPerpService
    {

        /// <summary>
        /// Retrieves perpetuals metadata
        /// </summary>
        /// <returns></returns>
        Task<PerpMetadataResponse> GetPerpMetadataAsync();


        /// <summary>
        /// Retrieves historical funding rates of the specified coin
        /// </summary>
        /// <param name="coin">A token eg "ETH"</param>
        /// <param name="startTime">Start time in milliseconds, inclusive</param>
        /// <param name="endTime">Optional, End time in milliseconds, defaults to current time</param>
        /// <returns></returns>
        Task<HistoricalFundingRateResponse> GetCoinHistoricalFundingRateAsync(string coin, int startTime, int? endTime = null);



        Task<AssetContextResponse> GetPerpAssetContextsAsync();

        Task<PerpAccountSummaryResponse> GetPerpAccountSummaryAsync(string address);

        Task<PerpUserNonFundingHistoryResponse> GetUserNonFundingHistoryAsync(
            string user, int startTime, int? endTime = null);


        Task<PerpUserFundingHistoryResponse> GetUserFundingHistoryAsync(
            string user, int startTime, int? endTime = null);
    }
}
