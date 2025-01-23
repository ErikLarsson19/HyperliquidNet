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
        Task<MarketOpenOrderResponse> GetMarketOpenOrdersAsync(string address);

        /// <summary>
        /// Retrieve a shorter version of the above call, no additional frontend info
        /// </summary>
        /// <param name="address">A valid wallet address</param>
        /// <returns></returns>
        Task<MarketOpenOrderTinyResponse> GetMarketOpenOrdersTinyAsync(string address);
    }
}
