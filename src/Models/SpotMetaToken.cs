using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models
{
    public class SpotMetaToken
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("szDecimals")]
        public int SizeDecimals { get; set; }

        [JsonPropertyName("weiDecimals")]
        public int WeiDecimals { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("tokenId")]
        public string TokenId { get; set; }

        [JsonPropertyName("isCanonical")]
        public bool IsCanonical { get; set; }

        [JsonPropertyName("evmContract")]
        public string? EvmContract { get; set; }

        [JsonPropertyName("fullName")]
        public string? FullName { get; set; }
    }
}
