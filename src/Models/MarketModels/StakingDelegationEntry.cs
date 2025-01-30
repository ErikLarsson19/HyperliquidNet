using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class StakingDelegationEntry
    {

        [JsonPropertyName("validator")]
        public string Validator { get; set; }

        [JsonPropertyName("amount")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Amount { get; set; }

        [JsonPropertyName("lockedUntilTimestamp")]
        public long LockedUntilTimestamp { get; set; }
    }
}
