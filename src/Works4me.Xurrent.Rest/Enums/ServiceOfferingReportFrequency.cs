using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various service offering report frequencies.
    /// </summary>
    public enum ServiceOfferingReportFrequency
    {
        /// <summary>
        /// Indicates a daily report frequency.
        /// </summary>
        [XurrentEnum("daily")]
        Daily,

        /// <summary>
        /// Indicates a weekly report frequency.
        /// </summary>
        [XurrentEnum("weekly")]
        Weekly,

        /// <summary>
        /// Indicates a report frequency of once every two weeks.
        /// </summary>
        [XurrentEnum("once_every_2_weeks")]
        OnceEvery2Weeks,

        /// <summary>
        /// Indicates a monthly report frequency.
        /// </summary>
        [XurrentEnum("monthly")]
        Monthly,

        /// <summary>
        /// Indicates a report frequency of once every two months.
        /// </summary>
        [XurrentEnum("once_every_2_months")]
        OnceEvery2Months,

        /// <summary>
        /// Indicates a quarterly report frequency.
        /// </summary>
        [XurrentEnum("quarterly")]
        Quarterly,

        /// <summary>
        /// Indicates a report frequency of once every six months.
        /// </summary>
        [XurrentEnum("once_every_6_months")]
        OnceEvery6Months,

        /// <summary>
        /// Indicates a yearly report frequency.
        /// </summary>
        [XurrentEnum("yearly")]
        Yearly,

        /// <summary>
        /// Indicates a report frequency of once every two years.
        /// </summary>
        [XurrentEnum("once_every_2_years")]
        OnceEvery2Years,

        /// <summary>
        /// Indicates a report frequency with no commitment.
        /// </summary>
        [XurrentEnum("no_commitment")]
        NoCommitment
    }
}
