using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="RfcTypeRate"/> records.
    /// </summary>
    public sealed class RfcTypeRateQuery
        : Query<RfcTypeRateQuery, RfcTypeRate.PredefinedFilter, RfcTypeRate.Field, RfcTypeRate.FilterField, RfcTypeRate.OrderField>
    {
    }
}
