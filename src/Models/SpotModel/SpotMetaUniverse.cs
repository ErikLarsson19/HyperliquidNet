using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.SpotModel
{
    public class SpotMetaUniverse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tokens")]
        public List<int> Tokens { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("isCanonical")]
        public bool IsCanonical { get; set; }
    }
}
