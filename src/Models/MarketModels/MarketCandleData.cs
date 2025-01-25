using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class MarketCandleData
    {

        [JsonPropertyName("T")]
        public long CloseTime { get; set; }

        [JsonPropertyName("c")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal ClosePrice { get; set; }

        [JsonPropertyName("h")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal HighPrice { get; set; }

        [JsonPropertyName("i")]
        public string Interval { get; set; }

        [JsonPropertyName("l")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal LowPrice { get; set; }

        [JsonPropertyName("n")]
        public int NumberOfTrades { get; set; }

        [JsonPropertyName("o")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal OpenPrice { get; set; }

        [JsonPropertyName("s")]
        public string Symbol { get; set; }

        [JsonPropertyName("t")]
        public long OpenTime { get; set; }

        [JsonPropertyName("v")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Volume { get; set; }
    }
}
