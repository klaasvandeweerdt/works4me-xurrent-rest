using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent contract object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Contract : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Contract"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The category field.
            /// </summary>
            [XurrentEnum("category")]
            Category,

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
            /// The customer field.
            /// </summary>
            [XurrentEnum("customer")]
            Customer,

            /// <summary>
            /// The customer rep field.
            /// </summary>
            [XurrentEnum("customer_rep")]
            CustomerRep,

            /// <summary>
            /// The expiry date field.
            /// </summary>
            [XurrentEnum("expiry_date")]
            ExpiryDate,

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
            /// The notice date field.
            /// </summary>
            [XurrentEnum("notice_date")]
            NoticeDate,

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
            /// The start date field.
            /// </summary>
            [XurrentEnum("start_date")]
            StartDate,

            /// <summary>
            /// The status field.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// The supplier field.
            /// </summary>
            [XurrentEnum("supplier")]
            Supplier,

            /// <summary>
            /// The supplier contact field.
            /// </summary>
            [XurrentEnum("supplier_contact")]
            SupplierContact,

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
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Contract"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters contracts by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Filters contracts by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters contracts by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters contracts by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters contracts by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters contracts by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters contracts by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters contracts by supplier.
            /// </summary>
            [XurrentEnum("supplier")]
            Supplier,

            /// <summary>
            /// Filters contracts by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Contract"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all active contracts.
            /// </summary>
            [XurrentEnum("active")]
            Active,

            /// <summary>
            /// Lists all inactive contracts.
            /// </summary>
            [XurrentEnum("inactive")]
            Inactive
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Contract"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts contracts by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Sorts contracts by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts contracts by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts contracts by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts contracts by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts contracts by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts contracts by supplier.
            /// </summary>
            [XurrentEnum("supplier")]
            Supplier,

            /// <summary>
            /// Sorts contracts by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private ContractCategory? _category;
        private DateTime? _createdAt;
        private Organization? _customer;
        private Person? _customerRep;
#if (NET6_0_OR_GREATER)
        private DateOnly? _expiryDate;
#else
        private DateTime? _expiryDate;
#endif
        private string? _name;
#if (NET6_0_OR_GREATER)
        private DateOnly? _noticeDate;
#else
        private DateTime? _noticeDate;
#endif
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private string? _source;
        private string? _sourceID;
#if (NET6_0_OR_GREATER)
        private DateOnly? _startDate;
#else
        private DateTime? _startDate;
#endif
        private AgreementStatus? _status;
        private Organization? _supplier;
        private Person? _supplierContact;
        private string? _timeZone;
        private UiExtension? _uiExtension;
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
        /// Gets or sets the category of the contract.
        /// </summary>
        [XurrentField("category")]
        public ContractCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets the date and time when the contract was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the customer organization of the contract.
        /// </summary>
        [XurrentField("customer")]
        public Organization? Customer
        {
            get => _customer;
            set => _customer = SetValue("customer", _customer, value);
        }

        /// <summary>
        /// Gets or sets the customer representative of the contract.
        /// </summary>
        [XurrentField("customer_rep")]
        public Person? CustomerRep
        {
            get => _customerRep;
            set => _customerRep = SetValue("customer_rep", _customerRep, value);
        }

        /// <summary>
        /// Gets or sets the expiry date of the contract.
        /// </summary>
        [XurrentField("expiry_date")]
#if (NET6_0_OR_GREATER)
        public DateOnly? ExpiryDate
#else
        public DateTime? ExpiryDate
#endif
        {
            get => _expiryDate;
            set => _expiryDate = SetValue("expiry_date", _expiryDate, value);
        }

        /// <summary>
        /// Gets or sets the name of the contract.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the notice date of the contract.
        /// </summary>
        [XurrentField("notice_date")]
#if (NET6_0_OR_GREATER)
        public DateOnly? NoticeDate
#else
        public DateTime? NoticeDate
#endif
        {
            get => _noticeDate;
            set => _noticeDate = SetValue("notice_date", _noticeDate, value);
        }

        /// <summary>
        /// Gets or sets the remarks of the contract.
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
        /// Sets the attachments used for the remarks field.<br />
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
        /// Gets or sets the source of the contract.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the contract.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the start date of the contract.
        /// </summary>
        [XurrentField("start_date")]
#if (NET6_0_OR_GREATER)
        public DateOnly? StartDate
#else
        public DateTime? StartDate
#endif
        {
            get => _startDate;
            set => _startDate = SetValue("start_date", _startDate, value);
        }

        /// <summary>
        /// Gets or sets the status of the contract.
        /// </summary>
        [XurrentField("status")]
        public AgreementStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the supplier organization of the contract.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the supplier contact of the contract.
        /// </summary>
        [XurrentField("supplier_contact")]
        public Person? SupplierContact
        {
            get => _supplierContact;
            set => _supplierContact = SetValue("supplier_contact", _supplierContact, value);
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the contract.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the UI extension applied to the contract.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time when the contract was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new contract instance.
        /// </summary>
        public Contract()
        {
        }

        /// <summary>
        /// Creates a new contract instance.
        /// </summary>
        /// <param name="id">The unique identifier of the contract.</param>
        public Contract(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new contract instance.
        /// </summary>
        /// <param name="category">The category of the contract.</param>
        /// <param name="customer">The customer of the contract.</param>
        /// <param name="status">The status of the contract.</param>
        public Contract(ContractCategory category, Organization customer, AgreementStatus status)
        {
            _category = SetValue("category", category);
            _customer = SetValue("customer", customer);
            _status = SetValue("status", status);
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }
    }
}
