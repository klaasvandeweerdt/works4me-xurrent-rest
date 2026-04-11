using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent holiday object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Holiday : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Holiday"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The end at field.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

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
            NodeId,

            /// <summary>
            /// The picture uri field.
            /// </summary>
            [XurrentEnum("picture_uri")]
            PictureUri,

            /// <summary>
            /// The source field.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// The source identifier field.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// The start at field.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Holiday"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters holidays by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters holidays by end date and time.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

            /// <summary>
            /// Filters holidays by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters holidays by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters holidays by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters holidays by start date and time.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// Filters holidays by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
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
        /// Represents the fields used to order a <see cref="Holiday"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts holidays by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts holidays by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts holidays by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts holidays by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts holidays by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private DateTime? _createdAt;
        private DateTime? _endAt;
        private string? _name;
        private Uri? _pictureUri;
        private string? _source;
        private string? _sourceID;
        private DateTime? _startAt;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time at which the holiday was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the end date and time of the holiday.
        /// </summary>
        [XurrentField("end_at")]
        public DateTime? EndAt
        {
            get => _endAt;
            set => _endAt = SetValue("end_at", _endAt, value);
        }

        /// <summary>
        /// Gets or sets the name of the holiday.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the URI of the picture for the holiday.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the source of the holiday.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the holiday.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the start date and time of the holiday.
        /// </summary>
        [XurrentField("start_at")]
        public DateTime? StartAt
        {
            get => _startAt;
            set => _startAt = SetValue("start_at", _startAt, value);
        }

        /// <summary>
        /// Gets the date and time at which the holiday was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new holiday instance.
        /// </summary>
        public Holiday()
        {
        }

        /// <summary>
        /// Creates a new holiday instance.
        /// </summary>
        /// <param name="id">The unique identifier of the holiday.</param>
        public Holiday(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new holiday instance.
        /// </summary>
        /// <param name="endAt">The end at of the holiday.</param>
        /// <param name="name">The name of the holiday.</param>
        /// <param name="startAt">The start at of the holiday.</param>
        public Holiday(DateTime endAt, string name, DateTime startAt)
        {
            _endAt = SetValue("end_at", endAt);
            _name = SetValue("name", name);
            _startAt = SetValue("start_at", startAt);
        }
    }
}
