using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="CustomCollection"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/custom_collections/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class CustomCollectionClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="CustomCollection"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="CustomCollectionElement"/> records related to an <see cref="CustomCollection"/>.
        /// </summary>
        public ElementsClient Elements { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCollectionClient"/> class.
        /// </summary>
        internal CustomCollectionClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "custom_collections/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Elements = new ElementsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="CustomCollection"/> using the specified <see cref="CustomCollectionQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which custom collection to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="CustomCollection"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<CustomCollection>> GetAsync(CustomCollectionQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<CustomCollection>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="CustomCollection"/> items as an asynchronous stream using the specified <see cref="CustomCollectionQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which custom collection to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="CustomCollection"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<CustomCollection> StreamAsync(CustomCollectionQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<CustomCollection>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="CustomCollection"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the custom collection.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="CustomCollection"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<CustomCollection?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<CustomCollection>(new CustomCollectionQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="CustomCollection"/>.
        /// </summary>
        /// <param name="customCollection">The custom collection to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="CustomCollection"/>.</returns>
        public async Task<CustomCollection> CreateAsync(CustomCollection customCollection, CancellationToken ct = default)
        {
            return await PostItemAsync(customCollection, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="CustomCollection"/>.
        /// </summary>
        /// <param name="customCollection">The custom collection to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="CustomCollection"/>.</returns>
        public async Task<CustomCollection> UpdateAsync(CustomCollection customCollection, CancellationToken ct = default)
        {
            return await PatchItemAsync(customCollection, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="CustomCollection"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly CustomCollectionClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(CustomCollectionClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified custom collection using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="customCollectionId">The unique identifier of the custom collection for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long customCollectionId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(customCollectionId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified custom collection using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="customCollection">The custom collection for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(CustomCollection customCollection, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (customCollection is null)
                    throw new ArgumentNullException(nameof(customCollection));

                return await GetAsync(customCollection.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified custom collection using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="customCollectionId">The unique identifier of the custom collection for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long customCollectionId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(customCollectionId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified custom collection using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="customCollection">The custom collection for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(CustomCollection customCollection, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (customCollection is null)
                    throw new ArgumentNullException(nameof(customCollection));

                return StreamAsync(customCollection.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="CustomCollectionElement"/> records related to an <see cref="CustomCollection"/>.
        /// </summary>
        public sealed class ElementsClient
        {
            private readonly CustomCollectionClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ElementsClient"/> class.
            /// </summary>
            internal ElementsClient(CustomCollectionClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="CustomCollectionElement"/> records for the specified custom collection using an <see cref="CustomCollectionElementQuery"/>.
            /// </summary>
            /// <param name="customCollectionId">The unique identifier of the custom collection for which to retrieve the elements.</param>
            /// <param name="query">The query that defines which elements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="CustomCollectionElement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<CustomCollectionElement>> GetAsync(long customCollectionId, CustomCollectionElementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<CustomCollectionElement>(customCollectionId, "collection_elements", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="CustomCollectionElement"/> records for the specified custom collection using an <see cref="CustomCollectionElementQuery"/>.
            /// </summary>
            /// <param name="customCollection">The custom collection for which to retrieve the elements.</param>
            /// <param name="query">The query that defines which elements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="CustomCollectionElement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<CustomCollectionElement>> GetAsync(CustomCollection customCollection, CustomCollectionElementQuery query, CancellationToken ct = default)
            {
                if (customCollection is null)
                    throw new ArgumentNullException(nameof(customCollection));

                return await GetAsync(customCollection.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="CustomCollectionElement"/> items as an asynchronous stream for the specified custom collection using an <see cref="CustomCollectionElementQuery"/>.
            /// </summary>
            /// <param name="customCollectionId">The unique identifier of the custom collection for which to enumerate the elements.</param>
            /// <param name="query">The query that defines which elements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="CustomCollectionElement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<CustomCollectionElement> StreamAsync(long customCollectionId, CustomCollectionElementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<CustomCollectionElement>(customCollectionId, "collection_elements", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="CustomCollectionElement"/> items as an asynchronous stream for the specified custom collection using an <see cref="CustomCollectionElementQuery"/>.
            /// </summary>
            /// <param name="customCollection">The custom collection for which to enumerate the elements.</param>
            /// <param name="query">The query that defines which elements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="CustomCollectionElement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<CustomCollectionElement> StreamAsync(CustomCollection customCollection, CustomCollectionElementQuery query, CancellationToken ct = default)
            {
                if (customCollection is null)
                    throw new ArgumentNullException(nameof(customCollection));

                return StreamAsync(customCollection.Id, query, ct);
            }
        }
    }
}
