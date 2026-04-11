using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="RfcType"/> records.
    /// </summary>
    public sealed class RfcTypeQuery
        : Query<RfcTypeQuery, RfcType.PredefinedFilter, RfcType.Field, RfcType.FilterField, RfcType.OrderField>
    {
    }
}
