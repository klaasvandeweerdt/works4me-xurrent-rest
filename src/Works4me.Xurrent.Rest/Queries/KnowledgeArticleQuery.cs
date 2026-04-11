using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="KnowledgeArticle"/> records.
    /// </summary>
    public sealed class KnowledgeArticleQuery
        : Query<KnowledgeArticleQuery, KnowledgeArticle.PredefinedFilter, KnowledgeArticle.Field, KnowledgeArticle.FilterField, KnowledgeArticle.OrderField>
    {
    }
}
