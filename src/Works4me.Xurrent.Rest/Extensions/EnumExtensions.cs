using System;
using System.Collections.Concurrent;
using System.Reflection;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest.Extensions
{
    /// <summary>
    /// A set of <see cref="Enum"/> extension methods.
    /// </summary>
    public static class EnumExtensions
    {
        private static readonly ConcurrentDictionary<(Type enumType, object value), XurrentEnumAttribute?> _enumValueCache = new();
        private static readonly ConcurrentDictionary<Type, Lazy<ConcurrentDictionary<string, XurrentEnumAttribute>>> _enumFromStringCache = new();

        /// <summary>
        /// Gets the serialized Xurrent value for the specified enum member.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="value">The enum value for which to obtain the serialized value.</param>
        /// <returns>The serialized Xurrent value for the specified enum member, or the enum name if no Xurrent value is defined.</returns>
        public static string ToXurrentString<TEnum>(this TEnum value)
            where TEnum : struct, Enum
        {
            if (TryGetXurrentEnumAttribute(value, out XurrentEnumAttribute? attribute) && attribute is not null)
                return attribute.Value;

            return value.ToString();
        }

        /// <summary>
        /// Attempts to retrieve the <see cref="XurrentEnumAttribute"/> associated with the specified enum member.
        /// </summary>
        /// <param name="value">The enum value for which to obtain the serialized.</param>
        /// <param name="result">When this method returns, contains the value defined on the enum field if found; otherwise, <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the enum member defines a <see cref="XurrentEnumAttribute"/> with a non-empty <c>EnumeratorName</c>;otherwise, <see langword="false"/>.</returns>
        internal static bool TryGetXurrentEnumAttribute(this Enum value, out XurrentEnumAttribute? result)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            XurrentEnumAttribute? cached = _enumValueCache.GetOrAdd((value.GetType(), value), key =>
            {
                Type enumType = key.enumType;
                object enumValue = key.value;

                FieldInfo? field = enumType.GetField(enumValue.ToString()!);
                XurrentEnumAttribute? attribute = field?.GetCustomAttribute<XurrentEnumAttribute>();

                return attribute;
            });

            if (cached is null)
            {
                result = null;
                return false;
            }

            result = cached;
            return true;
        }

        /// <summary>
        /// Tries to get the <see cref="XurrentEnumAttribute"/> for an enum member of type <typeparamref name="TEnum"/> based on its <see cref="XurrentEnumAttribute.Value"/>.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="source">The serialized enum value.</param>
        /// <param name="result">The attribute instance associated with the enum member, if found.</param>
        /// <returns><see langword="true"/> if successful; otherwise <see langword="false"/>.</returns>
        internal static bool TryGetXurrentEnumAttribute<TEnum>(this string source, out XurrentEnumAttribute? result)
            where TEnum : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                result = null;
                return false;
            }

            Type enumType = typeof(TEnum);

            Lazy<ConcurrentDictionary<string, XurrentEnumAttribute>> lazyCache =
                _enumFromStringCache.GetOrAdd(
                    enumType,
                    type => new Lazy<ConcurrentDictionary<string, XurrentEnumAttribute>>(
                        () => BuildStringToEnumCache(type)));

            ConcurrentDictionary<string, XurrentEnumAttribute> map = lazyCache.Value;

            if (map.TryGetValue(source, out XurrentEnumAttribute? attribute))
            {
                result = attribute;
                return true;
            }

            result = null;
            return false;
        }

        /// <summary>
        /// Builds a lookup table that maps the <see cref="XurrentEnumAttribute.Value"/> strings to their corresponding attributes.
        /// </summary>
        /// <returns>A <see cref="ConcurrentDictionary{TKey, TValue}"/> containing entries where each key is the exact <c>EnumeratorName</c> defined on an enum field, and each value is the associated enum member.</returns>
        private static ConcurrentDictionary<string, XurrentEnumAttribute> BuildStringToEnumCache(Type enumType)
        {
            ConcurrentDictionary<string, XurrentEnumAttribute> map = new();            
            FieldInfo[] fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];
                XurrentEnumAttribute? attribute = field.GetCustomAttribute<XurrentEnumAttribute>();

                if (attribute is null || string.IsNullOrWhiteSpace(attribute.Value))
                    continue;

                string key = attribute.Value;
                map.TryAdd(key, attribute);
            }

            return map;
        }
    }
}
