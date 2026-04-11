using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AppInstance"/> records.
    /// </summary>
    public sealed class AppInstanceQuery
        : Query<AppInstanceQuery, AppInstance.PredefinedFilter, AppInstance.Field, AppInstance.FilterField, AppInstance.OrderField>
    {
    }
}
