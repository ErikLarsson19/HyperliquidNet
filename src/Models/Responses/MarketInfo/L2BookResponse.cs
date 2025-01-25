using HyperliquidNet.src.Models.ArrayHandlers;
using HyperliquidNet.src.Models.MarketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses.MarketInfo
{
    public class L2BookResponse
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("levels")]
        public List<List<L2BookLevel>> Levels { get; set; }

        [JsonIgnore]
        public List<L2BookLevel> Bids => Levels?[0] ?? new List<L2BookLevel>();

        [JsonIgnore]
        public List<L2BookLevel> Asks => Levels?[1] ?? new List<L2BookLevel>();
    }
}
