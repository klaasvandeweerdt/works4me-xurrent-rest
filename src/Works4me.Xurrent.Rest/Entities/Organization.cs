using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent organization object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Organization : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="Organization"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The addresses field.
            /// </summary>
            [XurrentEnum("addresses")]
            Addresses,

            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The business unit field.
            /// </summary>
            [XurrentEnum("business_unit")]
            BusinessUnit,

            /// <summary>
            /// The business unit organization field.
            /// </summary>
            [XurrentEnum("business_unit_organization")]
            BusinessUnitOrganization,

            /// <summary>
            /// The contacts field.
            /// </summary>
            [XurrentEnum("contacts")]
            Contacts,

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
            /// The end user privacy field.
            /// </summary>
            [XurrentEnum("end_user_privacy")]
            EndUserPrivacy,

            /// <summary>
            /// The financial identifier field.
            /// </summary>
            [XurrentEnum("financialID")]
            FinancialID,

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
            /// The order template field.
            /// </summary>
            [XurrentEnum("order_template")]
            OrderTemplate,

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
            /// The region field.
            /// </summary>
            [XurrentEnum("region")]
            Region,

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
            /// The substitute field.
            /// </summary>
            [XurrentEnum("substitute")]
            Substitute,

            /// <summary>
            /// The user interface extension field.
            /// </summary>
            [XurrentEnum("ui_extension")]
            UiExtension,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="Organization"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters organizations by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters organizations by whether they are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters organizations by their financial identifier.
            /// </summary>
            [XurrentEnum("financialID")]
            FinancialID,

            /// <summary>
            /// Filters organizations by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters organizations by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters organizations by their parent organization.
            /// </summary>
            [XurrentEnum("parent")]
            Parent,

            /// <summary>
            /// Filters organizations by their external source identifier.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters organizations by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters organizations by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of an <see cref="Organization"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all organizations registered in the directory account of the support domain account from which the data is requested.
            /// </summary>
            [XurrentEnum("directory")]
            Directory,

            /// <summary>
            /// Lists all organizations that are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all organizations that are enabled.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled,

            /// <summary>
            /// Lists all external organizations.
            /// </summary>
            [XurrentEnum("external")]
            External,

            /// <summary>
            /// Lists all internal organizations.
            /// </summary>
            [XurrentEnum("internal")]
            Internal,

            /// <summary>
            /// Lists all organizations for which the API user is the manager or a substitute manager.
            /// </summary>
            [XurrentEnum("managed_by_me")]
            ManagedByMe,

            /// <summary>
            /// Lists all organizations registered in the account from which the data is requested.
            /// </summary>
            [XurrentEnum("support_domain")]
            SupportDomain,

            /// <summary>
            /// Lists all trusted organizations.
            /// </summary>
            [XurrentEnum("trusted")]
            Trusted
        }

        /// <summary>
        /// Represents the fields used to order an <see cref="Organization"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts organizations by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts organizations by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts organizations by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts organizations by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts organizations by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Address>? _addresses;
        private List<Attachment>? _attachments;
        private bool? _businessUnit;
        private Organization? _businessUnitOrganization;
        private List<Contact>? _contacts;
        private DateTime? _createdAt;
        private bool? _disabled;
        private bool? _endUserPrivacy;
        private string? _financialID;
        private Person? _manager;
        private string? _name;
        private RequestTemplate? _orderTemplate;
        private Organization? _parent;
        private Uri? _pictureUri;
        private string? _region;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private string? _source;
        private string? _sourceID;
        private Person? _substitute;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;

        [XurrentField("addresses")]
        internal List<Address>? AddressesCollection
        {
            get => _addresses;
            set => _addresses = value;
        }

        /// <summary>
        /// Gets the street, mailing, and billing addresses of the organization.
        /// </summary>
        public ReadOnlyCollection<Address>? Addresses
        {
            get => _addresses is null ? null : new ReadOnlyCollection<Address>(_addresses);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the read-only aggregated attachments.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the organization is treated as a separate entity from a reporting perspective.
        /// </summary>
        [XurrentField("business_unit")]
        public bool? BusinessUnit
        {
            get => _businessUnit;
            set => _businessUnit = SetValue("business_unit", _businessUnit, value);
        }

        /// <summary>
        /// Gets the business unit organization.<br />
        /// Refers to itself if the organization is a business unit, or to the business unit that the organization belongs to.
        /// </summary>
        [XurrentField("business_unit_organization")]
        public Organization? BusinessUnitOrganization
        {
            get => _businessUnitOrganization;
            internal set => _businessUnitOrganization = value;
        }

        [XurrentField("contacts")]
        internal List<Contact>? ContactsCollection
        {
            get => _contacts;
            set => _contacts = value;
        }

        /// <summary>
        /// Gets the general and service desk contact details of the organization.
        /// </summary>
        public ReadOnlyCollection<Contact>? Contacts
        {
            get => _contacts is null ? null : new ReadOnlyCollection<Contact>(_contacts);
        }

        /// <summary>
        /// Gets the date and time at which the organization was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the organization may no longer be related to other records.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether end users from this organization are prevented from seeing information of other end users.
        /// </summary>
        [XurrentField("end_user_privacy")]
        public bool? EndUserPrivacy
        {
            get => _endUserPrivacy;
            set => _endUserPrivacy = SetValue("end_user_privacy", _endUserPrivacy, value);
        }

        /// <summary>
        /// Gets or sets the unique identifier by which the organization is known in the financial system.
        /// </summary>
        [XurrentField("financialID")]
        public string? FinancialID
        {
            get => _financialID;
            set => _financialID = SetValue("financialID", _financialID, value);
        }

        /// <summary>
        /// Gets or sets the manager of the organization.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Gets or sets the full name of the organization.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the order template used for purchases of people defined in this organization or its descendants.
        /// </summary>
        [XurrentField("order_template")]
        public RequestTemplate? OrderTemplate
        {
            get => _orderTemplate;
            set => _orderTemplate = SetValue("order_template", _orderTemplate, value);
        }

        /// <summary>
        /// Gets or sets the parent organization.
        /// </summary>
        [XurrentField("parent")]
        public Organization? Parent
        {
            get => _parent;
            set => _parent = SetValue("parent", _parent, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the organization.<br />
        /// A data URL can be used to supply the image directly, removing the need for a separate upload.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the region to which the organization belongs.
        /// </summary>
        [XurrentField("region")]
        public string? Region
        {
            get => _region;
            set => _region = SetValue("region", _region, value);
        }

        /// <summary>
        /// Gets or sets additional information about the organization.
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
        /// Sets the attachments used in the remarks field.<br />
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
        /// Gets or sets the source of the organization.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the organization.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the substitute of the organization's manager.
        /// </summary>
        [XurrentField("substitute")]
        public Person? Substitute
        {
            get => _substitute;
            set => _substitute = SetValue("substitute", _substitute, value);
        }

        /// <summary>
        /// Gets the UI extension that is applied to the organization.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the organization.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new organization instance.
        /// </summary>
        public Organization()
        {
        }

        /// <summary>
        /// Creates a new organization instance.
        /// </summary>
        /// <param name="id">The unique identifier of the organization.</param>
        public Organization(long id)
        {
            Id = id;
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }
    }
}
