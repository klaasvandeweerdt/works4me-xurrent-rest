using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides JSON serialization and deserialization for enum types using Xurrent REST naming conventions.
    /// </summary>
    internal sealed class XurrentEnumConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : struct, Enum
    {
        private readonly Dictionary<string, TEnum> _fromName;
        private readonly Dictionary<TEnum, string?> _toName;

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentEnumConverter{T}"/> class.
        /// </summary>
        public XurrentEnumConverter()
        {
            _fromName = new Dictionary<string, TEnum>(StringComparer.OrdinalIgnoreCase);
            _toName = new Dictionary<TEnum, string?>();

            foreach (FieldInfo field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                XurrentEnumAttribute? attr = field.GetCustomAttribute<XurrentEnumAttribute>();
                string name = attr?.Value ?? field.Name;
                TEnum val = (TEnum)field.GetValue(null)!;

                _fromName[name] = val;
                _toName[val] = name;
            }
        }

        /// <summary>
        /// Reads an enum value from its Xurrent string representation in JSON.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert (should be <typeparamref name="TEnum"/>).</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <typeparamref name="TEnum"/> enum value.</returns>
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                throw new JsonException("Enum value cannot be null.");
            }

            string text = reader.GetString()!;
            if (_fromName.TryGetValue(text, out TEnum val))
            {
                return val;
            }

            throw new JsonException($"Unrecognized enum token: {text}");
        }

        /// <summary>
        /// Writes an enum value as a Xurrent string representation in JSON.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The <typeparamref name="TEnum"/> enum value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            if (_toName.TryGetValue(value, out string? name) && name is not null)
            {
                writer.WriteStringValue(name);
            }
            else
            {
                throw new JsonException($"No mapped name for enum value: {value}");
            }
        }
    }
}
