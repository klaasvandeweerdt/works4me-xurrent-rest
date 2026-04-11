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
    /// Provides JSON serialization and deserialization for <see cref="AutomationRule"/>.
    /// </summary>
    internal sealed class AutomationRuleConverter : JsonConverter<AutomationRule>
    {
        private readonly Dictionary<string, PropertyInfo> _propertyMapping;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomationRuleConverter"/> class and builds the property mapping
        /// from <see cref="XurrentFieldAttribute"/> decorations on <see cref="AutomationRule"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if <see cref="AutomationRule"/> does not have any properties decorated with <see cref="XurrentFieldAttribute"/>.</exception>
        public AutomationRuleConverter()
        {
            _propertyMapping = typeof(AutomationRule)
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(p => (Property: p, Attribute: p.GetCustomAttribute<XurrentFieldAttribute>()))
                .Where(x => x.Attribute is not null)
                .ToDictionary(
                    x => x.Attribute!.FieldName,
                    x => x.Property,
                    StringComparer.Ordinal);

            if (_propertyMapping.Count == 0)
                throw new InvalidOperationException($"Type {typeof(AutomationRule).FullName} has no [XurrentField] properties.");
        }

        /// <summary>
        /// Reads an <see cref="AutomationRule"/> value from JSON.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert (should be <see cref="AutomationRule"/>).</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>The deserialized <see cref="AutomationRule"/> value.</returns>
        /// <exception cref="JsonException">Thrown when the JSON does not represent an object or when a mapped property cannot be deserialized.</exception>
        public override AutomationRule Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            AutomationRule retval = new();

            retval.OnDeserializing();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    retval.OnDeserialized();
                    return retval;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    continue;
                }

                string propName = reader.GetString()!;
                reader.Read();

                if (_propertyMapping.TryGetValue(propName, out PropertyInfo? propInfo))
                {
                    if (string.Equals(propName, "generic", StringComparison.Ordinal) && reader.TokenType != JsonTokenType.String)
                        continue;

                    object? value = JsonSerializer.Deserialize(ref reader, propInfo.PropertyType, options);
                    propInfo.SetValue(retval, value);
                }
                else
                {
                    reader.Skip();
                }
            }

            retval.OnDeserialized();
            return retval;
        }

        /// <summary>
        /// Writes an <see cref="AutomationRule"/> value to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The <see cref="AutomationRule"/> value to write.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        public override void Write(Utf8JsonWriter writer, AutomationRule value, JsonSerializerOptions options)
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

