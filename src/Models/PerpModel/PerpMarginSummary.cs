using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpMarginSummary
    {
        [JsonPropertyName("accountValue")]
        public string AccountValue { get; set; }

        [JsonPropertyName("totalMarginUsed")]
        public string TotalMarginUsed { get; set; }

        [JsonPropertyName("totalNtlPos")]
        public string TotalNtlPos { get; set; }

        [JsonPropertyName("totalRawUsd")]
        public string TotalRawUsd { get; set; }
    }
}
