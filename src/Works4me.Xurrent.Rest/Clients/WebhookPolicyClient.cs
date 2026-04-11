using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="WebhookPolicy"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/webhook_policies/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class WebhookPolicyClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="WebhookPolicy"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookPolicyClient"/> class.
        /// </summary>
        internal WebhookPolicyClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "webhook_policies/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="WebhookPolicy"/> using the specified <see cref="WebhookPolicyQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which webhook policies to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="WebhookPolicy"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<WebhookPolicy>> GetAsync(WebhookPolicyQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<WebhookPolicy>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="WebhookPolicy"/> items as an asynchronous stream using the specified <see cref="WebhookPolicyQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which webhook policies to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WebhookPolicy"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<WebhookPolicy> StreamAsync(WebhookPolicyQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<WebhookPolicy>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="WebhookPolicy"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the webhook policy.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="WebhookPolicy"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<WebhookPolicy?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<WebhookPolicy>(new WebhookPolicyQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="WebhookPolicy"/>.
        /// </summary>
        /// <param name="webhookPolicy">The webhook policy to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="WebhookPolicy"/>.</returns>
        public async Task<WebhookPolicy> CreateAsync(WebhookPolicy webhookPolicy, CancellationToken ct = default)
        {
            return await PostItemAsync(webhookPolicy, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="WebhookPolicy"/>.
        /// </summary>
        /// <param name="webhookPolicy">The webhook policy to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="WebhookPolicy"/>.</returns>
        public async Task<WebhookPolicy> UpdateAsync(WebhookPolicy webhookPolicy, CancellationToken ct = default)
        {
            return await PatchItemAsync(webhookPolicy, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a <see cref="WebhookPolicy"/>.
        /// </summary>
            /// <param name="webhookPolicyId">The identifier of the webhook policy to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long webhookPolicyId, CancellationToken ct = default)
            {
                return await DeleteItemAsync(webhookPolicyId, ct).ConfigureAwait(false);
            }

        /// <summary>
        /// Delete a <see cref="WebhookPolicy"/>.
        /// </summary>
        /// <param name="webhookPolicy">The webhook policy to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="WebhookPolicy"/>.</returns>
        public async Task<bool> DeleteAsync(WebhookPolicy webhookPolicy, CancellationToken ct = default)
        {
            if (webhookPolicy is null)
                throw new ArgumentNullException(nameof(webhookPolicy));

            return await DeleteAsync(webhookPolicy.Id, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="WebhookPolicy"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly WebhookPolicyClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(WebhookPolicyClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified webhook policy using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="webhookPolicyId">The unique identifier of the webhook policy for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long webhookPolicyId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(webhookPolicyId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified webhook policy using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="webhookPolicy">The webhook policy for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(WebhookPolicy webhookPolicy, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (webhookPolicy is null)
                    throw new ArgumentNullException(nameof(webhookPolicy));

                return await GetAsync(webhookPolicy.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified webhook policy using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="webhookPolicyId">The unique identifier of the webhook policy for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long webhookPolicyId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(webhookPolicyId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified webhook policy using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="webhookPolicy">The webhook policy for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(WebhookPolicy webhookPolicy, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (webhookPolicy is null)
                    throw new ArgumentNullException(nameof(webhookPolicy));

                return StreamAsync(webhookPolicy.Id, query, ct);
            }
        }
    }
}
