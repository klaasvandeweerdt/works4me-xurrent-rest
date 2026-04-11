using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WorkflowTask"/> records.
    /// </summary>
    public sealed class WorkflowTaskQuery
        : Query<WorkflowTaskQuery, WorkflowTask.PredefinedFilter, WorkflowTask.Field, WorkflowTask.FilterField, WorkflowTask.OrderField>
    {
    }
}
