using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Utils
{
    public class UnixTimestampConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                long timestamp = reader.GetInt64();
                return ParseUtils.ParseUnixTimeStamp(timestamp);
            }
            throw new JsonException("Expected unix timestamp number");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var epoch = new DateTimeOffset(value).ToUnixTimeMilliseconds();
            writer.WriteNumberValue(epoch);
        }
    }
}
