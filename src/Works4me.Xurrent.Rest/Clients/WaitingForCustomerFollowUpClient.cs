using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="WaitingForCustomerFollowUp"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/waiting_for_customer_follow_ups/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class WaitingForCustomerFollowUpClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="WaitingForCustomerFollowUp"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WaitingForCustomerRules"/> records related to an <see cref="WaitingForCustomerFollowUp"/>.
        /// </summary>
        public RulesClient Rules { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaitingForCustomerFollowUpClient"/> class.
        /// </summary>
        internal WaitingForCustomerFollowUpClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "waiting_for_customer_follow_ups/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Rules = new RulesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="WaitingForCustomerFollowUp"/> using the specified <see cref="WaitingForCustomerFollowUpQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which waiting for customer follow ups to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="WaitingForCustomerFollowUp"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<WaitingForCustomerFollowUp>> GetAsync(WaitingForCustomerFollowUpQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<WaitingForCustomerFollowUp>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="WaitingForCustomerFollowUp"/> items as an asynchronous stream using the specified <see cref="WaitingForCustomerFollowUpQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which waiting for customer follow ups to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WaitingForCustomerFollowUp"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<WaitingForCustomerFollowUp> StreamAsync(WaitingForCustomerFollowUpQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<WaitingForCustomerFollowUp>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="WaitingForCustomerFollowUp"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the waiting for customer follow up.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="WaitingForCustomerFollowUp"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<WaitingForCustomerFollowUp?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<WaitingForCustomerFollowUp>(new WaitingForCustomerFollowUpQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="WaitingForCustomerFollowUp"/>.
        /// </summary>
        /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="WaitingForCustomerFollowUp"/>.</returns>
        public async Task<WaitingForCustomerFollowUp> CreateAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, CancellationToken ct = default)
        {
            return await PostItemAsync(waitingForCustomerFollowUp, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="WaitingForCustomerFollowUp"/>.
        /// </summary>
        /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="WaitingForCustomerFollowUp"/>.</returns>
        public async Task<WaitingForCustomerFollowUp> UpdateAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, CancellationToken ct = default)
        {
            return await PatchItemAsync(waitingForCustomerFollowUp, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="WaitingForCustomerFollowUp"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly WaitingForCustomerFollowUpClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(WaitingForCustomerFollowUpClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified waiting for customer follow up using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUpId">The unique identifier of the waiting for customer follow up for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long waitingForCustomerFollowUpId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(waitingForCustomerFollowUpId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified waiting for customer follow up using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (waitingForCustomerFollowUp is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerFollowUp));

                return await GetAsync(waitingForCustomerFollowUp.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified waiting for customer follow up using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUpId">The unique identifier of the waiting for customer follow up for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long waitingForCustomerFollowUpId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(waitingForCustomerFollowUpId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified waiting for customer follow up using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (waitingForCustomerFollowUp is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerFollowUp));

                return StreamAsync(waitingForCustomerFollowUp.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WaitingForCustomerRules"/> records related to an <see cref="WaitingForCustomerFollowUp"/>.
        /// </summary>
        public sealed class RulesClient
        {
            private readonly WaitingForCustomerFollowUpClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RulesClient"/> class.
            /// </summary>
            internal RulesClient(WaitingForCustomerFollowUpClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WaitingForCustomerRules"/> records for the specified waiting for customer follow up using an <see cref="WaitingForCustomerRulesQuery"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUpId">The unique identifier of the waiting for customer follow up for which to retrieve the rules.</param>
            /// <param name="query">The query that defines which rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WaitingForCustomerRules"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WaitingForCustomerRules>> GetAsync(long waitingForCustomerFollowUpId, WaitingForCustomerRulesQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WaitingForCustomerRules>(waitingForCustomerFollowUpId, "waiting_for_customer_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WaitingForCustomerRules"/> records for the specified waiting for customer follow up using an <see cref="WaitingForCustomerRulesQuery"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up for which to retrieve the rules.</param>
            /// <param name="query">The query that defines which rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WaitingForCustomerRules"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WaitingForCustomerRules>> GetAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, WaitingForCustomerRulesQuery query, CancellationToken ct = default)
            {
                if (waitingForCustomerFollowUp is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerFollowUp));

                return await GetAsync(waitingForCustomerFollowUp.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WaitingForCustomerRules"/> items as an asynchronous stream for the specified waiting for customer follow up using an <see cref="WaitingForCustomerRulesQuery"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUpId">The unique identifier of the waiting for customer follow up for which to enumerate the rules.</param>
            /// <param name="query">The query that defines which rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WaitingForCustomerRules"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WaitingForCustomerRules> StreamAsync(long waitingForCustomerFollowUpId, WaitingForCustomerRulesQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WaitingForCustomerRules>(waitingForCustomerFollowUpId, "waiting_for_customer_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WaitingForCustomerRules"/> items as an asynchronous stream for the specified waiting for customer follow up using an <see cref="WaitingForCustomerRulesQuery"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up for which to enumerate the rules.</param>
            /// <param name="query">The query that defines which rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WaitingForCustomerRules"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WaitingForCustomerRules> StreamAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, WaitingForCustomerRulesQuery query, CancellationToken ct = default)
            {
                if (waitingForCustomerFollowUp is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerFollowUp));

                return StreamAsync(waitingForCustomerFollowUp.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="WaitingForCustomerRules"/> to a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUpId">The identifier of the waiting for customer follow up.</param>
            /// <param name="waitingForCustomerRules">The waiting for customer rules to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WaitingForCustomerRules"/>.</returns>
            public async Task<WaitingForCustomerRules> CreateAsync(long waitingForCustomerFollowUpId, WaitingForCustomerRules waitingForCustomerRules, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(waitingForCustomerFollowUpId, "waiting_for_customer_rules", waitingForCustomerRules, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WaitingForCustomerRules"/> to a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up to which the waiting for customer rules is added.</param>
            /// <param name="waitingForCustomerRules">The waiting for customer rules to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WaitingForCustomerRules"/>.</returns>
            public async Task<WaitingForCustomerRules> CreateAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, WaitingForCustomerRules waitingForCustomerRules, CancellationToken ct = default)
            {
                if (waitingForCustomerFollowUp is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerFollowUp));

                return await CreateAsync(waitingForCustomerFollowUp.Id, waitingForCustomerRules, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WaitingForCustomerRules"/> associated with a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUpId">The identifier of the waiting for customer follow up.</param>
            /// <param name="waitingForCustomerRules">The waiting for customer rules to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WaitingForCustomerRules"/>.</returns>
            public async Task<WaitingForCustomerRules> UpdateAsync(long waitingForCustomerFollowUpId, WaitingForCustomerRules waitingForCustomerRules, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(waitingForCustomerFollowUpId, "waiting_for_customer_rules", waitingForCustomerRules, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WaitingForCustomerRules"/> associated with a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up with which the waiting for customer rules is associated.</param>
            /// <param name="waitingForCustomerRules">The waiting for customer rules to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WaitingForCustomerRules"/>.</returns>
            public async Task<WaitingForCustomerRules> UpdateAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, WaitingForCustomerRules waitingForCustomerRules, CancellationToken ct = default)
            {
                if (waitingForCustomerFollowUp is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerFollowUp));

                return await UpdateAsync(waitingForCustomerFollowUp.Id, waitingForCustomerRules, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WaitingForCustomerRules"/> associated with a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUpId">The identifier of the waiting for customer follow up.</param>
            /// <param name="waitingForCustomerRulesId">The identifier of the waiting for customer rules to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long waitingForCustomerFollowUpId, long waitingForCustomerRulesId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(waitingForCustomerFollowUpId, "waiting_for_customer_rules", waitingForCustomerRulesId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WaitingForCustomerRules"/> associated with a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUpId">The identifier of the waiting for customer follow up.</param>
            /// <param name="waitingForCustomerRules">The waiting for customer rules to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long waitingForCustomerFollowUpId, WaitingForCustomerRules waitingForCustomerRules, CancellationToken ct = default)
            {
                if (waitingForCustomerRules is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerRules));

                return await DeleteAsync(waitingForCustomerFollowUpId, waitingForCustomerRules.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WaitingForCustomerRules"/> associated with a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up from which the waiting for customer rules is removed.</param>
            /// <param name="waitingForCustomerRules">The waiting for customer rules to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, WaitingForCustomerRules waitingForCustomerRules, CancellationToken ct = default)
            {
                if (waitingForCustomerFollowUp is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerFollowUp));

                if (waitingForCustomerRules is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerRules));

                return await DeleteAsync(waitingForCustomerFollowUp.Id, waitingForCustomerRules.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WaitingForCustomerRules"/> associated with a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up from which the waiting for customer rules is removed.</param>
            /// <param name="waitingForCustomerRulesId">The identifier of the waiting for customer rules to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, long waitingForCustomerRulesId, CancellationToken ct = default)
            {
                if (waitingForCustomerFollowUp is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerFollowUp));

                return await DeleteAsync(waitingForCustomerFollowUp.Id, waitingForCustomerRulesId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all waiting for customer rules associated with a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUpId">The identifier of the waiting for customer follow up.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long waitingForCustomerFollowUpId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(waitingForCustomerFollowUpId, "waiting_for_customer_rules", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all waiting for customer rules associated with a <see cref="WaitingForCustomerFollowUp"/>.
            /// </summary>
            /// <param name="waitingForCustomerFollowUp">The waiting for customer follow up from which all waiting for customer rules are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(WaitingForCustomerFollowUp waitingForCustomerFollowUp, CancellationToken ct = default)
            {
                if (waitingForCustomerFollowUp is null)
                    throw new ArgumentNullException(nameof(waitingForCustomerFollowUp));

                return await DeleteAllAsync(waitingForCustomerFollowUp.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
