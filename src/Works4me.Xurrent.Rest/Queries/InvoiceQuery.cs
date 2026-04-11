using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Invoice"/> records.
    /// </summary>
    public sealed class InvoiceQuery
        : Query<InvoiceQuery, Invoice.PredefinedFilter, Invoice.Field, Invoice.FilterField, Invoice.OrderField>
    {
    }
}
