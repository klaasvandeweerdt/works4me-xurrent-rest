using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent workflow task template approval object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class WorkflowTaskTemplateApproval : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="WorkflowTaskTemplateApproval"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The approver field.
            /// </summary>
            [XurrentEnum("approver")]
            Approver,

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

        private Person? _approver;
        private int? _plannedEffort;

        /// <summary>
        /// Gets or sets the approver of the workflow task template approval.
        /// </summary>
        [XurrentField("approver")]
        public Person? Approver
        {
            get => _approver;
            set => _approver = SetValue("approver", _approver, value);
        }

        /// <summary>
        /// Gets or sets the planned effort in minutes for the workflow task template approval.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            set => _plannedEffort = SetValue("planned_effort", _plannedEffort, value);
        }

        /// <summary>
        /// Creates a new workflow task template approval instance.
        /// </summary>
        public WorkflowTaskTemplateApproval()
        {
        }

        /// <summary>
        /// Creates a new workflow task template approval instance.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow task template approval.</param>
        public WorkflowTaskTemplateApproval(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new workflow task template approval instance.
        /// </summary>
        /// <param name="approver">The approver of the workflow task template approval.</param>
        public WorkflowTaskTemplateApproval(Person approver)
        {
            _approver = SetValue("approver", approver);
        }
    }
}
