using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent site object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Site : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Site"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The address field.
            /// </summary>
            [XurrentEnum("address")]
            Address,

            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The city field.
            /// </summary>
            [XurrentEnum("city")]
            City,

            /// <summary>
            /// The country field.
            /// </summary>
            [XurrentEnum("country")]
            Country,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The custom fields field.
            /// </summary>
            [XurrentEnum("custom_fields")]
            CustomFields,

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
            /// The integration field.
            /// </summary>
            [XurrentEnum("integration")]
            Integration,

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
            /// The remarks field.
            /// </summary>
            [XurrentEnum("remarks")]
            Remarks,

            /// <summary>
            /// The remarks attachments field.
            /// </summary>
            [XurrentEnum("remarks_attachments", IgnoreInFieldSelection = true)]
            RemarksAttachments,

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
            /// The state field.
            /// </summary>
            [XurrentEnum("state")]
            State,

            /// <summary>
            /// The time zone field.
            /// </summary>
            [XurrentEnum("time_zone")]
            TimeZone,

            /// <summary>
            /// The user interface extension field.
            /// </summary>
            [XurrentEnum("ui_extension")]
            UiExtension,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The zip field.
            /// </summary>
            [XurrentEnum("zip")]
            Zip
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Site"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters sites by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters sites by disabled status.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters sites by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters sites by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters sites by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters sites by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters sites by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Site"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all sites registered in the directory account of the support domain account from which the data is requested.
            /// </summary>
            [XurrentEnum("directory")]
            Directory,

            /// <summary>
            /// Lists all disabled sites.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled sites.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled,

            /// <summary>
            /// Lists all sites registered in the account from which the data is requested.
            /// </summary>
            [XurrentEnum("support_domain")]
            SupportDomain
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Site"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts sites by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts sites by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts sites by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts sites by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts sites by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private string? _address;
        private List<Attachment>? _attachments;
        private string? _city;
        private string? _country;
        private DateTime? _createdAt;
        private bool? _disabled;
        private bool? _integration;
        private string? _name;
        private Uri? _pictureUri;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private string? _source;
        private string? _sourceID;
        private string? _state;
        private string? _timeZone;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;
        private string? _zip;

        /// <summary>
        /// Gets or sets the address lines of the street address.
        /// </summary>
        [XurrentField("address")]
        public string? Address
        {
            get => _address;
            set => _address = SetValue("address", _address, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated read-only collection of all attachments.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the city name of the street address.
        /// </summary>
        [XurrentField("city")]
        public string? City
        {
            get => _city;
            set => _city = SetValue("city", _city, value);
        }

        /// <summary>
        /// Gets or sets the two-letter country code of the street address.
        /// </summary>
        [XurrentField("country")]
        public string? Country
        {
            get => _country;
            set => _country = SetValue("country", _country, value);
        }

        /// <summary>
        /// Gets the date and time at which the site was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the site may no longer be related to other records.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the site address fields are managed by integration.<br />
        /// When set to <see langword="true"/>, the address fields are displayed as read-only in the user interface to prevent updates.
        /// </summary>
        [XurrentField("integration")]
        public bool? Integration
        {
            get => _integration;
            set => _integration = SetValue("integration", _integration, value);
        }

        /// <summary>
        /// Gets or sets the name of the site or facility.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the site.<br />
        /// A data URL can be used to supply the image directly, removing the need for a separate upload.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets additional information about the site.
        /// </summary>
        [XurrentField("remarks")]
        public string? Remarks
        {
            get => _remarks;
            set => _remarks = SetValue("remarks", _remarks, value);
        }

        [XurrentField("remarks_attachments")]
        internal ObservableCollection<AttachmentReference> RemarksAttachmentsCollection
        {
            get => GetCollection(ref _remarksAttachments, OnRemarksAttachmentsChanged);
            set => SetCollection(ref _remarksAttachments, "remarks_attachments", value, OnRemarksAttachmentsChanged);
        }

        /// <summary>
        /// Sets the inline attachments used in the remarks field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter RemarksAttachments
        {
            get
            {
                _remarksAttachmentsWriter ??= new AttachmentReferenceWriter(() => RemarksAttachmentsCollection, c => RemarksAttachmentsCollection = c);
                return _remarksAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the source of the site.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the site.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the state name of the street address.
        /// </summary>
        [XurrentField("state")]
        public string? State
        {
            get => _state;
            set => _state = SetValue("state", _state, value);
        }

        /// <summary>
        /// Gets or sets the time zone in which the site is located.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the UI extension that is applied to the site.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the site.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the zip code of the street address.
        /// </summary>
        [XurrentField("zip")]
        public string? Zip
        {
            get => _zip;
            set => _zip = SetValue("zip", _zip, value);
        }

        /// <summary>
        /// Creates a new site instance.
        /// </summary>
        public Site()
        {
        }

        /// <summary>
        /// Creates a new site instance.
        /// </summary>
        /// <param name="id">The unique identifier of the site.</param>
        public Site(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new site instance.
        /// </summary>
        /// <param name="name">The name of the site.</param>
        public Site(string name)
        {
            _name = SetValue("name", name);
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }
    }
}
