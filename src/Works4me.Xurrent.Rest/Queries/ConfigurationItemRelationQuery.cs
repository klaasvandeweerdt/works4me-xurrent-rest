using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ConfigurationItemRelation"/> records.
    /// </summary>
    public sealed class ConfigurationItemRelationQuery
        : Query<ConfigurationItemRelationQuery, ConfigurationItemRelation.PredefinedFilter, ConfigurationItemRelation.Field, ConfigurationItemRelation.FilterField, ConfigurationItemRelation.OrderField>
    {
    }
}
