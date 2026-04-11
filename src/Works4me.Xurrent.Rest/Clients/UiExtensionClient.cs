using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="UiExtension"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/ui_extensions/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class UiExtensionClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="UiExtensionVersion"/> records related to an <see cref="UiExtension"/>.
        /// </summary>
        public VersionsClient Versions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UiExtensionClient"/> class.
        /// </summary>
        internal UiExtensionClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "ui_extensions/"))
        {
            Versions = new VersionsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="UiExtension"/> using the specified <see cref="UiExtensionQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which user interface extensions to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="UiExtension"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<UiExtension>> GetAsync(UiExtensionQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<UiExtension>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="UiExtension"/> items as an asynchronous stream using the specified <see cref="UiExtensionQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which user interface extensions to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="UiExtension"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<UiExtension> StreamAsync(UiExtensionQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<UiExtension>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="UiExtension"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user interface extension.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="UiExtension"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<UiExtension?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<UiExtension>(new UiExtensionQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="UiExtension"/>.
        /// </summary>
        /// <param name="uiExtension">The user interface extension to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="UiExtension"/>.</returns>
        public async Task<UiExtension> CreateAsync(UiExtension uiExtension, CancellationToken ct = default)
        {
            return await PostItemAsync(uiExtension, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="UiExtension"/>.
        /// </summary>
        /// <param name="uiExtension">The user interface extension to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="UiExtension"/>.</returns>
        public async Task<UiExtension> UpdateAsync(UiExtension uiExtension, CancellationToken ct = default)
        {
            return await PatchItemAsync(uiExtension, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="UiExtensionVersion"/> records related to an <see cref="UiExtension"/>.
        /// </summary>
        public sealed class VersionsClient
        {
            private readonly UiExtensionClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="VersionsClient"/> class.
            /// </summary>
            internal VersionsClient(UiExtensionClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="UiExtensionVersion"/> records for the specified user interface extension using an <see cref="UiExtensionVersionQuery"/>.
            /// </summary>
            /// <param name="uiExtensionId">The unique identifier of the user interface extension for which to retrieve the versions.</param>
            /// <param name="query">The query that defines which versions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="UiExtensionVersion"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<UiExtensionVersion>> GetAsync(long uiExtensionId, UiExtensionVersionQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<UiExtensionVersion>(uiExtensionId, "versions", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="UiExtensionVersion"/> records for the specified user interface extension using an <see cref="UiExtensionVersionQuery"/>.
            /// </summary>
            /// <param name="uiExtension">The user interface extension for which to retrieve the versions.</param>
            /// <param name="query">The query that defines which versions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="UiExtensionVersion"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<UiExtensionVersion>> GetAsync(UiExtension uiExtension, UiExtensionVersionQuery query, CancellationToken ct = default)
            {
                if (uiExtension is null)
                    throw new ArgumentNullException(nameof(uiExtension));

                return await GetAsync(uiExtension.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="UiExtensionVersion"/> items as an asynchronous stream for the specified user interface extension using an <see cref="UiExtensionVersionQuery"/>.
            /// </summary>
            /// <param name="uiExtensionId">The unique identifier of the user interface extension for which to enumerate the versions.</param>
            /// <param name="query">The query that defines which versions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="UiExtensionVersion"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<UiExtensionVersion> StreamAsync(long uiExtensionId, UiExtensionVersionQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<UiExtensionVersion>(uiExtensionId, "versions", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="UiExtensionVersion"/> items as an asynchronous stream for the specified user interface extension using an <see cref="UiExtensionVersionQuery"/>.
            /// </summary>
            /// <param name="uiExtension">The user interface extension for which to enumerate the versions.</param>
            /// <param name="query">The query that defines which versions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="UiExtensionVersion"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<UiExtensionVersion> StreamAsync(UiExtension uiExtension, UiExtensionVersionQuery query, CancellationToken ct = default)
            {
                if (uiExtension is null)
                    throw new ArgumentNullException(nameof(uiExtension));

                return StreamAsync(uiExtension.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="UiExtensionVersion"/> by its unique identifier for the specified user interface extension.
            /// </summary>
            /// <param name="uiExtensionId">The unique identifier of the user interface extension.</param>
            /// <param name="uiExtensionVersionId">The unique identifier of the user interface extension version.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="UiExtensionVersion"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<UiExtensionVersion?> GetAsync(long uiExtensionId, long uiExtensionVersionId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<UiExtensionVersion>(uiExtensionId, "versions", new UiExtensionVersionQuery().WithId(uiExtensionVersionId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="UiExtensionVersion"/> record for the specified user interface extension.
            /// </summary>
            /// <param name="uiExtension">The user interface extension for which to retrieve the user interface extension version.</param>
            /// <param name="uiExtensionVersionId">The unique identifier of the user interface extension version.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="UiExtensionVersion"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<UiExtensionVersion?> GetAsync(UiExtension uiExtension, long uiExtensionVersionId, CancellationToken ct = default)
            {
                if (uiExtension is null)
                    throw new ArgumentNullException(nameof(uiExtension));

                return await GetAsync(uiExtension.Id, uiExtensionVersionId, ct).ConfigureAwait(false);
            }
        }
    }
}
