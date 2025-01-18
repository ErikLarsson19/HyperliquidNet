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
        public string StartGas { get; set; }

        [JsonPropertyName("currentGas")]
        public string? CurrentGas { get; set; }

        [JsonPropertyName("endGas")]
        public string EndGas { get; set; }
    }
}
