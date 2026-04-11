using System;
using System.Diagnostics;
using System.Text.Json;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent CI staged change object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class CiStagedChange : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="CiStagedChange"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The current values field.
            /// </summary>
            [XurrentEnum("current_values")]
            CurrentValues,

            /// <summary>
            /// The delta field.
            /// </summary>
            [XurrentEnum("delta")]
            Delta,

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
            /// The proposed values field.
            /// </summary>
            [XurrentEnum("proposed_values")]
            ProposedValues,

            /// <summary>
            /// The reviewed at field.
            /// </summary>
            [XurrentEnum("reviewed_at")]
            ReviewedAt,

            /// <summary>
            /// The reviewer note field.
            /// </summary>
            [XurrentEnum("reviewer_note")]
            ReviewerNote,

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

        private DateTime? _createdAt;
        private JsonElement? _currentValues;
        private bool? _delta;
        private JsonElement? _proposedValues;
        private DateTime? _reviewedAt;
        private string? _reviewerNote;
        private string? _source;
        private string? _sourceID;
        private CiStagedChangeStatus? _status;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time at which the staged change was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the original values of the configuration item fields at the time the change was staged.
        /// </summary>
        [XurrentField("current_values")]
        public JsonElement? CurrentValues
        {
            get => _currentValues;
            internal set => _currentValues = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether there are differences between the current and proposed values.
        /// </summary>
        [XurrentField("delta")]
        public bool? Delta
        {
            get => _delta;
            internal set => _delta = value;
        }

        /// <summary>
        /// Gets or sets the proposed values for the configuration item.<br />
        /// This JSON object is only used when approving.<br />
        /// The keys must be a subset of the original proposed values.
        /// </summary>
        [XurrentField("proposed_values")]
        public JsonElement? ProposedValues
        {
            get => _proposedValues;
            internal set => _proposedValues = value;
        }

        /// <summary>
        /// Gets or sets the date and time at which the staged change was reviewed.
        /// </summary>
        [XurrentField("reviewed_at")]
        public DateTime? ReviewedAt
        {
            get => _reviewedAt;
            internal set => _reviewedAt = value;
        }

        /// <summary>
        /// Gets or sets the note from the reviewer explaining the decision.
        /// </summary>
        [XurrentField("reviewer_note")]
        public string? ReviewerNote
        {
            get => _reviewerNote;
            internal set => _reviewerNote = value;
        }

        /// <summary>
        /// Gets or sets the source of the staged change.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            internal set => _source = value;
        }

        /// <summary>
        /// Gets or sets the source identifier of the staged change.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            internal set => _sourceID = value;
        }

        /// <summary>
        /// Gets or sets the status of the staged change.
        /// </summary>
        [XurrentField("status")]
        public CiStagedChangeStatus? Status
        {
            get => _status;
            internal set => _status = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the staged change.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new configuration item staged change instance.
        /// </summary>
        public CiStagedChange()
        {
        }

        /// <summary>
        /// Creates a new configuration item staged change instance.
        /// </summary>
        /// <param name="id">The unique identifier of the configuration item staged change.</param>
        public CiStagedChange(long id)
        {
            Id = id;
        }
    }
}
