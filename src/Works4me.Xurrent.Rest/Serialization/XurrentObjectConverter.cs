using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides JSON serialization and deserialization for Xurrent objects, mapping properties using <see cref="XurrentFieldAttribute"/>.
    /// </summary>
    /// <typeparam name="T">The object type being converted.</typeparam>
    internal sealed class XurrentObjectConverter<T> : JsonConverter<T>
        where T : class, new()
    {
        private readonly Dictionary<string, PropertyInfo> _propertyMapping;

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentObjectConverter{T}"/> class and builds the property mapping from <see cref="XurrentFieldAttribute"/> decorations.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if <typeparamref name="T"/> does not have any properties decorated with <see cref="XurrentFieldAttribute"/>.</exception>
        public XurrentObjectConverter()
        {
            _propertyMapping = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(p => (Property: p, Attribute: p.GetCustomAttribute<XurrentFieldAttribute>()))
                .Where(x => x.Attribute is not null)
                .ToDictionary(
                    x => x.Attribute!.FieldName,
                    x => x.Property,
                    StringComparer.Ordinal);

            if (_propertyMapping.Count == 0)
                throw new InvalidOperationException($"Type {typeof(T).FullName} has no [XurrentField] properties.");
        }

        /// <summary>
        /// Reads an instance of <typeparamref name="T"/> from JSON, mapping JSON fields to properties using <see cref="XurrentFieldAttribute"/>.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type being converted.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <typeparamref name="T"/> instance.</returns>
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            T retval = new();

            if (retval is IJsonOnDeserializing onDeserializing)
            {
                onDeserializing.OnDeserializing();
            }

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    if (retval is IJsonOnDeserialized onDeserialized)
                    {
                        onDeserialized.OnDeserialized();
                    }

                    return retval;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propName = reader.GetString()!;
                    reader.Read();

                    if (_propertyMapping.TryGetValue(propName, out PropertyInfo? propInfo))
                    {
                        object? value = JsonSerializer.Deserialize(ref reader, propInfo.PropertyType, options);
                        propInfo.SetValue(retval, value);
                    }
                    else
                    {
                        reader.Skip();
                    }
                }
            }

            if (retval is IJsonOnDeserialized onDeserializedEnd)
            {
                onDeserializedEnd.OnDeserialized();
            }

            return retval;
        }

        /// <summary>
        /// Writes an instance of <typeparamref name="T"/> to JSON, serializing all properties mapped by <see cref="XurrentFieldAttribute"/>.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (KeyValuePair<string, PropertyInfo> kv in _propertyMapping)
            {
                string jsonName = kv.Key;
                PropertyInfo prop = kv.Value;
                object? propValue = prop.GetValue(value);

                writer.WritePropertyName(jsonName);
                JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
            }

            writer.WriteEndObject();
        }
    }
}
