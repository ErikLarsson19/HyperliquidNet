using HyperliquidNet.src.Models.SpotModel;
using HyperliquidNet.src.Utils;
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
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MaxSupply { get; set; }

        [JsonPropertyName("totalSupply")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal TotalSupply { get; set; }

        [JsonPropertyName("circulatingSupply")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal CirculatingSupply { get; set; }

        [JsonPropertyName("szDecimals")]
        public int SizeDecimals { get; set; }

        [JsonPropertyName("weiDecimals")]
        public int WeiDecimals { get; set; }

        [JsonPropertyName("midPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MidPrice { get; set; }

        [JsonPropertyName("markPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MarkPrice { get; set; }

        [JsonPropertyName("prevDayPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal PreviousDayPrice { get; set; }

        [JsonPropertyName("genesis")]
        public GenesisInfo Genesis { get; set; }

        [JsonPropertyName("deployer")]
        public string Deployer { get; set; }

        [JsonPropertyName("deployGas")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal DeployGas { get; set; }

        [JsonPropertyName("deployTime")]
        public string DeployTime { get; set; }

        [JsonPropertyName("seededUsdc")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal SeededUsdc { get; set; }

        [JsonPropertyName("nonCirculatingUserBalances")]
        public List<object> NonCirculatingUserBalances { get; set; }

        [JsonPropertyName("futureEmissions")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal FutureEmissions { get; set; }
    }
}
