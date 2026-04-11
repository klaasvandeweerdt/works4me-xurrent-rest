using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent note create object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class NoteCreate : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="NoteCreate"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments", IgnoreInFieldSelection = true)]
            Attachments,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The internal field.
            /// </summary>
            [XurrentEnum("internal")]
            Internal,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The suppress note added notifications field.
            /// </summary>
            [XurrentEnum("suppress_note_added_notifications")]
            SuppressNoteAddedNotifications,

            /// <summary>
            /// The text field.
            /// </summary>
            [XurrentEnum("text")]
            Text
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

        private ObservableCollection<AttachmentReference>? _attachments;
        private AttachmentReferenceWriter? _attachmentsWriter;
        private bool? _internal;
        private bool? _suppressNoteAddedNotifications;
        private string? _text;

        [XurrentField("attachments")]
        internal ObservableCollection<AttachmentReference> AttachmentsCollection
        {
            get => GetCollection(ref _attachments, OnAttachmentsChanged);
            set => SetCollection(ref _attachments, "attachments", value, OnAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the note.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter Attachments
        {
            get
            {
                _attachmentsWriter ??= new AttachmentReferenceWriter(() => AttachmentsCollection, c => AttachmentsCollection = c);
                return _attachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the note is internal.
        /// </summary>
        [XurrentField("internal")]
        public bool? Internal
        {
            get => _internal;
            set => _internal = SetValue("internal", _internal, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether note added notifications are suppressed.
        /// </summary>
        [XurrentField("suppress_note_added_notifications")]
        public bool? SuppressNoteAddedNotifications
        {
            get => _suppressNoteAddedNotifications;
            set => _suppressNoteAddedNotifications = SetValue("suppress_note_added_notifications", _suppressNoteAddedNotifications, value);
        }

        /// <summary>
        /// Gets or sets the text of the note.
        /// </summary>
        [XurrentField("text")]
        public string? Text
        {
            get => _text;
            set => _text = SetValue("text", _text, value);
        }

        /// <summary>
        /// Creates a new note create instance.
        /// </summary>
        public NoteCreate()
        {
        }

        /// <summary>
        /// Creates a new note create instance.
        /// </summary>
        /// <param name="id">The unique identifier of the note create.</param>
        public NoteCreate(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new note create instance.
        /// </summary>
        /// <param name="text">The text of the note create.</param>
        public NoteCreate(string text)
        {
            _text = SetValue("text", text);
        }

        private void OnAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "attachments");
        }
    }
}
