using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent survey object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Survey : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Survey"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The completion field.
            /// </summary>
            [XurrentEnum("completion")]
            Completion,

            /// <summary>
            /// The completion attachments field.
            /// </summary>
            [XurrentEnum("completion_attachments", IgnoreInFieldSelection = true)]
            CompletionAttachments,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The introduction field.
            /// </summary>
            [XurrentEnum("introduction")]
            Introduction,

            /// <summary>
            /// The introduction attachments field.
            /// </summary>
            [XurrentEnum("introduction_attachments", IgnoreInFieldSelection = true)]
            IntroductionAttachments,

            /// <summary>
            /// The name field.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

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
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Survey"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters surveys by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters surveys by disabled status.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters surveys by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters surveys by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters surveys by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters surveys by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters surveys by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Survey"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled surveys.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled surveys.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Survey"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts surveys by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts surveys by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts surveys by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts surveys by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private string? _completion;
        private ObservableCollection<AttachmentReference>? _completionAttachments;
        private AttachmentReferenceWriter? _completionAttachmentsWriter;
        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _introduction;
        private ObservableCollection<AttachmentReference>? _introductionAttachments;
        private AttachmentReferenceWriter? _introductionAttachmentsWriter;
        private string? _name;
        private string? _source;
        private string? _sourceID;
        private DateTime? _updatedAt;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the survey.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the content shown to respondents upon completion of the survey.
        /// </summary>
        [XurrentField("completion")]
        public string? Completion
        {
            get => _completion;
            set => _completion = SetValue("completion", _completion, value);
        }

        [XurrentField("completion_attachments")]
        internal ObservableCollection<AttachmentReference> CompletionAttachmentsCollection
        {
            get => GetCollection(ref _completionAttachments, OnCompletionAttachmentsChanged);
            set => SetCollection(ref _completionAttachments, "completion_attachments", value, OnCompletionAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the completion field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter CompletionAttachments
        {
            get
            {
                _completionAttachmentsWriter ??= new AttachmentReferenceWriter(() => CompletionAttachmentsCollection, c => CompletionAttachmentsCollection = c);
                return _completionAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the date and time at which the survey was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the survey is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the content shown to respondents before the first question of the survey.
        /// </summary>
        [XurrentField("introduction")]
        public string? Introduction
        {
            get => _introduction;
            set => _introduction = SetValue("introduction", _introduction, value);
        }

        [XurrentField("introduction_attachments")]
        internal ObservableCollection<AttachmentReference> IntroductionAttachmentsCollection
        {
            get => GetCollection(ref _introductionAttachments, OnIntroductionAttachmentsChanged);
            set => SetCollection(ref _introductionAttachments, "introduction_attachments", value, OnIntroductionAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the introduction field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter IntroductionAttachments
        {
            get
            {
                _introductionAttachmentsWriter ??= new AttachmentReferenceWriter(() => IntroductionAttachmentsCollection, c => IntroductionAttachmentsCollection = c);
                return _introductionAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the name of the survey.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier for the survey.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the survey in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the survey.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new survey instance.
        /// </summary>
        public Survey()
        {
        }

        /// <summary>
        /// Creates a new survey instance.
        /// </summary>
        /// <param name="id">The unique identifier of the survey.</param>
        public Survey(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new survey instance.
        /// </summary>
        /// <param name="name">The name of the survey.</param>
        public Survey(string name)
        {
            _name = SetValue("name", name);
        }

        private void OnCompletionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "completion_attachments");
        }

        private void OnIntroductionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "introduction_attachments");
        }
    }
}
