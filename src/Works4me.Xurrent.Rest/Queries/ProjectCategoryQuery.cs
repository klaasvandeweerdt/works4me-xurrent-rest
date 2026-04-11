using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ProjectCategory"/> records.
    /// </summary>
    public sealed class ProjectCategoryQuery
        : Query<ProjectCategoryQuery, ProjectCategory.PredefinedFilter, ProjectCategory.Field, ProjectCategory.FilterField, ProjectCategory.OrderField>
    {
    }
}
