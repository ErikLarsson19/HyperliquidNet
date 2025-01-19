using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpFundingHistoryEntry : BasePerpHistoryEntry
    {
        [JsonPropertyName("delta")]
        public PerpUserFundingDelta Delta { get; set; }
    }
}
