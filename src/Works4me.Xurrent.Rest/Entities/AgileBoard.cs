using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent agile board object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AgileBoard : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AgileBoard"/> object.
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
            /// The current sprint field.
            /// </summary>
            [XurrentEnum("current_sprint")]
            CurrentSprint,

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
            /// The manager field.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

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
            /// The request template field.
            /// </summary>
            [XurrentEnum("request_template")]
            RequestTemplate,

            /// <summary>
            /// The service instance field.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

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
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="AgileBoard"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters agile boards by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters agile boards by disabled state.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters agile boards by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters agile boards by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters agile boards by request template.
            /// </summary>
            [XurrentEnum("request_template")]
            RequestTemplate,

            /// <summary>
            /// Filters agile boards by service instance.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

            /// <summary>
            /// Filters agile boards by external source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters agile boards by external source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters agile boards by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of an <see cref="AgileBoard"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled agile boards.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled agile boards.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order an <see cref="AgileBoard"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts agile boards by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts agile boards by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts agile boards by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts agile boards by request template.
            /// </summary>
            [XurrentEnum("request_template")]
            RequestTemplate,

            /// <summary>
            /// Sorts agile boards by service instance.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

            /// <summary>
            /// Sorts agile boards by external source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts agile boards by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private Sprint? _currentSprint;
        private string? _description;
        private ObservableCollection<AttachmentReference>? _descriptionAttachments;
        private AttachmentReferenceWriter? _descriptionAttachmentsWriter;
        private bool? _disabled;
        private Person? _manager;
        private string? _name;
        private Uri? _pictureUri;
        private RequestTemplate? _requestTemplate;
        private ServiceInstance? _serviceInstance;
        private string? _source;
        private string? _sourceID;
        private DateTime? _updatedAt;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the agile board.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the agile board was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the sprint to which the agile board is currently linked.
        /// </summary>
        [XurrentField("current_sprint")]
        public Sprint? CurrentSprint
        {
            get => _currentSprint;
            internal set => _currentSprint = value;
        }

        /// <summary>
        /// Gets or sets the description of the agile board.
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
        /// Gets or sets a value indicating whether the agile board is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the manager or supervisor responsible for maintaining the agile board.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Gets or sets the name of the agile board.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the agile board.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the request template used to generate new requests in this agile board.
        /// </summary>
        [XurrentField("request_template")]
        public RequestTemplate? RequestTemplate
        {
            get => _requestTemplate;
            set => _requestTemplate = SetValue("request_template", _requestTemplate, value);
        }

        /// <summary>
        /// Gets or sets the service instance used when creating requests in this agile board.
        /// </summary>
        [XurrentField("service_instance")]
        public ServiceInstance? ServiceInstance
        {
            get => _serviceInstance;
            set => _serviceInstance = SetValue("service_instance", _serviceInstance, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier for the agile board.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the agile board in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the agile board.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new agile board instance.
        /// </summary>
        public AgileBoard()
        {
        }

        /// <summary>
        /// Creates a new agile board instance.
        /// </summary>
        /// <param name="id">The unique identifier of the agile board.</param>
        public AgileBoard(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new agile board instance.
        /// </summary>
        /// <param name="name">The name of the agile board.</param>
        public AgileBoard(string name)
        {
            _name = SetValue("name", name);
        }

        private void OnDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "description_attachments");
        }
    }
}
