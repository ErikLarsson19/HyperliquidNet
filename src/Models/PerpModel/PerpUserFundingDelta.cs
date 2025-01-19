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
    public class PerpUserFundingDelta : BasePerpUserDelta
    {
        [JsonPropertyName("fundingRate")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal FundingRate { get; set; }

        [JsonPropertyName("szi")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Szi { get; set; }
    }
}
