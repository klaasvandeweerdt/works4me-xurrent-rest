using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent attachment object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Attachment : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="Attachment"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The inline field.
            /// </summary>
            [XurrentEnum("inline")]
            Inline,

            /// <summary>
            /// The key field.
            /// </summary>
            [XurrentEnum("key")]
            Key,

            /// <summary>
            /// The name field.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The size field.
            /// </summary>
            [XurrentEnum("size")]
            Size,

            /// <summary>
            /// The uri field.
            /// </summary>
            [XurrentEnum("uri")]
            Uri
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

        private DateTime? _createdAt;
        private bool? _inline;
        private string? _key;
        private string? _name;
        private long? _size;
        private Uri? _uri;

        /// <summary>
        /// Gets the date and time when the attachment was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets a value indicating whether the attachment is an inline image.
        /// </summary>
        [XurrentField("inline")]
        public bool? Inline
        {
            get => _inline;
            internal set => _inline = value;
        }

        /// <summary>
        /// Gets the key of the attachment that can be used to match the attachment to an inline image included in a rich text field.
        /// </summary>
        [XurrentField("key")]
        public string? Key
        {
            get => _key;
            internal set => _key = value;
        }

        /// <summary>
        /// Gets the name of the attachment.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            internal set => _name = value;
        }

        /// <summary>
        /// Gets the size of the attachment in bytes.
        /// </summary>
        [XurrentField("size")]
        public long? Size
        {
            get => _size;
            internal set => _size = value;
        }

        /// <summary>
        /// Gets a temporary expiring URL that can be used to access the attachment.
        /// </summary>
        [XurrentField("uri")]
        public Uri? Uri
        {
            get => _uri;
            internal set => _uri = value;
        }

        /// <summary>
        /// Creates a new attachment instance.
        /// </summary>
        public Attachment()
        {
        }

        /// <summary>
        /// Creates a new attachment instance.
        /// </summary>
        /// <param name="id">The unique identifier of the attachment.</param>
        public Attachment(long id)
        {
            Id = id;
        }
    }
}
