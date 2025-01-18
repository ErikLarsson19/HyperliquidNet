using HyperliquidNet.src.Models.PerpModel;
using HyperliquidNet.src.Models.Responses.Perp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.ArrayHandlers
{
    public class AssetContextResponseConverter : JsonConverter<AssetContextResponse>
    {
        private readonly ArrayResponseConverter<PerpMetadataResponse, List<PerpAssetContext>> _innerConverter;

        public AssetContextResponseConverter()
        {
            _innerConverter = new ArrayResponseConverter<PerpMetadataResponse, List<PerpAssetContext>>();
        }

        public override AssetContextResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var baseResponse = _innerConverter.Read(ref reader, typeToConvert, options);
            return new AssetContextResponse
            {
                First = baseResponse.First,
                Second = baseResponse.Second
            };
        }

        public override void Write(Utf8JsonWriter writer, AssetContextResponse value, JsonSerializerOptions options)
        {
            _innerConverter.Write(writer, value, options);
        }
    }
}
