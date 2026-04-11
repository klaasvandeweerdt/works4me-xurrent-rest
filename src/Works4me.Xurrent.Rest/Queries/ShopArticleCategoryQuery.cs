using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ShopArticleCategory"/> records.
    /// </summary>
    public sealed class ShopArticleCategoryQuery
        : Query<ShopArticleCategoryQuery, ShopArticleCategory.PredefinedFilter, ShopArticleCategory.Field, ShopArticleCategory.FilterField, ShopArticleCategory.OrderField>
    {
    }
}
