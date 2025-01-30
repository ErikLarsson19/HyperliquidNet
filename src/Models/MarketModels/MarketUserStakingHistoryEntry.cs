using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class MarketUserStakingHistoryEntry
    {
        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("delta")]
        public DeleGate Delegate { get; set; }
    }
}
