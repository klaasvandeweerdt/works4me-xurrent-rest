using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WorkflowPhase"/> records.
    /// </summary>
    public sealed class WorkflowPhaseQuery
        : Query<WorkflowPhaseQuery, WorkflowPhase.PredefinedFilter, WorkflowPhase.Field, WorkflowPhase.FilterField, WorkflowPhase.OrderField>
    {
    }
}
