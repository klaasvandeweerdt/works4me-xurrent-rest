using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ConfigurationItem"/> records.
    /// </summary>
    public sealed class ConfigurationItemQuery
        : Query<ConfigurationItemQuery, ConfigurationItem.PredefinedFilter, ConfigurationItem.Field, ConfigurationItem.FilterField, ConfigurationItem.OrderField>
    {
    }
}
