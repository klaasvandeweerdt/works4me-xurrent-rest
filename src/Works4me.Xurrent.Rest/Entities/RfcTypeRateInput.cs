using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent RFC type rate input object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class RfcTypeRateInput : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="RfcTypeRateInput"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The charge type field.
            /// </summary>
            [XurrentEnum("charge_type")]
            ChargeType,

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
            /// The rfc type field.
            /// </summary>
            [XurrentEnum("rfc_type")]
            RfcType
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
        private decimal? _rate;
        private Currency? _rateCurrency;
        private RfcType? _rfcType;

        /// <summary>
        /// Sets how the RFC type is charged.
        /// </summary>
        [XurrentField("charge_type")]
        public ServiceOfferingChargeType? ChargeType
        {
            get => _chargeType;
            set => _chargeType = SetValue("charge_type", _chargeType, value);
        }

        /// <summary>
        /// Sets the rate per RFC type.<br />
        /// This value is required when the charge type is <c>fixed_price</c>.
        /// </summary>
        [XurrentField("rate")]
        public decimal? Rate
        {
            get => _rate;
            set => _rate = SetValue("rate", _rate, value);
        }

        /// <summary>
        /// Sets the currency of the rate.<br />
        /// This value is required when the charge type is <c>fixed_price</c>.
        /// </summary>
        [XurrentField("rate_currency")]
        public Currency? RateCurrency
        {
            get => _rateCurrency;
            set => _rateCurrency = SetValue("rate_currency", _rateCurrency, value);
        }

        /// <summary>
        /// Sets the RFC type associated with the rate.
        /// </summary>
        [XurrentField("rfc_type")]
        public RfcType? RfcType
        {
            get => _rfcType;
            set => _rfcType = SetValue("rfc_type", _rfcType, value);
        }

        /// <summary>
        /// Creates a new rfc type rate input instance.
        /// </summary>
        public RfcTypeRateInput()
        {
        }

        /// <summary>
        /// Creates a new rfc type rate input instance.
        /// </summary>
        /// <param name="id">The unique identifier of the rfc type rate input.</param>
        public RfcTypeRateInput(long id)
        {
            Id = id;
        }
    }
}
