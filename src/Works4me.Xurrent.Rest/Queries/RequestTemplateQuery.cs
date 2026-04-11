using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="RequestTemplate"/> records.
    /// </summary>
    public sealed class RequestTemplateQuery
        : Query<RequestTemplateQuery, RequestTemplate.PredefinedFilter, RequestTemplate.Field, RequestTemplate.FilterField, RequestTemplate.OrderField>
    {
    }
}
