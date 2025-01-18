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

    /// <summary>
    /// Major changes needed, move to a response handler pattern instead of having it inside the response class.
    /// </summary>
    [JsonConverter(typeof(SpotAssetContextResponseConverter))]
    public class SpotAssetContextResponse
    {
        public SpotMetaResponse MetaData { get; set; }
        public List<SpotAssetContext> AssetContexts { get; set; }
    }

    public class SpotAssetContextResponseConverter : JsonConverter<SpotAssetContextResponse>
    {
        public override SpotAssetContextResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected JSON array");

            var response = new SpotAssetContextResponse();

            reader.Read();
            response.MetaData = JsonSerializer.Deserialize<SpotMetaResponse>(ref reader, options);

            reader.Read();
            response.AssetContexts = JsonSerializer.Deserialize<List<SpotAssetContext>>(ref reader, options);

            reader.Read();

            return response;
        }

        public override void Write(Utf8JsonWriter writer, SpotAssetContextResponse value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.MetaData, options);
            JsonSerializer.Serialize(writer, value.AssetContexts, options);
            writer.WriteEndArray();
        }
    }
}
