using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WorkflowTemplatePhase"/> records.
    /// </summary>
    public sealed class WorkflowTemplatePhaseQuery
        : Query<WorkflowTemplatePhaseQuery, WorkflowTemplatePhase.PredefinedFilter, WorkflowTemplatePhase.Field, WorkflowTemplatePhase.FilterField, WorkflowTemplatePhase.OrderField>
    {
    }
}
