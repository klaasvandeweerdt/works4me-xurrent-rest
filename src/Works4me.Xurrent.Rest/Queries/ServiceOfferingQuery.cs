using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ServiceOffering"/> records.
    /// </summary>
    public sealed class ServiceOfferingQuery
        : Query<ServiceOfferingQuery, ServiceOffering.PredefinedFilter, ServiceOffering.Field, ServiceOffering.FilterField, ServiceOffering.OrderField>
    {
    }
}
