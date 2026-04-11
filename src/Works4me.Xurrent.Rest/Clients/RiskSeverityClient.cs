using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="RiskSeverity"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/risk_severities/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class RiskSeverityClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="RiskSeverity"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiskSeverityClient"/> class.
        /// </summary>
        internal RiskSeverityClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "risk_severities/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="RiskSeverity"/> using the specified <see cref="RiskSeverityQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which risk severities to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="RiskSeverity"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<RiskSeverity>> GetAsync(RiskSeverityQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<RiskSeverity>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="RiskSeverity"/> items as an asynchronous stream using the specified <see cref="RiskSeverityQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which risk severities to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RiskSeverity"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<RiskSeverity> StreamAsync(RiskSeverityQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<RiskSeverity>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="RiskSeverity"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the risk severity.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="RiskSeverity"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<RiskSeverity?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<RiskSeverity>(new RiskSeverityQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="RiskSeverity"/>.
        /// </summary>
        /// <param name="riskSeverity">The risk severity to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="RiskSeverity"/>.</returns>
        public async Task<RiskSeverity> CreateAsync(RiskSeverity riskSeverity, CancellationToken ct = default)
        {
            return await PostItemAsync(riskSeverity, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="RiskSeverity"/>.
        /// </summary>
        /// <param name="riskSeverity">The risk severity to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="RiskSeverity"/>.</returns>
        public async Task<RiskSeverity> UpdateAsync(RiskSeverity riskSeverity, CancellationToken ct = default)
        {
            return await PatchItemAsync(riskSeverity, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="RiskSeverity"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly RiskSeverityClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(RiskSeverityClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified risk severity using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="riskSeverityId">The unique identifier of the risk severity for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long riskSeverityId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(riskSeverityId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified risk severity using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="riskSeverity">The risk severity for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(RiskSeverity riskSeverity, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (riskSeverity is null)
                    throw new ArgumentNullException(nameof(riskSeverity));

                return await GetAsync(riskSeverity.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified risk severity using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="riskSeverityId">The unique identifier of the risk severity for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long riskSeverityId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(riskSeverityId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified risk severity using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="riskSeverity">The risk severity for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(RiskSeverity riskSeverity, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (riskSeverity is null)
                    throw new ArgumentNullException(nameof(riskSeverity));

                return StreamAsync(riskSeverity.Id, query, ct);
            }
        }
    }
}
