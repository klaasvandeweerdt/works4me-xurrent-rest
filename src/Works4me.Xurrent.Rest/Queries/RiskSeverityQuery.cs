using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="RiskSeverity"/> records.
    /// </summary>
    public sealed class RiskSeverityQuery
        : Query<RiskSeverityQuery, RiskSeverity.PredefinedFilter, RiskSeverity.Field, RiskSeverity.FilterField, RiskSeverity.OrderField>
    {
    }
}
