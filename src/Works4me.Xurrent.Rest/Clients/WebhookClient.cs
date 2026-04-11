using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Webhook"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/webhooks/events/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class WebhookClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Webhook"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookClient"/> class.
        /// </summary>
        internal WebhookClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "webhooks/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Webhook"/> using the specified <see cref="WebhookQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which webhooks to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Webhook"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Webhook>> GetAsync(WebhookQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Webhook>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Webhook"/> items as an asynchronous stream using the specified <see cref="WebhookQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which webhooks to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Webhook"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Webhook> StreamAsync(WebhookQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Webhook>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Webhook"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the webhook.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Webhook"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Webhook?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Webhook>(new WebhookQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Webhook"/>.
        /// </summary>
        /// <param name="webhook">The webhook to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Webhook"/>.</returns>
        public async Task<Webhook> CreateAsync(Webhook webhook, CancellationToken ct = default)
        {
            return await PostItemAsync(webhook, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Webhook"/>.
        /// </summary>
        /// <param name="webhook">The webhook to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Webhook"/>.</returns>
        public async Task<Webhook> UpdateAsync(Webhook webhook, CancellationToken ct = default)
        {
            return await PatchItemAsync(webhook, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a <see cref="Webhook"/>.
        /// </summary>
            /// <param name="webhookId">The identifier of the webhook to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long webhookId, CancellationToken ct = default)
            {
                return await DeleteItemAsync(webhookId, ct).ConfigureAwait(false);
            }

        /// <summary>
        /// Delete a <see cref="Webhook"/>.
        /// </summary>
        /// <param name="webhook">The webhook to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Webhook"/>.</returns>
        public async Task<bool> DeleteAsync(Webhook webhook, CancellationToken ct = default)
        {
            if (webhook is null)
                throw new ArgumentNullException(nameof(webhook));

            return await DeleteAsync(webhook.Id, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Webhook"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly WebhookClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(WebhookClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified webhook using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="webhookId">The unique identifier of the webhook for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long webhookId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(webhookId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified webhook using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="webhook">The webhook for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Webhook webhook, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (webhook is null)
                    throw new ArgumentNullException(nameof(webhook));

                return await GetAsync(webhook.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified webhook using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="webhookId">The unique identifier of the webhook for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long webhookId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(webhookId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified webhook using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="webhook">The webhook for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Webhook webhook, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (webhook is null)
                    throw new ArgumentNullException(nameof(webhook));

                return StreamAsync(webhook.Id, query, ct);
            }
        }
    }
}
