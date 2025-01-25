using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class L2BookLevel
    {
        [JsonPropertyName("px")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Price { get; set; }

        [JsonPropertyName("sz")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Size { get; set; }

        [JsonPropertyName("n")]
        public int NumberOfOrders { get; set; }
    }
}
