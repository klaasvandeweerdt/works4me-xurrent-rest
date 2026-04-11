using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WorkflowTaskTemplateRelation"/> records.
    /// </summary>
    public sealed class WorkflowTaskTemplateRelationQuery
        : Query<WorkflowTaskTemplateRelationQuery, WorkflowTaskTemplateRelation.PredefinedFilter, WorkflowTaskTemplateRelation.Field, WorkflowTaskTemplateRelation.FilterField, WorkflowTaskTemplateRelation.OrderField>
    {
    }
}
