using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="TimeAllocation"/> records.
    /// </summary>
    public sealed class TimeAllocationQuery
        : Query<TimeAllocationQuery, TimeAllocation.PredefinedFilter, TimeAllocation.Field, TimeAllocation.FilterField, TimeAllocation.OrderField>
    {
    }
}
