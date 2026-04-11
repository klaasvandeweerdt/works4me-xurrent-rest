using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ConfigurationItem"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/configuration_items/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ConfigurationItemClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Contract"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public ContractsClient Contracts { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Problem"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public ProblemsClient Problems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItemRelation"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public RelationsClient Relations { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Request"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public RequestClient Request { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Person"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public UsersClient Users { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTask"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public WorkflowTasksClient WorkflowTasks { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationItemClient"/> class.
        /// </summary>
        internal ConfigurationItemClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "cis/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Contracts = new ContractsClient(this);
            Problems = new ProblemsClient(this);
            Relations = new RelationsClient(this);
            Request = new RequestClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
            Users = new UsersClient(this);
            WorkflowTasks = new WorkflowTasksClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ConfigurationItem"/> using the specified <see cref="ConfigurationItemQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which configuration items to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(ConfigurationItemQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ConfigurationItem>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream using the specified <see cref="ConfigurationItemQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which configuration items to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ConfigurationItem> StreamAsync(ConfigurationItemQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ConfigurationItem>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ConfigurationItem"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the configuration item.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ConfigurationItem"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ConfigurationItem?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ConfigurationItem>(new ConfigurationItemQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Archive a <see cref="ConfigurationItem"/>.<br />
        /// The configuration item must be disabled.
        /// </summary>
        /// <param name="configurationItem">The configuration item to archive.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The archived <see cref="ConfigurationItem"/>.</returns>
        public async Task<ConfigurationItem> ArchiveAsync(ConfigurationItem configurationItem, CancellationToken ct = default)
        {
            return await PostItemAsync(configurationItem, "archive", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ConfigurationItem"/>.
        /// </summary>
        /// <param name="configurationItem">The configuration item to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ConfigurationItem"/>.</returns>
        public async Task<ConfigurationItem> CreateAsync(ConfigurationItem configurationItem, CancellationToken ct = default)
        {
            return await PostItemAsync(configurationItem, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="ConfigurationItem"/>.
        /// </summary>
        /// <param name="configurationItemId">The identifier of the configuration item to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="ConfigurationItem"/>.</returns>
        public async Task<ConfigurationItem> RestoreAsync(long configurationItemId, CancellationToken ct = default)
        {
            return await PostItemAsync(new ConfigurationItem(configurationItemId), "restore", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="ConfigurationItem"/>.
        /// </summary>
        /// <param name="reference">The reference to the configuration item to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="ConfigurationItem"/>.</returns>
        public async Task<ConfigurationItem> RestoreAsync(ResourceReference reference, CancellationToken ct = default)
        {
            if (reference is null)
                throw new ArgumentNullException(nameof(reference));

            if (!reference.Id.HasValue)
                throw new ArgumentException("The archive reference must have a valid identifier.", nameof(reference));

            return await RestoreAsync(reference.Id.Value, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Trash a <see cref="ConfigurationItem"/>.<br />
        /// The configuration item must be disabled.
        /// </summary>
        /// <param name="configurationItem">The configuration item to trash.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The trashed <see cref="ConfigurationItem"/>.</returns>
        public async Task<ConfigurationItem> TrashAsync(ConfigurationItem configurationItem, CancellationToken ct = default)
        {
            return await PostItemAsync(configurationItem, "trash", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ConfigurationItem"/>.
        /// </summary>
        /// <param name="configurationItem">The configuration item to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ConfigurationItem"/>.</returns>
        public async Task<ConfigurationItem> UpdateAsync(ConfigurationItem configurationItem, CancellationToken ct = default)
        {
            return await PatchItemAsync(configurationItem, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ConfigurationItemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ConfigurationItemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified configuration item using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long configurationItemId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(configurationItemId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified configuration item using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ConfigurationItem configurationItem, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await GetAsync(configurationItem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified configuration item using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long configurationItemId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(configurationItemId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified configuration item using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ConfigurationItem configurationItem, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return StreamAsync(configurationItem.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Contract"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public sealed class ContractsClient
        {
            private readonly ConfigurationItemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ContractsClient"/> class.
            /// </summary>
            internal ContractsClient(ConfigurationItemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Contract"/> records for the specified configuration item using an <see cref="ContractQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to retrieve the contracts.</param>
            /// <param name="query">The query that defines which contracts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Contract"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Contract>> GetAsync(long configurationItemId, ContractQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Contract>(configurationItemId, "contracts", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Contract"/> records for the specified configuration item using an <see cref="ContractQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to retrieve the contracts.</param>
            /// <param name="query">The query that defines which contracts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Contract"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Contract>> GetAsync(ConfigurationItem configurationItem, ContractQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await GetAsync(configurationItem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Contract"/> items as an asynchronous stream for the specified configuration item using an <see cref="ContractQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to enumerate the contracts.</param>
            /// <param name="query">The query that defines which contracts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Contract"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Contract> StreamAsync(long configurationItemId, ContractQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Contract>(configurationItemId, "contracts", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Contract"/> items as an asynchronous stream for the specified configuration item using an <see cref="ContractQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to enumerate the contracts.</param>
            /// <param name="query">The query that defines which contracts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Contract"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Contract> StreamAsync(ConfigurationItem configurationItem, ContractQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return StreamAsync(configurationItem.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Contract"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="contractId">The identifier of the contract to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long configurationItemId, long contractId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(configurationItemId, "contracts", contractId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Contract"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="contract">The contract to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long configurationItemId, Contract contract, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return await AddAsync(configurationItemId, contract.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Contract"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the contract is removed.</param>
            /// <param name="contract">The contract to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ConfigurationItem configurationItem, Contract contract, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return await AddAsync(configurationItem.Id, contract.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Contract"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the contract is removed.</param>
            /// <param name="contractId">The identifier of the contract to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ConfigurationItem configurationItem, long contractId, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(configurationItem.Id, contractId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Contract"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="contractId">The identifier of the contract to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long configurationItemId, long contractId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(configurationItemId, "contracts", contractId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Contract"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="contract">The contract to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long configurationItemId, Contract contract, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return await RemoveAsync(configurationItemId, contract.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Contract"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the contract is removed.</param>
            /// <param name="contract">The contract to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ConfigurationItem configurationItem, Contract contract, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return await RemoveAsync(configurationItem.Id, contract.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Contract"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the contract is removed.</param>
            /// <param name="contractId">The identifier of the contract to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ConfigurationItem configurationItem, long contractId, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(configurationItem.Id, contractId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all contracts associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(configurationItemId, "contracts", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all contracts associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which all contracts are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAllAsync(configurationItem.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Problem"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public sealed class ProblemsClient
        {
            private readonly ConfigurationItemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ProblemsClient"/> class.
            /// </summary>
            internal ProblemsClient(ConfigurationItemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Problem"/> records for the specified configuration item using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to retrieve the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Problem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Problem>> GetAsync(long configurationItemId, ProblemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Problem>(configurationItemId, "problems", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Problem"/> records for the specified configuration item using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to retrieve the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Problem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Problem>> GetAsync(ConfigurationItem configurationItem, ProblemQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await GetAsync(configurationItem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Problem"/> items as an asynchronous stream for the specified configuration item using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to enumerate the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Problem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Problem> StreamAsync(long configurationItemId, ProblemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Problem>(configurationItemId, "problems", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Problem"/> items as an asynchronous stream for the specified configuration item using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to enumerate the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Problem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Problem> StreamAsync(ConfigurationItem configurationItem, ProblemQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return StreamAsync(configurationItem.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItemRelation"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public sealed class RelationsClient
        {
            private readonly ConfigurationItemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RelationsClient"/> class.
            /// </summary>
            internal RelationsClient(ConfigurationItemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItemRelation"/> records for the specified configuration item using an <see cref="ConfigurationItemRelationQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to retrieve the relations.</param>
            /// <param name="query">The query that defines which relations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItemRelation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItemRelation>> GetAsync(long configurationItemId, ConfigurationItemRelationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItemRelation>(configurationItemId, "ci_relations", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItemRelation"/> records for the specified configuration item using an <see cref="ConfigurationItemRelationQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to retrieve the relations.</param>
            /// <param name="query">The query that defines which relations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItemRelation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItemRelation>> GetAsync(ConfigurationItem configurationItem, ConfigurationItemRelationQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await GetAsync(configurationItem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItemRelation"/> items as an asynchronous stream for the specified configuration item using an <see cref="ConfigurationItemRelationQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to enumerate the relations.</param>
            /// <param name="query">The query that defines which relations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItemRelation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItemRelation> StreamAsync(long configurationItemId, ConfigurationItemRelationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItemRelation>(configurationItemId, "ci_relations", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItemRelation"/> items as an asynchronous stream for the specified configuration item using an <see cref="ConfigurationItemRelationQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to enumerate the relations.</param>
            /// <param name="query">The query that defines which relations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItemRelation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItemRelation> StreamAsync(ConfigurationItem configurationItem, ConfigurationItemRelationQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return StreamAsync(configurationItem.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="ConfigurationItemRelation"/> by its unique identifier for the specified configuration item.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item.</param>
            /// <param name="configurationItemRelationId">The unique identifier of the configuration item relation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="ConfigurationItemRelation"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<ConfigurationItemRelation?> GetAsync(long configurationItemId, long configurationItemRelationId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<ConfigurationItemRelation>(configurationItemId, "ci_relations", new ConfigurationItemRelationQuery().WithId(configurationItemRelationId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="ConfigurationItemRelation"/> record for the specified configuration item.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to retrieve the configuration item relation.</param>
            /// <param name="configurationItemRelationId">The unique identifier of the configuration item relation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="ConfigurationItemRelation"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<ConfigurationItemRelation?> GetAsync(ConfigurationItem configurationItem, long configurationItemRelationId, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await GetAsync(configurationItem.Id, configurationItemRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="ConfigurationItemRelation"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="configurationItemRelation">The configuration item relation to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ConfigurationItemRelation"/>.</returns>
            public async Task<ConfigurationItemRelation> CreateAsync(long configurationItemId, ConfigurationItemRelation configurationItemRelation, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(configurationItemId, "ci_relations", configurationItemRelation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="ConfigurationItemRelation"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item to which the configuration item relation is added.</param>
            /// <param name="configurationItemRelation">The configuration item relation to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ConfigurationItemRelation"/>.</returns>
            public async Task<ConfigurationItemRelation> CreateAsync(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await CreateAsync(configurationItem.Id, configurationItemRelation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="ConfigurationItemRelation"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="configurationItemRelation">The configuration item relation to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ConfigurationItemRelation"/>.</returns>
            public async Task<ConfigurationItemRelation> UpdateAsync(long configurationItemId, ConfigurationItemRelation configurationItemRelation, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(configurationItemId, "ci_relations", configurationItemRelation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="ConfigurationItemRelation"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item with which the configuration item relation is associated.</param>
            /// <param name="configurationItemRelation">The configuration item relation to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ConfigurationItemRelation"/>.</returns>
            public async Task<ConfigurationItemRelation> UpdateAsync(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await UpdateAsync(configurationItem.Id, configurationItemRelation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ConfigurationItemRelation"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="configurationItemRelationId">The identifier of the configuration item relation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long configurationItemId, long configurationItemRelationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(configurationItemId, "ci_relations", configurationItemRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ConfigurationItemRelation"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="configurationItemRelation">The configuration item relation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long configurationItemId, ConfigurationItemRelation configurationItemRelation, CancellationToken ct = default)
            {
                if (configurationItemRelation is null)
                    throw new ArgumentNullException(nameof(configurationItemRelation));

                return await DeleteAsync(configurationItemId, configurationItemRelation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ConfigurationItemRelation"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the configuration item relation is removed.</param>
            /// <param name="configurationItemRelation">The configuration item relation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ConfigurationItem configurationItem, ConfigurationItemRelation configurationItemRelation, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                if (configurationItemRelation is null)
                    throw new ArgumentNullException(nameof(configurationItemRelation));

                return await DeleteAsync(configurationItem.Id, configurationItemRelation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ConfigurationItemRelation"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the configuration item relation is removed.</param>
            /// <param name="configurationItemRelationId">The identifier of the configuration item relation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ConfigurationItem configurationItem, long configurationItemRelationId, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await DeleteAsync(configurationItem.Id, configurationItemRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all configuration item relations associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(configurationItemId, "ci_relations", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all configuration item relations associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which all configuration item relations are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await DeleteAllAsync(configurationItem.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Request"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public sealed class RequestClient
        {
            private readonly ConfigurationItemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RequestClient"/> class.
            /// </summary>
            internal RequestClient(ConfigurationItemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified configuration item using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to retrieve the request.</param>
            /// <param name="query">The query that defines which request to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(long configurationItemId, RequestQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Request>(configurationItemId, "requests", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified configuration item using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to retrieve the request.</param>
            /// <param name="query">The query that defines which request to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(ConfigurationItem configurationItem, RequestQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await GetAsync(configurationItem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified configuration item using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to enumerate the request.</param>
            /// <param name="query">The query that defines which request to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(long configurationItemId, RequestQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Request>(configurationItemId, "requests", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified configuration item using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to enumerate the request.</param>
            /// <param name="query">The query that defines which request to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(ConfigurationItem configurationItem, RequestQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return StreamAsync(configurationItem.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly ConfigurationItemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(ConfigurationItemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified configuration item using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long configurationItemId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(configurationItemId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified configuration item using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(ConfigurationItem configurationItem, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await GetAsync(configurationItem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified configuration item using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long configurationItemId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(configurationItemId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified configuration item using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(ConfigurationItem configurationItem, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return StreamAsync(configurationItem.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long configurationItemId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(configurationItemId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long configurationItemId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(configurationItemId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ConfigurationItem configurationItem, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(configurationItem.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ConfigurationItem configurationItem, long serviceInstanceId, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(configurationItem.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long configurationItemId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(configurationItemId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long configurationItemId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(configurationItemId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ConfigurationItem configurationItem, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(configurationItem.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ConfigurationItem configurationItem, long serviceInstanceId, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(configurationItem.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(configurationItemId, "service_instances", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which all service instances are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAllAsync(configurationItem.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Person"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public sealed class UsersClient
        {
            private readonly ConfigurationItemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="UsersClient"/> class.
            /// </summary>
            internal UsersClient(ConfigurationItemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified configuration item using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to retrieve the users.</param>
            /// <param name="query">The query that defines which users to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(long configurationItemId, PersonQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Person>(configurationItemId, "users", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified configuration item using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to retrieve the users.</param>
            /// <param name="query">The query that defines which users to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(ConfigurationItem configurationItem, PersonQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await GetAsync(configurationItem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified configuration item using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to enumerate the users.</param>
            /// <param name="query">The query that defines which users to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(long configurationItemId, PersonQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Person>(configurationItemId, "users", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified configuration item using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to enumerate the users.</param>
            /// <param name="query">The query that defines which users to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(ConfigurationItem configurationItem, PersonQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return StreamAsync(configurationItem.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long configurationItemId, long personId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(configurationItemId, "users", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long configurationItemId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(configurationItemId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the person is removed.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ConfigurationItem configurationItem, Person person, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(configurationItem.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ConfigurationItem configurationItem, long personId, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(configurationItem.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long configurationItemId, long personId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(configurationItemId, "users", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long configurationItemId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(configurationItemId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the person is removed.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ConfigurationItem configurationItem, Person person, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(configurationItem.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ConfigurationItem configurationItem, long personId, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(configurationItem.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all users associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItemId">The identifier of the configuration item.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(configurationItemId, "users", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all users associated with a <see cref="ConfigurationItem"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item from which all users are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAllAsync(configurationItem.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTask"/> records related to an <see cref="ConfigurationItem"/>.
        /// </summary>
        public sealed class WorkflowTasksClient
        {
            private readonly ConfigurationItemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="WorkflowTasksClient"/> class.
            /// </summary>
            internal WorkflowTasksClient(ConfigurationItemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified configuration item using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to retrieve the workflow tasks.</param>
            /// <param name="query">The query that defines which workflow tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(long configurationItemId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTask>(configurationItemId, "tasks", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified configuration item using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to retrieve the workflow tasks.</param>
            /// <param name="query">The query that defines which workflow tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(ConfigurationItem configurationItem, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await GetAsync(configurationItem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified configuration item using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="configurationItemId">The unique identifier of the configuration item for which to enumerate the workflow tasks.</param>
            /// <param name="query">The query that defines which workflow tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(long configurationItemId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTask>(configurationItemId, "tasks", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified configuration item using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="configurationItem">The configuration item for which to enumerate the workflow tasks.</param>
            /// <param name="query">The query that defines which workflow tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(ConfigurationItem configurationItem, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return StreamAsync(configurationItem.Id, query, ct);
            }
        }
    }
}
