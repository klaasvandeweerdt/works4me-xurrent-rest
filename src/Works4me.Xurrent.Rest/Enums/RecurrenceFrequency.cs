using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various recurrence frequencies.
    /// </summary>
    public enum RecurrenceFrequency
    {
        /// <summary>
        /// Indicates that the recurrence does not repeat.
        /// </summary>
        [XurrentEnum("no_repeat")]
        NoRepeat,

        /// <summary>
        /// Indicates that the recurrence occurs daily.
        /// </summary>
        [XurrentEnum("daily")]
        Daily,

        /// <summary>
        /// Indicates that the recurrence occurs weekly.
        /// </summary>
        [XurrentEnum("weekly")]
        Weekly,

        /// <summary>
        /// Indicates that the recurrence occurs monthly.
        /// </summary>
        [XurrentEnum("monthly")]
        Monthly,

        /// <summary>
        /// Indicates that the recurrence occurs yearly.
        /// </summary>
        [XurrentEnum("yearly")]
        Yearly
    }
}
