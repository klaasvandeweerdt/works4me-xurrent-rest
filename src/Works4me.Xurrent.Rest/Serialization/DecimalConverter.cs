using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides JSON serialization and deserialization for <see cref="decimal"/> values.
    /// Accepts both JSON numbers and numeric strings.
    /// </summary>
    internal sealed class DecimalConverter : JsonConverter<decimal>
    {
        /// <summary>
        /// Reads a <see cref="decimal"/> value from JSON.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert (should be <see cref="decimal"/>).</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <see cref="decimal"/> value.</returns>
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
                return reader.GetDecimal();

            if (reader.TokenType == JsonTokenType.String)
            {
                string s = reader.GetString()!;
                if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value))
                    return value;
            }

            throw new JsonException($"Expected number or numeric string for decimal, got {reader.TokenType}.");
        }

        /// <summary>
        /// Writes a <see cref="decimal"/> value as a JSON number.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The <see cref="decimal"/> value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}
