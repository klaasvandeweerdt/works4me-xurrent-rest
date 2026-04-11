using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides JSON serialization and deserialization for nullable <see cref="decimal"/> values.
    /// </summary>
    internal sealed class DecimalNullableConverter : JsonConverter<decimal?>
    {
        private readonly DecimalConverter _inner = new();

        /// <summary>
        /// Reads a nullable <see cref="decimal"/> value from JSON.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert (should be <see cref="decimal"/>?).</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <see cref="decimal"/>? value, or <see langword="null"/> if the token is null.</returns>
        public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            return _inner.Read(ref reader, typeof(decimal), options);
        }

        /// <summary>
        /// Writes a nullable <see cref="decimal"/> value as a JSON number.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The <see cref="decimal"/>? value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                _inner.Write(writer, value.Value, options);
            else
                writer.WriteNullValue();
        }
    }
}
