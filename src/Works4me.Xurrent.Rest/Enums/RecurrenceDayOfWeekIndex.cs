using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various recurrence day of week indexes.
    /// </summary>
    public enum RecurrenceDayOfWeekIndex
    {
        /// <summary>
        /// Indicates that the recurrence occurs on the first occurrence of the specified weekday.
        /// </summary>
        [XurrentEnum("first")]
        First,

        /// <summary>
        /// Indicates that the recurrence occurs on the second occurrence of the specified weekday.
        /// </summary>
        [XurrentEnum("second")]
        Second,

        /// <summary>
        /// Indicates that the recurrence occurs on the third occurrence of the specified weekday.
        /// </summary>
        [XurrentEnum("third")]
        Third,

        /// <summary>
        /// Indicates that the recurrence occurs on the fourth occurrence of the specified weekday.
        /// </summary>
        [XurrentEnum("fourth")]
        Fourth,

        /// <summary>
        /// Indicates that the recurrence occurs on the last occurrence of the specified weekday.
        /// </summary>
        [XurrentEnum("last")]
        Last
    }
}
