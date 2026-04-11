using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="TrashItem"/> records.
    /// </summary>
    public sealed class TrashItemQuery
        : Query<TrashItemQuery, TrashItem.PredefinedFilter, TrashItem.Field, TrashItem.FilterField, TrashItem.OrderField>
    {
    }
}
