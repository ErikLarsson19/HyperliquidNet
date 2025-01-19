using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpCumulativeFunding
    {
        [JsonPropertyName("allTime")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal AllTime { get; set; }

        [JsonPropertyName("sinceChange")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal SinceChange { get; set; }

        [JsonPropertyName("sinceOpen")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal SinceOpen { get; set; }
    }
}
