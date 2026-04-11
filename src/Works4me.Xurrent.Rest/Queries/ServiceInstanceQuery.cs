using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ServiceInstance"/> records.
    /// </summary>
    public sealed class ServiceInstanceQuery
        : Query<ServiceInstanceQuery, ServiceInstance.PredefinedFilter, ServiceInstance.Field, ServiceInstance.FilterField, ServiceInstance.OrderField>
    {
    }
}
