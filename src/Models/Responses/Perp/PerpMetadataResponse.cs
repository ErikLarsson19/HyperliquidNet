using HyperliquidNet.src.Models.PerpModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses.Perp
{
    public class PerpMetadataResponse
    {

        [JsonPropertyName("universe")]
        public List<PerpMetaUniverse> Universe { get; set; }
    }
}
