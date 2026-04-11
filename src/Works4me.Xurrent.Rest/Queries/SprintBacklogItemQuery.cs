using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="SprintBacklogItem"/> records.
    /// </summary>
    public sealed class SprintBacklogItemQuery
        : Query<SprintBacklogItemQuery, SprintBacklogItem.PredefinedFilter, SprintBacklogItem.Field, SprintBacklogItem.FilterField, SprintBacklogItem.OrderField>
    {
    }
}
