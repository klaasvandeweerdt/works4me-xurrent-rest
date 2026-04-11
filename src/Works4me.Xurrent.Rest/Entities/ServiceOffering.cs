using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent service offering object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ServiceOffering : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ServiceOffering"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The availability field.
            /// </summary>
            [XurrentEnum("availability")]
            Availability,

            /// <summary>
            /// The charge type case field.
            /// </summary>
            [XurrentEnum("charge_type_case")]
            ChargeTypeCase,

            /// <summary>
            /// The charge type high field.
            /// </summary>
            [XurrentEnum("charge_type_high")]
            ChargeTypeHigh,

            /// <summary>
            /// The charge type low field.
            /// </summary>
            [XurrentEnum("charge_type_low")]
            ChargeTypeLow,

            /// <summary>
            /// The charge type medium field.
            /// </summary>
            [XurrentEnum("charge_type_medium")]
            ChargeTypeMedium,

            /// <summary>
            /// The charge type rfc field.
            /// </summary>
            [XurrentEnum("charge_type_rfc")]
            ChargeTypeRfc,

            /// <summary>
            /// The charge type rfi field.
            /// </summary>
            [XurrentEnum("charge_type_rfi")]
            ChargeTypeRfi,

            /// <summary>
            /// The charge type top field.
            /// </summary>
            [XurrentEnum("charge_type_top")]
            ChargeTypeTop,

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
            /// The continuity field.
            /// </summary>
            [XurrentEnum("continuity")]
            Continuity,

            /// <summary>
            /// The continuity attachments field.
            /// </summary>
            [XurrentEnum("continuity_attachments", IgnoreInFieldSelection = true)]
            ContinuityAttachments,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The default effort class field.
            /// </summary>
            [XurrentEnum("default_effort_class")]
            DefaultEffortClass,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The limitations field.
            /// </summary>
            [XurrentEnum("limitations")]
            Limitations,

            /// <summary>
            /// The limitations attachments field.
            /// </summary>
            [XurrentEnum("limitations_attachments", IgnoreInFieldSelection = true)]
            LimitationsAttachments,

            /// <summary>
            /// The maximum risk of data loss field.
            /// </summary>
            [XurrentEnum("maximum_risk_of_data_loss")]
            MaximumRiskOfDataLoss,

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
            /// The penalties field.
            /// </summary>
            [XurrentEnum("penalties")]
            Penalties,

            /// <summary>
            /// The penalties attachments field.
            /// </summary>
            [XurrentEnum("penalties_attachments", IgnoreInFieldSelection = true)]
            PenaltiesAttachments,

            /// <summary>
            /// The performance field.
            /// </summary>
            [XurrentEnum("performance")]
            Performance,

            /// <summary>
            /// The performance attachments field.
            /// </summary>
            [XurrentEnum("performance_attachments", IgnoreInFieldSelection = true)]
            PerformanceAttachments,

            /// <summary>
            /// The prerequisites field.
            /// </summary>
            [XurrentEnum("prerequisites")]
            Prerequisites,

            /// <summary>
            /// The prerequisites attachments field.
            /// </summary>
            [XurrentEnum("prerequisites_attachments", IgnoreInFieldSelection = true)]
            PrerequisitesAttachments,

            /// <summary>
            /// The rate case field.
            /// </summary>
            [XurrentEnum("rate_case")]
            RateCase,

            /// <summary>
            /// The rate case currency field.
            /// </summary>
            [XurrentEnum("rate_case_currency")]
            RateCaseCurrency,

            /// <summary>
            /// The rate high field.
            /// </summary>
            [XurrentEnum("rate_high")]
            RateHigh,

            /// <summary>
            /// The rate high currency field.
            /// </summary>
            [XurrentEnum("rate_high_currency")]
            RateHighCurrency,

            /// <summary>
            /// The rate low field.
            /// </summary>
            [XurrentEnum("rate_low")]
            RateLow,

            /// <summary>
            /// The rate low currency field.
            /// </summary>
            [XurrentEnum("rate_low_currency")]
            RateLowCurrency,

            /// <summary>
            /// The rate medium field.
            /// </summary>
            [XurrentEnum("rate_medium")]
            RateMedium,

            /// <summary>
            /// The rate medium currency field.
            /// </summary>
            [XurrentEnum("rate_medium_currency")]
            RateMediumCurrency,

            /// <summary>
            /// The rate rfc field.
            /// </summary>
            [XurrentEnum("rate_rfc")]
            RateRfc,

            /// <summary>
            /// The rate rfc currency field.
            /// </summary>
            [XurrentEnum("rate_rfc_currency")]
            RateRfcCurrency,

            /// <summary>
            /// The rate rfi field.
            /// </summary>
            [XurrentEnum("rate_rfi")]
            RateRfi,

            /// <summary>
            /// The rate rfi currency field.
            /// </summary>
            [XurrentEnum("rate_rfi_currency")]
            RateRfiCurrency,

            /// <summary>
            /// The rate top field.
            /// </summary>
            [XurrentEnum("rate_top")]
            RateTop,

            /// <summary>
            /// The rate top currency field.
            /// </summary>
            [XurrentEnum("rate_top_currency")]
            RateTopCurrency,

            /// <summary>
            /// The recovery point objective field.
            /// </summary>
            [XurrentEnum("recovery_point_objective")]
            RecoveryPointObjective,

            /// <summary>
            /// The recovery time objective field.
            /// </summary>
            [XurrentEnum("recovery_time_objective")]
            RecoveryTimeObjective,

            /// <summary>
            /// The reliability field.
            /// </summary>
            [XurrentEnum("reliability")]
            Reliability,

            /// <summary>
            /// The report frequency field.
            /// </summary>
            [XurrentEnum("report_frequency")]
            ReportFrequency,

            /// <summary>
            /// The resolution target case field.
            /// </summary>
            [XurrentEnum("resolution_target_case")]
            ResolutionTargetCase,

            /// <summary>
            /// The resolution target case in days field.
            /// </summary>
            [XurrentEnum("resolution_target_case_in_days")]
            ResolutionTargetCaseInDays,

            /// <summary>
            /// The resolution target high field.
            /// </summary>
            [XurrentEnum("resolution_target_high")]
            ResolutionTargetHigh,

            /// <summary>
            /// The resolution target high in days field.
            /// </summary>
            [XurrentEnum("resolution_target_high_in_days")]
            ResolutionTargetHighInDays,

            /// <summary>
            /// The resolution target low field.
            /// </summary>
            [XurrentEnum("resolution_target_low")]
            ResolutionTargetLow,

            /// <summary>
            /// The resolution target low in days field.
            /// </summary>
            [XurrentEnum("resolution_target_low_in_days")]
            ResolutionTargetLowInDays,

            /// <summary>
            /// The resolution target medium field.
            /// </summary>
            [XurrentEnum("resolution_target_medium")]
            ResolutionTargetMedium,

            /// <summary>
            /// The resolution target medium in days field.
            /// </summary>
            [XurrentEnum("resolution_target_medium_in_days")]
            ResolutionTargetMediumInDays,

            /// <summary>
            /// The resolution target notification scheme high field.
            /// </summary>
            [XurrentEnum("resolution_target_notification_scheme_high")]
            ResolutionTargetNotificationSchemeHigh,

            /// <summary>
            /// The resolution target notification scheme low field.
            /// </summary>
            [XurrentEnum("resolution_target_notification_scheme_low")]
            ResolutionTargetNotificationSchemeLow,

            /// <summary>
            /// The resolution target notification scheme medium field.
            /// </summary>
            [XurrentEnum("resolution_target_notification_scheme_medium")]
            ResolutionTargetNotificationSchemeMedium,

            /// <summary>
            /// The resolution target notification scheme top field.
            /// </summary>
            [XurrentEnum("resolution_target_notification_scheme_top")]
            ResolutionTargetNotificationSchemeTop,

            /// <summary>
            /// The resolution target rfc field.
            /// </summary>
            [XurrentEnum("resolution_target_rfc")]
            ResolutionTargetRfc,

            /// <summary>
            /// The resolution target rfc in days field.
            /// </summary>
            [XurrentEnum("resolution_target_rfc_in_days")]
            ResolutionTargetRfcInDays,

            /// <summary>
            /// The resolution target rfi field.
            /// </summary>
            [XurrentEnum("resolution_target_rfi")]
            ResolutionTargetRfi,

            /// <summary>
            /// The resolution target rfi in days field.
            /// </summary>
            [XurrentEnum("resolution_target_rfi_in_days")]
            ResolutionTargetRfiInDays,

            /// <summary>
            /// The resolution target top field.
            /// </summary>
            [XurrentEnum("resolution_target_top")]
            ResolutionTargetTop,

            /// <summary>
            /// The resolution target top in days field.
            /// </summary>
            [XurrentEnum("resolution_target_top_in_days")]
            ResolutionTargetTopInDays,

            /// <summary>
            /// The resolutions within target field.
            /// </summary>
            [XurrentEnum("resolutions_within_target")]
            ResolutionsWithinTarget,

            /// <summary>
            /// The response target case field.
            /// </summary>
            [XurrentEnum("response_target_case")]
            ResponseTargetCase,

            /// <summary>
            /// The response target case in days field.
            /// </summary>
            [XurrentEnum("response_target_case_in_days")]
            ResponseTargetCaseInDays,

            /// <summary>
            /// The response target high field.
            /// </summary>
            [XurrentEnum("response_target_high")]
            ResponseTargetHigh,

            /// <summary>
            /// The response target high in days field.
            /// </summary>
            [XurrentEnum("response_target_high_in_days")]
            ResponseTargetHighInDays,

            /// <summary>
            /// The response target low field.
            /// </summary>
            [XurrentEnum("response_target_low")]
            ResponseTargetLow,

            /// <summary>
            /// The response target low in days field.
            /// </summary>
            [XurrentEnum("response_target_low_in_days")]
            ResponseTargetLowInDays,

            /// <summary>
            /// The response target medium field.
            /// </summary>
            [XurrentEnum("response_target_medium")]
            ResponseTargetMedium,

            /// <summary>
            /// The response target medium in days field.
            /// </summary>
            [XurrentEnum("response_target_medium_in_days")]
            ResponseTargetMediumInDays,

            /// <summary>
            /// The response target notification scheme high field.
            /// </summary>
            [XurrentEnum("response_target_notification_scheme_high")]
            ResponseTargetNotificationSchemeHigh,

            /// <summary>
            /// The response target notification scheme low field.
            /// </summary>
            [XurrentEnum("response_target_notification_scheme_low")]
            ResponseTargetNotificationSchemeLow,

            /// <summary>
            /// The response target notification scheme medium field.
            /// </summary>
            [XurrentEnum("response_target_notification_scheme_medium")]
            ResponseTargetNotificationSchemeMedium,

            /// <summary>
            /// The response target notification scheme top field.
            /// </summary>
            [XurrentEnum("response_target_notification_scheme_top")]
            ResponseTargetNotificationSchemeTop,

            /// <summary>
            /// The response target rfc field.
            /// </summary>
            [XurrentEnum("response_target_rfc")]
            ResponseTargetRfc,

            /// <summary>
            /// The response target rfc in days field.
            /// </summary>
            [XurrentEnum("response_target_rfc_in_days")]
            ResponseTargetRfcInDays,

            /// <summary>
            /// The response target rfi field.
            /// </summary>
            [XurrentEnum("response_target_rfi")]
            ResponseTargetRfi,

            /// <summary>
            /// The response target rfi in days field.
            /// </summary>
            [XurrentEnum("response_target_rfi_in_days")]
            ResponseTargetRfiInDays,

            /// <summary>
            /// The response target top field.
            /// </summary>
            [XurrentEnum("response_target_top")]
            ResponseTargetTop,

            /// <summary>
            /// The response target top in days field.
            /// </summary>
            [XurrentEnum("response_target_top_in_days")]
            ResponseTargetTopInDays,

            /// <summary>
            /// The responses within target field.
            /// </summary>
            [XurrentEnum("responses_within_target")]
            ResponsesWithinTarget,

            /// <summary>
            /// The review frequency field.
            /// </summary>
            [XurrentEnum("review_frequency")]
            ReviewFrequency,

            /// <summary>
            /// The service field.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// The service hours field.
            /// </summary>
            [XurrentEnum("service_hours")]
            ServiceHours,

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
            /// The status field.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// The summary field.
            /// </summary>
            [XurrentEnum("summary")]
            Summary,

            /// <summary>
            /// The summary attachments field.
            /// </summary>
            [XurrentEnum("summary_attachments", IgnoreInFieldSelection = true)]
            SummaryAttachments,

            /// <summary>
            /// The support hours case field.
            /// </summary>
            [XurrentEnum("support_hours_case")]
            SupportHoursCase,

            /// <summary>
            /// The support hours high field.
            /// </summary>
            [XurrentEnum("support_hours_high")]
            SupportHoursHigh,

            /// <summary>
            /// The support hours low field.
            /// </summary>
            [XurrentEnum("support_hours_low")]
            SupportHoursLow,

            /// <summary>
            /// The support hours medium field.
            /// </summary>
            [XurrentEnum("support_hours_medium")]
            SupportHoursMedium,

            /// <summary>
            /// The support hours rfc field.
            /// </summary>
            [XurrentEnum("support_hours_rfc")]
            SupportHoursRfc,

            /// <summary>
            /// The support hours rfi field.
            /// </summary>
            [XurrentEnum("support_hours_rfi")]
            SupportHoursRfi,

            /// <summary>
            /// The support hours top field.
            /// </summary>
            [XurrentEnum("support_hours_top")]
            SupportHoursTop,

            /// <summary>
            /// The termination field.
            /// </summary>
            [XurrentEnum("termination")]
            Termination,

            /// <summary>
            /// The termination attachments field.
            /// </summary>
            [XurrentEnum("termination_attachments", IgnoreInFieldSelection = true)]
            TerminationAttachments,

            /// <summary>
            /// The time zone field.
            /// </summary>
            [XurrentEnum("time_zone")]
            TimeZone,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The waiting for customer follow up field.
            /// </summary>
            [XurrentEnum("waiting_for_customer_follow_up")]
            WaitingForCustomerFollowUp
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ServiceOffering"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters service offerings by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters service offerings by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters service offerings by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters service offerings by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Filters service offerings by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters service offerings by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters service offerings by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters service offerings by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ServiceOffering"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all catalog service offerings.
            /// </summary>
            [XurrentEnum("catalog")]
            Catalog,

            /// <summary>
            /// Lists all portfolio service offerings.
            /// </summary>
            [XurrentEnum("portfolio")]
            Portfolio
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ServiceOffering"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts service offerings by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts service offerings by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts service offerings by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts service offerings by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Sorts service offerings by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts service offerings by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts service offerings by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private decimal? _availability;
        private ServiceOfferingChargeType? _chargeTypeCase;
        private ServiceOfferingChargeType? _chargeTypeHigh;
        private ServiceOfferingChargeType? _chargeTypeLow;
        private ServiceOfferingChargeType? _chargeTypeMedium;
        private ServiceOfferingChargeType? _chargeTypeRfc;
        private ServiceOfferingChargeType? _chargeTypeRfi;
        private ServiceOfferingChargeType? _chargeTypeTop;
        private string? _charges;
        private ObservableCollection<AttachmentReference>? _chargesAttachments;
        private AttachmentReferenceWriter? _chargesAttachmentsWriter;
        private string? _continuity;
        private ObservableCollection<AttachmentReference>? _continuityAttachments;
        private AttachmentReferenceWriter? _continuityAttachmentsWriter;
        private DateTime? _createdAt;
        private EffortClass? _defaultEffortClass;
        private string? _limitations;
        private ObservableCollection<AttachmentReference>? _limitationsAttachments;
        private AttachmentReferenceWriter? _limitationsAttachmentsWriter;
        private string? _maximumRiskOfDataLoss;
        private string? _name;
        private string? _penalties;
        private ObservableCollection<AttachmentReference>? _penaltiesAttachments;
        private AttachmentReferenceWriter? _penaltiesAttachmentsWriter;
        private string? _performance;
        private ObservableCollection<AttachmentReference>? _performanceAttachments;
        private AttachmentReferenceWriter? _performanceAttachmentsWriter;
        private string? _prerequisites;
        private ObservableCollection<AttachmentReference>? _prerequisitesAttachments;
        private AttachmentReferenceWriter? _prerequisitesAttachmentsWriter;
        private decimal? _rateCase;
        private Currency? _rateCaseCurrency;
        private decimal? _rateHigh;
        private Currency? _rateHighCurrency;
        private decimal? _rateLow;
        private Currency? _rateLowCurrency;
        private decimal? _rateMedium;
        private Currency? _rateMediumCurrency;
        private decimal? _rateRfc;
        private Currency? _rateRfcCurrency;
        private decimal? _rateRfi;
        private Currency? _rateRfiCurrency;
        private decimal? _rateTop;
        private Currency? _rateTopCurrency;
        private int? _recoveryPointObjective;
        private int? _recoveryTimeObjective;
        private int? _reliability;
        private ServiceOfferingReportFrequency? _reportFrequency;
        private int? _resolutionTargetCase;
        private int? _resolutionTargetCaseInDays;
        private int? _resolutionTargetHigh;
        private int? _resolutionTargetHighInDays;
        private int? _resolutionTargetLow;
        private int? _resolutionTargetLowInDays;
        private int? _resolutionTargetMedium;
        private int? _resolutionTargetMediumInDays;
        private SlaNotificationScheme? _resolutionTargetNotificationSchemeHigh;
        private SlaNotificationScheme? _resolutionTargetNotificationSchemeLow;
        private SlaNotificationScheme? _resolutionTargetNotificationSchemeMedium;
        private SlaNotificationScheme? _resolutionTargetNotificationSchemeTop;
        private int? _resolutionTargetRfc;
        private int? _resolutionTargetRfcInDays;
        private int? _resolutionTargetRfi;
        private int? _resolutionTargetRfiInDays;
        private int? _resolutionTargetTop;
        private int? _resolutionTargetTopInDays;
        private int? _resolutionsWithinTarget;
        private int? _responseTargetCase;
        private int? _responseTargetCaseInDays;
        private int? _responseTargetHigh;
        private int? _responseTargetHighInDays;
        private int? _responseTargetLow;
        private int? _responseTargetLowInDays;
        private int? _responseTargetMedium;
        private int? _responseTargetMediumInDays;
        private SlaNotificationScheme? _responseTargetNotificationSchemeHigh;
        private SlaNotificationScheme? _responseTargetNotificationSchemeLow;
        private SlaNotificationScheme? _responseTargetNotificationSchemeMedium;
        private SlaNotificationScheme? _responseTargetNotificationSchemeTop;
        private int? _responseTargetRfc;
        private int? _responseTargetRfcInDays;
        private int? _responseTargetRfi;
        private int? _responseTargetRfiInDays;
        private int? _responseTargetTop;
        private int? _responseTargetTopInDays;
        private int? _responsesWithinTarget;
        private ServiceOfferingReviewFrequency? _reviewFrequency;
        private Service? _service;
        private Calendar? _serviceHours;
        private string? _source;
        private string? _sourceID;
        private ServiceInstanceStatus? _status;
        private string? _summary;
        private ObservableCollection<AttachmentReference>? _summaryAttachments;
        private AttachmentReferenceWriter? _summaryAttachmentsWriter;
        private Calendar? _supportHoursCase;
        private Calendar? _supportHoursHigh;
        private Calendar? _supportHoursLow;
        private Calendar? _supportHoursMedium;
        private Calendar? _supportHoursRfc;
        private Calendar? _supportHoursRfi;
        private Calendar? _supportHoursTop;
        private string? _termination;
        private ObservableCollection<AttachmentReference>? _terminationAttachments;
        private AttachmentReferenceWriter? _terminationAttachmentsWriter;
        private string? _timeZone;
        private DateTime? _updatedAt;
        private WaitingForCustomerFollowUp? _waitingForCustomerFollowUp;

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
        /// Gets or sets the availability expressed as a percentage of the total number of service hours.
        /// </summary>
        [XurrentField("availability")]
        public decimal? Availability
        {
            get => _availability;
            set => _availability = SetValue("availability", _availability, value);
        }

        /// <summary>
        /// Gets or sets how a case must be charged.
        /// </summary>
        [XurrentField("charge_type_case")]
        public ServiceOfferingChargeType? ChargeTypeCase
        {
            get => _chargeTypeCase;
            set => _chargeTypeCase = SetValue("charge_type_case", _chargeTypeCase, value);
        }

        /// <summary>
        /// Gets or sets how a high incident must be charged.
        /// </summary>
        [XurrentField("charge_type_high")]
        public ServiceOfferingChargeType? ChargeTypeHigh
        {
            get => _chargeTypeHigh;
            set => _chargeTypeHigh = SetValue("charge_type_high", _chargeTypeHigh, value);
        }

        /// <summary>
        /// Gets or sets how a low incident must be charged.
        /// </summary>
        [XurrentField("charge_type_low")]
        public ServiceOfferingChargeType? ChargeTypeLow
        {
            get => _chargeTypeLow;
            set => _chargeTypeLow = SetValue("charge_type_low", _chargeTypeLow, value);
        }

        /// <summary>
        /// Gets or sets how a medium incident must be charged.
        /// </summary>
        [XurrentField("charge_type_medium")]
        public ServiceOfferingChargeType? ChargeTypeMedium
        {
            get => _chargeTypeMedium;
            set => _chargeTypeMedium = SetValue("charge_type_medium", _chargeTypeMedium, value);
        }

        /// <summary>
        /// Gets or sets how an RFC must be charged.
        /// </summary>
        [XurrentField("charge_type_rfc")]
        public ServiceOfferingChargeType? ChargeTypeRfc
        {
            get => _chargeTypeRfc;
            set => _chargeTypeRfc = SetValue("charge_type_rfc", _chargeTypeRfc, value);
        }

        /// <summary>
        /// Gets or sets how an RFI must be charged.
        /// </summary>
        [XurrentField("charge_type_rfi")]
        public ServiceOfferingChargeType? ChargeTypeRfi
        {
            get => _chargeTypeRfi;
            set => _chargeTypeRfi = SetValue("charge_type_rfi", _chargeTypeRfi, value);
        }

        /// <summary>
        /// Gets or sets how a top incident must be charged.
        /// </summary>
        [XurrentField("charge_type_top")]
        public ServiceOfferingChargeType? ChargeTypeTop
        {
            get => _chargeTypeTop;
            set => _chargeTypeTop = SetValue("charge_type_top", _chargeTypeTop, value);
        }

        /// <summary>
        /// Gets or sets the charges for the service offering.
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
        /// Gets or sets the continuity information of the service offering.
        /// </summary>
        [XurrentField("continuity")]
        public string? Continuity
        {
            get => _continuity;
            set => _continuity = SetValue("continuity", _continuity, value);
        }

        [XurrentField("continuity_attachments")]
        internal ObservableCollection<AttachmentReference> ContinuityAttachmentsCollection
        {
            get => GetCollection(ref _continuityAttachments, OnContinuityAttachmentsChanged);
            set => SetCollection(ref _continuityAttachments, "continuity_attachments", value, OnContinuityAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the continuity field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter ContinuityAttachments
        {
            get
            {
                _continuityAttachmentsWriter ??= new AttachmentReferenceWriter(() => ContinuityAttachmentsCollection, c => ContinuityAttachmentsCollection = c);
                return _continuityAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the date and time when the service offering was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the default effort class.
        /// </summary>
        [XurrentField("default_effort_class")]
        public EffortClass? DefaultEffortClass
        {
            get => _defaultEffortClass;
            set => _defaultEffortClass = SetValue("default_effort_class", _defaultEffortClass, value);
        }

        /// <summary>
        /// Gets or sets the limitations that apply to the service level agreements.
        /// </summary>
        [XurrentField("limitations")]
        public string? Limitations
        {
            get => _limitations;
            set => _limitations = SetValue("limitations", _limitations, value);
        }

        [XurrentField("limitations_attachments")]
        internal ObservableCollection<AttachmentReference> LimitationsAttachmentsCollection
        {
            get => GetCollection(ref _limitationsAttachments, OnLimitationsAttachmentsChanged);
            set => SetCollection(ref _limitationsAttachments, "limitations_attachments", value, OnLimitationsAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the limitations field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter LimitationsAttachments
        {
            get
            {
                _limitationsAttachmentsWriter ??= new AttachmentReferenceWriter(() => LimitationsAttachmentsCollection, c => LimitationsAttachmentsCollection = c);
                return _limitationsAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of hours of data loss.
        /// </summary>
        [XurrentField("maximum_risk_of_data_loss")]
        public string? MaximumRiskOfDataLoss
        {
            get => _maximumRiskOfDataLoss;
            set => _maximumRiskOfDataLoss = SetValue("maximum_risk_of_data_loss", _maximumRiskOfDataLoss, value);
        }

        /// <summary>
        /// Gets or sets the name of the service offering.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the penalties for breached service level targets.
        /// </summary>
        [XurrentField("penalties")]
        public string? Penalties
        {
            get => _penalties;
            set => _penalties = SetValue("penalties", _penalties, value);
        }

        [XurrentField("penalties_attachments")]
        internal ObservableCollection<AttachmentReference> PenaltiesAttachmentsCollection
        {
            get => GetCollection(ref _penaltiesAttachments, OnPenaltiesAttachmentsChanged);
            set => SetCollection(ref _penaltiesAttachments, "penalties_attachments", value, OnPenaltiesAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the penalties field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter PenaltiesAttachments
        {
            get
            {
                _penaltiesAttachmentsWriter ??= new AttachmentReferenceWriter(() => PenaltiesAttachmentsCollection, c => PenaltiesAttachmentsCollection = c);
                return _penaltiesAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the performance description of the service offering.
        /// </summary>
        [XurrentField("performance")]
        public string? Performance
        {
            get => _performance;
            set => _performance = SetValue("performance", _performance, value);
        }

        [XurrentField("performance_attachments")]
        internal ObservableCollection<AttachmentReference> PerformanceAttachmentsCollection
        {
            get => GetCollection(ref _performanceAttachments, OnPerformanceAttachmentsChanged);
            set => SetCollection(ref _performanceAttachments, "performance_attachments", value, OnPerformanceAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the performance field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter PerformanceAttachments
        {
            get
            {
                _performanceAttachmentsWriter ??= new AttachmentReferenceWriter(() => PerformanceAttachmentsCollection, c => PerformanceAttachmentsCollection = c);
                return _performanceAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the prerequisites required to benefit from the service.
        /// </summary>
        [XurrentField("prerequisites")]
        public string? Prerequisites
        {
            get => _prerequisites;
            set => _prerequisites = SetValue("prerequisites", _prerequisites, value);
        }

        [XurrentField("prerequisites_attachments")]
        internal ObservableCollection<AttachmentReference> PrerequisitesAttachmentsCollection
        {
            get => GetCollection(ref _prerequisitesAttachments, OnPrerequisitesAttachmentsChanged);
            set => SetCollection(ref _prerequisitesAttachments, "prerequisites_attachments", value, OnPrerequisitesAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the prerequisites field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter PrerequisitesAttachments
        {
            get
            {
                _prerequisitesAttachmentsWriter ??= new AttachmentReferenceWriter(() => PrerequisitesAttachmentsCollection, c => PrerequisitesAttachmentsCollection = c);
                return _prerequisitesAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the fixed price rate for a case.
        /// </summary>
        [XurrentField("rate_case")]
        public decimal? RateCase
        {
            get => _rateCase;
            set => _rateCase = SetValue("rate_case", _rateCase, value);
        }

        /// <summary>
        /// Gets or sets the currency for the case rate.
        /// </summary>
        [XurrentField("rate_case_currency")]
        public Currency? RateCaseCurrency
        {
            get => _rateCaseCurrency;
            set => _rateCaseCurrency = SetValue("rate_case_currency", _rateCaseCurrency, value);
        }

        /// <summary>
        /// Gets or sets the fixed price rate for a high incident.
        /// </summary>
        [XurrentField("rate_high")]
        public decimal? RateHigh
        {
            get => _rateHigh;
            set => _rateHigh = SetValue("rate_high", _rateHigh, value);
        }

        /// <summary>
        /// Gets or sets the currency for the high incident rate.
        /// </summary>
        [XurrentField("rate_high_currency")]
        public Currency? RateHighCurrency
        {
            get => _rateHighCurrency;
            set => _rateHighCurrency = SetValue("rate_high_currency", _rateHighCurrency, value);
        }

        /// <summary>
        /// Gets or sets the fixed price rate for a low incident.
        /// </summary>
        [XurrentField("rate_low")]
        public decimal? RateLow
        {
            get => _rateLow;
            set => _rateLow = SetValue("rate_low", _rateLow, value);
        }

        /// <summary>
        /// Gets or sets the currency for the low incident rate.
        /// </summary>
        [XurrentField("rate_low_currency")]
        public Currency? RateLowCurrency
        {
            get => _rateLowCurrency;
            set => _rateLowCurrency = SetValue("rate_low_currency", _rateLowCurrency, value);
        }

        /// <summary>
        /// Gets or sets the fixed price rate for a medium incident.
        /// </summary>
        [XurrentField("rate_medium")]
        public decimal? RateMedium
        {
            get => _rateMedium;
            set => _rateMedium = SetValue("rate_medium", _rateMedium, value);
        }

        /// <summary>
        /// Gets or sets the currency for the medium incident rate.
        /// </summary>
        [XurrentField("rate_medium_currency")]
        public Currency? RateMediumCurrency
        {
            get => _rateMediumCurrency;
            set => _rateMediumCurrency = SetValue("rate_medium_currency", _rateMediumCurrency, value);
        }

        /// <summary>
        /// Gets or sets the fixed price rate for an RFC.
        /// </summary>
        [XurrentField("rate_rfc")]
        public decimal? RateRfc
        {
            get => _rateRfc;
            set => _rateRfc = SetValue("rate_rfc", _rateRfc, value);
        }

        /// <summary>
        /// Gets or sets the currency for the RFC rate.
        /// </summary>
        [XurrentField("rate_rfc_currency")]
        public Currency? RateRfcCurrency
        {
            get => _rateRfcCurrency;
            set => _rateRfcCurrency = SetValue("rate_rfc_currency", _rateRfcCurrency, value);
        }

        /// <summary>
        /// Gets or sets the fixed price rate for an RFI.
        /// </summary>
        [XurrentField("rate_rfi")]
        public decimal? RateRfi
        {
            get => _rateRfi;
            set => _rateRfi = SetValue("rate_rfi", _rateRfi, value);
        }

        /// <summary>
        /// Gets or sets the currency for the RFI rate.
        /// </summary>
        [XurrentField("rate_rfi_currency")]
        public Currency? RateRfiCurrency
        {
            get => _rateRfiCurrency;
            set => _rateRfiCurrency = SetValue("rate_rfi_currency", _rateRfiCurrency, value);
        }

        /// <summary>
        /// Gets or sets the fixed price rate for a top incident.
        /// </summary>
        [XurrentField("rate_top")]
        public decimal? RateTop
        {
            get => _rateTop;
            set => _rateTop = SetValue("rate_top", _rateTop, value);
        }

        /// <summary>
        /// Gets or sets the currency for the top incident rate.
        /// </summary>
        [XurrentField("rate_top_currency")]
        public Currency? RateTopCurrency
        {
            get => _rateTopCurrency;
            set => _rateTopCurrency = SetValue("rate_top_currency", _rateTopCurrency, value);
        }

        /// <summary>
        /// Gets or sets the recovery point objective.
        /// </summary>
        [XurrentField("recovery_point_objective")]
        public int? RecoveryPointObjective
        {
            get => _recoveryPointObjective;
            set => _recoveryPointObjective = SetValue("recovery_point_objective", _recoveryPointObjective, value);
        }

        /// <summary>
        /// Gets or sets the recovery time objective.
        /// </summary>
        [XurrentField("recovery_time_objective")]
        public int? RecoveryTimeObjective
        {
            get => _recoveryTimeObjective;
            set => _recoveryTimeObjective = SetValue("recovery_time_objective", _recoveryTimeObjective, value);
        }

        /// <summary>
        /// Gets or sets the maximum number of service interruptions per month.
        /// </summary>
        [XurrentField("reliability")]
        public int? Reliability
        {
            get => _reliability;
            set => _reliability = SetValue("reliability", _reliability, value);
        }

        /// <summary>
        /// Gets or sets the report frequency.
        /// </summary>
        [XurrentField("report_frequency")]
        public ServiceOfferingReportFrequency? ReportFrequency
        {
            get => _reportFrequency;
            set => _reportFrequency = SetValue("report_frequency", _reportFrequency, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a case expressed in minutes.
        /// </summary>
        [XurrentField("resolution_target_case")]
        public int? ResolutionTargetCase
        {
            get => _resolutionTargetCase;
            set => _resolutionTargetCase = SetValue("resolution_target_case", _resolutionTargetCase, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a case expressed in business days.
        /// </summary>
        [XurrentField("resolution_target_case_in_days")]
        public int? ResolutionTargetCaseInDays
        {
            get => _resolutionTargetCaseInDays;
            set => _resolutionTargetCaseInDays = SetValue("resolution_target_case_in_days", _resolutionTargetCaseInDays, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a high impact incident expressed in minutes.
        /// </summary>
        [XurrentField("resolution_target_high")]
        public int? ResolutionTargetHigh
        {
            get => _resolutionTargetHigh;
            set => _resolutionTargetHigh = SetValue("resolution_target_high", _resolutionTargetHigh, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a high impact incident expressed in business days.
        /// </summary>
        [XurrentField("resolution_target_high_in_days")]
        public int? ResolutionTargetHighInDays
        {
            get => _resolutionTargetHighInDays;
            set => _resolutionTargetHighInDays = SetValue("resolution_target_high_in_days", _resolutionTargetHighInDays, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a low impact incident expressed in minutes.
        /// </summary>
        [XurrentField("resolution_target_low")]
        public int? ResolutionTargetLow
        {
            get => _resolutionTargetLow;
            set => _resolutionTargetLow = SetValue("resolution_target_low", _resolutionTargetLow, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a low impact incident expressed in business days.
        /// </summary>
        [XurrentField("resolution_target_low_in_days")]
        public int? ResolutionTargetLowInDays
        {
            get => _resolutionTargetLowInDays;
            set => _resolutionTargetLowInDays = SetValue("resolution_target_low_in_days", _resolutionTargetLowInDays, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a medium impact incident expressed in minutes.
        /// </summary>
        [XurrentField("resolution_target_medium")]
        public int? ResolutionTargetMedium
        {
            get => _resolutionTargetMedium;
            set => _resolutionTargetMedium = SetValue("resolution_target_medium", _resolutionTargetMedium, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a medium impact incident expressed in business days.
        /// </summary>
        [XurrentField("resolution_target_medium_in_days")]
        public int? ResolutionTargetMediumInDays
        {
            get => _resolutionTargetMediumInDays;
            set => _resolutionTargetMediumInDays = SetValue("resolution_target_medium_in_days", _resolutionTargetMediumInDays, value);
        }

        /// <summary>
        /// Gets or sets the resolution target notification scheme for high impact incidents.
        /// </summary>
        [XurrentField("resolution_target_notification_scheme_high")]
        public SlaNotificationScheme? ResolutionTargetNotificationSchemeHigh
        {
            get => _resolutionTargetNotificationSchemeHigh;
            set => _resolutionTargetNotificationSchemeHigh = SetValue("resolution_target_notification_scheme_high", _resolutionTargetNotificationSchemeHigh, value);
        }

        /// <summary>
        /// Gets or sets the resolution target notification scheme for low impact incidents.
        /// </summary>
        [XurrentField("resolution_target_notification_scheme_low")]
        public SlaNotificationScheme? ResolutionTargetNotificationSchemeLow
        {
            get => _resolutionTargetNotificationSchemeLow;
            set => _resolutionTargetNotificationSchemeLow = SetValue("resolution_target_notification_scheme_low", _resolutionTargetNotificationSchemeLow, value);
        }

        /// <summary>
        /// Gets or sets the resolution target notification scheme for medium impact incidents.
        /// </summary>
        [XurrentField("resolution_target_notification_scheme_medium")]
        public SlaNotificationScheme? ResolutionTargetNotificationSchemeMedium
        {
            get => _resolutionTargetNotificationSchemeMedium;
            set => _resolutionTargetNotificationSchemeMedium = SetValue("resolution_target_notification_scheme_medium", _resolutionTargetNotificationSchemeMedium, value);
        }

        /// <summary>
        /// Gets or sets the resolution target notification scheme for top impact incidents.
        /// </summary>
        [XurrentField("resolution_target_notification_scheme_top")]
        public SlaNotificationScheme? ResolutionTargetNotificationSchemeTop
        {
            get => _resolutionTargetNotificationSchemeTop;
            set => _resolutionTargetNotificationSchemeTop = SetValue("resolution_target_notification_scheme_top", _resolutionTargetNotificationSchemeTop, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for an RFC expressed in minutes.
        /// </summary>
        [XurrentField("resolution_target_rfc")]
        public int? ResolutionTargetRfc
        {
            get => _resolutionTargetRfc;
            set => _resolutionTargetRfc = SetValue("resolution_target_rfc", _resolutionTargetRfc, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for an RFC expressed in business days.
        /// </summary>
        [XurrentField("resolution_target_rfc_in_days")]
        public int? ResolutionTargetRfcInDays
        {
            get => _resolutionTargetRfcInDays;
            set => _resolutionTargetRfcInDays = SetValue("resolution_target_rfc_in_days", _resolutionTargetRfcInDays, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for an RFI expressed in minutes.
        /// </summary>
        [XurrentField("resolution_target_rfi")]
        public int? ResolutionTargetRfi
        {
            get => _resolutionTargetRfi;
            set => _resolutionTargetRfi = SetValue("resolution_target_rfi", _resolutionTargetRfi, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for an RFI expressed in business days.
        /// </summary>
        [XurrentField("resolution_target_rfi_in_days")]
        public int? ResolutionTargetRfiInDays
        {
            get => _resolutionTargetRfiInDays;
            set => _resolutionTargetRfiInDays = SetValue("resolution_target_rfi_in_days", _resolutionTargetRfiInDays, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a top impact incident expressed in minutes.
        /// </summary>
        [XurrentField("resolution_target_top")]
        public int? ResolutionTargetTop
        {
            get => _resolutionTargetTop;
            set => _resolutionTargetTop = SetValue("resolution_target_top", _resolutionTargetTop, value);
        }

        /// <summary>
        /// Gets or sets the resolution target for a top impact incident expressed in business days.
        /// </summary>
        [XurrentField("resolution_target_top_in_days")]
        public int? ResolutionTargetTopInDays
        {
            get => _resolutionTargetTopInDays;
            set => _resolutionTargetTopInDays = SetValue("resolution_target_top_in_days", _resolutionTargetTopInDays, value);
        }

        /// <summary>
        /// Gets or sets the minimum percentage of resolutions within target.
        /// </summary>
        [XurrentField("resolutions_within_target")]
        public int? ResolutionsWithinTarget
        {
            get => _resolutionsWithinTarget;
            set => _resolutionsWithinTarget = SetValue("resolutions_within_target", _resolutionsWithinTarget, value);
        }

        /// <summary>
        /// Gets or sets the response target for a case expressed in minutes.
        /// </summary>
        [XurrentField("response_target_case")]
        public int? ResponseTargetCase
        {
            get => _responseTargetCase;
            set => _responseTargetCase = SetValue("response_target_case", _responseTargetCase, value);
        }

        /// <summary>
        /// Gets or sets the response target for a case expressed in business days.
        /// </summary>
        [XurrentField("response_target_case_in_days")]
        public int? ResponseTargetCaseInDays
        {
            get => _responseTargetCaseInDays;
            set => _responseTargetCaseInDays = SetValue("response_target_case_in_days", _responseTargetCaseInDays, value);
        }

        /// <summary>
        /// Gets or sets the response target for a high impact incident expressed in minutes.
        /// </summary>
        [XurrentField("response_target_high")]
        public int? ResponseTargetHigh
        {
            get => _responseTargetHigh;
            set => _responseTargetHigh = SetValue("response_target_high", _responseTargetHigh, value);
        }

        /// <summary>
        /// Gets or sets the response target for a high impact incident expressed in business days.
        /// </summary>
        [XurrentField("response_target_high_in_days")]
        public int? ResponseTargetHighInDays
        {
            get => _responseTargetHighInDays;
            set => _responseTargetHighInDays = SetValue("response_target_high_in_days", _responseTargetHighInDays, value);
        }

        /// <summary>
        /// Gets or sets the response target for a low impact incident expressed in minutes.
        /// </summary>
        [XurrentField("response_target_low")]
        public int? ResponseTargetLow
        {
            get => _responseTargetLow;
            set => _responseTargetLow = SetValue("response_target_low", _responseTargetLow, value);
        }

        /// <summary>
        /// Gets or sets the response target for a low impact incident expressed in business days.
        /// </summary>
        [XurrentField("response_target_low_in_days")]
        public int? ResponseTargetLowInDays
        {
            get => _responseTargetLowInDays;
            set => _responseTargetLowInDays = SetValue("response_target_low_in_days", _responseTargetLowInDays, value);
        }

        /// <summary>
        /// Gets or sets the response target for a medium impact incident expressed in minutes.
        /// </summary>
        [XurrentField("response_target_medium")]
        public int? ResponseTargetMedium
        {
            get => _responseTargetMedium;
            set => _responseTargetMedium = SetValue("response_target_medium", _responseTargetMedium, value);
        }

        /// <summary>
        /// Gets or sets the response target for a medium impact incident expressed in business days.
        /// </summary>
        [XurrentField("response_target_medium_in_days")]
        public int? ResponseTargetMediumInDays
        {
            get => _responseTargetMediumInDays;
            set => _responseTargetMediumInDays = SetValue("response_target_medium_in_days", _responseTargetMediumInDays, value);
        }

        /// <summary>
        /// Gets or sets the response target notification scheme for high impact incidents.
        /// </summary>
        [XurrentField("response_target_notification_scheme_high")]
        public SlaNotificationScheme? ResponseTargetNotificationSchemeHigh
        {
            get => _responseTargetNotificationSchemeHigh;
            set => _responseTargetNotificationSchemeHigh = SetValue("response_target_notification_scheme_high", _responseTargetNotificationSchemeHigh, value);
        }

        /// <summary>
        /// Gets or sets the response target notification scheme for low impact incidents.
        /// </summary>
        [XurrentField("response_target_notification_scheme_low")]
        public SlaNotificationScheme? ResponseTargetNotificationSchemeLow
        {
            get => _responseTargetNotificationSchemeLow;
            set => _responseTargetNotificationSchemeLow = SetValue("response_target_notification_scheme_low", _responseTargetNotificationSchemeLow, value);
        }

        /// <summary>
        /// Gets or sets the response target notification scheme for medium impact incidents.
        /// </summary>
        [XurrentField("response_target_notification_scheme_medium")]
        public SlaNotificationScheme? ResponseTargetNotificationSchemeMedium
        {
            get => _responseTargetNotificationSchemeMedium;
            set => _responseTargetNotificationSchemeMedium = SetValue("response_target_notification_scheme_medium", _responseTargetNotificationSchemeMedium, value);
        }

        /// <summary>
        /// Gets or sets the response target notification scheme for top impact incidents.
        /// </summary>
        [XurrentField("response_target_notification_scheme_top")]
        public SlaNotificationScheme? ResponseTargetNotificationSchemeTop
        {
            get => _responseTargetNotificationSchemeTop;
            set => _responseTargetNotificationSchemeTop = SetValue("response_target_notification_scheme_top", _responseTargetNotificationSchemeTop, value);
        }

        /// <summary>
        /// Gets or sets the response target for an RFC expressed in minutes.
        /// </summary>
        [XurrentField("response_target_rfc")]
        public int? ResponseTargetRfc
        {
            get => _responseTargetRfc;
            set => _responseTargetRfc = SetValue("response_target_rfc", _responseTargetRfc, value);
        }

        /// <summary>
        /// Gets or sets the response target for an RFC expressed in business days.
        /// </summary>
        [XurrentField("response_target_rfc_in_days")]
        public int? ResponseTargetRfcInDays
        {
            get => _responseTargetRfcInDays;
            set => _responseTargetRfcInDays = SetValue("response_target_rfc_in_days", _responseTargetRfcInDays, value);
        }

        /// <summary>
        /// Gets or sets the response target for an RFI expressed in minutes.
        /// </summary>
        [XurrentField("response_target_rfi")]
        public int? ResponseTargetRfi
        {
            get => _responseTargetRfi;
            set => _responseTargetRfi = SetValue("response_target_rfi", _responseTargetRfi, value);
        }

        /// <summary>
        /// Gets or sets the response target for an RFI expressed in business days.
        /// </summary>
        [XurrentField("response_target_rfi_in_days")]
        public int? ResponseTargetRfiInDays
        {
            get => _responseTargetRfiInDays;
            set => _responseTargetRfiInDays = SetValue("response_target_rfi_in_days", _responseTargetRfiInDays, value);
        }

        /// <summary>
        /// Gets or sets the response target for a top impact incident expressed in minutes.
        /// </summary>
        [XurrentField("response_target_top")]
        public int? ResponseTargetTop
        {
            get => _responseTargetTop;
            set => _responseTargetTop = SetValue("response_target_top", _responseTargetTop, value);
        }

        /// <summary>
        /// Gets or sets the response target for a top impact incident expressed in business days.
        /// </summary>
        [XurrentField("response_target_top_in_days")]
        public int? ResponseTargetTopInDays
        {
            get => _responseTargetTopInDays;
            set => _responseTargetTopInDays = SetValue("response_target_top_in_days", _responseTargetTopInDays, value);
        }

        /// <summary>
        /// Gets or sets the minimum percentage of responses within target.
        /// </summary>
        [XurrentField("responses_within_target")]
        public int? ResponsesWithinTarget
        {
            get => _responsesWithinTarget;
            set => _responsesWithinTarget = SetValue("responses_within_target", _responsesWithinTarget, value);
        }

        /// <summary>
        /// Gets or sets the review frequency.
        /// </summary>
        [XurrentField("review_frequency")]
        public ServiceOfferingReviewFrequency? ReviewFrequency
        {
            get => _reviewFrequency;
            set => _reviewFrequency = SetValue("review_frequency", _reviewFrequency, value);
        }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the service hours.
        /// </summary>
        [XurrentField("service_hours")]
        public Calendar? ServiceHours
        {
            get => _serviceHours;
            set => _serviceHours = SetValue("service_hours", _serviceHours, value);
        }

        /// <summary>
        /// Gets or sets the source of the service offering.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the service offering.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the status of the service offering.
        /// </summary>
        [XurrentField("status")]
        public ServiceInstanceStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the summary of the service offering.
        /// </summary>
        [XurrentField("summary")]
        public string? Summary
        {
            get => _summary;
            set => _summary = SetValue("summary", _summary, value);
        }

        [XurrentField("summary_attachments")]
        internal ObservableCollection<AttachmentReference> SummaryAttachmentsCollection
        {
            get => GetCollection(ref _summaryAttachments, OnSummaryAttachmentsChanged);
            set => SetCollection(ref _summaryAttachments, "summary_attachments", value, OnSummaryAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the summary field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter SummaryAttachments
        {
            get
            {
                _summaryAttachmentsWriter ??= new AttachmentReferenceWriter(() => SummaryAttachmentsCollection, c => SummaryAttachmentsCollection = c);
                return _summaryAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the calendar that defines the support hours for cases.
        /// </summary>
        [XurrentField("support_hours_case")]
        public Calendar? SupportHoursCase
        {
            get => _supportHoursCase;
            set => _supportHoursCase = SetValue("support_hours_case", _supportHoursCase, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the support hours for high impact incidents.
        /// </summary>
        [XurrentField("support_hours_high")]
        public Calendar? SupportHoursHigh
        {
            get => _supportHoursHigh;
            set => _supportHoursHigh = SetValue("support_hours_high", _supportHoursHigh, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the support hours for low impact incidents.
        /// </summary>
        [XurrentField("support_hours_low")]
        public Calendar? SupportHoursLow
        {
            get => _supportHoursLow;
            set => _supportHoursLow = SetValue("support_hours_low", _supportHoursLow, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the support hours for medium impact incidents.
        /// </summary>
        [XurrentField("support_hours_medium")]
        public Calendar? SupportHoursMedium
        {
            get => _supportHoursMedium;
            set => _supportHoursMedium = SetValue("support_hours_medium", _supportHoursMedium, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the support hours for RFC requests.
        /// </summary>
        [XurrentField("support_hours_rfc")]
        public Calendar? SupportHoursRfc
        {
            get => _supportHoursRfc;
            set => _supportHoursRfc = SetValue("support_hours_rfc", _supportHoursRfc, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the support hours for RFI requests.
        /// </summary>
        [XurrentField("support_hours_rfi")]
        public Calendar? SupportHoursRfi
        {
            get => _supportHoursRfi;
            set => _supportHoursRfi = SetValue("support_hours_rfi", _supportHoursRfi, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the support hours for top impact incidents.
        /// </summary>
        [XurrentField("support_hours_top")]
        public Calendar? SupportHoursTop
        {
            get => _supportHoursTop;
            set => _supportHoursTop = SetValue("support_hours_top", _supportHoursTop, value);
        }

        /// <summary>
        /// Gets or sets the termination conditions.
        /// </summary>
        [XurrentField("termination")]
        public string? Termination
        {
            get => _termination;
            set => _termination = SetValue("termination", _termination, value);
        }

        [XurrentField("termination_attachments")]
        internal ObservableCollection<AttachmentReference> TerminationAttachmentsCollection
        {
            get => GetCollection(ref _terminationAttachments, OnTerminationAttachmentsChanged);
            set => SetCollection(ref _terminationAttachments, "termination_attachments", value, OnTerminationAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used for the termination field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter TerminationAttachments
        {
            get
            {
                _terminationAttachmentsWriter ??= new AttachmentReferenceWriter(() => TerminationAttachmentsCollection, c => TerminationAttachmentsCollection = c);
                return _terminationAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the service offering.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the date and time when the service offering was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the waiting for customer follow-up configuration.
        /// </summary>
        [XurrentField("waiting_for_customer_follow_up")]
        public WaitingForCustomerFollowUp? WaitingForCustomerFollowUp
        {
            get => _waitingForCustomerFollowUp;
            set => _waitingForCustomerFollowUp = SetValue("waiting_for_customer_follow_up", _waitingForCustomerFollowUp, value);
        }

        /// <summary>
        /// Creates a new service offering instance.
        /// </summary>
        public ServiceOffering()
        {
        }

        /// <summary>
        /// Creates a new service offering instance.
        /// </summary>
        /// <param name="id">The unique identifier of the service offering.</param>
        public ServiceOffering(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new service offering instance.
        /// </summary>
        /// <param name="name">The name of the service offering.</param>
        /// <param name="service">The service of the service offering.</param>
        public ServiceOffering(string name, Service service)
        {
            _name = SetValue("name", name);
            _service = SetValue("service", service);
        }

        private void OnChargesAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "charges_attachments");
        }

        private void OnContinuityAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "continuity_attachments");
        }

        private void OnLimitationsAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "limitations_attachments");
        }

        private void OnPenaltiesAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "penalties_attachments");
        }

        private void OnPerformanceAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "performance_attachments");
        }

        private void OnPrerequisitesAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "prerequisites_attachments");
        }

        private void OnSummaryAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "summary_attachments");
        }

        private void OnTerminationAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "termination_attachments");
        }
    }
}
