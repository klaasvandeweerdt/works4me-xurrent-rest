using System.Text.Json;
using System.Text.Json.Serialization;

namespace Works4me.Xurrent.Rest.Serialization
{
    /// <summary>
    /// Provides methods for creating and cloning <see cref="JsonSerializerOptions"/> preconfigured with Xurrent SDK converters.
    /// </summary>
    internal static class SerializationConfiguration
    {
        public static readonly JsonSerializerOptions DefaultJsonOption = new();

        /// <summary>
        /// Creates a new <see cref="JsonSerializerOptions"/> instance configured with the Xurrent converter factory.
        /// </summary>
        /// <returns>A new <see cref="JsonSerializerOptions"/> instance with standard Xurrent converters.</returns>
        public static JsonSerializerOptions CreateJsonOptions()
        {
            JsonSerializerOptions options = CloneOptions(DefaultJsonOption);
            options.Converters.Add(new XurrentJsonConverterFactory());
            return options;
        }

        /// <summary>
        /// Creates a deep copy of the given <see cref="JsonSerializerOptions"/> instance.
        /// </summary>
        /// <param name="source">The <see cref="JsonSerializerOptions"/> to clone.</param>
        /// <returns>A new <see cref="JsonSerializerOptions"/> instance with all settings and converters from the source.</returns>
        private static JsonSerializerOptions CloneOptions(JsonSerializerOptions source)
        {
            JsonSerializerOptions options = new()
            {
                AllowTrailingCommas = source.AllowTrailingCommas,
                DefaultBufferSize = source.DefaultBufferSize,
                DefaultIgnoreCondition = source.DefaultIgnoreCondition,
                DictionaryKeyPolicy = source.DictionaryKeyPolicy,
                Encoder = source.Encoder,
                IgnoreReadOnlyFields = source.IgnoreReadOnlyFields,
                IgnoreReadOnlyProperties = source.IgnoreReadOnlyProperties,
                IncludeFields = source.IncludeFields,
                MaxDepth = source.MaxDepth,
                NumberHandling = source.NumberHandling,
                PropertyNameCaseInsensitive = source.PropertyNameCaseInsensitive,
                PropertyNamingPolicy = source.PropertyNamingPolicy,
                ReadCommentHandling = source.ReadCommentHandling,
                ReferenceHandler = source.ReferenceHandler,
                TypeInfoResolver = source.TypeInfoResolver,
                UnmappedMemberHandling = source.UnmappedMemberHandling,
                UnknownTypeHandling = source.UnknownTypeHandling,
                WriteIndented = source.WriteIndented,
                IndentCharacter = source.IndentCharacter,
                IndentSize = source.IndentSize,
                NewLine = source.NewLine
            };

            foreach (JsonConverter converter in source.Converters)
                options.Converters.Add(converter);

            return options;
        }
    }
}
