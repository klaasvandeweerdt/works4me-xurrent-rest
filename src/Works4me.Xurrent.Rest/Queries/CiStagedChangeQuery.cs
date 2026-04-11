using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="CiStagedChange"/> records.
    /// </summary>
    public sealed class CiStagedChangeQuery
        : Query<CiStagedChangeQuery, CiStagedChange.PredefinedFilter, CiStagedChange.Field, CiStagedChange.FilterField, CiStagedChange.OrderField>
    {
    }
}
