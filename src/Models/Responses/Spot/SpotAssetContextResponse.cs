using HyperliquidNet.src.Models.ArrayHandlers;
using HyperliquidNet.src.Models.PerpModel;
using HyperliquidNet.src.Models.Responses.Perp;
using HyperliquidNet.src.Models.SpotModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses.Spot
{

    [JsonConverter(typeof(SpotAssetContextResponseConverter))]
    public class SpotAssetContextResponse : ArrayResponse<SpotMetaResponse, List<SpotAssetContext>>
    {

    }
}
