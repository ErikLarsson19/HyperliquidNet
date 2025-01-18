using HyperliquidNet.src.Models.SpotModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses.Spot
{
    public class SpotBalanceResponse
    {
        [JsonPropertyName("balances")]
        public List<SpotBalance> Balances { get; set; }
    }
}
