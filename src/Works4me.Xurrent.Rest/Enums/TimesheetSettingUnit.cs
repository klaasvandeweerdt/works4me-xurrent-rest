using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various timesheet setting unit values.
    /// </summary>
    public enum TimesheetSettingUnit
    {
        /// <summary>
        /// Indicates that time is expressed in hours and minutes.
        /// </summary>
        [XurrentEnum("hours_and_minutes")]
        HoursAndMinutes,

        /// <summary>
        /// Indicates that time is expressed as a percentage of a workday.
        /// </summary>
        [XurrentEnum("percentage_of_workday")]
        PercentageOfWorkday
    }
}
