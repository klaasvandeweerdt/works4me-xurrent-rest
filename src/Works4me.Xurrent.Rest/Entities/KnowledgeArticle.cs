using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent knowledge article object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class KnowledgeArticle : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="KnowledgeArticle"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The archive date field.
            /// </summary>
            [XurrentEnum("archive_date")]
            ArchiveDate,

            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The covered specialists field.
            /// </summary>
            [XurrentEnum("covered_specialists")]
            CoveredSpecialists,

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
            /// The custom fields field.
            /// </summary>
            [XurrentEnum("custom_fields")]
            CustomFields,

            /// <summary>
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

            /// <summary>
            /// The description attachments field.
            /// </summary>
            [XurrentEnum("description_attachments", IgnoreInFieldSelection = true)]
            DescriptionAttachments,

            /// <summary>
            /// The end users field.
            /// </summary>
            [XurrentEnum("end_users")]
            EndUsers,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The instructions field.
            /// </summary>
            [XurrentEnum("instructions")]
            Instructions,

            /// <summary>
            /// The instructions attachments field.
            /// </summary>
            [XurrentEnum("instructions_attachments", IgnoreInFieldSelection = true)]
            InstructionsAttachments,

            /// <summary>
            /// The internal specialists field.
            /// </summary>
            [XurrentEnum("internal_specialists")]
            InternalSpecialists,

            /// <summary>
            /// The key contacts field.
            /// </summary>
            [XurrentEnum("key_contacts")]
            KeyContacts,

            /// <summary>
            /// The keywords field.
            /// </summary>
            [XurrentEnum("keywords")]
            Keywords,

            /// <summary>
            /// The locale field.
            /// </summary>
            [XurrentEnum("locale", IgnoreInFieldSelection = true)]
            Locale,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The service field.
            /// </summary>
            [XurrentEnum("service")]
            Service,

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
            /// The template field.
            /// </summary>
            [XurrentEnum("template")]
            Template,

            /// <summary>
            /// The times applied field.
            /// </summary>
            [XurrentEnum("times_applied")]
            TimesApplied,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The updated by field.
            /// </summary>
            [XurrentEnum("updated_by")]
            UpdatedBy
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="KnowledgeArticle"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters knowledge articles by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters knowledge articles by creator.
            /// </summary>
            [XurrentEnum("created_by")]
            CreatedBy,

            /// <summary>
            /// Filters knowledge articles by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters knowledge articles by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Filters knowledge articles by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters knowledge articles by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters knowledge articles by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters knowledge articles by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Filters knowledge articles by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="KnowledgeArticle"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all active knowledge articles.
            /// </summary>
            [XurrentEnum("active")]
            Active,

            /// <summary>
            /// Lists all archived knowledge articles.
            /// </summary>
            [XurrentEnum("archived")]
            Archived,

            /// <summary>
            /// Lists all knowledge articles managed by the API user.
            /// </summary>
            [XurrentEnum("managed_by_me")]
            ManagedByMe
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="KnowledgeArticle"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts knowledge articles by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts knowledge articles by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts knowledge articles by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts knowledge articles by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts knowledge articles by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts knowledge articles by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private DateTime? _archiveDate;
        private List<Attachment>? _attachments;
        private bool? _coveredSpecialists;
        private DateTime? _createdAt;
        private Person? _createdBy;
        private string? _description;
        private ObservableCollection<AttachmentReference>? _descriptionAttachments;
        private AttachmentReferenceWriter? _descriptionAttachmentsWriter;
        private bool? _endUsers;
        private string? _instructions;
        private ObservableCollection<AttachmentReference>? _instructionsAttachments;
        private AttachmentReferenceWriter? _instructionsAttachmentsWriter;
        private bool? _internalSpecialists;
        private bool? _keyContacts;
        private string? _keywords;
        private string? _locale;
        private Service? _service;
        private string? _source;
        private string? _sourceID;
        private KnowledgeArticleStatus? _status;
        private string? _subject;
        private KnowledgeArticleTemplate? _template;
        private int? _timesApplied;
        private DateTime? _updatedAt;
        private Person? _updatedBy;

        /// <summary>
        /// Gets or sets the date until which the knowledge article is active.
        /// </summary>
        [XurrentField("archive_date")]
        public DateTime? ArchiveDate
        {
            get => _archiveDate;
            set => _archiveDate = SetValue("archive_date", _archiveDate, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated read-only collection of all attachments.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the knowledge article is available to covered specialists.
        /// </summary>
        [XurrentField("covered_specialists")]
        public bool? CoveredSpecialists
        {
            get => _coveredSpecialists;
            set => _coveredSpecialists = SetValue("covered_specialists", _coveredSpecialists, value);
        }

        /// <summary>
        /// Gets the date and time at which the knowledge article was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the person who created the knowledge article.
        /// </summary>
        [XurrentField("created_by")]
        public Person? CreatedBy
        {
            get => _createdBy;
            internal set => _createdBy = value;
        }

        /// <summary>
        /// Gets or sets the description of the knowledge article.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        [XurrentField("description_attachments")]
        internal ObservableCollection<AttachmentReference> DescriptionAttachmentsCollection
        {
            get => GetCollection(ref _descriptionAttachments, OnDescriptionAttachmentsChanged);
            set => SetCollection(ref _descriptionAttachments, "description_attachments", value, OnDescriptionAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the description field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter DescriptionAttachments
        {
            get
            {
                _descriptionAttachmentsWriter ??= new AttachmentReferenceWriter(() => DescriptionAttachmentsCollection, c => DescriptionAttachmentsCollection = c);
                return _descriptionAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the knowledge article is available to end users.
        /// </summary>
        [XurrentField("end_users")]
        public bool? EndUsers
        {
            get => _endUsers;
            set => _endUsers = SetValue("end_users", _endUsers, value);
        }

        /// <summary>
        /// Gets or sets the instructions of the knowledge article.
        /// </summary>
        [XurrentField("instructions")]
        public string? Instructions
        {
            get => _instructions;
            set => _instructions = SetValue("instructions", _instructions, value);
        }

        [XurrentField("instructions_attachments")]
        internal ObservableCollection<AttachmentReference> InstructionsAttachmentsCollection
        {
            get => GetCollection(ref _instructionsAttachments, OnInstructionsAttachmentsChanged);
            set => SetCollection(ref _instructionsAttachments, "instructions_attachments", value, OnInstructionsAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the instructions field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter InstructionsAttachments
        {
            get
            {
                _instructionsAttachmentsWriter ??= new AttachmentReferenceWriter(() => InstructionsAttachmentsCollection, c => InstructionsAttachmentsCollection = c);
                return _instructionsAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the knowledge article is available to internal specialists.
        /// </summary>
        [XurrentField("internal_specialists")]
        public bool? InternalSpecialists
        {
            get => _internalSpecialists;
            set => _internalSpecialists = SetValue("internal_specialists", _internalSpecialists, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the knowledge article is available to key contacts.
        /// </summary>
        [XurrentField("key_contacts")]
        public bool? KeyContacts
        {
            get => _keyContacts;
            set => _keyContacts = SetValue("key_contacts", _keyContacts, value);
        }

        /// <summary>
        /// Gets or sets the keywords used to search for the knowledge article.
        /// </summary>
        [XurrentField("keywords")]
        public string? Keywords
        {
            get => _keywords;
            set => _keywords = SetValue("keywords", _keywords, value);
        }

        /// <summary>
        /// Gets or sets the locale of the knowledge article.
        /// </summary>
        [XurrentField("locale")]
        public string? Locale
        {
            get => _locale;
            set => _locale = SetValue("locale", _locale, value);
        }

        /// <summary>
        /// Gets or sets the service to which the knowledge article is linked.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the source of the knowledge article.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the knowledge article.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the status of the knowledge article.
        /// </summary>
        [XurrentField("status")]
        public KnowledgeArticleStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the subject of the knowledge article.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets or sets the template on which the knowledge article is based.
        /// </summary>
        [XurrentField("template")]
        public KnowledgeArticleTemplate? Template
        {
            get => _template;
            set => _template = SetValue("template", _template, value);
        }

        /// <summary>
        /// Gets the number of times the knowledge article was applied.
        /// </summary>
        [XurrentField("times_applied")]
        public int? TimesApplied
        {
            get => _timesApplied;
            internal set => _timesApplied = value;
        }

        /// <summary>
        /// Gets the date and time at which the knowledge article was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets the person who last updated the knowledge article.
        /// </summary>
        [XurrentField("updated_by")]
        public Person? UpdatedBy
        {
            get => _updatedBy;
            internal set => _updatedBy = value;
        }

        /// <summary>
        /// Creates a new knowledge article instance.
        /// </summary>
        public KnowledgeArticle()
        {
        }

        /// <summary>
        /// Creates a new knowledge article instance.
        /// </summary>
        /// <param name="id">The unique identifier of the knowledge article.</param>
        public KnowledgeArticle(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new knowledge article instance.
        /// </summary>
        /// <param name="instructions">The instructions of the knowledge article.</param>
        /// <param name="service">The service of the knowledge article.</param>
        /// <param name="subject">The subject of the knowledge article.</param>
        public KnowledgeArticle(string instructions, Service service, string subject)
        {
            _instructions = SetValue("instructions", instructions);
            _service = SetValue("service", service);
            _subject = SetValue("subject", subject);
        }

        private void OnDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "description_attachments");
        }

        private void OnInstructionsAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "instructions_attachments");
        }
    }
}
