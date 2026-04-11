using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ProjectRiskLevel"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/project_risk_levels/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ProjectRiskLevelClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ProjectRiskLevel"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRiskLevelClient"/> class.
        /// </summary>
        internal ProjectRiskLevelClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "project_risk_levels/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ProjectRiskLevel"/> using the specified <see cref="ProjectRiskLevelQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which project risk levels to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ProjectRiskLevel"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ProjectRiskLevel>> GetAsync(ProjectRiskLevelQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ProjectRiskLevel>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ProjectRiskLevel"/> items as an asynchronous stream using the specified <see cref="ProjectRiskLevelQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which project risk levels to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectRiskLevel"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ProjectRiskLevel> StreamAsync(ProjectRiskLevelQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ProjectRiskLevel>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ProjectRiskLevel"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project risk level.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ProjectRiskLevel"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ProjectRiskLevel?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ProjectRiskLevel>(new ProjectRiskLevelQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ProjectRiskLevel"/>.
        /// </summary>
        /// <param name="projectRiskLevel">The project risk level to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ProjectRiskLevel"/>.</returns>
        public async Task<ProjectRiskLevel> CreateAsync(ProjectRiskLevel projectRiskLevel, CancellationToken ct = default)
        {
            return await PostItemAsync(projectRiskLevel, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ProjectRiskLevel"/>.
        /// </summary>
        /// <param name="projectRiskLevel">The project risk level to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ProjectRiskLevel"/>.</returns>
        public async Task<ProjectRiskLevel> UpdateAsync(ProjectRiskLevel projectRiskLevel, CancellationToken ct = default)
        {
            return await PatchItemAsync(projectRiskLevel, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ProjectRiskLevel"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ProjectRiskLevelClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ProjectRiskLevelClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project risk level using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectRiskLevelId">The unique identifier of the project risk level for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long projectRiskLevelId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(projectRiskLevelId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project risk level using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectRiskLevel">The project risk level for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ProjectRiskLevel projectRiskLevel, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (projectRiskLevel is null)
                    throw new ArgumentNullException(nameof(projectRiskLevel));

                return await GetAsync(projectRiskLevel.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project risk level using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectRiskLevelId">The unique identifier of the project risk level for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long projectRiskLevelId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(projectRiskLevelId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project risk level using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectRiskLevel">The project risk level for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ProjectRiskLevel projectRiskLevel, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (projectRiskLevel is null)
                    throw new ArgumentNullException(nameof(projectRiskLevel));

                return StreamAsync(projectRiskLevel.Id, query, ct);
            }
        }
    }
}
