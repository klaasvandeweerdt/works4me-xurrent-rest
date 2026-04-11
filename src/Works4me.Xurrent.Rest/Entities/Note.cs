using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent note object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Note : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Note"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

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
            /// The inbound email field.
            /// </summary>
            [XurrentEnum("inbound_email")]
            InboundEmail,

            /// <summary>
            /// The internal field.
            /// </summary>
            [XurrentEnum("internal")]
            Internal,

            /// <summary>
            /// The internal account field.
            /// </summary>
            [XurrentEnum("internal_account", IgnoreInFieldSelection = true)]
            InternalAccount,

            /// <summary>
            /// The medium field.
            /// </summary>
            [XurrentEnum("medium")]
            Medium,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The person field.
            /// </summary>
            [XurrentEnum("person")]
            Person,

            /// <summary>
            /// The suppress note added notifications field.
            /// </summary>
            [XurrentEnum("suppress_note_added_notifications", IgnoreInFieldSelection = true)]
            SuppressNoteAddedNotifications,

            /// <summary>
            /// The text field.
            /// </summary>
            [XurrentEnum("text")]
            Text
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Note"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by medium.
            /// </summary>
            [XurrentEnum("medium")]
            Medium,

            /// <summary>
            /// Filters by person.
            /// </summary>
            [XurrentEnum("person")]
            Person
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Note"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all internal notes of a request.
            /// </summary>
            [XurrentEnum("internal")]
            Internal,

            /// <summary>
            /// Lists all public notes of a request.
            /// </summary>
            [XurrentEnum("public")]
            Public
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Note"/> object.
        /// </summary>
        public enum OrderField
        {
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
            /// Sorts by the person identifier.
            /// </summary>
            [XurrentEnum("person_id")]
            PersonId
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private InboundEmail? _inboundEmail;
        private bool? _internal;
        private Account? _internalAccount;
        private NoteMedium? _medium;
        private Person? _person;
        private bool? _suppressNoteAddedNotifications;
        private string? _text;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the attachments associated with the note.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the note was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the inbound email that led to the creation of the note.
        /// </summary>
        [XurrentField("inbound_email")]
        public InboundEmail? InboundEmail
        {
            get => _inboundEmail;
            internal set => _inboundEmail = value;
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
        /// Gets the internal account associated with the note.
        /// </summary>
        [XurrentField("internal_account")]
        public Account? InternalAccount
        {
            get => _internalAccount;
            internal set => _internalAccount = value;
        }

        /// <summary>
        /// Gets the medium used to add the note.
        /// </summary>
        [XurrentField("medium")]
        public NoteMedium? Medium
        {
            get => _medium;
            internal set => _medium = value;
        }

        /// <summary>
        /// Gets or sets the person who created the note.
        /// </summary>
        [XurrentField("person")]
        public Person? Person
        {
            get => _person;
            set => _person = SetValue("person", _person, value);
        }

        /// <summary>
        /// Sets a value indicating whether note added notifications are suppressed.
        /// </summary>
        [XurrentField("suppress_note_added_notifications")]
        public bool? SuppressNoteAddedNotifications
        {
            get => _suppressNoteAddedNotifications;
            set => _suppressNoteAddedNotifications = SetValue("suppress_note_added_notifications", _suppressNoteAddedNotifications, value);
        }

        /// <summary>
        /// Gets or sets the note text in markdown.
        /// </summary>
        [XurrentField("text")]
        public string? Text
        {
            get => _text;
            set => _text = SetValue("text", _text, value);
        }

        /// <summary>
        /// Creates a new note instance.
        /// </summary>
        public Note()
        {
        }

        /// <summary>
        /// Creates a new note instance.
        /// </summary>
        /// <param name="id">The unique identifier of the note.</param>
        public Note(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new note instance.
        /// </summary>
        /// <param name="person">The person of the note.</param>
        /// <param name="text">The text of the note.</param>
        public Note(Person person, string text)
        {
            _person = SetValue("person", person);
            _text = SetValue("text", text);
        }
    }
}
