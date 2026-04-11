using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent service level agreement object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ServiceLevelAgreement : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ServiceLevelAgreement"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The activity identifier case field.
            /// </summary>
            [XurrentEnum("activityID_case")]
            ActivityIdCase,

            /// <summary>
            /// The activity identifier low field.
            /// </summary>
            [XurrentEnum("activityID_low")]
            ActivityIdLow,

            /// <summary>
            /// The activity identifier medium field.
            /// </summary>
            [XurrentEnum("activityID_medium")]
            ActivityIdMedium,

            /// <summary>
            /// The activity identifier rfc field.
            /// </summary>
            [XurrentEnum("activityID_rfc")]
            ActivityIdRfc,

            /// <summary>
            /// The activity identifier rfi field.
            /// </summary>
            [XurrentEnum("activityID_rfi")]
            ActivityIdRfi,

            /// <summary>
            /// The activity identifier top field.
            /// </summary>
            [XurrentEnum("activityID_top")]
            ActivityIdTop,

            /// <summary>
            /// The agreement identifier field.
            /// </summary>
            [XurrentEnum("agreementID")]
            AgreementID,

            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The coverage field.
            /// </summary>
            [XurrentEnum("coverage")]
            Coverage,

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
            /// The customer account field.
            /// </summary>
            [XurrentEnum("customer_account")]
            CustomerAccount,

            /// <summary>
            /// The customer rep field.
            /// </summary>
            [XurrentEnum("customer_rep")]
            CustomerRep,

            /// <summary>
            /// The customer representative field.
            /// </summary>
            [XurrentEnum("customer_representative", IgnoreInFieldSelection = true)]
            CustomerRepresentative,

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
            /// The service instance field.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

            /// <summary>
            /// The service level manager field.
            /// </summary>
            [XurrentEnum("service_level_manager")]
            ServiceLevelManager,

            /// <summary>
            /// The service offering field.
            /// </summary>
            [XurrentEnum("service_offering")]
            ServiceOffering,

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
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The use knowledge from service provider field.
            /// </summary>
            [XurrentEnum("use_knowledge_from_service_provider")]
            UseKnowledgeFromServiceProvider,

            /// <summary>
            /// The activity identifier high field.
            /// </summary>
            [XurrentEnum("activityID_high")]
            activityIdHigh
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ServiceLevelAgreement"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters service level agreements by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters service level agreements by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters service level agreements by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters service level agreements by service instance.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

            /// <summary>
            /// Filters service level agreements by service offering.
            /// </summary>
            [XurrentEnum("service_offering")]
            ServiceOffering,

            /// <summary>
            /// Filters service level agreements by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters service level agreements by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters service level agreements by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters service level agreements by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ServiceLevelAgreement"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all active service level agreements.
            /// </summary>
            [XurrentEnum("active")]
            Active,

            /// <summary>
            /// Lists all inactive service level agreements.
            /// </summary>
            [XurrentEnum("inactive")]
            Inactive
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ServiceLevelAgreement"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts service level agreements by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts service level agreements by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts service level agreements by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts service level agreements by service offering.
            /// </summary>
            [XurrentEnum("service_offering")]
            ServiceOffering,

            /// <summary>
            /// Sorts service level agreements by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts service level agreements by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts service level agreements by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private string? _activityIdCase;
        private string? _activityIdLow;
        private string? _activityIdMedium;
        private string? _activityIdRfc;
        private string? _activityIdRfi;
        private string? _activityIdTop;
        private string? _agreementID;
        private List<Attachment>? _attachments;
        private SlaCoverage? _coverage;
        private DateTime? _createdAt;
        private Organization? _customer;
        private Account? _customerAccount;
        private Person? _customerRep;
        private ObservableCollection<Person>? _customerRepresentative;
        private DateTime? _expiryDate;
        private string? _name;
#if (NET6_0_OR_GREATER)
        private DateOnly? _noticeDate;
#else
        private DateTime? _noticeDate;
#endif
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private ServiceInstance? _serviceInstance;
        private Person? _serviceLevelManager;
        private ServiceOffering? _serviceOffering;
        private string? _source;
        private string? _sourceID;
#if (NET6_0_OR_GREATER)
        private DateOnly? _startDate;
#else
        private DateTime? _startDate;
#endif
        private AgreementStatus? _status;
        private DateTime? _updatedAt;
        private bool? _useKnowledgeFromServiceProvider;
        private string? _activityIdHigh;

        /// <summary>
        /// Gets or sets the activity identifier for cases.
        /// </summary>
        [XurrentField("activityID_case")]
        public string? ActivityIdCase
        {
            get => _activityIdCase;
            set => _activityIdCase = SetValue("activityID_case", _activityIdCase, value);
        }

        /// <summary>
        /// Gets or sets the activity identifier for low incidents.
        /// </summary>
        [XurrentField("activityID_low")]
        public string? ActivityIdLow
        {
            get => _activityIdLow;
            set => _activityIdLow = SetValue("activityID_low", _activityIdLow, value);
        }

        /// <summary>
        /// Gets or sets the activity identifier for medium incidents.
        /// </summary>
        [XurrentField("activityID_medium")]
        public string? ActivityIdMedium
        {
            get => _activityIdMedium;
            set => _activityIdMedium = SetValue("activityID_medium", _activityIdMedium, value);
        }

        /// <summary>
        /// Gets or sets the activity identifier for RFCs.
        /// </summary>
        [XurrentField("activityID_rfc")]
        public string? ActivityIdRfc
        {
            get => _activityIdRfc;
            set => _activityIdRfc = SetValue("activityID_rfc", _activityIdRfc, value);
        }

        /// <summary>
        /// Gets or sets the activity identifier for RFIs.
        /// </summary>
        [XurrentField("activityID_rfi")]
        public string? ActivityIdRfi
        {
            get => _activityIdRfi;
            set => _activityIdRfi = SetValue("activityID_rfi", _activityIdRfi, value);
        }

        /// <summary>
        /// Gets or sets the activity identifier for top incidents.
        /// </summary>
        [XurrentField("activityID_top")]
        public string? ActivityIdTop
        {
            get => _activityIdTop;
            set => _activityIdTop = SetValue("activityID_top", _activityIdTop, value);
        }

        /// <summary>
        /// Gets or sets the agreement identifier.
        /// </summary>
        [XurrentField("agreementID")]
        public string? AgreementID
        {
            get => _agreementID;
            set => _agreementID = SetValue("agreementID", _agreementID, value);
        }

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
        /// Gets or sets the coverage definition of the service level agreement.
        /// </summary>
        [XurrentField("coverage")]
        public SlaCoverage? Coverage
        {
            get => _coverage;
            set => _coverage = SetValue("coverage", _coverage, value);
        }

        /// <summary>
        /// Gets the date and time when the service level agreement was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the customer organization of the service level agreement.
        /// </summary>
        [XurrentField("customer")]
        public Organization? Customer
        {
            get => _customer;
            set => _customer = SetValue("customer", _customer, value);
        }

        /// <summary>
        /// Gets or sets the customer account associated with the service level agreement.
        /// </summary>
        [XurrentField("customer_account")]
        public Account? CustomerAccount
        {
            get => _customerAccount;
            set => _customerAccount = SetValue("customer_account", _customerAccount, value);
        }

        /// <summary>
        /// Gets or sets the customer representative.
        /// </summary>
        [XurrentField("customer_rep")]
        public Person? CustomerRep
        {
            get => _customerRep;
            set => _customerRep = SetValue("customer_rep", _customerRep, value);
        }

        /// <summary>
        /// Sets the customer representatives of the service level agreement.<br />
        /// This property is write-only and can only be used during creation.
        /// </summary>
        [XurrentField("customer_representative")]
        public ObservableCollection<Person> CustomerRepresentative
        {
            get => GetCollection(ref _customerRepresentative, OnCustomerRepresentativeChanged);
            set => SetCollection(ref _customerRepresentative, "customer_representative", value, OnCustomerRepresentativeChanged);
        }

        /// <summary>
        /// Gets or sets the expiry date of the service level agreement.
        /// </summary>
        [XurrentField("expiry_date")]
        public DateTime? ExpiryDate
        {
            get => _expiryDate;
            set => _expiryDate = SetValue("expiry_date", _expiryDate, value);
        }

        /// <summary>
        /// Gets or sets the name of the service level agreement.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the notice date of the service level agreement.
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
        /// Gets or sets the remarks of the service level agreement.
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
        /// Sets the attachments used in the remarks.<br />
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
        /// Gets or sets the service instance used to provide the service.
        /// </summary>
        [XurrentField("service_instance")]
        public ServiceInstance? ServiceInstance
        {
            get => _serviceInstance;
            set => _serviceInstance = SetValue("service_instance", _serviceInstance, value);
        }

        /// <summary>
        /// Gets or sets the service level manager.
        /// </summary>
        [XurrentField("service_level_manager")]
        public Person? ServiceLevelManager
        {
            get => _serviceLevelManager;
            set => _serviceLevelManager = SetValue("service_level_manager", _serviceLevelManager, value);
        }

        /// <summary>
        /// Gets or sets the service offering associated with the service level agreement.
        /// </summary>
        [XurrentField("service_offering")]
        public ServiceOffering? ServiceOffering
        {
            get => _serviceOffering;
            set => _serviceOffering = SetValue("service_offering", _serviceOffering, value);
        }

        /// <summary>
        /// Gets or sets the source of the service level agreement.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the source associated with the service level agreement.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the start date of the service level agreement.
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
        /// Gets or sets the status of the service level agreement.
        /// </summary>
        [XurrentField("status")]
        public AgreementStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets the date and time when the service level agreement was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether knowledge from the service provider is used.
        /// </summary>
        [XurrentField("use_knowledge_from_service_provider")]
        public bool? UseKnowledgeFromServiceProvider
        {
            get => _useKnowledgeFromServiceProvider;
            set => _useKnowledgeFromServiceProvider = SetValue("use_knowledge_from_service_provider", _useKnowledgeFromServiceProvider, value);
        }

        /// <summary>
        /// Gets or sets the activity identifier for high incidents.
        /// </summary>
        [XurrentField("activityID_high")]
        public string? activityIdHigh
        {
            get => _activityIdHigh;
            set => _activityIdHigh = SetValue("activityID_high", _activityIdHigh, value);
        }

        /// <summary>
        /// Creates a new service level agreement instance.
        /// </summary>
        public ServiceLevelAgreement()
        {
        }

        /// <summary>
        /// Creates a new service level agreement instance.
        /// </summary>
        /// <param name="id">The unique identifier of the service level agreement.</param>
        public ServiceLevelAgreement(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new service level agreement instance.
        /// </summary>
        /// <param name="customer">The customer of the service level agreement.</param>
        /// <param name="name">The name of the service level agreement.</param>
        /// <param name="serviceOffering">The service offering of the service level agreement.</param>
        public ServiceLevelAgreement(Organization customer, string name, ServiceOffering serviceOffering)
        {
            _customer = SetValue("customer", customer);
            _name = SetValue("name", name);
            _serviceOffering = SetValue("service_offering", serviceOffering);
        }

        private void OnCustomerRepresentativeChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<Person> collection)
                MarkCollectionChanged(collection, "customer_representative");
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }
    }
}
