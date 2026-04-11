using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="CustomCollectionElement"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/custom_collection_elements/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class CustomCollectionElementClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="CustomCollectionElement"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCollectionElementClient"/> class.
        /// </summary>
        internal CustomCollectionElementClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "custom_collection_elements/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="CustomCollectionElement"/> using the specified <see cref="CustomCollectionElementQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which custom collection elements to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="CustomCollectionElement"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<CustomCollectionElement>> GetAsync(CustomCollectionElementQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<CustomCollectionElement>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="CustomCollectionElement"/> items as an asynchronous stream using the specified <see cref="CustomCollectionElementQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which custom collection elements to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="CustomCollectionElement"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<CustomCollectionElement> StreamAsync(CustomCollectionElementQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<CustomCollectionElement>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="CustomCollectionElement"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the custom collection element.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="CustomCollectionElement"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<CustomCollectionElement?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<CustomCollectionElement>(new CustomCollectionElementQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="CustomCollectionElement"/>.
        /// </summary>
        /// <param name="customCollectionElement">The custom collection element to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="CustomCollectionElement"/>.</returns>
        public async Task<CustomCollectionElement> CreateAsync(CustomCollectionElement customCollectionElement, CancellationToken ct = default)
        {
            return await PostItemAsync(customCollectionElement, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="CustomCollectionElement"/>.
        /// </summary>
        /// <param name="customCollectionElement">The custom collection element to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="CustomCollectionElement"/>.</returns>
        public async Task<CustomCollectionElement> UpdateAsync(CustomCollectionElement customCollectionElement, CancellationToken ct = default)
        {
            return await PatchItemAsync(customCollectionElement, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="CustomCollectionElement"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly CustomCollectionElementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(CustomCollectionElementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified custom collection element using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="customCollectionElementId">The unique identifier of the custom collection element for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long customCollectionElementId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(customCollectionElementId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified custom collection element using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="customCollectionElement">The custom collection element for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(CustomCollectionElement customCollectionElement, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (customCollectionElement is null)
                    throw new ArgumentNullException(nameof(customCollectionElement));

                return await GetAsync(customCollectionElement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified custom collection element using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="customCollectionElementId">The unique identifier of the custom collection element for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long customCollectionElementId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(customCollectionElementId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified custom collection element using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="customCollectionElement">The custom collection element for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(CustomCollectionElement customCollectionElement, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (customCollectionElement is null)
                    throw new ArgumentNullException(nameof(customCollectionElement));

                return StreamAsync(customCollectionElement.Id, query, ct);
            }
        }
    }
}
