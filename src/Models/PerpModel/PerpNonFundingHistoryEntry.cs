using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class PerpNonFundingHistoryEntry : BasePerpHistoryEntry
    {
        [JsonPropertyName("delta")]
        public PerpUserNonFundingDelta Delta { get; set; }
    }
}
