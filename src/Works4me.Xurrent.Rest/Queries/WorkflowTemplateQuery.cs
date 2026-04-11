using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WorkflowTemplate"/> records.
    /// </summary>
    public sealed class WorkflowTemplateQuery
        : Query<WorkflowTemplateQuery, WorkflowTemplate.PredefinedFilter, WorkflowTemplate.Field, WorkflowTemplate.FilterField, WorkflowTemplate.OrderField>
    {
    }
}
