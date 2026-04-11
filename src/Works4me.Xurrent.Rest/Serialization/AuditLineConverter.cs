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
    /// Provides JSON deserialization for <see cref="AuditLine"/>, mapping the property named by <c>audited</c>
    /// into <see cref="AuditLine.Data"/> as a <see cref="JsonElement"/>.
    /// </summary>
    internal sealed class AuditLineConverter : JsonConverter<AuditLine>
    {
        private readonly Dictionary<string, PropertyInfo> _propertyMapping;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLineConverter"/> class.
        /// </summary>
        public AuditLineConverter()
        {
            _propertyMapping = typeof(AuditLine)
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(p => (Property: p, Attribute: p.GetCustomAttribute<XurrentFieldAttribute>()))
                .Where(x => x.Attribute is not null)
                .ToDictionary(
                    x => x.Attribute!.FieldName,
                    x => x.Property,
                    StringComparer.Ordinal);

            if (_propertyMapping.Count == 0)
                throw new InvalidOperationException($"Type {typeof(AuditLine).FullName} has no [XurrentField] properties.");
        }

        /// <summary>
        /// Reads and converts the JSON representation of an <see cref="AuditLine"/>.
        /// </summary>
        /// <param name="reader">The UTF-8 JSON reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The serializer options.</param>
        /// <returns>A fully populated <see cref="AuditLine"/> instance with the audited payload assigned to <see cref="AuditLine.Data"/>.</returns>
        public override AuditLine Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            AuditLine retval = new();
            retval.OnDeserializing();

            string? audited = null;
            JsonElement? data = null;

            Dictionary<string, JsonElement>? pending = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    if (data.HasValue)
                        retval.Data = data.Value;
                    else
                        retval.Data = null;

                    retval.OnDeserialized();
                    return retval;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                    continue;

                string propName = reader.GetString()!;
                reader.Read();

                if (string.Equals(propName, "audited", StringComparison.Ordinal))
                {
                    if (reader.TokenType == JsonTokenType.String)
                    {
                        audited = reader.GetString();

                        if (!string.IsNullOrWhiteSpace(audited) && pending is not null && pending.TryGetValue(audited!, out JsonElement pendingElement))
                        {
                            data = pendingElement;
                            pending.Remove(audited!);
                        }
                    }

                    if (_propertyMapping.TryGetValue(propName, out PropertyInfo? auditedProp))
                        auditedProp.SetValue(retval, audited);

                    continue;
                }

                if (!string.IsNullOrWhiteSpace(audited) && string.Equals(propName, audited, StringComparison.Ordinal))
                {
                    JsonElement element = JsonSerializer.Deserialize<JsonElement>(ref reader, options).Clone();
                    data = element;
                    continue;
                }

                if (_propertyMapping.TryGetValue(propName, out PropertyInfo? propInfo))
                {
                    object? value = JsonSerializer.Deserialize(ref reader, propInfo.PropertyType, options);
                    propInfo.SetValue(retval, value);
                    continue;
                }

                if (!data.HasValue)
                {
                    JsonElement unknown = JsonSerializer.Deserialize<JsonElement>(ref reader, options).Clone();

                    if (pending == null)
                        pending = new Dictionary<string, JsonElement>(StringComparer.Ordinal);

                    pending[propName] = unknown;
                }
                else
                {
                    reader.Skip();
                }
            }

            if (data.HasValue)
                retval.Data = data.Value;
            else
                retval.Data = null;

            retval.OnDeserialized();
            return retval;
        }

        /// <summary>
        /// Writes an <see cref="AuditLine"/> value as JSON.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="options">The serializer options.</param>
        /// <exception cref="NotSupportedException">Always thrown, as <see cref="AuditLineConverter"/> is read-only and does not support JSON serialization.</exception>
        public override void Write(Utf8JsonWriter writer, AuditLine value, JsonSerializerOptions options)
        {
            throw new NotSupportedException($"{nameof(AuditLineConverter)} is read-only and does not support writing JSON.");
        }
    }
}