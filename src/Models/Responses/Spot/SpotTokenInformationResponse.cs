using HyperliquidNet.src.Models.SpotModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses.Spot
{
    public class SpotTokenInformationResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("maxSupply")]
        public string MaxSupply { get; set; }

        [JsonPropertyName("totalSupply")]
        public string TotalSupply { get; set; }

        [JsonPropertyName("circulatingSupply")]
        public string CirculatingSupply { get; set; }

        [JsonPropertyName("szDecimals")]
        public int SizeDecimals { get; set; }

        [JsonPropertyName("weiDecimals")]
        public int WeiDecimals { get; set; }

        [JsonPropertyName("midPx")]
        public string MidPrice { get; set; }

        [JsonPropertyName("markPx")]
        public string MarkPrice { get; set; }

        [JsonPropertyName("prevDayPx")]
        public string PreviousDayPrice { get; set; }

        [JsonPropertyName("genesis")]
        public GenesisInfo Genesis { get; set; }

        [JsonPropertyName("deployer")]
        public string Deployer { get; set; }

        [JsonPropertyName("deployGas")]
        public string DeployGas { get; set; }

        [JsonPropertyName("deployTime")]
        public string DeployTime { get; set; }

        [JsonPropertyName("seededUsdc")]
        public string SeededUsdc { get; set; }

        [JsonPropertyName("nonCirculatingUserBalances")]
        public List<object> NonCirculatingUserBalances { get; set; }

        [JsonPropertyName("futureEmissions")]
        public string FutureEmissions { get; set; }
    }
}
