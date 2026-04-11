using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent survey answer object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class SurveyAnswer : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="SurveyAnswer"/> object.
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
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The rating field.
            /// </summary>
            [XurrentEnum("rating")]
            Rating,

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
            /// The survey question field.
            /// </summary>
            [XurrentEnum("survey_question")]
            SurveyQuestion,

            /// <summary>
            /// The text field.
            /// </summary>
            [XurrentEnum("text")]
            Text,

            /// <summary>
            /// The text attachments field.
            /// </summary>
            [XurrentEnum("text_attachments", IgnoreInFieldSelection = true)]
            TextAttachments,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
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
        private decimal? _rating;
        private string? _source;
        private string? _sourceID;
        private SurveyQuestion? _surveyQuestion;
        private string? _text;
        private ObservableCollection<AttachmentReference>? _textAttachments;
        private AttachmentReferenceWriter? _textAttachmentsWriter;
        private DateTime? _updatedAt;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the survey answer.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the survey answer was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the rating provided for the survey answer.
        /// </summary>
        [XurrentField("rating")]
        public decimal? Rating
        {
            get => _rating;
            set => _rating = SetValue("rating", _rating, value);
        }

        /// <summary>
        /// Gets or sets the source of the survey answer.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the survey answer.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the survey question associated with the answer.
        /// </summary>
        [XurrentField("survey_question")]
        public SurveyQuestion? SurveyQuestion
        {
            get => _surveyQuestion;
            set => _surveyQuestion = SetValue("survey_question", _surveyQuestion, value);
        }

        /// <summary>
        /// Gets or sets the text provided for the survey answer.
        /// </summary>
        [XurrentField("text")]
        public string? Text
        {
            get => _text;
            set => _text = SetValue("text", _text, value);
        }

        [XurrentField("text_attachments")]
        internal ObservableCollection<AttachmentReference> TextAttachmentsCollection
        {
            get => GetCollection(ref _textAttachments, OnTextAttachmentsChanged);
            set => SetCollection(ref _textAttachments, "text_attachments", value, OnTextAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the text field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter TextAttachments
        {
            get
            {
                _textAttachmentsWriter ??= new AttachmentReferenceWriter(() => TextAttachmentsCollection, c => TextAttachmentsCollection = c);
                return _textAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the date and time when the survey answer was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new survey answer instance.
        /// </summary>
        public SurveyAnswer()
        {
        }

        /// <summary>
        /// Creates a new survey answer instance.
        /// </summary>
        /// <param name="id">The unique identifier of the survey answer.</param>
        public SurveyAnswer(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new survey answer instance.
        /// </summary>
        /// <param name="surveyQuestion">The survey question of the survey answer.</param>
        public SurveyAnswer(SurveyQuestion surveyQuestion)
        {
            _surveyQuestion = SetValue("survey_question", surveyQuestion);
        }

        private void OnTextAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "text_attachments");
        }
    }
}
