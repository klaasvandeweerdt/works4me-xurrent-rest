using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Holiday"/> records.
    /// </summary>
    public sealed class HolidayQuery
        : Query<HolidayQuery, Holiday.PredefinedFilter, Holiday.Field, Holiday.FilterField, Holiday.OrderField>
    {
    }
}
