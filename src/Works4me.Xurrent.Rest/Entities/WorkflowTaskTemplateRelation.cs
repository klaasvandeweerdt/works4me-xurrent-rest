using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent workflow task template relation.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class WorkflowTaskTemplateRelation : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="WorkflowTaskTemplateRelation"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The failure task template field.
            /// </summary>
            [XurrentEnum("failure_task_template")]
            FailureTaskTemplate,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The phase name field.
            /// </summary>
            [XurrentEnum("phase_name")]
            PhaseName,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The workflow task template field.
            /// </summary>
            [XurrentEnum("task_template")]
            WorkflowTaskTemplate
        }

        /// <summary>
        /// Represents the absence of supported filters for a query.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the absence of supported predefined filters for a query.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the absence of supported ordering fields for a query.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Specifies that no ordering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        private DateTime? _createdAt;
        private WorkflowTaskTemplate? _failureTaskTemplate;
        private string? _phaseName;
        private DateTime? _updatedAt;
        private WorkflowTaskTemplate? _workflowTaskTemplate;

        /// <summary>
        /// Gets the date and time at which the workflow task template relation was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the workflow task template that is assigned when the task is failed or rejected.
        /// </summary>
        [XurrentField("failure_task_template")]
        public WorkflowTaskTemplate? FailureTaskTemplate
        {
            get => _failureTaskTemplate;
            set => _failureTaskTemplate = SetValue("failure_task_template", _failureTaskTemplate, value);
        }

        /// <summary>
        /// Gets or sets the name of the workflow template phase to which the task template relation belongs.
        /// </summary>
        [XurrentField("phase_name")]
        public string? PhaseName
        {
            get => _phaseName;
            set => _phaseName = SetValue("phase_name", _phaseName, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the workflow task template relation.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the related workflow task template.
        /// </summary>
        [XurrentField("task_template")]
        public WorkflowTaskTemplate? WorkflowTaskTemplate
        {
            get => _workflowTaskTemplate;
            set => _workflowTaskTemplate = SetValue("task_template", _workflowTaskTemplate, value);
        }

        /// <summary>
        /// Creates a new workflow task template relation instance.
        /// </summary>
        public WorkflowTaskTemplateRelation()
        {
        }

        /// <summary>
        /// Creates a new workflow task template relation instance.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow task template relation.</param>
        public WorkflowTaskTemplateRelation(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new workflow task template relation instance.
        /// </summary>
        /// <param name="workflowTaskTemplate">The workflow task template of the workflow task template relation.</param>
        public WorkflowTaskTemplateRelation(WorkflowTaskTemplate workflowTaskTemplate)
        {
            _workflowTaskTemplate = SetValue("task_template", workflowTaskTemplate);
        }
    }
}
