﻿using HyperliquidNet.src.Models.Responses.Spot;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Services.Interfaces
{
    /// <summary>
    /// Provides access to spot market operations and data
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

        /// <summary>
        /// Retrieves spot asset contexts
        /// </summary>
        /// <returns></returns>
        Task<SpotAssetContextResponse> GetSpotAssetContextsAsync();

        /// <summary>
        /// Retrieves detailed information about a specified token
        /// </summary>
        /// <param name="id">The onchain 34-char hexdecimal format id of the token</param>
        /// <returns></returns>
        Task<SpotTokenInformationResponse> GetSpotTokenDetailsAsync(string id);
    }
}
