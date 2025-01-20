using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpUserLedgerDelta
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("usdc")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal USDC { get; set; }


        [JsonPropertyName("fundingRate")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal? FundingRate { get; set; }

        [JsonPropertyName("szi")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal? SZI { get; set; }
    }
}
