using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Project"/> records.
    /// </summary>
    public sealed class ProjectQuery
        : Query<ProjectQuery, Project.PredefinedFilter, Project.Field, Project.FilterField, Project.OrderField>
    {
    }
}
