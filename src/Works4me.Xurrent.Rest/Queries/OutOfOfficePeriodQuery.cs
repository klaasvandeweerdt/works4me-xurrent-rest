using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="OutOfOfficePeriod"/> records.
    /// </summary>
    public sealed class OutOfOfficePeriodQuery
        : Query<OutOfOfficePeriodQuery, OutOfOfficePeriod.PredefinedFilter, OutOfOfficePeriod.Field, OutOfOfficePeriod.FilterField, OutOfOfficePeriod.OrderField>
    {
    }
}
