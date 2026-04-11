using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ProductCategory"/> records.
    /// </summary>
    public sealed class ProductCategoryQuery
        : Query<ProductCategoryQuery, ProductCategory.PredefinedFilter, ProductCategory.Field, ProductCategory.FilterField, ProductCategory.OrderField>
    {
    }
}
