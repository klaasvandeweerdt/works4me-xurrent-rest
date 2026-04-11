using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various depreciation methods.
    /// </summary>
    public enum ProductDepreciationMethod
    {
        /// <summary>
        /// Indicates that the asset is not depreciated.
        /// </summary>
        [XurrentEnum("not_depreciated")]
        NotDepreciated,

        /// <summary>
        /// Indicates that depreciation is calculated using the double declining balance method.
        /// </summary>
        [XurrentEnum("double_declining_balance")]
        DoubleDecliningBalance,

        /// <summary>
        /// Indicates that depreciation is calculated using the reducing balance method.
        /// </summary>
        [XurrentEnum("reducing_balance")]
        ReducingBalance,

        /// <summary>
        /// Indicates that depreciation is calculated using the straight line method.
        /// </summary>
        [XurrentEnum("straight_line")]
        StraightLine,

        /// <summary>
        /// Indicates that depreciation is calculated using the sum of the years digits method.
        /// </summary>
        [XurrentEnum("sum_of_the_years_digits")]
        SumOfTheYearsDigits
    }
}
