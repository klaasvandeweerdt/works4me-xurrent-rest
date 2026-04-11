using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ShopOrderLine"/> records.
    /// </summary>
    public sealed class ShopOrderLineQuery
        : Query<ShopOrderLineQuery, ShopOrderLine.PredefinedFilter, ShopOrderLine.Field, ShopOrderLine.FilterField, ShopOrderLine.OrderField>
    {
    }
}
