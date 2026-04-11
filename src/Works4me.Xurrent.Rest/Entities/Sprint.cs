using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent sprint object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Sprint : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Sprint"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

            /// <summary>
            /// The description attachments field.
            /// </summary>
            [XurrentEnum("description_attachments", IgnoreInFieldSelection = true)]
            DescriptionAttachments,

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
            /// The number field.
            /// </summary>
            [XurrentEnum("number")]
            Number,

            /// <summary>
            /// The scrum workspace field.
            /// </summary>
            [XurrentEnum("scrum_workspace")]
            ScrumWorkspace,

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
            /// The status field.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Sprint"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters sprints by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters sprints by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters sprints by scrum workspace.
            /// </summary>
            [XurrentEnum("scrum_workspace")]
            ScrumWorkspace,

            /// <summary>
            /// Filters sprints by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters sprints by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters sprints by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters sprints by last update date.
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
        /// Represents the fields used to order a <see cref="Sprint"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts sprints by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts sprints by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts sprints by number.
            /// </summary>
            [XurrentEnum("number")]
            Number,

            /// <summary>
            /// Sorts sprints by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts sprints by start date.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// Sorts sprints by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private string? _description;
        private ObservableCollection<AttachmentReference>? _descriptionAttachments;
        private AttachmentReferenceWriter? _descriptionAttachmentsWriter;
        private DateTime? _endAt;
        private string? _name;
        private int? _number;
        private ScrumWorkspace? _scrumWorkspace;
        private string? _source;
        private string? _sourceID;
        private DateTime? _startAt;
        private SprintStatus? _status;
        private DateTime? _updatedAt;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the sprint.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the sprint was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the description of the sprint.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        [XurrentField("description_attachments")]
        internal ObservableCollection<AttachmentReference> DescriptionAttachmentsCollection
        {
            get => GetCollection(ref _descriptionAttachments, OnDescriptionAttachmentsChanged);
            set => SetCollection(ref _descriptionAttachments, "description_attachments", value, OnDescriptionAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the description field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter DescriptionAttachments
        {
            get
            {
                _descriptionAttachmentsWriter ??= new AttachmentReferenceWriter(() => DescriptionAttachmentsCollection, c => DescriptionAttachmentsCollection = c);
                return _descriptionAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the date and time at which the sprint ended or is scheduled to end.
        /// </summary>
        [XurrentField("end_at")]
        public DateTime? EndAt
        {
            get => _endAt;
            set => _endAt = SetValue("end_at", _endAt, value);
        }

        /// <summary>
        /// Gets or sets the name of the sprint.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the sprint number.
        /// </summary>
        [XurrentField("number")]
        public int? Number
        {
            get => _number;
            set => _number = SetValue("number", _number, value);
        }

        /// <summary>
        /// Gets the scrum workspace to which this sprint belongs.
        /// </summary>
        [XurrentField("scrum_workspace")]
        public ScrumWorkspace? ScrumWorkspace
        {
            get => _scrumWorkspace;
            internal set => _scrumWorkspace = value;
        }

        /// <summary>
        /// Gets or sets the external source identifier for the sprint.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the sprint in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the date and time at which the sprint started or is scheduled to start.
        /// </summary>
        [XurrentField("start_at")]
        public DateTime? StartAt
        {
            get => _startAt;
            set => _startAt = SetValue("start_at", _startAt, value);
        }

        /// <summary>
        /// Gets the current status of the sprint.
        /// </summary>
        [XurrentField("status")]
        public SprintStatus? Status
        {
            get => _status;
            internal set => _status = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the sprint.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new sprint instance.
        /// </summary>
        public Sprint()
        {
        }

        /// <summary>
        /// Creates a new sprint instance.
        /// </summary>
        /// <param name="id">The unique identifier of the sprint.</param>
        public Sprint(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new sprint instance.
        /// </summary>
        /// <param name="number">The number of the sprint.</param>
        public Sprint(int number)
        {
            _number = SetValue("number", number);
        }

        private void OnDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "description_attachments");
        }
    }
}
