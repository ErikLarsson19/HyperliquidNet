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
    public class PerpLeverage
    {
        [JsonPropertyName("rawUsd")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal RawUsd { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}
