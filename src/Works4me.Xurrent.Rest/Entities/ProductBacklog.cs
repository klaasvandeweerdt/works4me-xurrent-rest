using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent product backlog object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ProductBacklog : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ProductBacklog"/> object.
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
            /// The product owner field.
            /// </summary>
            [XurrentEnum("product_owner")]
            ProductOwner,

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
        /// Represents the filterable fields of a <see cref="ProductBacklog"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters product backlogs by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters product backlogs by whether they are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters product backlogs by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters product backlogs by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters product backlogs by request template.
            /// </summary>
            [XurrentEnum("request_template")]
            RequestTemplate,

            /// <summary>
            /// Filters product backlogs by service instance.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

            /// <summary>
            /// Filters product backlogs by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters product backlogs by identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters product backlogs by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ProductBacklog"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled product backlogs.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled product backlogs.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ProductBacklog"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts product backlogs by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts product backlogs by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts product backlogs by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts product backlogs by their request template.
            /// </summary>
            [XurrentEnum("request_template")]
            RequestTemplate,

            /// <summary>
            /// Sorts product backlogs by their service instance.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

            /// <summary>
            /// Sorts product backlogs by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts product backlogs by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private string? _description;
        private ObservableCollection<AttachmentReference>? _descriptionAttachments;
        private AttachmentReferenceWriter? _descriptionAttachmentsWriter;
        private bool? _disabled;
        private string? _name;
        private Uri? _pictureUri;
        private Person? _productOwner;
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
        /// Gets the aggregated attachments associated with the product backlog.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the product backlog was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the high-level description of the product backlog.
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
        /// Gets or sets a value indicating whether the product backlog is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the name of the product backlog.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the product backlog.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for maximizing the value of the work based on this product backlog.
        /// </summary>
        [XurrentField("product_owner")]
        public Person? ProductOwner
        {
            get => _productOwner;
            set => _productOwner = SetValue("product_owner", _productOwner, value);
        }

        /// <summary>
        /// Gets or sets the request template used to generate new requests in this product backlog.
        /// </summary>
        [XurrentField("request_template")]
        public RequestTemplate? RequestTemplate
        {
            get => _requestTemplate;
            set => _requestTemplate = SetValue("request_template", _requestTemplate, value);
        }

        /// <summary>
        /// Gets or sets the service instance used when creating requests in this product backlog.
        /// </summary>
        [XurrentField("service_instance")]
        public ServiceInstance? ServiceInstance
        {
            get => _serviceInstance;
            set => _serviceInstance = SetValue("service_instance", _serviceInstance, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier for the product backlog.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the product backlog in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the product backlog.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new product backlog instance.
        /// </summary>
        public ProductBacklog()
        {
        }

        /// <summary>
        /// Creates a new product backlog instance.
        /// </summary>
        /// <param name="id">The unique identifier of the product backlog.</param>
        public ProductBacklog(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new product backlog instance.
        /// </summary>
        /// <param name="name">The name of the product backlog.</param>
        public ProductBacklog(string name)
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
