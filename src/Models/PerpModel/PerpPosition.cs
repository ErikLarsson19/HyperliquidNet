using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpPosition
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("cumFunding")]
        public PerpCumulativeFunding CumFunding { get; set; }

        [JsonPropertyName("entryPx")]
        public string EntryPx { get; set; }

        [JsonPropertyName("leverage")]
        public PerpLeverage Leverage { get; set; }

        [JsonPropertyName("liquidationPx")]
        public string LiquidationPx { get; set; }

        [JsonPropertyName("marginUsed")]
        public string MarginUsed { get; set; }

        [JsonPropertyName("maxLeverage")]
        public int MaxLeverage { get; set; }

        [JsonPropertyName("positionValue")]
        public string PositionValue { get; set; }

        [JsonPropertyName("returnOnEquity")]
        public string ReturnOnEquity { get; set; }

        [JsonPropertyName("szi")]
        public string Szi { get; set; }

        [JsonPropertyName("unrealizedPnl")]
        public string UnrealizedPnl { get; set; }
    }
}
