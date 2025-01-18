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
        public string DayNotionalVolume { get; set; }

        [JsonPropertyName("funding")]
        public string Funding { get; set; }

        [JsonPropertyName("impactPxs")]
        public List<string> ImpactPrices { get; set; }

        [JsonPropertyName("markPx")]
        public string MarkPrice { get; set; }

        [JsonPropertyName("midPx")]
        public string MidPrice { get; set; }

        [JsonPropertyName("openInterest")]
        public string OpenInterest { get; set; }

        [JsonPropertyName("oraclePx")]
        public string OraclePrice { get; set; }

        [JsonPropertyName("premium")]
        public string Premium { get; set; }

        [JsonPropertyName("prevDayPx")]
        public string PreviousDayPrice { get; set; }
    }
}
