using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="CalendarHour"/> records.
    /// </summary>
    public sealed class CalendarHourQuery
        : Query<CalendarHourQuery, CalendarHour.PredefinedFilter, CalendarHour.Field, CalendarHour.FilterField, CalendarHour.OrderField>
    {
    }
}
