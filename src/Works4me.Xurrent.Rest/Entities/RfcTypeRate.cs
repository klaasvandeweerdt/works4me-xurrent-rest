using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent RFC type rate object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class RfcTypeRate : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="RfcTypeRate"/> object.
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
        private string? _rfcType;

        /// <summary>
        /// Gets how the RFC type is charged.
        /// </summary>
        [XurrentField("charge_type")]
        public ServiceOfferingChargeType? ChargeType
        {
            get => _chargeType;
            internal set => _chargeType = value;
        }

        /// <summary>
        /// Gets the rate per RFC type.
        /// </summary>
        [XurrentField("rate")]
        public decimal? Rate
        {
            get => _rate;
            internal set => _rate = value;
        }

        /// <summary>
        /// Gets the currency of the rate.
        /// </summary>
        [XurrentField("rate_currency")]
        public Currency? RateCurrency
        {
            get => _rateCurrency;
            internal set => _rateCurrency = value;
        }

        /// <summary>
        /// Gets the RFC type reference associated with the rate.
        /// </summary>
        [XurrentField("rfc_type")]
        public string? RfcType
        {
            get => _rfcType;
            internal set => _rfcType = value;
        }

        /// <summary>
        /// Creates a new rfc type rate instance.
        /// </summary>
        public RfcTypeRate()
        {
        }

        /// <summary>
        /// Creates a new rfc type rate instance.
        /// </summary>
        /// <param name="id">The unique identifier of the rfc type rate.</param>
        public RfcTypeRate(long id)
        {
            Id = id;
        }
    }
}
