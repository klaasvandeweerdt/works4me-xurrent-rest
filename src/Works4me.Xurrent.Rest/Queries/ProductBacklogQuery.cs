using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ProductBacklog"/> records.
    /// </summary>
    public sealed class ProductBacklogQuery
        : Query<ProductBacklogQuery, ProductBacklog.PredefinedFilter, ProductBacklog.Field, ProductBacklog.FilterField, ProductBacklog.OrderField>
    {
    }
}
