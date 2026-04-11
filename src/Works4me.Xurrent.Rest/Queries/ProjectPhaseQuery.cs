using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ProjectPhase"/> records.
    /// </summary>
    public sealed class ProjectPhaseQuery
        : Query<ProjectPhaseQuery, ProjectPhase.PredefinedFilter, ProjectPhase.Field, ProjectPhase.FilterField, ProjectPhase.OrderField>
    {
    }
}
