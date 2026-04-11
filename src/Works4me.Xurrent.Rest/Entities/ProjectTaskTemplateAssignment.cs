using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent project task template assignment object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ProjectTaskTemplateAssignment : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ProjectTaskTemplateAssignment"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The assignee field.
            /// </summary>
            [XurrentEnum("assignee")]
            Assignee,

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
            /// The planned effort field.
            /// </summary>
            [XurrentEnum("planned_effort")]
            PlannedEffort
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

        private Person? _assignee;
        private int? _plannedEffort;

        /// <summary>
        /// Gets or sets the assignee for the project task template assignment.
        /// </summary>
        [XurrentField("assignee")]
        public Person? Assignee
        {
            get => _assignee;
            set => _assignee = SetValue("assignee", _assignee, value);
        }

        /// <summary>
        /// Gets or sets the planned effort, expressed in minutes, for the assignee.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            set => _plannedEffort = SetValue("planned_effort", _plannedEffort, value);
        }

        /// <summary>
        /// Creates a new project task template assignment instance.
        /// </summary>
        public ProjectTaskTemplateAssignment()
        {
        }

        /// <summary>
        /// Creates a new project task template assignment instance.
        /// </summary>
        /// <param name="id">The unique identifier of the project task template assignment.</param>
        public ProjectTaskTemplateAssignment(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new project task template assignment instance.
        /// </summary>
        /// <param name="assignee">The assignee of the project task template assignment.</param>
        public ProjectTaskTemplateAssignment(Person assignee)
        {
            _assignee = SetValue("assignee", assignee);
        }
    }
}
