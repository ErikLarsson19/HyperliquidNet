using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models
{
    public class StateSpec
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("szDecimals")]
        public int SizeDecimals { get; set; }

        [JsonPropertyName("weiDecimals")]
        public int WeiDecimals { get; set; }
    }
}
