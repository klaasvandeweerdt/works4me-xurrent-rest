using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="SurveyResponse"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/survey_responses/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class SurveyResponseClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="SurveyAnswer"/> records related to an <see cref="SurveyResponse"/>.
        /// </summary>
        public AnswersClient Answers { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="SurveyResponse"/>.
        /// </summary>
        public ServiceLevelAgreementsClient ServiceLevelAgreements { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveyResponseClient"/> class.
        /// </summary>
        internal SurveyResponseClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "survey_responses/"))
        {
            Answers = new AnswersClient(this);
            ServiceLevelAgreements = new ServiceLevelAgreementsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="SurveyResponse"/> using the specified <see cref="SurveyResponseQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which survey responses to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="SurveyResponse"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<SurveyResponse>> GetAsync(SurveyResponseQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<SurveyResponse>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="SurveyResponse"/> items as an asynchronous stream using the specified <see cref="SurveyResponseQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which survey responses to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SurveyResponse"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<SurveyResponse> StreamAsync(SurveyResponseQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<SurveyResponse>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="SurveyResponse"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the survey response.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="SurveyResponse"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<SurveyResponse?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<SurveyResponse>(new SurveyResponseQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="SurveyResponse"/>.
        /// </summary>
        /// <param name="surveyResponse">The survey response to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="SurveyResponse"/>.</returns>
        public async Task<SurveyResponse> CreateAsync(SurveyResponse surveyResponse, CancellationToken ct = default)
        {
            return await PostItemAsync(surveyResponse, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="SurveyResponse"/>.
        /// </summary>
        /// <param name="surveyResponse">The survey response to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="SurveyResponse"/>.</returns>
        public async Task<SurveyResponse> UpdateAsync(SurveyResponse surveyResponse, CancellationToken ct = default)
        {
            return await PatchItemAsync(surveyResponse, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SurveyAnswer"/> records related to an <see cref="SurveyResponse"/>.
        /// </summary>
        public sealed class AnswersClient
        {
            private readonly SurveyResponseClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AnswersClient"/> class.
            /// </summary>
            internal AnswersClient(SurveyResponseClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SurveyAnswer"/> records for the specified survey response using an <see cref="SurveyAnswerQuery"/>.
            /// </summary>
            /// <param name="surveyResponseId">The unique identifier of the survey response for which to retrieve the answers.</param>
            /// <param name="query">The query that defines which answers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SurveyAnswer"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SurveyAnswer>> GetAsync(long surveyResponseId, SurveyAnswerQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SurveyAnswer>(surveyResponseId, "survey_answers", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SurveyAnswer"/> records for the specified survey response using an <see cref="SurveyAnswerQuery"/>.
            /// </summary>
            /// <param name="surveyResponse">The survey response for which to retrieve the answers.</param>
            /// <param name="query">The query that defines which answers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SurveyAnswer"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SurveyAnswer>> GetAsync(SurveyResponse surveyResponse, SurveyAnswerQuery query, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                return await GetAsync(surveyResponse.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SurveyAnswer"/> items as an asynchronous stream for the specified survey response using an <see cref="SurveyAnswerQuery"/>.
            /// </summary>
            /// <param name="surveyResponseId">The unique identifier of the survey response for which to enumerate the answers.</param>
            /// <param name="query">The query that defines which answers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SurveyAnswer"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SurveyAnswer> StreamAsync(long surveyResponseId, SurveyAnswerQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SurveyAnswer>(surveyResponseId, "survey_answers", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SurveyAnswer"/> items as an asynchronous stream for the specified survey response using an <see cref="SurveyAnswerQuery"/>.
            /// </summary>
            /// <param name="surveyResponse">The survey response for which to enumerate the answers.</param>
            /// <param name="query">The query that defines which answers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SurveyAnswer"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SurveyAnswer> StreamAsync(SurveyResponse surveyResponse, SurveyAnswerQuery query, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                return StreamAsync(surveyResponse.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="SurveyAnswer"/> by its unique identifier for the specified survey response.
            /// </summary>
            /// <param name="surveyResponseId">The unique identifier of the survey response.</param>
            /// <param name="surveyAnswerId">The unique identifier of the survey answer.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="SurveyAnswer"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<SurveyAnswer?> GetAsync(long surveyResponseId, long surveyAnswerId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<SurveyAnswer>(surveyResponseId, "survey_answers", new SurveyAnswerQuery().WithId(surveyAnswerId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="SurveyAnswer"/> record for the specified survey response.
            /// </summary>
            /// <param name="surveyResponse">The survey response for which to retrieve the survey answer.</param>
            /// <param name="surveyAnswerId">The unique identifier of the survey answer.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="SurveyAnswer"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<SurveyAnswer?> GetAsync(SurveyResponse surveyResponse, long surveyAnswerId, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                return await GetAsync(surveyResponse.Id, surveyAnswerId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="SurveyAnswer"/> to a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponseId">The identifier of the survey response.</param>
            /// <param name="surveyAnswer">The survey answer to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SurveyAnswer"/>.</returns>
            public async Task<SurveyAnswer> CreateAsync(long surveyResponseId, SurveyAnswer surveyAnswer, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(surveyResponseId, "survey_answers", surveyAnswer, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="SurveyAnswer"/> to a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponse">The survey response to which the survey answer is added.</param>
            /// <param name="surveyAnswer">The survey answer to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SurveyAnswer"/>.</returns>
            public async Task<SurveyAnswer> CreateAsync(SurveyResponse surveyResponse, SurveyAnswer surveyAnswer, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                return await CreateAsync(surveyResponse.Id, surveyAnswer, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="SurveyAnswer"/> associated with a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponseId">The identifier of the survey response.</param>
            /// <param name="surveyAnswer">The survey answer to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SurveyAnswer"/>.</returns>
            public async Task<SurveyAnswer> UpdateAsync(long surveyResponseId, SurveyAnswer surveyAnswer, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(surveyResponseId, "survey_answers", surveyAnswer, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="SurveyAnswer"/> associated with a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponse">The survey response with which the survey answer is associated.</param>
            /// <param name="surveyAnswer">The survey answer to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SurveyAnswer"/>.</returns>
            public async Task<SurveyAnswer> UpdateAsync(SurveyResponse surveyResponse, SurveyAnswer surveyAnswer, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                return await UpdateAsync(surveyResponse.Id, surveyAnswer, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SurveyAnswer"/> associated with a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponseId">The identifier of the survey response.</param>
            /// <param name="surveyAnswerId">The identifier of the survey answer to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long surveyResponseId, long surveyAnswerId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(surveyResponseId, "survey_answers", surveyAnswerId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SurveyAnswer"/> associated with a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponseId">The identifier of the survey response.</param>
            /// <param name="surveyAnswer">The survey answer to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long surveyResponseId, SurveyAnswer surveyAnswer, CancellationToken ct = default)
            {
                if (surveyAnswer is null)
                    throw new ArgumentNullException(nameof(surveyAnswer));

                return await DeleteAsync(surveyResponseId, surveyAnswer.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SurveyAnswer"/> associated with a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponse">The survey response from which the survey answer is removed.</param>
            /// <param name="surveyAnswer">The survey answer to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(SurveyResponse surveyResponse, SurveyAnswer surveyAnswer, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                if (surveyAnswer is null)
                    throw new ArgumentNullException(nameof(surveyAnswer));

                return await DeleteAsync(surveyResponse.Id, surveyAnswer.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SurveyAnswer"/> associated with a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponse">The survey response from which the survey answer is removed.</param>
            /// <param name="surveyAnswerId">The identifier of the survey answer to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(SurveyResponse surveyResponse, long surveyAnswerId, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                return await DeleteAsync(surveyResponse.Id, surveyAnswerId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all survey answers associated with a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponseId">The identifier of the survey response.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long surveyResponseId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(surveyResponseId, "survey_answers", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all survey answers associated with a <see cref="SurveyResponse"/>.
            /// </summary>
            /// <param name="surveyResponse">The survey response from which all survey answers are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(SurveyResponse surveyResponse, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                return await DeleteAllAsync(surveyResponse.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="SurveyResponse"/>.
        /// </summary>
        public sealed class ServiceLevelAgreementsClient
        {
            private readonly SurveyResponseClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceLevelAgreementsClient"/> class.
            /// </summary>
            internal ServiceLevelAgreementsClient(SurveyResponseClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified survey response using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="surveyResponseId">The unique identifier of the survey response for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(long surveyResponseId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceLevelAgreement>(surveyResponseId, "slas", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified survey response using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="surveyResponse">The survey response for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(SurveyResponse surveyResponse, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                return await GetAsync(surveyResponse.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified survey response using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="surveyResponseId">The unique identifier of the survey response for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(long surveyResponseId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceLevelAgreement>(surveyResponseId, "slas", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified survey response using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="surveyResponse">The survey response for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(SurveyResponse surveyResponse, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (surveyResponse is null)
                    throw new ArgumentNullException(nameof(surveyResponse));

                return StreamAsync(surveyResponse.Id, query, ct);
            }
        }
    }
}
