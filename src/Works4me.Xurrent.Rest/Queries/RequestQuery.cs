using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Request"/> records.
    /// </summary>
    public sealed class RequestQuery
        : Query<RequestQuery, Request.PredefinedFilter, Request.Field, Request.FilterField, Request.OrderField>
    {
    }
}
