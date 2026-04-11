using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Permission"/> records.
    /// </summary>
    public sealed class PermissionQuery
        : Query<PermissionQuery, Permission.PredefinedFilter, Permission.Field, Permission.FilterField, Permission.OrderField>
    {
    }
}
