using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent custom collection element object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class CustomCollectionElement : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="CustomCollectionElement"/> object.
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
            /// The custom collection field.
            /// </summary>
            [XurrentEnum("custom_collection")]
            CustomCollection,

            /// <summary>
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

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
            /// The information field.
            /// </summary>
            [XurrentEnum("information")]
            Information,

            /// <summary>
            /// The information attachments field.
            /// </summary>
            [XurrentEnum("information_attachments", IgnoreInFieldSelection = true)]
            InformationAttachments,

            /// <summary>
            /// The localized description field.
            /// </summary>
            [XurrentEnum("localized_description", IgnoreInFieldSelection = true)]
            LocalizedDescription,

            /// <summary>
            /// The localized name field.
            /// </summary>
            [XurrentEnum("localized_name", IgnoreInFieldSelection = true)]
            LocalizedName,

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
            /// The reference field.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

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
        /// Represents the filterable fields of a <see cref="CustomCollectionElement"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters custom collection elements by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters custom collection elements by custom collection.
            /// </summary>
            [XurrentEnum("custom_collection")]
            CustomCollection,

            /// <summary>
            /// Filters custom collection elements by disabled status.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters custom collection elements by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters custom collection elements by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters custom collection elements by reference.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Filters custom collection elements by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters custom collection elements by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters custom collection elements by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="CustomCollectionElement"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled custom collection elements.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled custom collection elements.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="CustomCollectionElement"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts custom collection elements by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts custom collection elements by custom collection.
            /// </summary>
            [XurrentEnum("custom_collection")]
            CustomCollection,

            /// <summary>
            /// Sorts custom collection elements by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts custom collection elements by reference.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Sorts custom collection elements by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts custom collection elements by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private string? _customCollection;
        private string? _description;
        private bool? _disabled;
        private string? _information;
        private ObservableCollection<AttachmentReference>? _informationAttachments;
        private AttachmentReferenceWriter? _informationAttachmentsWriter;
        private string? _localizedDescription;
        private string? _localizedName;
        private string? _name;
        private Uri? _pictureUri;
        private string? _reference;
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
        /// Gets the aggregated attachments.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time when the custom collection element was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the reference of the custom collection to which the custom collection element belongs.
        /// </summary>
        [XurrentField("custom_collection")]
        public string? CustomCollection
        {
            get => _customCollection;
            internal set => _customCollection = value;
        }

        /// <summary>
        /// Gets or sets the description of the custom collection element.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the custom collection element is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the information of the custom collection element.
        /// </summary>
        [XurrentField("information")]
        public string? Information
        {
            get => _information;
            set => _information = SetValue("information", _information, value);
        }

        [XurrentField("information_attachments")]
        internal ObservableCollection<AttachmentReference> InformationAttachmentsCollection
        {
            get => GetCollection(ref _informationAttachments, OnInformationAttachmentsChanged);
            set => SetCollection(ref _informationAttachments, "information_attachments", value, OnInformationAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the information field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter InformationAttachments
        {
            get
            {
                _informationAttachmentsWriter ??= new AttachmentReferenceWriter(() => InformationAttachmentsCollection, c => InformationAttachmentsCollection = c);
                return _informationAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the localized description of the custom collection element.
        /// </summary>
        [XurrentField("localized_description")]
        public string? LocalizedDescription
        {
            get => _localizedDescription;
            internal set => _localizedDescription = value;
        }

        /// <summary>
        /// Gets the localized name of the custom collection element.
        /// </summary>
        [XurrentField("localized_name")]
        public string? LocalizedName
        {
            get => _localizedName;
            internal set => _localizedName = value;
        }

        /// <summary>
        /// Gets or sets the name of the custom collection element.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the URI of the image associated with the custom collection element.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the reference of the custom collection element.
        /// </summary>
        [XurrentField("reference")]
        public string? Reference
        {
            get => _reference;
            set => _reference = SetValue("reference", _reference, value);
        }

        /// <summary>
        /// Gets or sets the source of the custom collection element.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the custom collection element.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time when the custom collection element was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new custom collection element instance.
        /// </summary>
        public CustomCollectionElement()
        {
        }

        /// <summary>
        /// Creates a new custom collection element instance.
        /// </summary>
        /// <param name="id">The unique identifier of the custom collection element.</param>
        public CustomCollectionElement(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new custom collection element instance.
        /// </summary>
        /// <param name="name">The name of the custom collection element.</param>
        public CustomCollectionElement(string name)
        {
            _name = SetValue("name", name);
        }

        private void OnInformationAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "information_attachments");
        }
    }
}
