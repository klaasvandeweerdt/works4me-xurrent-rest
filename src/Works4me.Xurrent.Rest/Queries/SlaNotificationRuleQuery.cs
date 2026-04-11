using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="SlaNotificationRule"/> records.
    /// </summary>
    public sealed class SlaNotificationRuleQuery
        : Query<SlaNotificationRuleQuery, SlaNotificationRule.PredefinedFilter, SlaNotificationRule.Field, SlaNotificationRule.FilterField, SlaNotificationRule.OrderField>
    {
    }
}
