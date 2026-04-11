using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Survey"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/surveys/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class SurveyClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Survey"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SurveyQuestion"/> records related to an <see cref="Survey"/>.
        /// </summary>
        public QuestionsClient Questions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveyClient"/> class.
        /// </summary>
        internal SurveyClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "surveys/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Questions = new QuestionsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Survey"/> using the specified <see cref="SurveyQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which surveys to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Survey"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Survey>> GetAsync(SurveyQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Survey>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Survey"/> items as an asynchronous stream using the specified <see cref="SurveyQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which surveys to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Survey"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Survey> StreamAsync(SurveyQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Survey>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Survey"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the survey.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Survey"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Survey?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Survey>(new SurveyQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Survey"/>.
        /// </summary>
        /// <param name="survey">The survey to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Survey"/>.</returns>
        public async Task<Survey> CreateAsync(Survey survey, CancellationToken ct = default)
        {
            return await PostItemAsync(survey, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Survey"/>.
        /// </summary>
        /// <param name="survey">The survey to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Survey"/>.</returns>
        public async Task<Survey> UpdateAsync(Survey survey, CancellationToken ct = default)
        {
            return await PatchItemAsync(survey, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Survey"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly SurveyClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(SurveyClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified survey using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="surveyId">The unique identifier of the survey for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long surveyId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(surveyId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified survey using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="survey">The survey for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Survey survey, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                return await GetAsync(survey.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified survey using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="surveyId">The unique identifier of the survey for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long surveyId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(surveyId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified survey using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="survey">The survey for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Survey survey, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                return StreamAsync(survey.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SurveyQuestion"/> records related to an <see cref="Survey"/>.
        /// </summary>
        public sealed class QuestionsClient
        {
            private readonly SurveyClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="QuestionsClient"/> class.
            /// </summary>
            internal QuestionsClient(SurveyClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SurveyQuestion"/> records for the specified survey using an <see cref="SurveyQuestionQuery"/>.
            /// </summary>
            /// <param name="surveyId">The unique identifier of the survey for which to retrieve the questions.</param>
            /// <param name="query">The query that defines which questions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SurveyQuestion"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SurveyQuestion>> GetAsync(long surveyId, SurveyQuestionQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SurveyQuestion>(surveyId, "survey_questions", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SurveyQuestion"/> records for the specified survey using an <see cref="SurveyQuestionQuery"/>.
            /// </summary>
            /// <param name="survey">The survey for which to retrieve the questions.</param>
            /// <param name="query">The query that defines which questions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SurveyQuestion"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SurveyQuestion>> GetAsync(Survey survey, SurveyQuestionQuery query, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                return await GetAsync(survey.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SurveyQuestion"/> items as an asynchronous stream for the specified survey using an <see cref="SurveyQuestionQuery"/>.
            /// </summary>
            /// <param name="surveyId">The unique identifier of the survey for which to enumerate the questions.</param>
            /// <param name="query">The query that defines which questions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SurveyQuestion"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SurveyQuestion> StreamAsync(long surveyId, SurveyQuestionQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SurveyQuestion>(surveyId, "survey_questions", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SurveyQuestion"/> items as an asynchronous stream for the specified survey using an <see cref="SurveyQuestionQuery"/>.
            /// </summary>
            /// <param name="survey">The survey for which to enumerate the questions.</param>
            /// <param name="query">The query that defines which questions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SurveyQuestion"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SurveyQuestion> StreamAsync(Survey survey, SurveyQuestionQuery query, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                return StreamAsync(survey.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="SurveyQuestion"/> by its unique identifier for the specified survey.
            /// </summary>
            /// <param name="surveyId">The unique identifier of the survey.</param>
            /// <param name="surveyQuestionId">The unique identifier of the survey question.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="SurveyQuestion"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<SurveyQuestion?> GetAsync(long surveyId, long surveyQuestionId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<SurveyQuestion>(surveyId, "survey_questions", new SurveyQuestionQuery().WithId(surveyQuestionId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="SurveyQuestion"/> record for the specified survey.
            /// </summary>
            /// <param name="survey">The survey for which to retrieve the survey question.</param>
            /// <param name="surveyQuestionId">The unique identifier of the survey question.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="SurveyQuestion"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<SurveyQuestion?> GetAsync(Survey survey, long surveyQuestionId, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                return await GetAsync(survey.Id, surveyQuestionId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="SurveyQuestion"/> to a <see cref="Survey"/>.
            /// </summary>
            /// <param name="surveyId">The identifier of the survey.</param>
            /// <param name="surveyQuestion">The survey question to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SurveyQuestion"/>.</returns>
            public async Task<SurveyQuestion> CreateAsync(long surveyId, SurveyQuestion surveyQuestion, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(surveyId, "survey_questions", surveyQuestion, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="SurveyQuestion"/> to a <see cref="Survey"/>.
            /// </summary>
            /// <param name="survey">The survey to which the survey question is added.</param>
            /// <param name="surveyQuestion">The survey question to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SurveyQuestion"/>.</returns>
            public async Task<SurveyQuestion> CreateAsync(Survey survey, SurveyQuestion surveyQuestion, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                return await CreateAsync(survey.Id, surveyQuestion, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="SurveyQuestion"/> associated with a <see cref="Survey"/>.
            /// </summary>
            /// <param name="surveyId">The identifier of the survey.</param>
            /// <param name="surveyQuestion">The survey question to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SurveyQuestion"/>.</returns>
            public async Task<SurveyQuestion> UpdateAsync(long surveyId, SurveyQuestion surveyQuestion, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(surveyId, "survey_questions", surveyQuestion, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="SurveyQuestion"/> associated with a <see cref="Survey"/>.
            /// </summary>
            /// <param name="survey">The survey with which the survey question is associated.</param>
            /// <param name="surveyQuestion">The survey question to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SurveyQuestion"/>.</returns>
            public async Task<SurveyQuestion> UpdateAsync(Survey survey, SurveyQuestion surveyQuestion, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                return await UpdateAsync(survey.Id, surveyQuestion, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SurveyQuestion"/> associated with a <see cref="Survey"/>.
            /// </summary>
            /// <param name="surveyId">The identifier of the survey.</param>
            /// <param name="surveyQuestionId">The identifier of the survey question to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long surveyId, long surveyQuestionId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(surveyId, "survey_questions", surveyQuestionId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SurveyQuestion"/> associated with a <see cref="Survey"/>.
            /// </summary>
            /// <param name="surveyId">The identifier of the survey.</param>
            /// <param name="surveyQuestion">The survey question to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long surveyId, SurveyQuestion surveyQuestion, CancellationToken ct = default)
            {
                if (surveyQuestion is null)
                    throw new ArgumentNullException(nameof(surveyQuestion));

                return await DeleteAsync(surveyId, surveyQuestion.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SurveyQuestion"/> associated with a <see cref="Survey"/>.
            /// </summary>
            /// <param name="survey">The survey from which the survey question is removed.</param>
            /// <param name="surveyQuestion">The survey question to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Survey survey, SurveyQuestion surveyQuestion, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                if (surveyQuestion is null)
                    throw new ArgumentNullException(nameof(surveyQuestion));

                return await DeleteAsync(survey.Id, surveyQuestion.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SurveyQuestion"/> associated with a <see cref="Survey"/>.
            /// </summary>
            /// <param name="survey">The survey from which the survey question is removed.</param>
            /// <param name="surveyQuestionId">The identifier of the survey question to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Survey survey, long surveyQuestionId, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                return await DeleteAsync(survey.Id, surveyQuestionId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all survey questions associated with a <see cref="Survey"/>.
            /// </summary>
            /// <param name="surveyId">The identifier of the survey.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long surveyId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(surveyId, "survey_questions", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all survey questions associated with a <see cref="Survey"/>.
            /// </summary>
            /// <param name="survey">The survey from which all survey questions are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Survey survey, CancellationToken ct = default)
            {
                if (survey is null)
                    throw new ArgumentNullException(nameof(survey));

                return await DeleteAllAsync(survey.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
