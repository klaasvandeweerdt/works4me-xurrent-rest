using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Repesents a Xurrent risk object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Risk : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Risk"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The closed at field.
            /// </summary>
            [XurrentEnum("closed_at")]
            ClosedAt,

            /// <summary>
            /// The closure reason field.
            /// </summary>
            [XurrentEnum("closure_reason")]
            ClosureReason,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The custom fields field.
            /// </summary>
            [XurrentEnum("custom_fields")]
            CustomFields,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The manager field.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

            /// <summary>
            /// The mitigation target at field.
            /// </summary>
            [XurrentEnum("mitigation_target_at")]
            MitigationTargetAt,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The note field.
            /// </summary>
            [XurrentEnum("note", IgnoreInFieldSelection = true)]
            Note,

            /// <summary>
            /// The note attachments field.
            /// </summary>
            [XurrentEnum("note_attachments", IgnoreInFieldSelection = true)]
            NoteAttachments,

            /// <summary>
            /// The resolution duration field.
            /// </summary>
            [XurrentEnum("resolution_duration")]
            ResolutionDuration,

            /// <summary>
            /// The severity field.
            /// </summary>
            [XurrentEnum("severity")]
            Severity,

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
            /// The subject field.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// The user interface extension field.
            /// </summary>
            [XurrentEnum("ui_extension")]
            UiExtension,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Risk"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters risks by closure date.
            /// </summary>
            [XurrentEnum("closed_at")]
            ClosedAt,

            /// <summary>
            /// Filters risks by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters risks by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters risks by mitigation target date.
            /// </summary>
            [XurrentEnum("mitigation_target_at")]
            MitigationTargetAt,

            /// <summary>
            /// Filters risks by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters risks by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters risks by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters risks by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Filters risks by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Risk"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all closed risks.
            /// </summary>
            [XurrentEnum("closed")]
            Closed,

            /// <summary>
            /// Lists all open risks.
            /// </summary>
            [XurrentEnum("open")]
            Open
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Risk"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts risks by closure date.
            /// </summary>
            [XurrentEnum("closed_at")]
            ClosedAt,

            /// <summary>
            /// Sorts risks by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts risks by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts risks by mitigation target date.
            /// </summary>
            [XurrentEnum("mitigation_target_at")]
            MitigationTargetAt,

            /// <summary>
            /// Sorts risks by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts risks by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts risks by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _closedAt;
        private RiskClosureReason? _closureReason;
        private DateTime? _createdAt;
        private Person? _manager;
#if (NET6_0_OR_GREATER)
        private DateOnly? _mitigationTargetAt;
#else
        private DateTime? _mitigationTargetAt;
#endif
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private int? _resolutionDuration;
        private string? _severity;
        private string? _source;
        private string? _sourceID;
        private RiskStatus? _status;
        private string? _subject;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the attachments.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time when the risk was closed.
        /// </summary>
        [XurrentField("closed_at")]
        public DateTime? ClosedAt
        {
            get => _closedAt;
            internal set => _closedAt = value;
        }

        /// <summary>
        /// Gets or sets the closure reason of the risk.
        /// </summary>
        [XurrentField("closure_reason")]
        public RiskClosureReason? ClosureReason
        {
            get => _closureReason;
            set => _closureReason = SetValue("closure_reason", _closureReason, value);
        }

        /// <summary>
        /// Gets the date and time when the risk was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the manager of the risk.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Gets or sets the target date by which the risk should be mitigated.
        /// </summary>
        [XurrentField("mitigation_target_at")]
#if (NET6_0_OR_GREATER)
        public DateOnly? MitigationTargetAt
#else
        public DateTime? MitigationTargetAt
#endif
        {
            get => _mitigationTargetAt;
            set => _mitigationTargetAt = SetValue("mitigation_target_at", _mitigationTargetAt, value);
        }

        /// <summary>
        /// Gets or sets the note of the risk.<br />
        /// This property is write-only.
        /// </summary>
        [XurrentField("note")]
        public string? Note
        {
            get => _note;
            set => _note = SetValue("note", _note, value);
        }

        [XurrentField("note_attachments")]
        internal ObservableCollection<AttachmentReference> NoteAttachmentsCollection
        {
            get => GetCollection(ref _noteAttachments, OnNoteAttachmentsChanged);
            set => SetCollection(ref _noteAttachments, "note_attachments", value, OnNoteAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the note field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter NoteAttachments
        {
            get
            {
                _noteAttachmentsWriter ??= new AttachmentReferenceWriter(() => NoteAttachmentsCollection, c => NoteAttachmentsCollection = c);
                return _noteAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the duration in minutes between creation and closure of the risk.
        /// </summary>
        [XurrentField("resolution_duration")]
        public int? ResolutionDuration
        {
            get => _resolutionDuration;
            set => _resolutionDuration = SetValue("resolution_duration", _resolutionDuration, value);
        }

        /// <summary>
        /// Gets or sets the reference to the severity of the risk.
        /// </summary>
        [XurrentField("severity")]
        public string? Severity
        {
            get => _severity;
            set => _severity = SetValue("severity", _severity, value);
        }

        /// <summary>
        /// Gets or sets the source of the risk.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the risk.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the status of the risk.
        /// </summary>
        [XurrentField("status")]
        public RiskStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the subject of the risk.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets the UI extension associated with the risk.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time when the risk was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new risk instance.
        /// </summary>
        public Risk()
        {
        }

        /// <summary>
        /// Creates a new risk instance.
        /// </summary>
        /// <param name="id">The unique identifier of the risk.</param>
        public Risk(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new risk instance.
        /// </summary>
        /// <param name="subject">The subject of the risk.</param>
        public Risk(string subject)
        {
            _subject = SetValue("subject", subject);
        }

        private void OnNoteAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "note_attachments");
        }
    }
}
