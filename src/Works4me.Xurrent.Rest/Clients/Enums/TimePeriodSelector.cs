namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Specifies how a provided date is used to select the time period for which totals are retrieved.
    /// </summary>
    public enum TimePeriodSelector
    {
        /// <summary>
        /// Uses the specified date to retrieve totals for that single day (yyyy-MM-dd).
        /// </summary>
        Day,

        /// <summary>
        /// Uses the specified date to retrieve totals for the week containing that date (yyyy-MM-dd).
        /// </summary>
        Week,

        /// <summary>
        /// Uses the specified date to retrieve totals for the month containing that date (yyyy-MM-dd).
        /// </summary>
        Month
    }
}
