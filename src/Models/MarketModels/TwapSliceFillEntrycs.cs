using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class TwapSliceFillEntrycs
    {
        [JsonPropertyName("closedPnl")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal ClosedPnl { get; set; }

        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("crossed")]
        public bool Crossed { get; set; }

        [JsonPropertyName("dir")]
        public string Dir { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("oid")]
        public long Oid { get; set; }

        [JsonPropertyName("px")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Px { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("startPosition")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal StartPosition { get; set; }

        [JsonPropertyName("sz")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Sz { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonIgnore]
        public DateTime Timestamp => ParseUtils.ParseUnixTimeStamp(Time);

        [JsonPropertyName("fee")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Fee { get; set; }

        [JsonPropertyName("feeToken")]
        public string FeeToken { get; set; }

        [JsonPropertyName("tid")]
        public long Tid { get; set; }
    }
}
