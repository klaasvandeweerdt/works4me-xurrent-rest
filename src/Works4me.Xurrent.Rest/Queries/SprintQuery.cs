using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Sprint"/> records.
    /// </summary>
    public sealed class SprintQuery
        : Query<SprintQuery, Sprint.PredefinedFilter, Sprint.Field, Sprint.FilterField, Sprint.OrderField>
    {
    }
}
