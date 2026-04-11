using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides JSON serialization and deserialization for nullable <see cref="TimeSpan"/> values using ISO 8601 time format ("HH:mm").
    /// </summary>
    internal sealed class ISO8601TimeNullableConverter : JsonConverter<TimeSpan?>
    {
        private readonly ISO8601TimeConverter _inner = new();

        /// <summary>
        /// Reads a nullable <see cref="TimeSpan"/> value from an ISO 8601 time string in JSON.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert (should be <see cref="Nullable{TimeSpan}"/>).</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <see cref="Nullable{TimeSpan}"/> value, or <see langword="null"/> if the token is null.</returns>
        public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            return _inner.Read(ref reader, typeof(TimeSpan), options);
        }

        /// <summary>
        /// Writes a nullable <see cref="TimeSpan"/> value as an ISO 8601 time string ("HH:mm") in JSON.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The <see cref="Nullable{TimeSpan}"/> value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                _inner.Write(writer, value.Value, options);
            else
                writer.WriteNullValue();
        }
    }
}
