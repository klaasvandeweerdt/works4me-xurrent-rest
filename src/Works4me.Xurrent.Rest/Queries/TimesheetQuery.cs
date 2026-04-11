using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Timesheet"/> records.
    /// </summary>
    public sealed class TimesheetQuery
        : Query<TimesheetQuery, Timesheet.PredefinedFilter, Timesheet.Field, Timesheet.FilterField, Timesheet.OrderField>
    {
    }
}
