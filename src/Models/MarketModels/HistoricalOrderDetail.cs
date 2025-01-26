using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class HistoricalOrderDetail
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("limitPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal LimitPrice { get; set; }

        [JsonPropertyName("sz")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Size { get; set; }

        [JsonPropertyName("oid")]
        public long OrderId { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("triggerCondition")]
        public string TriggerCondition { get; set; }

        [JsonPropertyName("isTrigger")]
        public bool IsTrigger { get; set; }

        [JsonPropertyName("triggerPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal TriggerPrice { get; set; }

        [JsonPropertyName("children")]
        public List<object> Children { get; set; }

        [JsonPropertyName("isPositionTpsl")]
        public bool IsPositionTpsl { get; set; }

        [JsonPropertyName("reduceOnly")]
        public bool ReduceOnly { get; set; }

        [JsonPropertyName("orderType")]
        public string OrderType { get; set; }

        [JsonPropertyName("origSz")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal OriginalSize { get; set; }

        [JsonPropertyName("tif")]
        public string TimeInForce { get; set; }

        [JsonPropertyName("cloid")]
        public string ClientOrderId { get; set; }
    }
}
