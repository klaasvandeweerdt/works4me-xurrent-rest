using System.Text.Json;

namespace Works4me.Xurrent.Rest.Extensions
{
    /// <summary>
    /// Provides extension methods for working with JSON strings.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Attempts to parse the specified string as JSON and returns the root <see cref="JsonElement"/>when successful.
        /// </summary>
        /// <param name="value">The string to parse as JSON.</param>
        /// <param name="jsonElement">When this method returns <see langword="true"/>, contains the parsed JSON root element. When this method returns <see langword="false"/>, contains <see langword="default"/>.</param>
        /// <returns><see langword="true"/> if the string was successfully parsed as JSON; otherwise, <c>false</c>.</returns>
        public static bool TryParseJsonElement(this string? value, out JsonElement jsonElement)
        {
            jsonElement = default;

            if (string.IsNullOrWhiteSpace(value))
                return false;

            try
            {
                using (JsonDocument document = JsonDocument.Parse(value!))
                {
                    jsonElement = document.RootElement.Clone();
                    return true;
                }
            }
            catch (JsonException)
            {
                return false;
            }
        }
    }
}
