using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Product"/> records.
    /// </summary>
    public sealed class ProductQuery
        : Query<ProductQuery, Product.PredefinedFilter, Product.Field, Product.FilterField, Product.OrderField>
    {
    }
}
