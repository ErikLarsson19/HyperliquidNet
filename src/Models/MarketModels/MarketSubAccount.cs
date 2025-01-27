using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class MarketSubAccount
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("subAccountUser")]
        public string SubAccountUser { get; set; }

        [JsonPropertyName("master")]
        public string Master { get; set; }

        [JsonPropertyName("clearinghouseState")]
        public MarketClearinghouseState ClearinghouseState { get; set; }

        [JsonPropertyName("spotState")]
        public SpotState SpotState { get; set; }
    }
}
