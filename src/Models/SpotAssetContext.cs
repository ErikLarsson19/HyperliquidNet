using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models
{
    public class SpotAssetContext
    {
        [JsonPropertyName("dayNtlVlm")]
        public string DayNtlVolume { get; set; }

        [JsonPropertyName("markPx")]
        public string MarkPrice { get; set; }

        [JsonPropertyName("midPx")]
        public string MidPrice { get; set; }

        [JsonPropertyName("prevDayPx")]
        public string PrevDayPrice { get; set; }
    }
}
