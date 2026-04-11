using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Workflow"/> records.
    /// </summary>
    public sealed class WorkflowQuery
        : Query<WorkflowQuery, Workflow.PredefinedFilter, Workflow.Field, Workflow.FilterField, Workflow.OrderField>
    {
    }
}
