using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent automation rule object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AutomationRule : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AutomationRule"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The actions field.
            /// </summary>
            [XurrentEnum("actions")]
            Actions,

            /// <summary>
            /// The actions html field.
            /// </summary>
            [XurrentEnum("actions_html")]
            ActionsHtml,

            /// <summary>
            /// The condition field.
            /// </summary>
            [XurrentEnum("condition")]
            Condition,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

            /// <summary>
            /// The description html field.
            /// </summary>
            [XurrentEnum("description_html")]
            DescriptionHtml,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The expressions field.
            /// </summary>
            [XurrentEnum("expressions")]
            Expressions,

            /// <summary>
            /// The generic field.
            /// </summary>
            [XurrentEnum("generic")]
            Generic,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The name field.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The position field.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// The project task field.
            /// </summary>
            [XurrentEnum("project_task", IgnoreInFieldSelection = true)]
            ProjectTask,

            /// <summary>
            /// The project task template field.
            /// </summary>
            [XurrentEnum("project_task_template", IgnoreInFieldSelection = true)]
            ProjectTaskTemplate,

            /// <summary>
            /// The project template field.
            /// </summary>
            [XurrentEnum("project_template", IgnoreInFieldSelection = true)]
            ProjectTemplate,

            /// <summary>
            /// The request field.
            /// </summary>
            [XurrentEnum("request", IgnoreInFieldSelection = true)]
            Request,

            /// <summary>
            /// The request template field.
            /// </summary>
            [XurrentEnum("request_template", IgnoreInFieldSelection = true)]
            RequestTemplate,

            /// <summary>
            /// The source field.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// The source identifier field.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// The trigger field.
            /// </summary>
            [XurrentEnum("trigger")]
            Trigger,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The workflow field.
            /// </summary>
            [XurrentEnum("workflow", IgnoreInFieldSelection = true)]
            Workflow,

            /// <summary>
            /// The workflow task field.
            /// </summary>
            [XurrentEnum("task", IgnoreInFieldSelection = true)]
            WorkflowTask,

            /// <summary>
            /// The workflow task template field.
            /// </summary>
            [XurrentEnum("task_template", IgnoreInFieldSelection = true)]
            WorkflowTaskTemplate,

            /// <summary>
            /// The workflow template field.
            /// </summary>
            [XurrentEnum("workflow_template", IgnoreInFieldSelection = true)]
            WorkflowTemplate
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="AutomationRule"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters automation rules by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters automation rules by identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID
        }

        /// <summary>
        /// Represents the predefined filters of an <see cref="AutomationRule"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled automation rules.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled automation rules.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled,

            /// <summary>
            /// Lists all automation rules for configuration items.
            /// </summary>
            [XurrentEnum("for_cis")]
            ForCis,

            /// <summary>
            /// Lists all automation rules for problems.
            /// </summary>
            [XurrentEnum("for_problems")]
            ForProblems,

            /// <summary>
            /// Lists all automation rules for project task templates.
            /// </summary>
            [XurrentEnum("for_project_task_templates")]
            ForProjectTaskTemplates,

            /// <summary>
            /// Lists all automation rules for project tasks.
            /// </summary>
            [XurrentEnum("for_project_tasks")]
            ForProjectTasks,

            /// <summary>
            /// Lists all automation rules for project templates.
            /// </summary>
            [XurrentEnum("for_project_templates")]
            ForProjectTemplates,

            /// <summary>
            /// Lists all automation rules for request templates.
            /// </summary>
            [XurrentEnum("for_request_templates")]
            ForRequestTemplates,

            /// <summary>
            /// Lists all automation rules for requests.
            /// </summary>
            [XurrentEnum("for_requests")]
            ForRequests,

            /// <summary>
            /// Lists all automation rules for risks.
            /// </summary>
            [XurrentEnum("for_risks")]
            ForRisks,

            /// <summary>
            /// Lists all automation rules for SCIM groups.
            /// </summary>
            [XurrentEnum("for_scim_groups")]
            ForScimGroups,

            /// <summary>
            /// Lists all automation rules for SCIM users.
            /// </summary>
            [XurrentEnum("for_scim_users")]
            ForScimUsers,

            /// <summary>
            /// Lists all automation rules for task templates.
            /// </summary>
            [XurrentEnum("for_task_templates")]
            ForTaskTemplates,

            /// <summary>
            /// Lists all automation rules for tasks.
            /// </summary>
            [XurrentEnum("for_tasks")]
            ForTasks,

            /// <summary>
            /// Lists all automation rules for workflow templates.
            /// </summary>
            [XurrentEnum("for_workflow_templates")]
            ForWorkflowTemplates,

            /// <summary>
            /// Lists all automation rules for workflows.
            /// </summary>
            [XurrentEnum("for_workflows")]
            ForWorkflows
        }

        /// <summary>
        /// Represents the fields used to order an <see cref="AutomationRule"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts automation rules by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts automation rules by their position.
            /// </summary>
            [XurrentEnum("position")]
            Position
        }

        private string? _actions;
        private string? _actionsHtml;
        private string? _condition;
        private DateTime? _createdAt;
        private string? _description;
        private string? _descriptionHtml;
        private bool? _disabled;
        private string? _expressions;
        private string? _generic;
        private string? _name;
        private int? _position;
        private ProjectTask? _projectTask;
        private ProjectTaskTemplate? _projectTaskTemplate;
        private ProjectTemplate? _projectTemplate;
        private Request? _request;
        private RequestTemplate? _requestTemplate;
        private string? _source;
        private string? _sourceID;
        private string? _trigger;
        private DateTime? _updatedAt;
        private Workflow? _workflow;
        private WorkflowTask? _workflowTask;
        private WorkflowTaskTemplate? _workflowTaskTemplate;
        private WorkflowTemplate? _workflowTemplate;

        /// <summary>
        /// Gets or sets the actions that are executed when the condition of the automation rule is met.
        /// </summary>
        [XurrentField("actions")]
        public string? Actions
        {
            get => _actions;
            set => _actions = SetValue("actions", _actions, value);
        }

        /// <summary>
        /// Gets the actions of the automation rule converted to HTML.
        /// </summary>
        [XurrentField("actions_html")]
        public string? ActionsHtml
        {
            get => _actionsHtml;
            internal set => _actionsHtml = value;
        }

        /// <summary>
        /// Gets or sets the condition that must be met for the automation rule to be applied.
        /// </summary>
        [XurrentField("condition")]
        public string? Condition
        {
            get => _condition;
            set => _condition = SetValue("condition", _condition, value);
        }

        /// <summary>
        /// Gets the date and time at which the automation rule was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the description of the automation rule.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        /// <summary>
        /// Gets the description of the automation rule converted to HTML.
        /// </summary>
        [XurrentField("description_html")]
        public string? DescriptionHtml
        {
            get => _descriptionHtml;
            set => _descriptionHtml = SetValue("description_html", _descriptionHtml, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the automation rule is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the expressions used by the automation rule.
        /// </summary>
        [XurrentField("expressions")]
        public string? Expressions
        {
            get => _expressions;
            set => _expressions = SetValue("expressions", _expressions, value);
        }

        /// <summary>
        /// Gets or sets the generic configuration of the automation rule.
        /// </summary>
        [XurrentField("generic")]
        public string? Generic
        {
            get => _generic;
            set => _generic = SetValue("generic", _generic, value);
        }

        /// <summary>
        /// Gets or sets the name of the automation rule.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the execution order position of the automation rule.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            set => _position = SetValue("position", _position, value);
        }

        /// <summary>
        /// Gets or sets the project task linked to the automation rule.
        /// </summary>
        [XurrentField("project_task")]
        public ProjectTask? ProjectTask
        {
            get => _projectTask;
            set => _projectTask = SetValue("project_task", _projectTask, value);
        }

        /// <summary>
        /// Gets or sets the project task template linked to the automation rule.
        /// </summary>
        [XurrentField("project_task_template")]
        public ProjectTaskTemplate? ProjectTaskTemplate
        {
            get => _projectTaskTemplate;
            set => _projectTaskTemplate = SetValue("project_task_template", _projectTaskTemplate, value);
        }

        /// <summary>
        /// Gets or sets the project template linked to the automation rule.
        /// </summary>
        [XurrentField("project_template")]
        public ProjectTemplate? ProjectTemplate
        {
            get => _projectTemplate;
            set => _projectTemplate = SetValue("project_template", _projectTemplate, value);
        }

        /// <summary>
        /// Gets or sets the request linked to the automation rule.
        /// </summary>
        [XurrentField("request")]
        public Request? Request
        {
            get => _request;
            set => _request = SetValue("request", _request, value);
        }

        /// <summary>
        /// Gets or sets the request template linked to the automation rule.
        /// </summary>
        [XurrentField("request_template")]
        public RequestTemplate? RequestTemplate
        {
            get => _requestTemplate;
            set => _requestTemplate = SetValue("request_template", _requestTemplate, value);
        }

        /// <summary>
        /// Gets or sets the source of the automation rule.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the automation rule in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the trigger that determines when the automation rule is evaluated.
        /// </summary>
        [XurrentField("trigger")]
        public string? Trigger
        {
            get => _trigger;
            set => _trigger = SetValue("trigger", _trigger, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the automation rule.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the workflow linked to the automation rule.
        /// </summary>
        [XurrentField("workflow")]
        public Workflow? Workflow
        {
            get => _workflow;
            set => _workflow = SetValue("workflow", _workflow, value);
        }

        /// <summary>
        /// Gets or sets the workflow task linked to the automation rule.
        /// </summary>
        [XurrentField("task")]
        public WorkflowTask? WorkflowTask
        {
            get => _workflowTask;
            set => _workflowTask = SetValue("task", _workflowTask, value);
        }

        /// <summary>
        /// Gets or sets the workflow task template linked to the automation rule.
        /// </summary>
        [XurrentField("task_template")]
        public WorkflowTaskTemplate? WorkflowTaskTemplate
        {
            get => _workflowTaskTemplate;
            set => _workflowTaskTemplate = SetValue("task_template", _workflowTaskTemplate, value);
        }

        /// <summary>
        /// Gets or sets the workflow template linked to the automation rule.
        /// </summary>
        [XurrentField("workflow_template")]
        public WorkflowTemplate? WorkflowTemplate
        {
            get => _workflowTemplate;
            set => _workflowTemplate = SetValue("workflow_template", _workflowTemplate, value);
        }

        /// <summary>
        /// Creates a new automation rule instance.
        /// </summary>
        public AutomationRule()
        {
        }

        /// <summary>
        /// Creates a new automation rule instance.
        /// </summary>
        /// <param name="id">The unique identifier of the automation rule.</param>
        public AutomationRule(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new automation rule instance.
        /// </summary>
        /// <param name="condition">The condition of the automation rule.</param>
        /// <param name="name">The name of the automation rule.</param>
        /// <param name="trigger">The trigger of the automation rule.</param>
        public AutomationRule(string condition, string name, string trigger)
        {
            _condition = SetValue("condition", condition);
            _name = SetValue("name", name);
            _trigger = SetValue("trigger", trigger);
        }
    }
}
