using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WorkflowTaskTemplate"/> records.
    /// </summary>
    public sealed class WorkflowTaskTemplateQuery
        : Query<WorkflowTaskTemplateQuery, WorkflowTaskTemplate.PredefinedFilter, WorkflowTaskTemplate.Field, WorkflowTaskTemplate.FilterField, WorkflowTaskTemplate.OrderField>
    {
    }
}
