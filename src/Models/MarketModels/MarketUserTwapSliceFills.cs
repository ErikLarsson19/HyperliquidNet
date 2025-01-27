using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class MarketUserTwapSliceFills
    {
        [JsonPropertyName("fill")]
        public TwapSliceFillEntrycs twapSliceFillEntry { get; set; }

        [JsonPropertyName("twapId")]
        public long TwapId { get; set; }
    }
}
