using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpUserFundingDelta : BasePerpUserDelta
    {
        [JsonPropertyName("fundingRate")]
        public string FundingRate { get; set; }

        [JsonPropertyName("szi")]
        public string Szi { get; set; }
    }
}
