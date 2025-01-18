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
        public string AllTime { get; set; }

        [JsonPropertyName("sinceChange")]
        public string SinceChange { get; set; }

        [JsonPropertyName("sinceOpen")]
        public string SinceOpen { get; set; }
    }
}
