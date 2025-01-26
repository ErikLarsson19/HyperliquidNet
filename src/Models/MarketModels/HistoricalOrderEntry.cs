using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class HistoricalOrderEntry
    {
        [JsonPropertyName("order")]
        public HistoricalOrderDetail Order { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("statusTimestamp")]
        public long StatusTimestamp { get; set; }
    }
}
