using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent survey response object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class SurveyResponse : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="SurveyResponse"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The completed field.
            /// </summary>
            [XurrentEnum("completed")]
            Completed,

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
            /// The rating calculation json field.
            /// </summary>
            [XurrentEnum("rating_calculation_json")]
            RatingCalculationJson,

            /// <summary>
            /// The responded at field.
            /// </summary>
            [XurrentEnum("responded_at")]
            RespondedAt,

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
            /// The survey field.
            /// </summary>
            [XurrentEnum("survey")]
            Survey,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="SurveyResponse"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters survey responses by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters survey responses by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters survey responses by response date.
            /// </summary>
            [XurrentEnum("responded_at")]
            RespondedAt,

            /// <summary>
            /// Filters survey responses by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters survey responses by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters survey responses by survey.
            /// </summary>
            [XurrentEnum("survey")]
            Survey,

            /// <summary>
            /// Filters survey responses by last update date.
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
        /// Represents the fields used to order a <see cref="SurveyResponse"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts survey responses by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts survey responses by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts survey responses by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts survey responses by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private bool? _completed;
        private DateTime? _createdAt;
        private decimal? _rating;
        private string? _ratingCalculationJson;
        private DateTime? _respondedAt;
        private Service? _service;
        private string? _source;
        private string? _sourceID;
        private Survey? _survey;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets a value indicating whether the survey response is completed.
        /// </summary>
        [XurrentField("completed")]
        public bool? Completed
        {
            get => _completed;
            set => _completed = SetValue("completed", _completed, value);
        }

        /// <summary>
        /// Gets the date and time when the survey response was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the rating calculated for the survey response.
        /// </summary>
        [XurrentField("rating")]
        public decimal? Rating
        {
            get => _rating;
            set => _rating = SetValue("rating", _rating, value);
        }

        /// <summary>
        /// Gets the calculation details used to determine the rating.
        /// </summary>
        [XurrentField("rating_calculation_json")]
        public string? RatingCalculationJson
        {
            get => _ratingCalculationJson;
            internal set => _ratingCalculationJson = value;
        }

        /// <summary>
        /// Gets the date and time when the survey response was submitted.
        /// </summary>
        [XurrentField("responded_at")]
        public DateTime? RespondedAt
        {
            get => _respondedAt;
            internal set => _respondedAt = value;
        }

        /// <summary>
        /// Gets or sets the service associated with the survey response.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the source of the survey response.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the survey response.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the survey associated with the response.
        /// </summary>
        [XurrentField("survey")]
        public Survey? Survey
        {
            get => _survey;
            set => _survey = SetValue("survey", _survey, value);
        }

        /// <summary>
        /// Gets the date and time when the survey response was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new survey response instance.
        /// </summary>
        public SurveyResponse()
        {
        }

        /// <summary>
        /// Creates a new survey response instance.
        /// </summary>
        /// <param name="id">The unique identifier of the survey response.</param>
        public SurveyResponse(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new survey response instance.
        /// </summary>
        /// <param name="survey">The survey of the survey response.</param>
        public SurveyResponse(Survey survey)
        {
            _survey = SetValue("survey", survey);
        }
    }
}
