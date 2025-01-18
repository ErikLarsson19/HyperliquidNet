using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpMetaUniverse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("szDecimals")]
        public int SizeDecimals { get; set; }

        [JsonPropertyName("maxLeverage")]
        public int MaxLeverage { get; set; }

        [JsonPropertyName("onlyIsolated")]
        public bool? OnlyIsolated { get; set; }

        [JsonPropertyName("isDelisted")]
        public bool? IsDelisted { get; set; }
    }
}
