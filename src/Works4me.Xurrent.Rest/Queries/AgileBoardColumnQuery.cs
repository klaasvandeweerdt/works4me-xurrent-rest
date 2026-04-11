using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AgileBoardColumn"/> records.
    /// </summary>
    public sealed class AgileBoardColumnQuery
        : Query<AgileBoardColumnQuery, AgileBoardColumn.PredefinedFilter, AgileBoardColumn.Field, AgileBoardColumn.FilterField, AgileBoardColumn.OrderField>
    {
    }
}
