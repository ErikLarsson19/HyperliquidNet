using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.SpotModel
{
    public class GasAuction
    {
        [JsonPropertyName("startTimeSeconds")]
        public long StartTimeSeconds { get; set; }

        [JsonPropertyName("durationSeconds")]
        public int DurationSeconds { get; set; }

        [JsonPropertyName("startGas")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal StartGas { get; set; }

        [JsonPropertyName("currentGas")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal? CurrentGas { get; set; }

        [JsonPropertyName("endGas")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public string EndGas { get; set; }
    }
}
