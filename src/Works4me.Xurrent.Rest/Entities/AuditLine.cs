using System;
using System.Diagnostics;
using System.Text.Json;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent audit line object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AuditLine : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AuditLine"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The action field.
            /// </summary>
            [XurrentEnum("action")]
            Action,

            /// <summary>
            /// The audited field.
            /// </summary>
            [XurrentEnum("audited", IgnoreInFieldSelection = true)]
            Audited,

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
        /// Represents the filterable fields of an <see cref="AuditLine"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters audit lines by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters audit lines by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id
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
        /// Represents the fields used to order an <see cref="AuditLine"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts audit lines by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id
        }

        private string? _action;
        private string? _audited;
        private DateTime? _createdAt;
        private Person? _createdBy;
        private JsonElement? _data;
        private Person? _user;

        /// <summary>
        /// Gets the type of transaction that caused the audit entry to be generated.
        /// </summary>
        [XurrentField("action")]
        public string? Action
        {
            get => _action;
            internal set => _action = value;
        }

        /// <summary>
        /// Gets the record type name of the record for which the audit entry was generated.
        /// </summary>
        [XurrentField("audited")]
        public string? Audited
        {
            get => _audited;
            internal set => _audited = value;
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
        /// Gets a reference to the record for which the audit entry was generated.
        /// </summary>
        public JsonElement? Data
        {
            get => _data;
            internal set => _data = value;
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
        /// Creates a new audit line instance.
        /// </summary>
        public AuditLine()
        {
        }

        /// <summary>
        /// Creates a new audit line instance.
        /// </summary>
        /// <param name="id">The unique identifier of the audit line.</param>
        public AuditLine(long id)
        {
            Id = id;
        }
    }
}
