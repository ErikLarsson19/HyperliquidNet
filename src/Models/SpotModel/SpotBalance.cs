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
        public string Hold { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }

        [JsonPropertyName("entryNtl")]
        public string EntryNtl { get; set; }
    }
}
