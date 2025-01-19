using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal EntryPx { get; set; }

        [JsonPropertyName("leverage")]
        public PerpLeverage Leverage { get; set; }

        [JsonPropertyName("liquidationPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal LiquidationPx { get; set; }

        [JsonPropertyName("marginUsed")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MarginUsed { get; set; }

        [JsonPropertyName("maxLeverage")]
        public int MaxLeverage { get; set; }

        [JsonPropertyName("positionValue")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal PositionValue { get; set; }

        [JsonPropertyName("returnOnEquity")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal ReturnOnEquity { get; set; }

        [JsonPropertyName("szi")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Szi { get; set; }

        [JsonPropertyName("unrealizedPnl")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal UnrealizedPnl { get; set; }
    }
}
