using HyperliquidNet.src.Models.ArrayHandlers;
using HyperliquidNet.src.Models.MarketModels;
using System.Text.Json.Serialization;


namespace HyperliquidNet.src.Models.Responses.MarketInfo
{
    public class MarketSubAccountsResponse : List<MarketSubAccount>
    {
        public bool HasSubAccounts => this.Any();
    }
}
