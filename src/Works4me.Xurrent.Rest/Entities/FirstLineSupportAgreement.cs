using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent first line support agreement object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class FirstLineSupportAgreement : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="FirstLineSupportAgreement"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The charges field.
            /// </summary>
            [XurrentEnum("charges")]
            Charges,

            /// <summary>
            /// The charges attachments field.
            /// </summary>
            [XurrentEnum("charges_attachments", IgnoreInFieldSelection = true)]
            ChargesAttachments,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

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
            /// The first call resolutions field.
            /// </summary>
            [XurrentEnum("first_call_resolutions")]
            FirstCallResolutions,

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
            /// The pickup target field.
            /// </summary>
            [XurrentEnum("pickup_target")]
            PickupTarget,

            /// <summary>
            /// The pickups within target field.
            /// </summary>
            [XurrentEnum("pickups_within_target")]
            PickupsWithinTarget,

            /// <summary>
            /// The provider field.
            /// </summary>
            [XurrentEnum("provider")]
            Provider,

            /// <summary>
            /// The rejected solutions field.
            /// </summary>
            [XurrentEnum("rejected_solutions")]
            RejectedSolutions,

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
            /// The service desk only resolutions field.
            /// </summary>
            [XurrentEnum("service_desk_only_resolutions")]
            ServiceDeskOnlyResolutions,

            /// <summary>
            /// The service desk team field.
            /// </summary>
            [XurrentEnum("service_desk_team")]
            ServiceDeskTeam,

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
            /// The support chat pickup target field.
            /// </summary>
            [XurrentEnum("support_chat_pickup_target")]
            SupportChatPickupTarget,

            /// <summary>
            /// The support hours field.
            /// </summary>
            [XurrentEnum("support_hours")]
            SupportHours,

            /// <summary>
            /// The target details field.
            /// </summary>
            [XurrentEnum("target_details")]
            TargetDetails,

            /// <summary>
            /// The target details attachments field.
            /// </summary>
            [XurrentEnum("target_details_attachments", IgnoreInFieldSelection = true)]
            TargetDetailsAttachments,

            /// <summary>
            /// The time zone field.
            /// </summary>
            [XurrentEnum("time_zone")]
            TimeZone,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="FirstLineSupportAgreement"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters first line support agreements by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters first line support agreements by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters first line support agreements by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters first line support agreements by provider.
            /// </summary>
            [XurrentEnum("provider")]
            Provider,

            /// <summary>
            /// Filters first line support agreements by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters first line support agreements by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters first line support agreements by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters first line support agreements by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="FirstLineSupportAgreement"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all active first line support agreements.
            /// </summary>
            [XurrentEnum("active")]
            Active,

            /// <summary>
            /// Lists all inactive first line support agreements.
            /// </summary>
            [XurrentEnum("inactive")]
            Inactive
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="FirstLineSupportAgreement"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts first line support agreements by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts first line support agreements by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts first line support agreements by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts first line support agreements by provider.
            /// </summary>
            [XurrentEnum("provider")]
            Provider,

            /// <summary>
            /// Sorts first line support agreements by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts first line support agreements by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts first line support agreements by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private string? _charges;
        private ObservableCollection<AttachmentReference>? _chargesAttachments;
        private AttachmentReferenceWriter? _chargesAttachmentsWriter;
        private DateTime? _createdAt;
        private Organization? _customer;
        private Person? _customerRep;
#if (NET6_0_OR_GREATER)
        private DateOnly? _expiryDate;
#else
        private DateTime? _expiryDate;
#endif
        private int? _firstCallResolutions;
        private string? _name;
#if (NET6_0_OR_GREATER)
        private DateOnly? _noticeDate;
#else
        private DateTime? _noticeDate;
#endif
        private int? _pickupTarget;
        private int? _pickupsWithinTarget;
        private Organization? _provider;
        private int? _rejectedSolutions;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private int? _serviceDeskOnlyResolutions;
        private Team? _serviceDeskTeam;
        private string? _source;
        private string? _sourceID;
#if (NET6_0_OR_GREATER)
        private DateOnly? _startDate;
#else
        private DateTime? _startDate;
#endif
        private AgreementStatus? _status;
        private int? _supportChatPickupTarget;
        private Calendar? _supportHours;
        private string? _targetDetails;
        private ObservableCollection<AttachmentReference>? _targetDetailsAttachments;
        private AttachmentReferenceWriter? _targetDetailsAttachmentsWriter;
        private string? _timeZone;
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
        /// Gets or sets the charges of the first line support agreement.
        /// </summary>
        [XurrentField("charges")]
        public string? Charges
        {
            get => _charges;
            set => _charges = SetValue("charges", _charges, value);
        }

        [XurrentField("charges_attachments")]
        internal ObservableCollection<AttachmentReference> ChargesAttachmentsCollection
        {
            get => GetCollection(ref _chargesAttachments, OnChargesAttachmentsChanged);
            set => SetCollection(ref _chargesAttachments, "charges_attachments", value, OnChargesAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the charges field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter ChargesAttachments
        {
            get
            {
                _chargesAttachmentsWriter ??= new AttachmentReferenceWriter(() => ChargesAttachmentsCollection, c => ChargesAttachmentsCollection = c);
                return _chargesAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the date and time when the first line support agreement was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the customer organization of the first line support agreement.
        /// </summary>
        [XurrentField("customer")]
        public Organization? Customer
        {
            get => _customer;
            set => _customer = SetValue("customer", _customer, value);
        }

        /// <summary>
        /// Gets or sets the customer representative of the first line support agreement.
        /// </summary>
        [XurrentField("customer_rep")]
        public Person? CustomerRep
        {
            get => _customerRep;
            set => _customerRep = SetValue("customer_rep", _customerRep, value);
        }

        /// <summary>
        /// Gets or sets the expiry date of the first line support agreement.
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
        /// Gets or sets the minimum percentage of requests resolved during registration by the service desk team.
        /// </summary>
        [XurrentField("first_call_resolutions")]
        public int? FirstCallResolutions
        {
            get => _firstCallResolutions;
            set => _firstCallResolutions = SetValue("first_call_resolutions", _firstCallResolutions, value);
        }

        /// <summary>
        /// Gets or sets the name of the first line support agreement.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the notice date of the first line support agreement.
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
        /// Gets or sets the pickup target in minutes.
        /// </summary>
        [XurrentField("pickup_target")]
        public int? PickupTarget
        {
            get => _pickupTarget;
            set => _pickupTarget = SetValue("pickup_target", _pickupTarget, value);
        }

        /// <summary>
        /// Gets or sets the minimum percentage of requests picked up within the pickup target.
        /// </summary>
        [XurrentField("pickups_within_target")]
        public int? PickupsWithinTarget
        {
            get => _pickupsWithinTarget;
            set => _pickupsWithinTarget = SetValue("pickups_within_target", _pickupsWithinTarget, value);
        }

        /// <summary>
        /// Gets or sets the provider organization of the first line support agreement.
        /// </summary>
        [XurrentField("provider")]
        public Organization? Provider
        {
            get => _provider;
            set => _provider = SetValue("provider", _provider, value);
        }

        /// <summary>
        /// Gets or sets the maximum percentage of reopened requests.
        /// </summary>
        [XurrentField("rejected_solutions")]
        public int? RejectedSolutions
        {
            get => _rejectedSolutions;
            set => _rejectedSolutions = SetValue("rejected_solutions", _rejectedSolutions, value);
        }

        /// <summary>
        /// Gets or sets the remarks of the first line support agreement.
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
        /// Gets or sets the minimum percentage of requests resolved by the service desk team.
        /// </summary>
        [XurrentField("service_desk_only_resolutions")]
        public int? ServiceDeskOnlyResolutions
        {
            get => _serviceDeskOnlyResolutions;
            set => _serviceDeskOnlyResolutions = SetValue("service_desk_only_resolutions", _serviceDeskOnlyResolutions, value);
        }

        /// <summary>
        /// Gets or sets the service desk team that provides first line support.
        /// </summary>
        [XurrentField("service_desk_team")]
        public Team? ServiceDeskTeam
        {
            get => _serviceDeskTeam;
            set => _serviceDeskTeam = SetValue("service_desk_team", _serviceDeskTeam, value);
        }

        /// <summary>
        /// Gets or sets the source of the first line support agreement.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the first line support agreement.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the start date of the first line support agreement.
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
        /// Gets or sets the status of the first line support agreement.
        /// </summary>
        [XurrentField("status")]
        public AgreementStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the chat pickup target in minutes.
        /// </summary>
        [XurrentField("support_chat_pickup_target")]
        public int? SupportChatPickupTarget
        {
            get => _supportChatPickupTarget;
            set => _supportChatPickupTarget = SetValue("support_chat_pickup_target", _supportChatPickupTarget, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the support hours for first line support.
        /// </summary>
        [XurrentField("support_hours")]
        public Calendar? SupportHours
        {
            get => _supportHours;
            set => _supportHours = SetValue("support_hours", _supportHours, value);
        }

        /// <summary>
        /// Gets or sets the target details of the first line support agreement.
        /// </summary>
        [XurrentField("target_details")]
        public string? TargetDetails
        {
            get => _targetDetails;
            set => _targetDetails = SetValue("target_details", _targetDetails, value);
        }

        [XurrentField("target_details_attachments")]
        internal ObservableCollection<AttachmentReference> TargetDetailsAttachmentsCollection
        {
            get => GetCollection(ref _targetDetailsAttachments, OnTargetDetailsAttachmentsChanged);
            set => SetCollection(ref _targetDetailsAttachments, "target_details_attachments", value, OnTargetDetailsAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the target details field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter TargetDetailsAttachments
        {
            get
            {
                _targetDetailsAttachmentsWriter ??= new AttachmentReferenceWriter(() => TargetDetailsAttachmentsCollection, c => TargetDetailsAttachmentsCollection = c);
                return _targetDetailsAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the first line support agreement.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the date and time when the first line support agreement was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new first line support agreement instance.
        /// </summary>
        public FirstLineSupportAgreement()
        {
        }

        /// <summary>
        /// Creates a new first line support agreement instance.
        /// </summary>
        /// <param name="id">The unique identifier of the first line support agreement.</param>
        public FirstLineSupportAgreement(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new first line support agreement instance.
        /// </summary>
        /// <param name="customer">The customer of the first line support agreement.</param>
        /// <param name="name">The name of the first line support agreement.</param>
        /// <param name="provider">The provider of the first line support agreement.</param>
        public FirstLineSupportAgreement(Organization customer, string name, Organization provider)
        {
            _customer = SetValue("customer", customer);
            _name = SetValue("name", name);
            _provider = SetValue("provider", provider);
        }

        private void OnChargesAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "charges_attachments");
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }

        private void OnTargetDetailsAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "target_details_attachments");
        }
    }
}
