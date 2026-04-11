using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ParentServiceInstance"/> records.
    /// </summary>
    public sealed class ParentServiceInstanceQuery
        : Query<ParentServiceInstanceQuery, ParentServiceInstance.PredefinedFilter, ParentServiceInstance.Field, ParentServiceInstance.FilterField, ParentServiceInstance.OrderField>
    {
    }
}
