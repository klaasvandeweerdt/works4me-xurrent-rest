using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ProjectTask"/> records.
    /// </summary>
    public sealed class ProjectTaskQuery
        : Query<ProjectTaskQuery, ProjectTask.PredefinedFilter, ProjectTask.Field, ProjectTask.FilterField, ProjectTask.OrderField>
    {
    }
}
