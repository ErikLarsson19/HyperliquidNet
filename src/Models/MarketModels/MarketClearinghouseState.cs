using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class MarketClearinghouseState
    {
        [JsonPropertyName("marginSummary")]
        public MarginSummary MarginSummary { get; set; }

        [JsonPropertyName("crossMarginSummary")]
        public MarginSummary CrossMarginSummary { get; set; }

        [JsonPropertyName("crossMaintenanceMarginUsed")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal CrossMaintenanceMarginUsed { get; set; }

        [JsonPropertyName("withdrawable")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Withdrawable { get; set; }

        [JsonPropertyName("assetPositions")]
        public List<object> AssetPositions { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonIgnore]
        public DateTime Timestamp => ParseUtils.ParseUnixTimeStamp(Time);
    }
}
