using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses
{
    public class SpotDeployAuctionResponse
    {
        [JsonPropertyName("states")]
        public List<DeployState>States { get; set; }


        [JsonPropertyName("gasAuction")]
        public GasAuction GasAuction { get; set; }
    }
}
