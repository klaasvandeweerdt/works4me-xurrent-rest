using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent workflow task approval object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class WorkflowTaskApproval : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="WorkflowTaskApproval"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The approver field.
            /// </summary>
            [XurrentEnum("approver")]
            Approver,

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

        private Person? _approver;
        private Attachment? _attachment;
        private DateTime? _createdAt;
        private int? _plannedEffort;
        private WorkflowTaskStatus? _status;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets the approver of the workflow task approval.
        /// </summary>
        [XurrentField("approver")]
        public Person? Approver
        {
            get => _approver;
            set => _approver = SetValue("approver", _approver, value);
        }

        /// <summary>
        /// Gets the attachment containing the workflow summary.
        /// </summary>
        [XurrentField("attachment")]
        public Attachment? Attachment
        {
            get => _attachment;
            internal set => _attachment = value;
        }

        /// <summary>
        /// Gets the date and time when the workflow task approval was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the planned effort in minutes for the workflow task approval.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            set => _plannedEffort = SetValue("planned_effort", _plannedEffort, value);
        }

        /// <summary>
        /// Gets the status of the workflow task approval.
        /// </summary>
        [XurrentField("status")]
        public WorkflowTaskStatus? Status
        {
            get => _status;
            internal set => _status = value;
        }

        /// <summary>
        /// Gets the date and time when the workflow task approval was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new workflow task approval instance.
        /// </summary>
        public WorkflowTaskApproval()
        {
        }

        /// <summary>
        /// Creates a new workflow task approval instance.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow task approval.</param>
        public WorkflowTaskApproval(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new workflow task approval instance.
        /// </summary>
        /// <param name="approver">The approver of the workflow task approval.</param>
        public WorkflowTaskApproval(Person approver)
        {
            _approver = SetValue("approver", approver);
        }
    }
}
