using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various timesheet percentage increment values.
    /// </summary>
    public enum PercentageIncrement
    {
        /// <summary>
        /// Indicates that the percentage increment is 50 percent.
        /// </summary>
        [XurrentEnum("50")]
        Fifty,

        /// <summary>
        /// Indicates that the percentage increment is 100 percent.
        /// </summary>
        [XurrentEnum("100")]
        OneHundred,

        /// <summary>
        /// Indicates that the percentage increment is 12.5 percent.
        /// </summary>
        [XurrentEnum("12.5")]
        TwelveAndAHalf,

        /// <summary>
        /// Indicates that the percentage increment is 25 percent.
        /// </summary>
        [XurrentEnum("25")]
        TwentyFive
    }
}
