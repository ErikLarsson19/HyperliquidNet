using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class UserStakingRewardEntry
    {
        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("totalAmount")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal TotalAmount { get; set; }
    }
}
