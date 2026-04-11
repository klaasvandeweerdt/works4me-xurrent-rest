using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Watch"/> records.
    /// </summary>
    public sealed class WatchQuery
        : Query<WatchQuery, Watch.PredefinedFilter, Watch.Field, Watch.FilterField, Watch.OrderField>
    {
    }
}
