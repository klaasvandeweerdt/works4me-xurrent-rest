namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// The filter operators that can be applied when constructing query filters.
    /// </summary>
    public enum FilterOperator
    {
        /// <summary>
        /// Same as given value.
        /// </summary>
        Equality,

        /// <summary>
        /// Different from given value.
        /// </summary>
        Negation,

        /// <summary>
        /// Equal to one of the given values (integers and enumerable values only).
        /// </summary>
        In,

        /// <summary>
        /// Not equal to one of the given values (integers and enumerable values only).
        /// </summary>
        NotIn,

        /// <summary>
        /// Less than given value (not for enumerable values, strings and booleans).
        /// </summary>
        LessThan,

        /// <summary>
        /// Less than or equal to given value (not for enumerable values, strings and booleans).
        /// </summary>
        LessThanOrEqualsTo,

        /// <summary>
        /// Greater than given value (not for enumerable values, strings and booleans).
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Greater than or equal to given value (not for enumerable values, strings and booleans).
        /// </summary>
        GreaterThanOrEqualsTo,

        /// <summary>
        /// Contains a value (not null).
        /// </summary>
        Present,

        /// <summary>
        /// Has no value.
        /// </summary>
        Empty,

        /// <summary>
        /// Greater than given value and less than the other given value (numeric and date/time types only).
        /// </summary>
        GreaterThanAndLessThan,

        /// <summary>
        /// Greater than or equal to given value and less than or equal to the other given value (numeric and date/time types only).
        /// </summary>
        GreaterThanOrEqualToAndLessThanOrEqualTo
    }

}
