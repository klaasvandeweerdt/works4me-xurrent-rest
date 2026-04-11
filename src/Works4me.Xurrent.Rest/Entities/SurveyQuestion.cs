using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent survey question object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class SurveyQuestion : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="SurveyQuestion"/> object.
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
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The guidance field.
            /// </summary>
            [XurrentEnum("guidance")]
            Guidance,

            /// <summary>
            /// The guidance attachments field.
            /// </summary>
            [XurrentEnum("guidance_attachments", IgnoreInFieldSelection = true)]
            GuidanceAttachments,

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
            /// The position field.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// The question field.
            /// </summary>
            [XurrentEnum("question")]
            Question,

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
            /// The type field.
            /// </summary>
            [XurrentEnum("type")]
            Type,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The weight field.
            /// </summary>
            [XurrentEnum("weight")]
            Weight
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

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _guidance;
        private ObservableCollection<AttachmentReference>? _guidanceAttachments;
        private AttachmentReferenceWriter? _guidanceAttachmentsWriter;
        private int? _position;
        private string? _question;
        private string? _source;
        private string? _sourceID;
        private SurveyQuestionType? _type;
        private DateTime? _updatedAt;
        private int? _weight;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the survey question.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the survey question was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the survey question is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the guidance text for the survey question.
        /// </summary>
        [XurrentField("guidance")]
        public string? Guidance
        {
            get => _guidance;
            set => _guidance = SetValue("guidance", _guidance, value);
        }

        [XurrentField("guidance_attachments")]
        internal ObservableCollection<AttachmentReference> GuidanceAttachmentsCollection
        {
            get => GetCollection(ref _guidanceAttachments, OnGuidanceAttachmentsChanged);
            set => SetCollection(ref _guidanceAttachments, "guidance_attachments", value, OnGuidanceAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the guidance field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter GuidanceAttachments
        {
            get
            {
                _guidanceAttachmentsWriter ??= new AttachmentReferenceWriter(() => GuidanceAttachmentsCollection, c => GuidanceAttachmentsCollection = c);
                return _guidanceAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the position of the survey question within the survey.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            set => _position = SetValue("position", _position, value);
        }

        /// <summary>
        /// Gets or sets the question text.
        /// </summary>
        [XurrentField("question")]
        public string? Question
        {
            get => _question;
            set => _question = SetValue("question", _question, value);
        }

        /// <summary>
        /// Gets or sets the source of the survey question.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the survey question.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the type of the survey question.
        /// </summary>
        [XurrentField("type")]
        public SurveyQuestionType? Type
        {
            get => _type;
            set => _type = SetValue("type", _type, value);
        }

        /// <summary>
        /// Gets the date and time when the survey question was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the weight of the survey question.
        /// </summary>
        [XurrentField("weight")]
        public int? Weight
        {
            get => _weight;
            set => _weight = SetValue("weight", _weight, value);
        }

        /// <summary>
        /// Creates a new survey question instance.
        /// </summary>
        public SurveyQuestion()
        {
        }

        /// <summary>
        /// Creates a new survey question instance.
        /// </summary>
        /// <param name="id">The unique identifier of the survey question.</param>
        public SurveyQuestion(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new survey question instance.
        /// </summary>
        /// <param name="question">The question of the survey question.</param>
        /// <param name="type">The type of the survey question.</param>
        public SurveyQuestion(string question, SurveyQuestionType type)
        {
            _question = SetValue("question", question);
            _type = SetValue("type", type);
        }

        private void OnGuidanceAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "guidance_attachments");
        }
    }
}
