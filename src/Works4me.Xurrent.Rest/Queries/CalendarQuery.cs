using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Calendar"/> records.
    /// </summary>
    public sealed class CalendarQuery
        : Query<CalendarQuery, Calendar.PredefinedFilter, Calendar.Field, Calendar.FilterField, Calendar.OrderField>
    {
    }
}
