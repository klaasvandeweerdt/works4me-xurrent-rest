using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="WorkflowType"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/workflow_types/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class WorkflowTypeClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="WorkflowType"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowTypeClient"/> class.
        /// </summary>
        internal WorkflowTypeClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "workflow_types/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="WorkflowType"/> using the specified <see cref="WorkflowTypeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflow types to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="WorkflowType"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<WorkflowType>> GetAsync(WorkflowTypeQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<WorkflowType>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="WorkflowType"/> items as an asynchronous stream using the specified <see cref="WorkflowTypeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflow types to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowType"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<WorkflowType> StreamAsync(WorkflowTypeQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<WorkflowType>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="WorkflowType"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow type.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="WorkflowType"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<WorkflowType?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<WorkflowType>(new WorkflowTypeQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="WorkflowType"/>.
        /// </summary>
        /// <param name="workflowType">The workflow type to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="WorkflowType"/>.</returns>
        public async Task<WorkflowType> CreateAsync(WorkflowType workflowType, CancellationToken ct = default)
        {
            return await PostItemAsync(workflowType, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="WorkflowType"/>.
        /// </summary>
        /// <param name="workflowType">The workflow type to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="WorkflowType"/>.</returns>
        public async Task<WorkflowType> UpdateAsync(WorkflowType workflowType, CancellationToken ct = default)
        {
            return await PatchItemAsync(workflowType, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="WorkflowType"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly WorkflowTypeClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(WorkflowTypeClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow type using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTypeId">The unique identifier of the workflow type for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long workflowTypeId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(workflowTypeId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow type using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowType">The workflow type for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(WorkflowType workflowType, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflowType is null)
                    throw new ArgumentNullException(nameof(workflowType));

                return await GetAsync(workflowType.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow type using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTypeId">The unique identifier of the workflow type for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long workflowTypeId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(workflowTypeId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow type using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowType">The workflow type for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(WorkflowType workflowType, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflowType is null)
                    throw new ArgumentNullException(nameof(workflowType));

                return StreamAsync(workflowType.Id, query, ct);
            }
        }
    }
}
