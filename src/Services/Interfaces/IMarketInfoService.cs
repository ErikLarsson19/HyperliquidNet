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

        Task<MarketOpenOrderResponse> GetMarketOpenOrdersAsync(string address);
    }
}
