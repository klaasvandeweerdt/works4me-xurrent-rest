using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent request tag object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Tag : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Tag"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The name field.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
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

        private string? _name;

        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Creates a new tag instance.
        /// </summary>
        public Tag()
        {
        }

        /// <summary>
        /// Creates a new tag instance.
        /// </summary>
        /// <param name="id">The unique identifier of the tag.</param>
        public Tag(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new tag instance.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        public Tag(string name)
        {
            _name = SetValue("name", name);
        }
    }
}
