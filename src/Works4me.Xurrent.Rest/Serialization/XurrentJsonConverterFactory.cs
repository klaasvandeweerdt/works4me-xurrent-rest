using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides a factory for creating JSON converters for Xurrent SDK types, including support for enums, interfaces, and fields with <see cref="XurrentFieldAttribute"/>.
    /// </summary>
    internal sealed class XurrentJsonConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentJsonConverterFactory"/> class with default configuration.
        /// </summary>
        public XurrentJsonConverterFactory()
        {
        }

        /// <summary>
        /// Determines whether this factory can create a converter for the specified type.
        /// </summary>
        /// <param name="typeToConvert">The type to evaluate.</param>
        /// <returns><see langword="true"/> if a converter can be created for <paramref name="typeToConvert"/>; otherwise, <see langword="false"/>.</returns>
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert == typeof(DateTime) || typeToConvert == typeof(DateTime?))
                return true;

            if (typeToConvert == typeof(TimeSpan) || typeToConvert == typeof(TimeSpan?))
                return true;

            if (typeToConvert == typeof(decimal) || typeToConvert == typeof(decimal?))
                return true;

            if (typeToConvert == typeof(AutomationRule))
                return true;

            if (typeToConvert == typeof(AuditLine))
                return true;

            if (typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (Nullable.GetUnderlyingType(typeToConvert) is Type underlying && underlying.IsEnum)
                    return true;
            }

            if (typeToConvert.IsEnum)
                return true;

            if (typeToConvert.IsClass)
            {
                bool hasFields = typeToConvert
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Any(pi => pi.GetCustomAttribute<XurrentFieldAttribute>() is not null);

                if (hasFields)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Creates a JSON converter for the specified type using Xurrent SDK conventions.
        /// </summary>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> in use.</param>
        /// <returns>A <see cref="JsonConverter"/> instance for the specified type.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the factory cannot create a converter for the given type.</exception>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert == typeof(DateTime))
                return new ISO8601TimestampConverter();

            if (typeToConvert == typeof(DateTime?))
                return new ISO8601TimestampNullableConverter();

            if (typeToConvert == typeof(TimeSpan))
                return new ISO8601TimeConverter();

            if (typeToConvert == typeof(TimeSpan?))
                return new ISO8601TimeNullableConverter();

            if (typeToConvert == typeof(decimal))
                return new DecimalConverter();

            if (typeToConvert == typeof(decimal?))
                return new DecimalNullableConverter();

            if (typeToConvert == typeof(AutomationRule))
                return new AutomationRuleConverter();

            if (typeToConvert == typeof(AuditLine))
                return new AuditLineConverter();

            if (typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (Nullable.GetUnderlyingType(typeToConvert) is Type underlying && underlying.IsEnum)
                {
                    Type convType = typeof(XurrentEnumNullableConverter<>).MakeGenericType(underlying);
                    return (JsonConverter)Activator.CreateInstance(convType)!;
                }
            }

            if (typeToConvert.IsEnum)
            {
                Type convType = typeof(XurrentEnumConverter<>).MakeGenericType(typeToConvert);
                return (JsonConverter)Activator.CreateInstance(convType)!;
            }

            if (typeToConvert.IsClass)
            {
                Type convType = typeof(XurrentObjectConverter<>).MakeGenericType(typeToConvert);
                return (JsonConverter)Activator.CreateInstance(convType)!;

            }

            throw new InvalidOperationException($"{nameof(XurrentJsonConverterFactory)} cannot create a converter for {typeToConvert}.");
        }
    }
}
