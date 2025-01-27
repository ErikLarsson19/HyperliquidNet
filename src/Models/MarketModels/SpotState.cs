using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class SpotState
    {
        [JsonPropertyName("balances")]
        public List<Balance> Balances { get; set; }
    }
}
