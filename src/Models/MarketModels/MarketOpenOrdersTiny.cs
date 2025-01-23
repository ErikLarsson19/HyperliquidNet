using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class MarketOpenOrdersTiny
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }


        [JsonPropertyName("limitPx")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal LimitPx { get; set; }


        [JsonPropertyName("oid")]
        public long Oid { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("sz")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Sz { get; set; }

        [JsonPropertyName("timestamp")]
        public long time { get; set; }

        [JsonIgnore]
        public DateTime Timestamp => ParseUtils.ParseUnixTimeStamp(time);

    }
}
