using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WorkflowType"/> records.
    /// </summary>
    public sealed class WorkflowTypeQuery
        : Query<WorkflowTypeQuery, WorkflowType.PredefinedFilter, WorkflowType.Field, WorkflowType.FilterField, WorkflowType.OrderField>
    {
    }
}
