using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.SpotModel
{
    public class SpotAssetContext
    {
        [JsonPropertyName("dayNtlVlm")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal DayNtlVolume { get; set; }

        [JsonPropertyName("markPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MarkPrice { get; set; }

        [JsonPropertyName("midPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MidPrice { get; set; }

        [JsonPropertyName("prevDayPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal PrevDayPrice { get; set; }
    }
}
