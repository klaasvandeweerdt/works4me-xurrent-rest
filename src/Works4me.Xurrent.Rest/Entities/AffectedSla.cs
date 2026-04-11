using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent affected service level agreement object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AffectedSla : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AffectedSla"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The accountability field.
            /// </summary>
            [XurrentEnum("accountability")]
            Accountability,

            /// <summary>
            /// The actual resolution at field.
            /// </summary>
            [XurrentEnum("actual_resolution_at")]
            ActualResolutionAt,

            /// <summary>
            /// The actual resolution duration field.
            /// </summary>
            [XurrentEnum("actual_resolution_duration")]
            ActualResolutionDuration,

            /// <summary>
            /// The actual response at field.
            /// </summary>
            [XurrentEnum("actual_response_at")]
            ActualResponseAt,

            /// <summary>
            /// The actual response duration field.
            /// </summary>
            [XurrentEnum("actual_response_duration")]
            ActualResponseDuration,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The desired completion at field.
            /// </summary>
            [XurrentEnum("desired_completion_at")]
            DesiredCompletionAt,

            /// <summary>
            /// The downtime duration field.
            /// </summary>
            [XurrentEnum("downtime_duration")]
            DowntimeDuration,

            /// <summary>
            /// The downtime end at field.
            /// </summary>
            [XurrentEnum("downtime_end_at")]
            DowntimeEndAt,

            /// <summary>
            /// The downtime start at field.
            /// </summary>
            [XurrentEnum("downtime_start_at")]
            DowntimeStartAt,

            /// <summary>
            /// The first line team field.
            /// </summary>
            [XurrentEnum("first_line_team")]
            FirstLineTeam,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The impact field.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// The maximum resolution duration field.
            /// </summary>
            [XurrentEnum("maximum_resolution_duration")]
            MaximumResolutionDuration,

            /// <summary>
            /// The maximum resolution duration in days field.
            /// </summary>
            [XurrentEnum("maximum_resolution_duration_in_days")]
            MaximumResolutionDurationInDays,

            /// <summary>
            /// The maximum response duration field.
            /// </summary>
            [XurrentEnum("maximum_response_duration")]
            MaximumResponseDuration,

            /// <summary>
            /// The maximum response duration in days field.
            /// </summary>
            [XurrentEnum("maximum_response_duration_in_days")]
            MaximumResponseDurationInDays,

            /// <summary>
            /// The next target at field.
            /// </summary>
            [XurrentEnum("next_target_at")]
            NextTargetAt,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The provider not accountable field.
            /// </summary>
            [XurrentEnum("provider_not_accountable")]
            ProviderNotAccountable,

            /// <summary>
            /// The provider was not accountable field.
            /// </summary>
            [XurrentEnum("provider_was_not_accountable")]
            ProviderWasNotAccountable,

            /// <summary>
            /// The request field.
            /// </summary>
            [XurrentEnum("request")]
            Request,

            /// <summary>
            /// The resolution target at field.
            /// </summary>
            [XurrentEnum("resolution_target_at")]
            ResolutionTargetAt,

            /// <summary>
            /// The response target at field.
            /// </summary>
            [XurrentEnum("response_target_at")]
            ResponseTargetAt,

            /// <summary>
            /// The service hours field.
            /// </summary>
            [XurrentEnum("service_hours")]
            ServiceHours,

            /// <summary>
            /// The service instance field.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

            /// <summary>
            /// The service level agreement field.
            /// </summary>
            [XurrentEnum("sla")]
            ServiceLevelAgreement,

            /// <summary>
            /// The standard service request field.
            /// </summary>
            [XurrentEnum("standard_service_request")]
            StandardServiceRequest,

            /// <summary>
            /// The started at field.
            /// </summary>
            [XurrentEnum("started_at")]
            StartedAt,

            /// <summary>
            /// The stopped clock at field.
            /// </summary>
            [XurrentEnum("stopped_clock_at")]
            StoppedClockAt,

            /// <summary>
            /// The stopped clock duration field.
            /// </summary>
            [XurrentEnum("stopped_clock_duration")]
            StoppedClockDuration,

            /// <summary>
            /// The supplier field.
            /// </summary>
            [XurrentEnum("supplier")]
            Supplier,

            /// <summary>
            /// The support hours field.
            /// </summary>
            [XurrentEnum("support_hours")]
            SupportHours,

            /// <summary>
            /// The support team field.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

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
        /// Represents the filterable fields of an <see cref="AffectedSla"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters by the next target date.
            /// </summary>
            [XurrentEnum("next_target_at")]
            NextTargetAt,

            /// <summary>
            /// Filters by request.
            /// </summary>
            [XurrentEnum("request")]
            Request,

            /// <summary>
            /// Filters by service instance.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

            /// <summary>
            /// Filters by service level agreement.
            /// </summary>
            [XurrentEnum("sla")]
            Sla,

            /// <summary>
            /// Filters by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the absence of supported predefined filters for a query.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the fields used to order an <see cref="AffectedSla"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts by request.
            /// </summary>
            [XurrentEnum("request")]
            Request,

            /// <summary>
            /// Sorts by service instance.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

            /// <summary>
            /// Sorts by service level agreement.
            /// </summary>
            [XurrentEnum("sla")]
            Sla
        }

        private AffectedSlaAccountability? _accountability;
        private DateTime? _actualResolutionAt;
        private int? _actualResolutionDuration;
        private DateTime? _actualResponseAt;
        private int? _actualResponseDuration;
        private DateTime? _createdAt;
        private DateTime? _desiredCompletionAt;
        private int? _downtimeDuration;
        private DateTime? _downtimeEndAt;
        private DateTime? _downtimeStartAt;
        private Team? _firstLineTeam;
        private RequestImpact? _impact;
        private int? _maximumResolutionDuration;
        private int? _maximumResolutionDurationInDays;
        private int? _maximumResponseDuration;
        private int? _maximumResponseDurationInDays;
        private DateTime? _nextTargetAt;
        private bool? _providerNotAccountable;
        private bool? _providerWasNotAccountable;
        private Request? _request;
        private DateTime? _resolutionTargetAt;
        private DateTime? _responseTargetAt;
        private Calendar? _serviceHours;
        private ServiceInstance? _serviceInstance;
        private ServiceLevelAgreement? _serviceLevelAgreement;
        private Request? _standardServiceRequest;
        private DateTime? _startedAt;
        private DateTime? _stoppedClockAt;
        private int? _stoppedClockDuration;
        private Organization? _supplier;
        private Calendar? _supportHours;
        private Team? _supportTeam;
        private string? _timeZone;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the accountability of the affected service level agreement.
        /// </summary>
        [XurrentField("accountability")]
        public AffectedSlaAccountability? Accountability
        {
            get => _accountability;
            internal set => _accountability = value;
        }

        /// <summary>
        /// Gets the date and time when the request was actually resolved.
        /// </summary>
        [XurrentField("actual_resolution_at")]
        public DateTime? ActualResolutionAt
        {
            get => _actualResolutionAt;
            internal set => _actualResolutionAt = value;
        }

        /// <summary>
        /// Gets the actual resolution duration, expressed in minutes.
        /// </summary>
        [XurrentField("actual_resolution_duration")]
        public int? ActualResolutionDuration
        {
            get => _actualResolutionDuration;
            internal set => _actualResolutionDuration = value;
        }

        /// <summary>
        /// Gets the date and time when the request was actually responded to.
        /// </summary>
        [XurrentField("actual_response_at")]
        public DateTime? ActualResponseAt
        {
            get => _actualResponseAt;
            internal set => _actualResponseAt = value;
        }

        /// <summary>
        /// Gets the actual response duration, expressed in minutes.
        /// </summary>
        [XurrentField("actual_response_duration")]
        public int? ActualResponseDuration
        {
            get => _actualResponseDuration;
            internal set => _actualResponseDuration = value;
        }

        /// <summary>
        /// Gets the date and time when the affected service level agreement was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the desired completion date and time.
        /// </summary>
        [XurrentField("desired_completion_at")]
        public DateTime? DesiredCompletionAt
        {
            get => _desiredCompletionAt;
            internal set => _desiredCompletionAt = value;
        }

        /// <summary>
        /// Gets the downtime duration, expressed in minutes.
        /// </summary>
        [XurrentField("downtime_duration")]
        public int? DowntimeDuration
        {
            get => _downtimeDuration;
            internal set => _downtimeDuration = value;
        }

        /// <summary>
        /// Gets the date and time when downtime ended.
        /// </summary>
        [XurrentField("downtime_end_at")]
        public DateTime? DowntimeEndAt
        {
            get => _downtimeEndAt;
            internal set => _downtimeEndAt = value;
        }

        /// <summary>
        /// Gets the date and time when downtime started.
        /// </summary>
        [XurrentField("downtime_start_at")]
        public DateTime? DowntimeStartAt
        {
            get => _downtimeStartAt;
            internal set => _downtimeStartAt = value;
        }

        /// <summary>
        /// Gets the first line team associated with the affected service level agreement.
        /// </summary>
        [XurrentField("first_line_team")]
        public Team? FirstLineTeam
        {
            get => _firstLineTeam;
            internal set => _firstLineTeam = value;
        }

        /// <summary>
        /// Gets the impact associated with the affected service level agreement.
        /// </summary>
        [XurrentField("impact")]
        public RequestImpact? Impact
        {
            get => _impact;
            internal set => _impact = value;
        }

        /// <summary>
        /// Gets the maximum resolution duration, expressed in minutes.
        /// </summary>
        [XurrentField("maximum_resolution_duration")]
        public int? MaximumResolutionDuration
        {
            get => _maximumResolutionDuration;
            internal set => _maximumResolutionDuration = value;
        }

        /// <summary>
        /// Gets the maximum resolution duration, expressed in days.
        /// </summary>
        [XurrentField("maximum_resolution_duration_in_days")]
        public int? MaximumResolutionDurationInDays
        {
            get => _maximumResolutionDurationInDays;
            internal set => _maximumResolutionDurationInDays = value;
        }

        /// <summary>
        /// Gets the maximum response duration, expressed in minutes.
        /// </summary>
        [XurrentField("maximum_response_duration")]
        public int? MaximumResponseDuration
        {
            get => _maximumResponseDuration;
            internal set => _maximumResponseDuration = value;
        }

        /// <summary>
        /// Gets the maximum response duration, expressed in days.
        /// </summary>
        [XurrentField("maximum_response_duration_in_days")]
        public int? MaximumResponseDurationInDays
        {
            get => _maximumResponseDurationInDays;
            internal set => _maximumResponseDurationInDays = value;
        }

        /// <summary>
        /// Gets the next target date and time.
        /// </summary>
        [XurrentField("next_target_at")]
        public DateTime? NextTargetAt
        {
            get => _nextTargetAt;
            internal set => _nextTargetAt = value;
        }

        /// <summary>
        /// Gets a value indicating whether the provider is not accountable.
        /// </summary>
        [XurrentField("provider_not_accountable")]
        public bool? ProviderNotAccountable
        {
            get => _providerNotAccountable;
            internal set => _providerNotAccountable = value;
        }

        /// <summary>
        /// Gets a value indicating whether the provider was not accountable.
        /// </summary>
        [XurrentField("provider_was_not_accountable")]
        public bool? ProviderWasNotAccountable
        {
            get => _providerWasNotAccountable;
            internal set => _providerWasNotAccountable = value;
        }

        /// <summary>
        /// Gets the request associated with the affected service level agreement.
        /// </summary>
        [XurrentField("request")]
        public Request? Request
        {
            get => _request;
            internal set => _request = value;
        }

        /// <summary>
        /// Gets the resolution target date and time.
        /// </summary>
        [XurrentField("resolution_target_at")]
        public DateTime? ResolutionTargetAt
        {
            get => _resolutionTargetAt;
            internal set => _resolutionTargetAt = value;
        }

        /// <summary>
        /// Gets the response target date and time.
        /// </summary>
        [XurrentField("response_target_at")]
        public DateTime? ResponseTargetAt
        {
            get => _responseTargetAt;
            internal set => _responseTargetAt = value;
        }

        /// <summary>
        /// Gets the service hours calendar.
        /// </summary>
        [XurrentField("service_hours")]
        public Calendar? ServiceHours
        {
            get => _serviceHours;
            internal set => _serviceHours = value;
        }

        /// <summary>
        /// Gets the service instance associated with the affected service level agreement.
        /// </summary>
        [XurrentField("service_instance")]
        public ServiceInstance? ServiceInstance
        {
            get => _serviceInstance;
            internal set => _serviceInstance = value;
        }

        /// <summary>
        /// Gets the service level agreement that is affected.
        /// </summary>
        [XurrentField("sla")]
        public ServiceLevelAgreement? ServiceLevelAgreement
        {
            get => _serviceLevelAgreement;
            internal set => _serviceLevelAgreement = value;
        }

        /// <summary>
        /// Gets the standard service request associated with the affected service level agreement.
        /// </summary>
        [XurrentField("standard_service_request")]
        public Request? StandardServiceRequest
        {
            get => _standardServiceRequest;
            internal set => _standardServiceRequest = value;
        }

        /// <summary>
        /// Gets the date and time when the service level agreement clock started.
        /// </summary>
        [XurrentField("started_at")]
        public DateTime? StartedAt
        {
            get => _startedAt;
            internal set => _startedAt = value;
        }

        /// <summary>
        /// Gets the date and time when the service level agreement clock was stopped.
        /// </summary>
        [XurrentField("stopped_clock_at")]
        public DateTime? StoppedClockAt
        {
            get => _stoppedClockAt;
            internal set => _stoppedClockAt = value;
        }

        /// <summary>
        /// Gets the stopped clock duration, expressed in minutes.
        /// </summary>
        [XurrentField("stopped_clock_duration")]
        public int? StoppedClockDuration
        {
            get => _stoppedClockDuration;
            internal set => _stoppedClockDuration = value;
        }

        /// <summary>
        /// Gets the supplier associated with the affected service level agreement.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            internal set => _supplier = value;
        }

        /// <summary>
        /// Gets the support hours calendar.
        /// </summary>
        [XurrentField("support_hours")]
        public Calendar? SupportHours
        {
            get => _supportHours;
            internal set => _supportHours = value;
        }

        /// <summary>
        /// Gets the support team associated with the affected service level agreement.
        /// </summary>
        [XurrentField("support_team")]
        public Team? SupportTeam
        {
            get => _supportTeam;
            internal set => _supportTeam = value;
        }

        /// <summary>
        /// Gets the time zone that applies to the affected service level agreement.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            internal set => _timeZone = value;
        }

        /// <summary>
        /// Gets the date and time when the affected service level agreement was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new affected service level agreement instance.
        /// </summary>
        public AffectedSla()
        {
        }

        /// <summary>
        /// Creates a new affected service level agreement instance.
        /// </summary>
        /// <param name="id">The unique identifier of the affected service level agreement.</param>
        public AffectedSla(long id)
        {
            Id = id;
        }
    }
}
