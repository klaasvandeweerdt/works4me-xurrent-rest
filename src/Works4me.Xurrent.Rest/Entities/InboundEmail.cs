using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent inboud email object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class InboundEmail : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="InboundEmail"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The body start field.
            /// </summary>
            [XurrentEnum("body_start")]
            BodyStart,

            /// <summary>
            /// The cc field.
            /// </summary>
            [XurrentEnum("cc")]
            CC,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The failure reason field.
            /// </summary>
            [XurrentEnum("failure_reason")]
            FailureReason,

            /// <summary>
            /// The from field.
            /// </summary>
            [XurrentEnum("from")]
            From,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The message identifier field.
            /// </summary>
            [XurrentEnum("message_id")]
            MessageId,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The note field.
            /// </summary>
            [XurrentEnum("note")]
            Note,

            /// <summary>
            /// The source uri field.
            /// </summary>
            [XurrentEnum("source_uri")]
            SourceUri,

            /// <summary>
            /// The subject field.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// The to field.
            /// </summary>
            [XurrentEnum("to")]
            To
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

        private string? _bodyStart;
        private string? _cC;
        private DateTime? _createdAt;
        private string? _failureReason;
        private string? _from;
        private string? _messageId;
        private Note? _note;
        private Uri? _sourceUri;
        private string? _subject;
        private string? _to;

        /// <summary>
        /// Gets the first 255 characters of the body of the inbound email.
        /// </summary>
        [XurrentField("body_start")]
        public string? BodyStart
        {
            get => _bodyStart;
            internal set => _bodyStart = value;
        }

        /// <summary>
        /// Gets the CC recipients of the inbound email.
        /// </summary>
        [XurrentField("cc")]
        public string? CC
        {
            get => _cC;
            internal set => _cC = value;
        }

        /// <summary>
        /// Gets the date and time at which the inbound email was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the reason why processing of the inbound email failed.
        /// </summary>
        [XurrentField("failure_reason")]
        public string? FailureReason
        {
            get => _failureReason;
            internal set => _failureReason = value;
        }

        /// <summary>
        /// Gets the sender address of the inbound email.
        /// </summary>
        [XurrentField("from")]
        public string? From
        {
            get => _from;
            internal set => _from = value;
        }

        /// <summary>
        /// Gets the value of the Message-ID header of the inbound email.
        /// </summary>
        [XurrentField("message_id")]
        public string? MessageId
        {
            get => _messageId;
            internal set => _messageId = value;
        }

        /// <summary>
        /// Gets the note that was created from the inbound email.
        /// </summary>
        [XurrentField("note")]
        public Note? Note
        {
            get => _note;
            internal set => _note = value;
        }

        /// <summary>
        /// Gets an expiring URL that provides access to the source of the inbound email.
        /// </summary>
        [XurrentField("source_uri")]
        public Uri? SourceUri
        {
            get => _sourceUri;
            internal set => _sourceUri = value;
        }

        /// <summary>
        /// Gets the subject of the inbound email.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            internal set => _subject = value;
        }

        /// <summary>
        /// Gets the recipient of the inbound email.
        /// </summary>
        [XurrentField("to")]
        public string? To
        {
            get => _to;
            internal set => _to = value;
        }

        /// <summary>
        /// Creates a new inbound email instance.
        /// </summary>
        public InboundEmail()
        {
        }

        /// <summary>
        /// Creates a new inbound email instance.
        /// </summary>
        /// <param name="id">The unique identifier of the inbound email.</param>
        public InboundEmail(long id)
        {
            Id = id;
        }
    }
}
