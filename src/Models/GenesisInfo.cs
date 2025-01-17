using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models
{
    public class GenesisInfo
    {
        [JsonPropertyName("userBalances")]
        public List<List<string>> UserBalances { get; set; }

        [JsonPropertyName("existingTokenBalances")]
        public List<object> ExistingTokenBalances { get; set; }
    }
}
