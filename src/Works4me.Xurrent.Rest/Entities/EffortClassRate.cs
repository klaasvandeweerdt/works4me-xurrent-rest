using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent effort class rate object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class EffortClassRate : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="EffortClassRate"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The effort class field.
            /// </summary>
            [XurrentEnum("effort_class")]
            EffortClass,

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
            RateCurrency
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

        private EffortClass? _effortClass;
        private decimal? _rate;
        private Currency? _rateCurrency;

        /// <summary>
        /// Gets or sets the effort class associated with the effort class rate.
        /// </summary>
        [XurrentField("effort_class")]
        public EffortClass? EffortClass
        {
            get => _effortClass;
            set => _effortClass = SetValue("effort_class", _effortClass, value);
        }

        /// <summary>
        /// Gets or sets the rate per hour for the effort class.
        /// </summary>
        [XurrentField("rate")]
        public decimal? Rate
        {
            get => _rate;
            set => _rate = SetValue("rate", _rate, value);
        }

        /// <summary>
        /// Gets or sets the currency of the rate per hour for the effort class.
        /// </summary>
        [XurrentField("rate_currency")]
        public Currency? RateCurrency
        {
            get => _rateCurrency;
            set => _rateCurrency = SetValue("rate_currency", _rateCurrency, value);
        }

        /// <summary>
        /// Creates a new effort class rate instance.
        /// </summary>
        public EffortClassRate()
        {
        }

        /// <summary>
        /// Creates a new effort class rate instance.
        /// </summary>
        /// <param name="id">The unique identifier of the effort class rate.</param>
        public EffortClassRate(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new effort class rate instance.
        /// </summary>
        /// <param name="effortClass">The effort class of the effort class rate.</param>
        /// <param name="rate">The rate of the effort class rate.</param>
        /// <param name="rateCurrency">The rate currency of the effort class rate.</param>
        public EffortClassRate(EffortClass effortClass, decimal rate, Currency rateCurrency)
        {
            _effortClass = SetValue("effort_class", effortClass);
            _rate = SetValue("rate", rate);
            _rateCurrency = SetValue("rate_currency", rateCurrency);
        }
    }
}
