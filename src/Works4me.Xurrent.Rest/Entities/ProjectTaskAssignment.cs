using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent project task assignment object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ProjectTaskAssignment : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ProjectTaskAssignment"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The assignee field.
            /// </summary>
            [XurrentEnum("assignee")]
            Assignee,

            /// <summary>
            /// The attachment field.
            /// </summary>
            [XurrentEnum("attachment")]
            Attachment,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

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
            PlannedEffort,

            /// <summary>
            /// The status field.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The waiting until field.
            /// </summary>
            [XurrentEnum("waiting_until")]
            WaitingUntil
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
        private Uri? _attachment;
        private DateTime? _createdAt;
        private int? _plannedEffort;
        private ProjectTaskStatus? _status;
        private DateTime? _updatedAt;
        private DateTime? _waitingUntil;

        /// <summary>
        /// Gets or sets the assignee for the project task assignment.
        /// </summary>
        [XurrentField("assignee")]
        public Person? Assignee
        {
            get => _assignee;
            set => _assignee = SetValue("assignee", _assignee, value);
        }

        /// <summary>
        /// Gets the hyperlink to the project summary PDF for the assignee.
        /// </summary>
        [XurrentField("attachment")]
        public Uri? Attachment
        {
            get => _attachment;
            internal set => _attachment = value;
        }

        /// <summary>
        /// Gets the date and time when the project task assignment was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
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
        /// Gets the status of the project task assignment.
        /// </summary>
        [XurrentField("status")]
        public ProjectTaskStatus? Status
        {
            get => _status;
            internal set => _status = value;
        }

        /// <summary>
        /// Gets the date and time when the project task assignment was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the date and time until which the assignment is waiting.
        /// </summary>
        [XurrentField("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => _waitingUntil;
            set => _waitingUntil = SetValue("waiting_until", _waitingUntil, value);
        }

        /// <summary>
        /// Creates a new project task assignment instance.
        /// </summary>
        public ProjectTaskAssignment()
        {
        }

        /// <summary>
        /// Creates a new project task assignment instance.
        /// </summary>
        /// <param name="id">The unique identifier of the project task assignment.</param>
        public ProjectTaskAssignment(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new project task assignment instance.
        /// </summary>
        /// <param name="assignee">The assignee of the project task assignment.</param>
        public ProjectTaskAssignment(Person assignee)
        {
            _assignee = SetValue("assignee", assignee);
        }
    }
}
