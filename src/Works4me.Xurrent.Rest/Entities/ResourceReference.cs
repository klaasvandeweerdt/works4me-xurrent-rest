using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent resource reference object.
    /// </summary>
    public sealed class ResourceReference : ObservableItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ResourceReference"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The display name field.
            /// </summary>
            [XurrentEnum("display_name")]
            DisplayName,

            /// <summary>
            /// The href field.
            /// </summary>
            [XurrentEnum("href")]
            Href,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID")]
            NodeId
        }

        /// <summary>
        /// Represents the absence of supported filters for a query.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the absence of supported predefined filters for a query.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the absence of supported ordering fields for a query.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Specifies that no ordering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        private string? _displayName;
        private string? _href;
        private long? _id;
        private string? _nodeId;

        /// <summary>
        /// Gets the display name of the archived object.
        /// </summary>
        [XurrentField("display_name")]
        public string? DisplayName
        {
            get => _displayName;
            internal set => _displayName = value;
        }

        /// <summary>
        /// Gets the partial path to the archived object.
        /// </summary>
        [XurrentField("href")]
        public string? Href
        {
            get => _href;
            internal set => _href = value;
        }

        /// <summary>
        /// Gets the unique identifier of the archived object.
        /// </summary>
        [XurrentField("id")]
        public long? Id
        {
            get => _id;
            internal set => _id = value;
        }

        /// <summary>
        /// Gets the node identifier of the archived object.
        /// </summary>
        [XurrentField("nodeID")]
        public string? NodeId
        {
            get => _nodeId;
            internal set => _nodeId = value;
        }
    }
}
