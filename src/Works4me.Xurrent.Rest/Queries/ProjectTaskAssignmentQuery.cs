using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ProjectTaskAssignment"/> records.
    /// </summary>
    public sealed class ProjectTaskAssignmentQuery
        : Query<ProjectTaskAssignmentQuery, ProjectTaskAssignment.PredefinedFilter, ProjectTaskAssignment.Field, ProjectTaskAssignment.FilterField, ProjectTaskAssignment.OrderField>
    {
    }
}
