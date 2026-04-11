using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various shop article recurring periods.
    /// </summary>
    public enum ShopArticleRecurringPeriod
    {
        /// <summary>
        /// Indicates that the recurring period is monthly.
        /// </summary>
        [XurrentEnum("monthly")]
        Monthly,

        /// <summary>
        /// Indicates that the recurring period is yearly.
        /// </summary>
        [XurrentEnum("yearly")]
        Yearly
    }
}
