using HyperliquidNet.src.Utils;
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
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal FundingRate { get; set; }

        [JsonPropertyName("premium")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Premium { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonIgnore]
        public DateTime Timestamp => ParseUtils.ParseUnixTimeStamp(Time);
    }
}
