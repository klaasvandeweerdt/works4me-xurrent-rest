using System.Collections.Generic;

namespace Works4me.Xurrent.Rest.Utilities
{
    /// <summary>
    /// Provides commonly used constant values throughout the application.
    /// </summary>
    internal static class Constants
    {
        private static readonly HashSet<string> _defaultFields = new() { "account", "id", "nodeID" };

        /// <summary>
        /// The HTTP header key for the Xurrent account identifier.
        /// </summary>
        public const string AccountHeader = "x-xurrent-account";

        /// <summary>
        /// The media type for JSON content in HTTP requests and responses.
        /// </summary>
        public const string ApplicationJsonMediaType = "application/json";

        /// <summary>
        /// The standard date and time format used for serializing and parsing date-time values.
        /// </summary>
        public const string DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ssK";

        /// <summary>
        /// The default fields returned for entities.
        /// </summary>
        public static HashSet<string> DefaultFields
        {
            get => _defaultFields;
        }
    }
}
