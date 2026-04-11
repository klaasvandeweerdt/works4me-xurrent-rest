using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ProjectTemplate"/> records.
    /// </summary>
    public sealed class ProjectTemplateQuery
        : Query<ProjectTemplateQuery, ProjectTemplate.PredefinedFilter, ProjectTemplate.Field, ProjectTemplate.FilterField, ProjectTemplate.OrderField>
    {
    }
}
