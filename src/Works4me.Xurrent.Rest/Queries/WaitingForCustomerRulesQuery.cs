using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WaitingForCustomerRules"/> records.
    /// </summary>
    public sealed class WaitingForCustomerRulesQuery
        : Query<WaitingForCustomerRulesQuery, WaitingForCustomerRules.PredefinedFilter, WaitingForCustomerRules.Field, WaitingForCustomerRules.FilterField, WaitingForCustomerRules.OrderField>
    {
    }
}
