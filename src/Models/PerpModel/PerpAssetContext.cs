using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpAssetContext
    {
        [JsonPropertyName("dayNtlVlm")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal DayNotionalVolume { get; set; }

        [JsonPropertyName("funding")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Funding { get; set; }

        [JsonPropertyName("impactPxs")]
        public List<string> ImpactPrices { get; set; }

        [JsonPropertyName("markPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MarkPrice { get; set; }

        [JsonPropertyName("midPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MidPrice { get; set; }

        [JsonPropertyName("openInterest")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal OpenInterest { get; set; }

        [JsonPropertyName("oraclePx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal OraclePrice { get; set; }

        [JsonPropertyName("premium")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal? Premium { get; set; }

        [JsonPropertyName("prevDayPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal PreviousDayPrice { get; set; }
    }
}
