using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class MarginSummary
    {
        [JsonPropertyName("accountValue")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal AccountValue { get; set; }

        [JsonPropertyName("totalNtlPos")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal TotalNtlPos { get; set; }

        [JsonPropertyName("totalRawUsd")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal TotalRawUsd { get; set; }

        [JsonPropertyName("totalMarginUsed")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal TotalMarginUsed { get; set; }
    }
}
