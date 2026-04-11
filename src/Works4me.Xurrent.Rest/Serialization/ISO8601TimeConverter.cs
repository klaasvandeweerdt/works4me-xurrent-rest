using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Globalization;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides JSON serialization and deserialization for <see cref="TimeSpan"/> values using ISO 8601 time format ("HH:mm").
    /// </summary>
    internal sealed class ISO8601TimeConverter : JsonConverter<TimeSpan>
    {
        /// <summary>
        /// Reads a <see cref="TimeSpan"/> value from an ISO 8601 time string in JSON.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert (should be <see cref="TimeSpan"/>).</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <see cref="TimeSpan"/> value.</returns>
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException($"Expected string for TimeSpan, got {reader.TokenType}.");

            string s = reader.GetString()!;

            string[] parts = s.Split(':');
            if (parts.Length == 2
                && int.TryParse(parts[0], out int h)
                && int.TryParse(parts[1], out int m))
            {
                return TimeSpan.FromHours(h).Add(TimeSpan.FromMinutes(m));
            }

            return TimeSpan.Parse(s, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Writes a <see cref="TimeSpan"/> value as an ISO 8601 time string ("HH:mm") in JSON.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The <see cref="TimeSpan"/> value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            int hours = (int)Math.Floor(value.TotalHours);
            writer.WriteStringValue($"{hours:00}:{value.Minutes:00}");
        }
    }
}
