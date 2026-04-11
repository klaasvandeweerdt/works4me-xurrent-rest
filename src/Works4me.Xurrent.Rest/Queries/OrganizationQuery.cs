using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Organization"/> records.
    /// </summary>
    public sealed class OrganizationQuery
        : Query<OrganizationQuery, Organization.PredefinedFilter, Organization.Field, Organization.FilterField, Organization.OrderField>
    {
    }
}
