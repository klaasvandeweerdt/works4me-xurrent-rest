using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AppOffering"/> records.
    /// </summary>
    public sealed class AppOfferingQuery
        : Query<AppOfferingQuery, AppOffering.PredefinedFilter, AppOffering.Field, AppOffering.FilterField, AppOffering.OrderField>
    {
    }
}
