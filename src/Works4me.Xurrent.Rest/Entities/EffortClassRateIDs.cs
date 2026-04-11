using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent effort class rate identifier object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class EffortClassRateIDs : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="EffortClassRateIDs"/> object.
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
            /// The rate identifier field.
            /// </summary>
            [XurrentEnum("rateID")]
            RateID
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
        private string? _rateID;

        /// <summary>
        /// Gets or sets the effort class associated with the effort class rate identifier.
        /// </summary>
        [XurrentField("effort_class")]
        public EffortClass? EffortClass
        {
            get => _effortClass;
            set => _effortClass = SetValue("effort_class", _effortClass, value);
        }

        /// <summary>
        /// Gets or sets the rate identifier used by the service provider billing system.
        /// </summary>
        [XurrentField("rateID")]
        public string? RateID
        {
            get => _rateID;
            set => _rateID = SetValue("rateID", _rateID, value);
        }

        /// <summary>
        /// Creates a new effort class rate i ds instance.
        /// </summary>
        public EffortClassRateIDs()
        {
        }

        /// <summary>
        /// Creates a new effort class rate i ds instance.
        /// </summary>
        /// <param name="id">The unique identifier of the effort class rate i ds.</param>
        public EffortClassRateIDs(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new effort class rate i ds instance.
        /// </summary>
        /// <param name="effortClass">The effort class of the effort class rate i ds.</param>
        /// <param name="rateID">The rate identifier of the effort class rate i ds.</param>
        public EffortClassRateIDs(EffortClass effortClass, string rateID)
        {
            _effortClass = SetValue("effort_class", effortClass);
            _rateID = SetValue("rateID", rateID);
        }
    }
}
