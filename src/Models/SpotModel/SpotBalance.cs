using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.SpotModel
{
    public class SpotBalance
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("token")]
        public int Token { get; set; }

        [JsonPropertyName("hold")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Hold { get; set; }

        [JsonPropertyName("total")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Total { get; set; }

        [JsonPropertyName("entryNtl")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal EntryNtl { get; set; }
    }
}
