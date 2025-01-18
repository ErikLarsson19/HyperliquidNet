using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpUserState
    {
        [JsonPropertyName("assetPositions")]
        public List<AssetPosition> AssetPositions { get; set; }

        [JsonPropertyName("crossMaintenanceMarginUsed")]
        public string CrossMaintenanceMarginUsed { get; set; }

        [JsonPropertyName("crossMarginSummary")]
        public PerpMarginSummary CrossMarginSummary { get; set; }

        [JsonPropertyName("marginSummary")]
        public PerpMarginSummary MarginSummary { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("withdrawable")]
        public string Withdrawable { get; set; }
    }
}
