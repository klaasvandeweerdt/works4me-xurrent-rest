using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="InboundEmail"/> records.
    /// </summary>
    public sealed class InboundEmailQuery
        : Query<InboundEmailQuery, InboundEmail.PredefinedFilter, InboundEmail.Field, InboundEmail.FilterField, InboundEmail.OrderField>
    {
    }
}
