using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses.MarketInfo
{
    public class MarketUserRateLimitResponse
    {
        [JsonPropertyName("cumVlm")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal CumVlm { get; set; }

        [JsonPropertyName("nRequestsUsed")]
        public long NRequestsUsed { get; set; }

        [JsonPropertyName("nRequestsCap")]
        public long NRequestsCap { get; set; }
    }
}
