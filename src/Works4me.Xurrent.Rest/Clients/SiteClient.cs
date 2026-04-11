using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Site"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/sites/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class SiteClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Site"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Person"/> records related to an <see cref="Site"/>.
        /// </summary>
        public PeopleClient People { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="Site"/>.
        /// </summary>
        public ServiceLevelAgreementsClient ServiceLevelAgreements { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteClient"/> class.
        /// </summary>
        internal SiteClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "sites/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            People = new PeopleClient(this);
            ServiceLevelAgreements = new ServiceLevelAgreementsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Site"/> using the specified <see cref="SiteQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which sites to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Site"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Site>> GetAsync(SiteQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Site>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Site"/> items as an asynchronous stream using the specified <see cref="SiteQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which sites to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Site"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Site> StreamAsync(SiteQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Site>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Site"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the site.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Site"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Site?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Site>(new SiteQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Site"/>.
        /// </summary>
        /// <param name="site">The site to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Site"/>.</returns>
        public async Task<Site> CreateAsync(Site site, CancellationToken ct = default)
        {
            return await PostItemAsync(site, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Site"/>.
        /// </summary>
        /// <param name="site">The site to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Site"/>.</returns>
        public async Task<Site> UpdateAsync(Site site, CancellationToken ct = default)
        {
            return await PatchItemAsync(site, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Site"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly SiteClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(SiteClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified site using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="siteId">The unique identifier of the site for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long siteId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(siteId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified site using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="site">The site for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Site site, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return await GetAsync(site.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified site using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="siteId">The unique identifier of the site for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long siteId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(siteId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified site using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="site">The site for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Site site, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return StreamAsync(site.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Person"/> records related to an <see cref="Site"/>.
        /// </summary>
        public sealed class PeopleClient
        {
            private readonly SiteClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PeopleClient"/> class.
            /// </summary>
            internal PeopleClient(SiteClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified site using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="siteId">The unique identifier of the site for which to retrieve the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(long siteId, PersonQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Person>(siteId, "people", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified site using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="site">The site for which to retrieve the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(Site site, PersonQuery query, CancellationToken ct = default)
            {
                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return await GetAsync(site.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified site using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="siteId">The unique identifier of the site for which to enumerate the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(long siteId, PersonQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Person>(siteId, "people", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified site using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="site">The site for which to enumerate the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(Site site, PersonQuery query, CancellationToken ct = default)
            {
                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return StreamAsync(site.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="Site"/>.
        /// </summary>
        public sealed class ServiceLevelAgreementsClient
        {
            private readonly SiteClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceLevelAgreementsClient"/> class.
            /// </summary>
            internal ServiceLevelAgreementsClient(SiteClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified site using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="siteId">The unique identifier of the site for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(long siteId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceLevelAgreement>(siteId, "slas", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified site using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="site">The site for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(Site site, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return await GetAsync(site.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified site using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="siteId">The unique identifier of the site for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(long siteId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceLevelAgreement>(siteId, "slas", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified site using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="site">The site for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(Site site, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return StreamAsync(site.Id, query, ct);
            }
        }
    }
}
