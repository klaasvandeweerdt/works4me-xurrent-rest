using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various weekdays.
    /// </summary>
    public enum Weekday
    {
        /// <summary>
        /// Represents Monday.
        /// </summary>
        [XurrentEnum("mon")]
        Monday,

        /// <summary>
        /// Represents Tuesday.
        /// </summary>
        [XurrentEnum("tue")]
        Tuesday,

        /// <summary>
        /// Represents Wednesday.
        /// </summary>
        [XurrentEnum("wed")]
        Wednesday,

        /// <summary>
        /// Represents Thursday.
        /// </summary>
        [XurrentEnum("thu")]
        Thursday,

        /// <summary>
        /// Represents Friday.
        /// </summary>
        [XurrentEnum("fri")]
        Friday,

        /// <summary>
        /// Represents Saturday.
        /// </summary>
        [XurrentEnum("sat")]
        Saturday,

        /// <summary>
        /// Represents Sunday.
        /// </summary>
        [XurrentEnum("sun")]
        Sunday
    }
}
