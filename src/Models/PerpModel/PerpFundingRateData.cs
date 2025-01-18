using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpFundingRateData
    {

        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("fundingRate")]
        public string FundingRate { get; set; }

        [JsonPropertyName("premium")]
        public string Premium { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }
    }
}
