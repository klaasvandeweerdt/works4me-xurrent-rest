using System;
using System.Diagnostics;
using System.Text.Json;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent audit entry object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AuditEntry : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AuditEntry"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The action field.
            /// </summary>
            [XurrentEnum("action")]
            Action,

            /// <summary>
            /// The changes field.
            /// </summary>
            [XurrentEnum("changes", IgnoreInFieldSelection = true)]
            Changes,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The created by field.
            /// </summary>
            [XurrentEnum("created_by")]
            CreatedBy,

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
            /// The user field.
            /// </summary>
            [XurrentEnum("user")]
            User
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

        private string? _action;
        private JsonElement? _changes;
        private DateTime? _createdAt;
        private Person? _createdBy;
        private Person? _user;

        /// <summary>
        /// Gets the action performed.
        /// </summary>
        [XurrentField("action")]
        public string? Action
        {
            get => _action;
            internal set => _action = value;
        }

        /// <summary>
        /// Gets the changes recorded for the audit entry as structured JSON.
        /// </summary>
        [XurrentField("changes")]
        public JsonElement? Changes
        {
            get => _changes;
            internal set => _changes = value;
        }

        /// <summary>
        /// Gets the date and time at which the audit entry was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the person that performed the action.
        /// </summary>
        [XurrentField("created_by")]
        public Person? CreatedBy
        {
            get => _createdBy;
            internal set => _createdBy = value;
        }

        /// <summary>
        /// Gets the user reference that performed the action.
        /// </summary>
        [XurrentField("user")]
        public Person? User
        {
            get => _user;
            internal set => _user = value;
        }

        /// <summary>
        /// Creates a new audit entry instance.
        /// </summary>
        public AuditEntry()
        {
        }

        /// <summary>
        /// Creates a new audit entry instance.
        /// </summary>
        /// <param name="id">The unique identifier of the audit entry.</param>
        public AuditEntry(long id)
        {
            Id = id;
        }
    }
}
