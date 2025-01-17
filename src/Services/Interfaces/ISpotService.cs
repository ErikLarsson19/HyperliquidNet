using HyperliquidNet.src.Models.Responses;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services.Interfaces
{
    /// <summary>
    /// Provedes access to spot market operations and data
    /// </summary>
    public interface ISpotService
    {

        /// <summary>
        /// Retrieves the spot market balance of the specified wallet address
        /// </summary>
        /// <param name="address">A valid wallet address</param>
        /// <returns>A collection of token balances for the specified wallet</returns>
        Task<SpotBalanceResponse> GetSpotBalanceAsync(string address);

        /// <summary>
        /// Retrieves information about the spot deploy auction
        /// </summary>
        /// <param name="address">Onchain address in 42-char hexdecimal format</param>
        /// <returns>ADD</returns>
        Task<SpotDeployAuctionResponse> GetSpotDeployAuctionAsync(string address);


        /// <summary>
        /// Retrieves spot metadata information
        /// </summary>
        /// <returns>ADD</returns>
        Task<SpotMetaResponse> GetSpotMetadataAsync();


        Task<SpotAssetContextResponse> GetSpotAssetContextsAsync();
    }
}
