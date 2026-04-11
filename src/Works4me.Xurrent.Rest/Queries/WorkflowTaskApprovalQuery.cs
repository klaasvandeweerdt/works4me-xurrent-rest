using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WorkflowTaskApproval"/> records.
    /// </summary>
    public sealed class WorkflowTaskApprovalQuery
        : Query<WorkflowTaskApprovalQuery, WorkflowTaskApproval.PredefinedFilter, WorkflowTaskApproval.Field, WorkflowTaskApproval.FilterField, WorkflowTaskApproval.OrderField>
    {
    }
}
