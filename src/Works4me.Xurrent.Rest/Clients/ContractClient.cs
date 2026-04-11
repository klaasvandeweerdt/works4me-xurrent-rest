using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Contract"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/contracts/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ContractClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Contract"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Contract"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractClient"/> class.
        /// </summary>
        internal ContractClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "contracts/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Contract"/> using the specified <see cref="ContractQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which contracts to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Contract"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Contract>> GetAsync(ContractQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Contract>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Contract"/> items as an asynchronous stream using the specified <see cref="ContractQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which contracts to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Contract"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Contract> StreamAsync(ContractQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Contract>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Contract"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contract.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Contract"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Contract?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Contract>(new ContractQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Contract"/>.
        /// </summary>
        /// <param name="contract">The contract to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Contract"/>.</returns>
        public async Task<Contract> CreateAsync(Contract contract, CancellationToken ct = default)
        {
            return await PostItemAsync(contract, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Contract"/>.
        /// </summary>
        /// <param name="contract">The contract to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Contract"/>.</returns>
        public async Task<Contract> UpdateAsync(Contract contract, CancellationToken ct = default)
        {
            return await PatchItemAsync(contract, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Contract"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ContractClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ContractClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified contract using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="contractId">The unique identifier of the contract for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long contractId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(contractId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified contract using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="contract">The contract for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Contract contract, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return await GetAsync(contract.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified contract using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="contractId">The unique identifier of the contract for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long contractId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(contractId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified contract using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="contract">The contract for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Contract contract, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return StreamAsync(contract.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Contract"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly ContractClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(ContractClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified contract using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="contractId">The unique identifier of the contract for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long contractId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(contractId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified contract using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="contract">The contract for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(Contract contract, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return await GetAsync(contract.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified contract using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="contractId">The unique identifier of the contract for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long contractId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(contractId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified contract using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="contract">The contract for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(Contract contract, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return StreamAsync(contract.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contractId">The identifier of the contract.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long contractId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(contractId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contractId">The identifier of the contract.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long contractId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(contractId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contract">The contract from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Contract contract, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(contract.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contract">The contract from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Contract contract, long configurationItemId, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return await AddAsync(contract.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contractId">The identifier of the contract.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long contractId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(contractId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contractId">The identifier of the contract.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long contractId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(contractId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contract">The contract from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Contract contract, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(contract.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contract">The contract from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Contract contract, long configurationItemId, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return await RemoveAsync(contract.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contractId">The identifier of the contract.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long contractId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(contractId, "cis", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="Contract"/>.
            /// </summary>
            /// <param name="contract">The contract from which all configuration items are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Contract contract, CancellationToken ct = default)
            {
                if (contract is null)
                    throw new ArgumentNullException(nameof(contract));

                return await RemoveAllAsync(contract.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
