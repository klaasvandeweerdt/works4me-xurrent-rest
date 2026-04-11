using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides JSON serialization and deserialization for nullable enum types using Xurrent REST naming conventions.
    /// </summary>
    internal sealed class XurrentEnumNullableConverter<TEnum> : JsonConverter<TEnum?>
        where TEnum : struct, Enum
    {
        private readonly XurrentEnumConverter<TEnum> _inner = new();

        /// <summary>
        /// Reads a nullable enum value from its Xurrent string representation in JSON.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert (should be <see cref="Nullable{TEnum}"/> where T is an enum type).</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <see cref="Nullable{TEnum}"/> enum value, or <see langword="null"/> if the token is null.</returns>

        public override TEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            try
            {
                return _inner.Read(ref reader, typeof(TEnum), options);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        /// <summary>
        /// Writes a nullable enum value as a Xurrent string representation in JSON.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The <see cref="Nullable{TEnum}"/> enum value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, TEnum? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                _inner.Write(writer, value.Value, options);
            else
                writer.WriteNullValue();
        }
    }
}
