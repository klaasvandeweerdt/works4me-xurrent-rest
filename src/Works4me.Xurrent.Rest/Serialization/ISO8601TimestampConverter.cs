using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Works4me.Xurrent.Rest.Utilities;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides JSON serialization and deserialization for <see cref="DateTime"/> values using ISO 8601 timestamp format ("yyyy-MM-ddTHH:mm:ssK").
    /// </summary>
    internal sealed class ISO8601TimestampConverter : JsonConverter<DateTime>
    {
        /// <summary>
        /// Reads a <see cref="DateTime"/> value from an ISO 8601 timestamp string in JSON.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert (should be <see cref="DateTime"/>).</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <see cref="DateTime"/> value.</returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException($"Unexpected token parsing DateTime. Expected String, got {reader.TokenType}.");

            string? value = reader.GetString();

            if (DateTime.TryParse(value, out DateTime dt))
                return dt;

            switch (value)
            {
                case "best_effort":
                    return SpecialTimestamps.BestEffort.Value;
                case "no_target":
                    return SpecialTimestamps.NoTarget.Value;
                case "clock_stopped":
                    return SpecialTimestamps.ClockStopped.Value;
                default:
                    throw new JsonException($"Unrecognized timestamp token: {value}");
            }
        }

        /// <summary>
        /// Writes a <see cref="DateTime"/> value as an ISO 8601 timestamp string ("yyyy-MM-ddTHH:mm:ssK") in JSON.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The <see cref="DateTime"/> value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            if (SpecialTimestamps.ValueToText.TryGetValue(value, out string? text))
                writer.WriteStringValue(text);
            else
                writer.WriteStringValue(value.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture));
        }
    }
}
