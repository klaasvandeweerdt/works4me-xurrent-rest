using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AutomationRule"/> records.
    /// </summary>
    public sealed class AutomationRuleQuery
        : Query<AutomationRuleQuery, AutomationRule.PredefinedFilter, AutomationRule.Field, AutomationRule.FilterField, AutomationRule.OrderField>
    {
    }
}
