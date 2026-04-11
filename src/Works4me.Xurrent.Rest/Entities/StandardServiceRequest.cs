using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent standard service request object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class StandardServiceRequest : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="StandardServiceRequest"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The charge type field.
            /// </summary>
            [XurrentEnum("charge_type")]
            ChargeType,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The rate field.
            /// </summary>
            [XurrentEnum("rate")]
            Rate,

            /// <summary>
            /// The rate currency field.
            /// </summary>
            [XurrentEnum("rate_currency")]
            RateCurrency,

            /// <summary>
            /// The request template field.
            /// </summary>
            [XurrentEnum("request_template")]
            RequestTemplate,

            /// <summary>
            /// The resolution target field.
            /// </summary>
            [XurrentEnum("resolution_target")]
            ResolutionTarget,

            /// <summary>
            /// The resolution target best effort field.
            /// </summary>
            [XurrentEnum("resolution_target_best_effort")]
            ResolutionTargetBestEffort,

            /// <summary>
            /// The resolution target in days field.
            /// </summary>
            [XurrentEnum("resolution_target_in_days")]
            ResolutionTargetInDays,

            /// <summary>
            /// The response target field.
            /// </summary>
            [XurrentEnum("response_target")]
            ResponseTarget,

            /// <summary>
            /// The response target best effort field.
            /// </summary>
            [XurrentEnum("response_target_best_effort")]
            ResponseTargetBestEffort,

            /// <summary>
            /// The response target in days field.
            /// </summary>
            [XurrentEnum("response_target_in_days")]
            ResponseTargetInDays,

            /// <summary>
            /// The support hours field.
            /// </summary>
            [XurrentEnum("support_hours")]
            SupportHours,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the absence of supported filters for a query.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
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
        /// Represents the absence of supported ordering fields for a query.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Specifies that no ordering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        private ServiceOfferingChargeType? _chargeType;
        private DateTime? _createdAt;
        private decimal? _rate;
        private Currency? _rateCurrency;
        private RequestImpact? _requestTemplate;
        private int? _resolutionTarget;
        private bool? _resolutionTargetBestEffort;
        private int? _resolutionTargetInDays;
        private int? _responseTarget;
        private bool? _responseTargetBestEffort;
        private int? _responseTargetInDays;
        private Calendar? _supportHours;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets how the standard service request is charged.
        /// </summary>
        [XurrentField("charge_type")]
        public ServiceOfferingChargeType? ChargeType
        {
            get => _chargeType;
            set => _chargeType = SetValue("charge_type", _chargeType, value);
        }

        /// <summary>
        /// Gets the date and time when the standard service request was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the fixed price rate for the standard service request.
        /// </summary>
        [XurrentField("rate")]
        public decimal? Rate
        {
            get => _rate;
            set => _rate = SetValue("rate", _rate, value);
        }

        /// <summary>
        /// Gets or sets the currency of the fixed price rate for the standard service request.
        /// </summary>
        [XurrentField("rate_currency")]
        public Currency? RateCurrency
        {
            get => _rateCurrency;
            set => _rateCurrency = SetValue("rate_currency", _rateCurrency, value);
        }

        /// <summary>
        /// Gets or sets the request template related to the service offering.
        /// </summary>
        [XurrentField("request_template")]
        public RequestImpact? RequestTemplate
        {
            get => _requestTemplate;
            set => _requestTemplate = SetValue("request_template", _requestTemplate, value);
        }

        /// <summary>
        /// Gets or sets the number of minutes within which the request must be completed.
        /// </summary>
        [XurrentField("resolution_target")]
        public int? ResolutionTarget
        {
            get => _resolutionTarget;
            set => _resolutionTarget = SetValue("resolution_target", _resolutionTarget, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the resolution target is best effort.
        /// </summary>
        [XurrentField("resolution_target_best_effort")]
        public bool? ResolutionTargetBestEffort
        {
            get => _resolutionTargetBestEffort;
            set => _resolutionTargetBestEffort = SetValue("resolution_target_best_effort", _resolutionTargetBestEffort, value);
        }

        /// <summary>
        /// Gets or sets the number of business days within which the request must be completed.
        /// </summary>
        [XurrentField("resolution_target_in_days")]
        public int? ResolutionTargetInDays
        {
            get => _resolutionTargetInDays;
            set => _resolutionTargetInDays = SetValue("resolution_target_in_days", _resolutionTargetInDays, value);
        }

        /// <summary>
        /// Gets or sets the number of minutes within which a response must be provided.
        /// </summary>
        [XurrentField("response_target")]
        public int? ResponseTarget
        {
            get => _responseTarget;
            set => _responseTarget = SetValue("response_target", _responseTarget, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the response target is best effort.
        /// </summary>
        [XurrentField("response_target_best_effort")]
        public bool? ResponseTargetBestEffort
        {
            get => _responseTargetBestEffort;
            set => _responseTargetBestEffort = SetValue("response_target_best_effort", _responseTargetBestEffort, value);
        }

        /// <summary>
        /// Gets or sets the number of business days within which a response must be provided.
        /// </summary>
        [XurrentField("response_target_in_days")]
        public int? ResponseTargetInDays
        {
            get => _responseTargetInDays;
            set => _responseTargetInDays = SetValue("response_target_in_days", _responseTargetInDays, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the support hours.
        /// </summary>
        [XurrentField("support_hours")]
        public Calendar? SupportHours
        {
            get => _supportHours;
            set => _supportHours = SetValue("support_hours", _supportHours, value);
        }

        /// <summary>
        /// Gets the date and time when the standard service request was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new standard service request instance.
        /// </summary>
        public StandardServiceRequest()
        {
        }

        /// <summary>
        /// Creates a new standard service request instance.
        /// </summary>
        /// <param name="id">The unique identifier of the standard service request.</param>
        public StandardServiceRequest(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new standard service request instance.
        /// </summary>
        /// <param name="requestTemplate">The request template of the standard service request.</param>
        public StandardServiceRequest(RequestImpact requestTemplate)
        {
            _requestTemplate = SetValue("request_template", requestTemplate);
        }
    }
}
