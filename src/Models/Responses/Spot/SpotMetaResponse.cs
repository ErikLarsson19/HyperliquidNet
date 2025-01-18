using HyperliquidNet.src.Models.SpotModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses.Spot
{
    public class SpotMetaResponse
    {
        [JsonPropertyName("tokens")]
        public List<SpotMetaToken> Tokens { get; set; }


        [JsonPropertyName("universe")]
        public List<SpotMetaUniverse> Universe { get; set; }
    }
}
