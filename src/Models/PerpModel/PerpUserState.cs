using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal CrossMaintenanceMarginUsed { get; set; }

        [JsonPropertyName("crossMarginSummary")]
        public PerpMarginSummary CrossMarginSummary { get; set; }

        [JsonPropertyName("marginSummary")]
        public PerpMarginSummary MarginSummary { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonIgnore]
        public DateTime Timestamp => ParseUtils.ParseUnixTimeStamp(Time);

        [JsonPropertyName("withdrawable")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Withdrawable { get; set; }
    }
}
