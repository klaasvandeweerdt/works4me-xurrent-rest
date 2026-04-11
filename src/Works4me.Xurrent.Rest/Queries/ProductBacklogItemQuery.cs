using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ProductBacklogItem"/> records.
    /// </summary>
    public sealed class ProductBacklogItemQuery
        : Query<ProductBacklogItemQuery, ProductBacklogItem.PredefinedFilter, ProductBacklogItem.Field, ProductBacklogItem.FilterField, ProductBacklogItem.OrderField>
    {
    }
}
