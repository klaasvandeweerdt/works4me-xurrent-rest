using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides JSON serialization and deserialization for nullable <see cref="DateTimeOffset"/> values using ISO 8601 timestamp format ("yyyy-MM-ddTHH:mm:ssK").
    /// </summary>
    internal sealed class ISO8601TimestampNullableConverter : JsonConverter<DateTime?>
    {
        private readonly ISO8601TimestampConverter _inner = new();

        /// <summary>
        /// Reads a nullable <see cref="DateTimeOffset"/> value from an ISO 8601 timestamp string in JSON.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert (should be <see cref="Nullable{DateTimeOffset}"/>).</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <see cref="Nullable{DateTimeOffset}"/> value, or <see langword="null"/> if the token is null.</returns>
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            return _inner.Read(ref reader, typeof(DateTime), options);
        }

        /// <summary>
        /// Writes a nullable <see cref="DateTimeOffset"/> value as an ISO 8601 timestamp string ("yyyy-MM-ddTHH:mm:ssK") in JSON.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The <see cref="Nullable{DateTimeOffset}"/> value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                _inner.Write(writer, value.Value, options);
            else
                writer.WriteNullValue();
        }
    }
}
