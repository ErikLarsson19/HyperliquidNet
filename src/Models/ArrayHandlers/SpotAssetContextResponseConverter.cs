using HyperliquidNet.src.Models.ArrayHandlers;
using HyperliquidNet.src.Models.PerpModel;
using HyperliquidNet.src.Models.Responses.Perp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using HyperliquidNet.src.Models.Responses.Spot;
using HyperliquidNet.src.Models.SpotModel;
using System.Buffers.Text;
using System.Runtime.ConstrainedExecution;

namespace HyperliquidNet.src.Models.ArrayHandlers
{
    public class SpotAssetContextResponseConverter : JsonConverter<SpotAssetContextResponse>
    {
        private readonly ArrayResponseConverter<SpotMetaResponse, List<SpotAssetContext>> _innerConverter;

        public SpotAssetContextResponseConverter()
        {
            _innerConverter = new ArrayResponseConverter<SpotMetaResponse, List<SpotAssetContext>>();
        }

        public override SpotAssetContextResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var baseResponse = _innerConverter.Read(ref reader, typeToConvert, options);
            return new SpotAssetContextResponse
            {
                First = baseResponse.First,
                Second = baseResponse.Second
            };
        }

        public override void Write(Utf8JsonWriter writer, SpotAssetContextResponse value, JsonSerializerOptions options)
        {
            _innerConverter.Write(writer, value, options);
        }
    }
}


