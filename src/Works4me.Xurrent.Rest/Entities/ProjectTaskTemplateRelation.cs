using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent project task template relation object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ProjectTaskTemplateRelation : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ProjectTaskTemplateRelation"/> object.
        /// </summary>
        public enum Field
        {
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
            /// The task template field.
            /// </summary>
            [XurrentEnum("task_template")]
            TaskTemplate
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

        private string? _phaseName;
        private ProjectTaskTemplate? _taskTemplate;

        /// <summary>
        /// Gets or sets the name of the project template phase.
        /// </summary>
        [XurrentField("phase_name")]
        public string? PhaseName
        {
            get => _phaseName;
            set => _phaseName = SetValue("phase_name", _phaseName, value);
        }

        /// <summary>
        /// Gets or sets the project task template.
        /// </summary>
        [XurrentField("task_template")]
        public ProjectTaskTemplate? TaskTemplate
        {
            get => _taskTemplate;
            set => _taskTemplate = SetValue("task_template", _taskTemplate, value);
        }

        /// <summary>
        /// Creates a new project task template relation instance.
        /// </summary>
        public ProjectTaskTemplateRelation()
        {
        }

        /// <summary>
        /// Creates a new project task template relation instance.
        /// </summary>
        /// <param name="id">The unique identifier of the project task template relation.</param>
        public ProjectTaskTemplateRelation(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new project task template relation instance.
        /// </summary>
        /// <param name="phaseName">The phase name of the project task template relation.</param>
        /// <param name="taskTemplate">The task template of the project task template relation.</param>
        public ProjectTaskTemplateRelation(string phaseName, ProjectTaskTemplate taskTemplate)
        {
            _phaseName = SetValue("phase_name", phaseName);
            _taskTemplate = SetValue("task_template", taskTemplate);
        }
    }
}
