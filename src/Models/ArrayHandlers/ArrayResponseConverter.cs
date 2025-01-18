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
    public class ArrayResponseConverter<T1, T2> : JsonConverter<ArrayResponse<T1, T2>>
    {
        public override ArrayResponse<T1, T2> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException("Expected start of array");
            }

            reader.Read();
            var first = JsonSerializer.Deserialize<T1>(ref reader, options);

            reader.Read();
            var second = JsonSerializer.Deserialize<T2>(ref reader, options);

            reader.Read();

            return new ArrayResponse<T1, T2>
            {
                First = first,
                Second = second
            };
        }

        public override void Write(Utf8JsonWriter writer, ArrayResponse<T1, T2> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.First, options);
            JsonSerializer.Serialize(writer, value.Second, options);
            writer.WriteEndArray();
        }
    }
}

