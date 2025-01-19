using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class BasePerpHistoryEntry
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }
    }
}
