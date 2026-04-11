using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Service"/> records.
    /// </summary>
    public sealed class ServiceQuery
        : Query<ServiceQuery, Service.PredefinedFilter, Service.Field, Service.FilterField, Service.OrderField>
    {
    }
}
