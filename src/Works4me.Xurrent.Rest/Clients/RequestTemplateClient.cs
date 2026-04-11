using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="RequestTemplate"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/request_templates/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class RequestTemplateClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="RequestTemplate"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="RequestTemplate"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Request"/> records related to an <see cref="RequestTemplate"/>.
        /// </summary>
        public RequestsClient Requests { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ReservationOffering"/> records related to an <see cref="RequestTemplate"/>.
        /// </summary>
        public ReservationOfferingsClient ReservationOfferings { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTemplateClient"/> class.
        /// </summary>
        internal RequestTemplateClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "request_templates/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
            Requests = new RequestsClient(this);
            ReservationOfferings = new ReservationOfferingsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="RequestTemplate"/> using the specified <see cref="RequestTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which request templates to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="RequestTemplate"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<RequestTemplate>> GetAsync(RequestTemplateQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<RequestTemplate>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="RequestTemplate"/> items as an asynchronous stream using the specified <see cref="RequestTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which request templates to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RequestTemplate"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<RequestTemplate> StreamAsync(RequestTemplateQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<RequestTemplate>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="RequestTemplate"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the request template.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="RequestTemplate"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<RequestTemplate?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<RequestTemplate>(new RequestTemplateQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="RequestTemplate"/>.
        /// </summary>
        /// <param name="requestTemplate">The request template to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="RequestTemplate"/>.</returns>
        public async Task<RequestTemplate> CreateAsync(RequestTemplate requestTemplate, CancellationToken ct = default)
        {
            return await PostItemAsync(requestTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="RequestTemplate"/>.
        /// </summary>
        /// <param name="requestTemplate">The request template to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="RequestTemplate"/>.</returns>
        public async Task<RequestTemplate> UpdateAsync(RequestTemplate requestTemplate, CancellationToken ct = default)
        {
            return await PatchItemAsync(requestTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="RequestTemplate"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly RequestTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(RequestTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified request template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="requestTemplateId">The unique identifier of the request template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long requestTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(requestTemplateId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified request template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="requestTemplate">The request template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(RequestTemplate requestTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (requestTemplate is null)
                    throw new ArgumentNullException(nameof(requestTemplate));

                return await GetAsync(requestTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified request template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="requestTemplateId">The unique identifier of the request template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long requestTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(requestTemplateId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified request template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="requestTemplate">The request template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(RequestTemplate requestTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (requestTemplate is null)
                    throw new ArgumentNullException(nameof(requestTemplate));

                return StreamAsync(requestTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="RequestTemplate"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly RequestTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(RequestTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified request template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="requestTemplateId">The unique identifier of the request template for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long requestTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(requestTemplateId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified request template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="requestTemplate">The request template for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(RequestTemplate requestTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (requestTemplate is null)
                    throw new ArgumentNullException(nameof(requestTemplate));

                return await GetAsync(requestTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified request template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="requestTemplateId">The unique identifier of the request template for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long requestTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(requestTemplateId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified request template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="requestTemplate">The request template for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(RequestTemplate requestTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (requestTemplate is null)
                    throw new ArgumentNullException(nameof(requestTemplate));

                return StreamAsync(requestTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Request"/> records related to an <see cref="RequestTemplate"/>.
        /// </summary>
        public sealed class RequestsClient
        {
            private readonly RequestTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RequestsClient"/> class.
            /// </summary>
            internal RequestsClient(RequestTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified request template using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="requestTemplateId">The unique identifier of the request template for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(long requestTemplateId, RequestQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Request>(requestTemplateId, "requests", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified request template using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="requestTemplate">The request template for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(RequestTemplate requestTemplate, RequestQuery query, CancellationToken ct = default)
            {
                if (requestTemplate is null)
                    throw new ArgumentNullException(nameof(requestTemplate));

                return await GetAsync(requestTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified request template using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="requestTemplateId">The unique identifier of the request template for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(long requestTemplateId, RequestQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Request>(requestTemplateId, "requests", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified request template using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="requestTemplate">The request template for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(RequestTemplate requestTemplate, RequestQuery query, CancellationToken ct = default)
            {
                if (requestTemplate is null)
                    throw new ArgumentNullException(nameof(requestTemplate));

                return StreamAsync(requestTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ReservationOffering"/> records related to an <see cref="RequestTemplate"/>.
        /// </summary>
        public sealed class ReservationOfferingsClient
        {
            private readonly RequestTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ReservationOfferingsClient"/> class.
            /// </summary>
            internal ReservationOfferingsClient(RequestTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ReservationOffering"/> records for the specified request template using an <see cref="ReservationOfferingQuery"/>.
            /// </summary>
            /// <param name="requestTemplateId">The unique identifier of the request template for which to retrieve the reservation offerings.</param>
            /// <param name="query">The query that defines which reservation offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ReservationOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ReservationOffering>> GetAsync(long requestTemplateId, ReservationOfferingQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ReservationOffering>(requestTemplateId, "reservation_offerings", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ReservationOffering"/> records for the specified request template using an <see cref="ReservationOfferingQuery"/>.
            /// </summary>
            /// <param name="requestTemplate">The request template for which to retrieve the reservation offerings.</param>
            /// <param name="query">The query that defines which reservation offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ReservationOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ReservationOffering>> GetAsync(RequestTemplate requestTemplate, ReservationOfferingQuery query, CancellationToken ct = default)
            {
                if (requestTemplate is null)
                    throw new ArgumentNullException(nameof(requestTemplate));

                return await GetAsync(requestTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ReservationOffering"/> items as an asynchronous stream for the specified request template using an <see cref="ReservationOfferingQuery"/>.
            /// </summary>
            /// <param name="requestTemplateId">The unique identifier of the request template for which to enumerate the reservation offerings.</param>
            /// <param name="query">The query that defines which reservation offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ReservationOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ReservationOffering> StreamAsync(long requestTemplateId, ReservationOfferingQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ReservationOffering>(requestTemplateId, "reservation_offerings", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ReservationOffering"/> items as an asynchronous stream for the specified request template using an <see cref="ReservationOfferingQuery"/>.
            /// </summary>
            /// <param name="requestTemplate">The request template for which to enumerate the reservation offerings.</param>
            /// <param name="query">The query that defines which reservation offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ReservationOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ReservationOffering> StreamAsync(RequestTemplate requestTemplate, ReservationOfferingQuery query, CancellationToken ct = default)
            {
                if (requestTemplate is null)
                    throw new ArgumentNullException(nameof(requestTemplate));

                return StreamAsync(requestTemplate.Id, query, ct);
            }
        }
    }
}
