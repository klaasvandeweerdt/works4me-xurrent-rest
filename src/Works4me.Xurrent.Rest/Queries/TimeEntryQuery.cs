using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="TimeEntry"/> records.
    /// </summary>
    public sealed class TimeEntryQuery
        : Query<TimeEntryQuery, TimeEntry.PredefinedFilter, TimeEntry.Field, TimeEntry.FilterField, TimeEntry.OrderField>
    {
    }
}
