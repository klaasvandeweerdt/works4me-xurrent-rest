using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ShopArticle"/> records.
    /// </summary>
    public sealed class ShopArticleQuery
        : Query<ShopArticleQuery, ShopArticle.PredefinedFilter, ShopArticle.Field, ShopArticle.FilterField, ShopArticle.OrderField>
    {
    }
}
