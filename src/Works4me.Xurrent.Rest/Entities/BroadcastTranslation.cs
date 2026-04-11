using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent broadcast translation object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class BroadcastTranslation : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="BroadcastTranslation"/> object.
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
            /// The locale field.
            /// </summary>
            [XurrentEnum("locale")]
            Locale,

            /// <summary>
            /// The message field.
            /// </summary>
            [XurrentEnum("message")]
            Message,

            /// <summary>
            /// The message attachments field.
            /// </summary>
            [XurrentEnum("message_attachments", IgnoreInFieldSelection = true)]
            MessageAttachments,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="BroadcastTranslation"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters broadcast translations by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters broadcast translations by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters broadcast translations by locale.
            /// </summary>
            [XurrentEnum("locale")]
            Locale,

            /// <summary>
            /// Filters broadcast translations by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
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
        /// Represents the fields used to order a <see cref="BroadcastTranslation"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts broadcast translations by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts broadcast translations by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts broadcast translations by locale.
            /// </summary>
            [XurrentEnum("locale")]
            Locale,

            /// <summary>
            /// Sorts broadcast translations by message.
            /// </summary>
            [XurrentEnum("message")]
            Message,

            /// <summary>
            /// Sorts broadcast translations by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private string? _locale;
        private string? _message;
        private ObservableCollection<AttachmentReference>? _messageAttachments;
        private AttachmentReferenceWriter? _messageAttachmentsWriter;
        private DateTime? _updatedAt;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the broadcast translation.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the broadcast translation was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the locale of the broadcast translation.
        /// </summary>
        [XurrentField("locale")]
        public string? Locale
        {
            get => _locale;
            set => _locale = SetValue("locale", _locale, value);
        }

        /// <summary>
        /// Gets or sets the message content that is broadcasted for the specified locale.
        /// </summary>
        [XurrentField("message")]
        public string? Message
        {
            get => _message;
            set => _message = SetValue("message", _message, value);
        }

        [XurrentField("message_attachments")]
        internal ObservableCollection<AttachmentReference> MessageAttachmentsCollection
        {
            get => GetCollection(ref _messageAttachments, OnMessageAttachmentsChanged);
            set => SetCollection(ref _messageAttachments, "message_attachments", value, OnMessageAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the message field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter MessageAttachments
        {
            get
            {
                _messageAttachmentsWriter ??= new AttachmentReferenceWriter(() => MessageAttachmentsCollection, c => MessageAttachmentsCollection = c);
                return _messageAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the date and time of the last update of the broadcast translation.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new broadcast translation instance.
        /// </summary>
        public BroadcastTranslation()
        {
        }

        /// <summary>
        /// Creates a new broadcast translation instance.
        /// </summary>
        /// <param name="id">The unique identifier of the broadcast translation.</param>
        public BroadcastTranslation(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new broadcast translation instance.
        /// </summary>
        /// <param name="message">The message of the broadcast translation.</param>
        public BroadcastTranslation(string message)
        {
            _message = SetValue("message", message);
        }

        private void OnMessageAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "message_attachments");
        }
    }
}
