using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent workflow phase object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class WorkflowPhase : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="WorkflowPhase"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The completed at field.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

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
            /// The started at field.
            /// </summary>
            [XurrentEnum("started_at")]
            StartedAt,

            /// <summary>
            /// The status field.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
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

        private DateTime? _completedAt;
        private DateTime? _createdAt;
        private string? _name;
        private int? _position;
        private DateTime? _startedAt;
        private WorkflowPhaseStatus? _status;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time at which the workflow phase was completed.
        /// </summary>
        [XurrentField("completed_at")]
        public DateTime? CompletedAt
        {
            get => _completedAt;
            internal set => _completedAt = value;
        }

        /// <summary>
        /// Gets the date and time at which the workflow phase was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the name of the workflow phase.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the position of the workflow phase.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            set => _position = SetValue("position", _position, value);
        }

        /// <summary>
        /// Gets the date and time at which the workflow phase was started.
        /// </summary>
        [XurrentField("started_at")]
        public DateTime? StartedAt
        {
            get => _startedAt;
            internal set => _startedAt = value;
        }

        /// <summary>
        /// Gets or sets the status of the workflow phase.
        /// </summary>
        [XurrentField("status")]
        public WorkflowPhaseStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the workflow phase.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new workflow phase instance.
        /// </summary>
        public WorkflowPhase()
        {
        }

        /// <summary>
        /// Creates a new workflow phase instance.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow phase.</param>
        public WorkflowPhase(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new workflow phase instance.
        /// </summary>
        /// <param name="name">The name of the workflow phase.</param>
        public WorkflowPhase(string name)
        {
            _name = SetValue("name", name);
        }
    }
}
