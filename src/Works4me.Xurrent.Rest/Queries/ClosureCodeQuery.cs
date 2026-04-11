using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ClosureCode"/> records.
    /// </summary>
    public sealed class ClosureCodeQuery
        : Query<ClosureCodeQuery, ClosureCode.PredefinedFilter, ClosureCode.Field, ClosureCode.FilterField, ClosureCode.OrderField>
    {
    }
}
