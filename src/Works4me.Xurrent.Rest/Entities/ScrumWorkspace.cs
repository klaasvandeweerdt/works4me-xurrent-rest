using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent scrum workspace object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ScrumWorkspace : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ScrumWorkspace"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The agile board field.
            /// </summary>
            [XurrentEnum("agile_board")]
            AgileBoard,

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
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

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
            /// The product backlog field.
            /// </summary>
            [XurrentEnum("product_backlog")]
            ProductBacklog,

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
            /// The sprint length field.
            /// </summary>
            [XurrentEnum("sprint_length")]
            SprintLength,

            /// <summary>
            /// The team field.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ScrumWorkspace"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by whether the scrum workspace is disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters by the name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters by the source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ScrumWorkspace"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all scrum workspaces that are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all scrum workspaces that are enabled.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ScrumWorkspace"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts by the name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private AgileBoard? _agileBoard;
        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private string? _description;
        private ObservableCollection<AttachmentReference>? _descriptionAttachments;
        private AttachmentReferenceWriter? _descriptionAttachmentsWriter;
        private bool? _disabled;
        private string? _name;
        private Uri? _pictureUri;
        private ProductBacklog? _productBacklog;
        private string? _source;
        private string? _sourceID;
        private int? _sprintLength;
        private Team? _team;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets the agile board used to track the progress of the active sprint in this scrum workspace.
        /// </summary>
        [XurrentField("agile_board")]
        public AgileBoard? AgileBoard
        {
            get => _agileBoard;
            set => _agileBoard = SetValue("agile_board", _agileBoard, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the scrum workspace.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the scrum workspace was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets additional information about the scrum workspace.
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
        /// Gets or sets a value indicating whether the scrum workspace is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the name of the scrum workspace.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the scrum workspace.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the product backlog used when planning sprints in this scrum workspace.
        /// </summary>
        [XurrentField("product_backlog")]
        public ProductBacklog? ProductBacklog
        {
            get => _productBacklog;
            set => _productBacklog = SetValue("product_backlog", _productBacklog, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier for the scrum workspace.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the scrum workspace in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the standard length, in weeks, of new sprints planned in this scrum workspace.
        /// </summary>
        [XurrentField("sprint_length")]
        public int? SprintLength
        {
            get => _sprintLength;
            set => _sprintLength = SetValue("sprint_length", _sprintLength, value);
        }

        /// <summary>
        /// Gets or sets the team planning their work using this scrum workspace.
        /// </summary>
        [XurrentField("team")]
        public Team? Team
        {
            get => _team;
            set => _team = SetValue("team", _team, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the scrum workspace.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new scrum workspace instance.
        /// </summary>
        public ScrumWorkspace()
        {
        }

        /// <summary>
        /// Creates a new scrum workspace instance.
        /// </summary>
        /// <param name="id">The unique identifier of the scrum workspace.</param>
        public ScrumWorkspace(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new scrum workspace instance.
        /// </summary>
        /// <param name="agileBoard">The agile board of the scrum workspace.</param>
        /// <param name="name">The name of the scrum workspace.</param>
        /// <param name="productBacklog">The product backlog of the scrum workspace.</param>
        /// <param name="sprintLength">The sprint length of the scrum workspace.</param>
        public ScrumWorkspace(AgileBoard agileBoard, string name, ProductBacklog productBacklog, int sprintLength)
        {
            _agileBoard = SetValue("agile_board", agileBoard);
            _name = SetValue("name", name);
            _productBacklog = SetValue("product_backlog", productBacklog);
            _sprintLength = SetValue("sprint_length", sprintLength);
        }

        private void OnDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "description_attachments");
        }
    }
}
