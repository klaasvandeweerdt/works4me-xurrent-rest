using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Broadcast"/> records.
    /// </summary>
    public sealed class BroadcastQuery
        : Query<BroadcastQuery, Broadcast.PredefinedFilter, Broadcast.Field, Broadcast.FilterField, Broadcast.OrderField>
    {
    }
}
