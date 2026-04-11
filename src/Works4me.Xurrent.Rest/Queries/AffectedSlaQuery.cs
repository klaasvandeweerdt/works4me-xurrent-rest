using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AffectedSla"/> records.
    /// </summary>
    public sealed class AffectedSlaQuery
        : Query<AffectedSlaQuery, AffectedSla.PredefinedFilter, AffectedSla.Field, AffectedSla.FilterField, AffectedSla.OrderField>
    {
    }
}
