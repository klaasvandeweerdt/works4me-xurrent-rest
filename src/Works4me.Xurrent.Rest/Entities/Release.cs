using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent release object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Release : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Release"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The completed at field.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// The completion reason field.
            /// </summary>
            [XurrentEnum("completion_reason")]
            CompletionReason,

            /// <summary>
            /// The completion target at field.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

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
            /// The impact field.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// The manager field.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

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
        /// Represents the filterable fields of a <see cref="Release"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by the completion date.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Filters by the completion target date.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Filters by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Filters by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Release"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all completed releases.
            /// </summary>
            [XurrentEnum("completed")]
            Completed,

            /// <summary>
            /// Lists all releases managed by the API user.
            /// </summary>
            [XurrentEnum("managed_by_me")]
            ManagedByMe,

            /// <summary>
            /// Lists all open releases.
            /// </summary>
            [XurrentEnum("open")]
            Open
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Release"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts by the completion date.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Sorts by the completion target date.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Sorts by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Sorts by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _completedAt;
        private WorkflowCompletionReason? _completionReason;
        private DateTime? _completionTargetAt;
        private DateTime? _createdAt;
        private WorkflowImpact? _impact;
        private Person? _manager;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private string? _source;
        private string? _sourceID;
        private WorkflowStatus? _status;
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
        /// Gets the aggregated attachments associated with the release.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time when the release was completed.
        /// </summary>
        [XurrentField("completed_at")]
        public DateTime? CompletedAt
        {
            get => _completedAt;
            internal set => _completedAt = value;
        }

        /// <summary>
        /// Gets the completion reason of the release.
        /// </summary>
        [XurrentField("completion_reason")]
        public WorkflowCompletionReason? CompletionReason
        {
            get => _completionReason;
            internal set => _completionReason = value;
        }

        /// <summary>
        /// Gets the completion target date and time of the release.
        /// </summary>
        [XurrentField("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => _completionTargetAt;
            internal set => _completionTargetAt = value;
        }

        /// <summary>
        /// Gets the date and time when the release was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the maximum impact level associated with the release.
        /// </summary>
        [XurrentField("impact")]
        public WorkflowImpact? Impact
        {
            get => _impact;
            internal set => _impact = value;
        }

        /// <summary>
        /// Gets or sets the manager responsible for coordinating the release.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Sets the note describing the release.<br />
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
        /// Gets or sets the source of the release.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the release.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the status of the release.
        /// </summary>
        [XurrentField("status")]
        public WorkflowStatus? Status
        {
            get => _status;
            internal set => _status = value;
        }

        /// <summary>
        /// Gets or sets the subject of the release.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets the UI extension associated with the release.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time when the release was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new release instance.
        /// </summary>
        public Release()
        {
        }

        /// <summary>
        /// Creates a new release instance.
        /// </summary>
        /// <param name="id">The unique identifier of the release.</param>
        public Release(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new release instance.
        /// </summary>
        /// <param name="manager">The manager of the release.</param>
        /// <param name="subject">The subject of the release.</param>
        public Release(Person manager, string subject)
        {
            _manager = SetValue("manager", manager);
            _subject = SetValue("subject", subject);
        }

        private void OnNoteAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "note_attachments");
        }
    }
}
