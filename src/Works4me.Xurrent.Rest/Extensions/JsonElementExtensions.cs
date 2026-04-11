using System;
using System.Globalization;
using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Works4me.Xurrent.Rest.Utilities;

namespace Works4me.Xurrent.Rest.Extensions
{
    /// <summary>
    /// Provides extension methods for converting CLR values into <see cref="JsonElement"/> instances.
    /// </summary>
    /// <remarks>
    /// These helpers serialize values using the library’s configured JSON options and return a cloned
    /// <see cref="JsonElement"/> suitable for inclusion in request payloads.
    /// </remarks>
    public static class JsonElementExtensions
    {
        private static readonly JsonSerializerOptions _jsonOptions = SerializationConfiguration.CreateJsonOptions();

        /// <summary>
        /// Converts an <see cref="int"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this int value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this long value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this short value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this sbyte value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="uint"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this uint value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this ulong value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this ushort value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this byte value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this float value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this double value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this decimal value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="bool"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this bool value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a <see cref="JsonElement"/> as a JSON string.
        /// </summary>
        public static JsonElement ToJsonElement(this char value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="string"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        public static JsonElement ToJsonElement(this string value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts an array to a <see cref="JsonElement"/>.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="value">The array to convert.</param>
        public static JsonElement ToJsonElement<T>(this T[] value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts an object to a <see cref="JsonElement"/>.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="value">The value to convert.</param>
        public static JsonElement ToJsonElement<T>(this T value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="TimeSpan"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        /// <remarks>
        /// Serialized using the configured JSON converters (ISO 8601 time representation).
        /// </remarks>
        public static JsonElement ToJsonElement(this TimeSpan value)
        {
            string json = JsonSerializer.Serialize(value, _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        /// <remarks>
        /// Serialized using the format <c>yyyy-MM-dd'T'HH:mm:sszzz</c>.
        /// </remarks>
        public static JsonElement ToJsonElement(this DateTime value)
        {
            string json = JsonSerializer.Serialize(value.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture), _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="DateTimeOffset"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        /// <remarks>
        /// Serialized using the format <c>yyyy-MM-dd'T'HH:mm:sszzz</c>.
        /// </remarks>
        public static JsonElement ToJsonElement(this DateTimeOffset value)
        {
            string json = JsonSerializer.Serialize(value.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture), _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

#if NET6_0_OR_GREATER
        /// <summary>
        /// Converts a <see cref="DateOnly"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        /// <remarks>
        /// Serialized using the format <c>yyyy-MM-dd</c>.
        /// </remarks>
        public static JsonElement ToJsonElement(this DateOnly value)
        {
            string json = JsonSerializer.Serialize(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }

        /// <summary>
        /// Converts a <see cref="TimeOnly"/> value to a <see cref="JsonElement"/>.
        /// </summary>
        /// <remarks>
        /// Serialized using the format <c>HH:mm:ss</c>.
        /// </remarks>
        public static JsonElement ToJsonElement(this TimeOnly value)
        {
            string json = JsonSerializer.Serialize(value.ToString("HH:mm:ss", CultureInfo.InvariantCulture), _jsonOptions);
            return JsonDocument.Parse(json).RootElement.Clone();
        }
#endif
    }
}