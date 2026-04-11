using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ProjectCategory"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/project_categories/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ProjectCategoryClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ProjectCategory"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectCategoryClient"/> class.
        /// </summary>
        internal ProjectCategoryClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "project_categories/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ProjectCategory"/> using the specified <see cref="ProjectCategoryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which project categories to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ProjectCategory"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ProjectCategory>> GetAsync(ProjectCategoryQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ProjectCategory>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ProjectCategory"/> items as an asynchronous stream using the specified <see cref="ProjectCategoryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which project categories to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectCategory"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ProjectCategory> StreamAsync(ProjectCategoryQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ProjectCategory>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ProjectCategory"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project category.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ProjectCategory"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ProjectCategory?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ProjectCategory>(new ProjectCategoryQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ProjectCategory"/>.
        /// </summary>
        /// <param name="projectCategory">The project category to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ProjectCategory"/>.</returns>
        public async Task<ProjectCategory> CreateAsync(ProjectCategory projectCategory, CancellationToken ct = default)
        {
            return await PostItemAsync(projectCategory, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ProjectCategory"/>.
        /// </summary>
        /// <param name="projectCategory">The project category to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ProjectCategory"/>.</returns>
        public async Task<ProjectCategory> UpdateAsync(ProjectCategory projectCategory, CancellationToken ct = default)
        {
            return await PatchItemAsync(projectCategory, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ProjectCategory"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ProjectCategoryClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ProjectCategoryClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectCategoryId">The unique identifier of the project category for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long projectCategoryId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(projectCategoryId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectCategory">The project category for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ProjectCategory projectCategory, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (projectCategory is null)
                    throw new ArgumentNullException(nameof(projectCategory));

                return await GetAsync(projectCategory.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectCategoryId">The unique identifier of the project category for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long projectCategoryId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(projectCategoryId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectCategory">The project category for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ProjectCategory projectCategory, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (projectCategory is null)
                    throw new ArgumentNullException(nameof(projectCategory));

                return StreamAsync(projectCategory.Id, query, ct);
            }
        }
    }
}
