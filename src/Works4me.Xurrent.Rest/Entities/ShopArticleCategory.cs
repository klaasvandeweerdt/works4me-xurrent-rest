using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent shop article category object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ShopArticleCategory : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ShopArticleCategory"/> object.
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
            /// The full description field.
            /// </summary>
            [XurrentEnum("full_description")]
            FullDescription,

            /// <summary>
            /// The full description attachments field.
            /// </summary>
            [XurrentEnum("full_description_attachments", IgnoreInFieldSelection = true)]
            FullDescriptionAttachments,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The localized full description field.
            /// </summary>
            [XurrentEnum("localized_full_description", IgnoreInFieldSelection = true)]
            LocalizedFullDescription,

            /// <summary>
            /// The localized name field.
            /// </summary>
            [XurrentEnum("localized_name", IgnoreInFieldSelection = true)]
            LocalizedName,

            /// <summary>
            /// The localized short description field.
            /// </summary>
            [XurrentEnum("localized_short_description", IgnoreInFieldSelection = true)]
            LocalizedShortDescription,

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
            /// The parent field.
            /// </summary>
            [XurrentEnum("parent")]
            Parent,

            /// <summary>
            /// The picture uri field.
            /// </summary>
            [XurrentEnum("picture_uri")]
            PictureUri,

            /// <summary>
            /// The short description field.
            /// </summary>
            [XurrentEnum("short_description")]
            ShortDescription,

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
        /// Represents the filterable fields of a <see cref="ShopArticleCategory"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters shop article categories by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters shop article categories by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters shop article categories by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters shop article categories by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters shop article categories by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters shop article categories by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ShopArticleCategory"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all shop article categories registered in the directory account of the support domain account from which the data is requested.
            /// </summary>
            [XurrentEnum("directory")]
            Directory,

            /// <summary>
            /// Lists all shop article categories registered in the account from which the data is requested.
            /// </summary>
            [XurrentEnum("support_domain")]
            SupportDomain
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ShopArticleCategory"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts shop article categories by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts shop article categories by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts shop article categories by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts shop article categories by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Sorts shop article categories by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts shop article categories by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private string? _fullDescription;
        private ObservableCollection<AttachmentReference>? _fullDescriptionAttachments;
        private AttachmentReferenceWriter? _fullDescriptionAttachmentsWriter;
        private string? _localizedFullDescription;
        private string? _localizedName;
        private string? _localizedShortDescription;
        private string? _name;
        private ShopArticleCategory? _parent;
        private Uri? _pictureUri;
        private string? _shortDescription;
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
        /// Readonly aggregated Attachments.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time when the shop article category was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the full description of the shop article category.
        /// </summary>
        [XurrentField("full_description")]
        public string? FullDescription
        {
            get => _fullDescription;
            set => _fullDescription = SetValue("full_description", _fullDescription, value);
        }

        [XurrentField("full_description_attachments")]
        internal ObservableCollection<AttachmentReference> FullDescriptionAttachmentsCollection
        {
            get => GetCollection(ref _fullDescriptionAttachments, OnFullDescriptionAttachmentsChanged);
            set => SetCollection(ref _fullDescriptionAttachments, "full_description_attachments", value, OnFullDescriptionAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the full description.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter FullDescriptionAttachments
        {
            get
            {
                _fullDescriptionAttachmentsWriter ??= new AttachmentReferenceWriter(() => FullDescriptionAttachmentsCollection, c => FullDescriptionAttachmentsCollection = c);
                return _fullDescriptionAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the localized full description of the shop article category.
        /// </summary>
        [XurrentField("localized_full_description")]
        public string? LocalizedFullDescription
        {
            get => _localizedFullDescription;
            set => _localizedFullDescription = SetValue("localized_full_description", _localizedFullDescription, value);
        }

        /// <summary>
        /// Gets or sets the localized name of the shop article category.
        /// </summary>
        [XurrentField("localized_name")]
        public string? LocalizedName
        {
            get => _localizedName;
            set => _localizedName = SetValue("localized_name", _localizedName, value);
        }

        /// <summary>
        /// Gets or sets the localized short description of the shop article category.
        /// </summary>
        [XurrentField("localized_short_description")]
        public string? LocalizedShortDescription
        {
            get => _localizedShortDescription;
            set => _localizedShortDescription = SetValue("localized_short_description", _localizedShortDescription, value);
        }

        /// <summary>
        /// Gets or sets the name of the shop article category.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the parent shop article category.
        /// </summary>
        [XurrentField("parent")]
        public ShopArticleCategory? Parent
        {
            get => _parent;
            set => _parent = SetValue("parent", _parent, value);
        }

        /// <summary>
        /// Gets or sets the URI of the image associated with the shop article category.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the short description of the shop article category.
        /// </summary>
        [XurrentField("short_description")]
        public string? ShortDescription
        {
            get => _shortDescription;
            set => _shortDescription = SetValue("short_description", _shortDescription, value);
        }

        /// <summary>
        /// Gets or sets the source of the shop article category.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the source associated with the shop article category.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time when the shop article category was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new shop article category instance.
        /// </summary>
        public ShopArticleCategory()
        {
        }

        /// <summary>
        /// Creates a new shop article category instance.
        /// </summary>
        /// <param name="id">The unique identifier of the shop article category.</param>
        public ShopArticleCategory(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new shop article category instance.
        /// </summary>
        /// <param name="name">The name of the shop article category.</param>
        public ShopArticleCategory(string name)
        {
            _name = SetValue("name", name);
        }

        private void OnFullDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "full_description_attachments");
        }
    }
}
