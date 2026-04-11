using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ServiceCategory"/> records.
    /// </summary>
    public sealed class ServiceCategoryQuery
        : Query<ServiceCategoryQuery, ServiceCategory.PredefinedFilter, ServiceCategory.Field, ServiceCategory.FilterField, ServiceCategory.OrderField>
    {
    }
}
