using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Utils
{
    public class DecimalJsonConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Number:
                    // Direct decimal parsing for number tokens
                    return reader.GetDecimal();

                case JsonTokenType.String:
                    // Parse string representation
                    string stringValue = reader.GetString();
                    return ParseStringToDecimal(stringValue);

                case JsonTokenType.Null:
                    // Default to 0 for null values
                    return 0m;

                default:
                    // Catch-all for unexpected token types
                    throw new JsonException($"Unexpected token type {reader.TokenType} when parsing decimal");
            }
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            // Consistent string representation for writing
            writer.WriteStringValue(value.ToStringInvariant());
        }

        private decimal ParseStringToDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0m; 
            }

            try
            {
                return ParseUtils.ParseDecimal(value);
            }
            catch (FormatException ex)
            {
                throw new JsonException($"Failed to parse '{value}' to decimal", ex);
            }
        }
    }
}
