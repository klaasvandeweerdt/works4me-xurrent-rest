using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ScrumWorkspace"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/scrum_workspaces/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ScrumWorkspaceClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ScrumWorkspace"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrumWorkspaceClient"/> class.
        /// </summary>
        internal ScrumWorkspaceClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "scrum_workspaces/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ScrumWorkspace"/> using the specified <see cref="ScrumWorkspaceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which scrum workspaces to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ScrumWorkspace"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ScrumWorkspace>> GetAsync(ScrumWorkspaceQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ScrumWorkspace>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ScrumWorkspace"/> items as an asynchronous stream using the specified <see cref="ScrumWorkspaceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which scrum workspaces to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ScrumWorkspace"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ScrumWorkspace> StreamAsync(ScrumWorkspaceQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ScrumWorkspace>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ScrumWorkspace"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the scrum workspace.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ScrumWorkspace"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ScrumWorkspace?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ScrumWorkspace>(new ScrumWorkspaceQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ScrumWorkspace"/>.
        /// </summary>
        /// <param name="scrumWorkspace">The scrum workspace to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ScrumWorkspace"/>.</returns>
        public async Task<ScrumWorkspace> CreateAsync(ScrumWorkspace scrumWorkspace, CancellationToken ct = default)
        {
            return await PostItemAsync(scrumWorkspace, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ScrumWorkspace"/>.
        /// </summary>
        /// <param name="scrumWorkspace">The scrum workspace to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ScrumWorkspace"/>.</returns>
        public async Task<ScrumWorkspace> UpdateAsync(ScrumWorkspace scrumWorkspace, CancellationToken ct = default)
        {
            return await PatchItemAsync(scrumWorkspace, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ScrumWorkspace"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ScrumWorkspaceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ScrumWorkspaceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified scrum workspace using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="scrumWorkspaceId">The unique identifier of the scrum workspace for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long scrumWorkspaceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(scrumWorkspaceId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified scrum workspace using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="scrumWorkspace">The scrum workspace for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ScrumWorkspace scrumWorkspace, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (scrumWorkspace is null)
                    throw new ArgumentNullException(nameof(scrumWorkspace));

                return await GetAsync(scrumWorkspace.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified scrum workspace using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="scrumWorkspaceId">The unique identifier of the scrum workspace for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long scrumWorkspaceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(scrumWorkspaceId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified scrum workspace using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="scrumWorkspace">The scrum workspace for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ScrumWorkspace scrumWorkspace, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (scrumWorkspace is null)
                    throw new ArgumentNullException(nameof(scrumWorkspace));

                return StreamAsync(scrumWorkspace.Id, query, ct);
            }
        }
    }
}
