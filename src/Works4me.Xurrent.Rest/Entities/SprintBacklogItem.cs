using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent sprint backlog object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class SprintBacklogItem : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="SprintBacklogItem"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The done field.
            /// </summary>
            [XurrentEnum("done")]
            Done,

            /// <summary>
            /// The estimate field.
            /// </summary>
            [XurrentEnum("estimate")]
            Estimate,

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
            /// The planned field.
            /// </summary>
            [XurrentEnum("planned")]
            Planned,

            /// <summary>
            /// The position field.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// The problem field.
            /// </summary>
            [XurrentEnum("problem", IgnoreInFieldSelection = true)]
            Problem,

            /// <summary>
            /// The project task field.
            /// </summary>
            [XurrentEnum("project_task", IgnoreInFieldSelection = true)]
            ProjectTask,

            /// <summary>
            /// The request field.
            /// </summary>
            [XurrentEnum("request", IgnoreInFieldSelection = true)]
            Request,

            /// <summary>
            /// The sprint field.
            /// </summary>
            [XurrentEnum("sprint")]
            Sprint,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The workflow task field.
            /// </summary>
            [XurrentEnum("task", IgnoreInFieldSelection = true)]
            WorkflowTask
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="SprintBacklogItem"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters sprint backlog items by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters sprint backlog items by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
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
        /// Represents the fields used to order a <see cref="SprintBacklogItem"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts sprint backlog items by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts sprint backlog items by position.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// Sorts sprint backlog items by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private DateTime? _createdAt;
        private bool? _done;
        private int? _estimate;
        private bool? _planned;
        private int? _position;
        private Problem? _problem;
        private ProjectTask? _projectTask;
        private Request? _request;
        private Sprint? _sprint;
        private DateTime? _updatedAt;
        private WorkflowTask? _workflowTask;

        /// <summary>
        /// Gets the date and time when the sprint backlog item was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets a value indicating whether the sprint backlog item is done.
        /// </summary>
        [XurrentField("done")]
        public bool? Done
        {
            get => _done;
            internal set => _done = value;
        }

        /// <summary>
        /// Gets or sets the estimate of the relative size of the sprint backlog item.
        /// </summary>
        [XurrentField("estimate")]
        public int? Estimate
        {
            get => _estimate;
            set => _estimate = SetValue("estimate", _estimate, value);
        }

        /// <summary>
        /// Gets a value indicating whether the sprint backlog item is planned.
        /// </summary>
        [XurrentField("planned")]
        public bool? Planned
        {
            get => _planned;
            internal set => _planned = value;
        }

        /// <summary>
        /// Gets or sets the position of the sprint backlog item on the sprint backlog.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            set => _position = SetValue("position", _position, value);
        }

        /// <summary>
        /// Gets the problem associated with the sprint backlog item.
        /// </summary>
        [XurrentField("problem")]
        public Problem? Problem
        {
            get => _problem;
            internal set => _problem = value;
        }

        /// <summary>
        /// Gets the project task associated with the sprint backlog item.
        /// </summary>
        [XurrentField("project_task")]
        public ProjectTask? ProjectTask
        {
            get => _projectTask;
            internal set => _projectTask = value;
        }

        /// <summary>
        /// Gets the request associated with the sprint backlog item.
        /// </summary>
        [XurrentField("request")]
        public Request? Request
        {
            get => _request;
            internal set => _request = value;
        }

        /// <summary>
        /// Gets the sprint associated with the sprint backlog item.
        /// </summary>
        [XurrentField("sprint")]
        public Sprint? Sprint
        {
            get => _sprint;
            internal set => _sprint = value;
        }

        /// <summary>
        /// Gets the date and time when the sprint backlog item was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets the workflow task associated with the sprint backlog item.
        /// </summary>
        [XurrentField("task")]
        public WorkflowTask? WorkflowTask
        {
            get => _workflowTask;
            internal set => _workflowTask = value;
        }

        /// <summary>
        /// Creates a new sprint backlog item instance.
        /// </summary>
        public SprintBacklogItem()
        {
        }

        /// <summary>
        /// Creates a new sprint backlog item instance.
        /// </summary>
        /// <param name="id">The unique identifier of the sprint backlog item.</param>
        public SprintBacklogItem(long id)
        {
            Id = id;
        }
    }
}
