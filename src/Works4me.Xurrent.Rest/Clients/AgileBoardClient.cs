using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="AgileBoard"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/agile_boards/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class AgileBoardClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="AgileBoard"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AgileBoardColumn"/> records related to an <see cref="AgileBoard"/>.
        /// </summary>
        public ColumnsClient Columns { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="AgileBoard"/>.
        /// </summary>
        public CustomerRepresentativeSLAsClient CustomerRepresentativeSLAs { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileBoardClient"/> class.
        /// </summary>
        internal AgileBoardClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "agile_boards/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Columns = new ColumnsClient(this);
            CustomerRepresentativeSLAs = new CustomerRepresentativeSLAsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="AgileBoard"/> using the specified <see cref="AgileBoardQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which agile boards to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="AgileBoard"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<AgileBoard>> GetAsync(AgileBoardQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<AgileBoard>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="AgileBoard"/> items as an asynchronous stream using the specified <see cref="AgileBoardQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which agile boards to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AgileBoard"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<AgileBoard> StreamAsync(AgileBoardQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<AgileBoard>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="AgileBoard"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the agile board.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="AgileBoard"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<AgileBoard?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<AgileBoard>(new AgileBoardQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="AgileBoard"/>.
        /// </summary>
        /// <param name="agileBoard">The agile board to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="AgileBoard"/>.</returns>
        public async Task<AgileBoard> CreateAsync(AgileBoard agileBoard, CancellationToken ct = default)
        {
            return await PostItemAsync(agileBoard, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="AgileBoard"/>.
        /// </summary>
        /// <param name="agileBoard">The agile board to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="AgileBoard"/>.</returns>
        public async Task<AgileBoard> UpdateAsync(AgileBoard agileBoard, CancellationToken ct = default)
        {
            return await PatchItemAsync(agileBoard, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="AgileBoard"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly AgileBoardClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(AgileBoardClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified agile board using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="agileBoardId">The unique identifier of the agile board for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long agileBoardId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(agileBoardId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified agile board using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(AgileBoard agileBoard, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await GetAsync(agileBoard.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified agile board using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="agileBoardId">The unique identifier of the agile board for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long agileBoardId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(agileBoardId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified agile board using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(AgileBoard agileBoard, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return StreamAsync(agileBoard.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AgileBoardColumn"/> records related to an <see cref="AgileBoard"/>.
        /// </summary>
        public sealed class ColumnsClient
        {
            private readonly AgileBoardClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ColumnsClient"/> class.
            /// </summary>
            internal ColumnsClient(AgileBoardClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AgileBoardColumn"/> records for the specified agile board using an <see cref="AgileBoardColumnQuery"/>.
            /// </summary>
            /// <param name="agileBoardId">The unique identifier of the agile board for which to retrieve the columns.</param>
            /// <param name="query">The query that defines which columns to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AgileBoardColumn"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AgileBoardColumn>> GetAsync(long agileBoardId, AgileBoardColumnQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AgileBoardColumn>(agileBoardId, "agile_board_columns", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AgileBoardColumn"/> records for the specified agile board using an <see cref="AgileBoardColumnQuery"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board for which to retrieve the columns.</param>
            /// <param name="query">The query that defines which columns to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AgileBoardColumn"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AgileBoardColumn>> GetAsync(AgileBoard agileBoard, AgileBoardColumnQuery query, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await GetAsync(agileBoard.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AgileBoardColumn"/> items as an asynchronous stream for the specified agile board using an <see cref="AgileBoardColumnQuery"/>.
            /// </summary>
            /// <param name="agileBoardId">The unique identifier of the agile board for which to enumerate the columns.</param>
            /// <param name="query">The query that defines which columns to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AgileBoardColumn"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AgileBoardColumn> StreamAsync(long agileBoardId, AgileBoardColumnQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AgileBoardColumn>(agileBoardId, "agile_board_columns", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AgileBoardColumn"/> items as an asynchronous stream for the specified agile board using an <see cref="AgileBoardColumnQuery"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board for which to enumerate the columns.</param>
            /// <param name="query">The query that defines which columns to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AgileBoardColumn"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AgileBoardColumn> StreamAsync(AgileBoard agileBoard, AgileBoardColumnQuery query, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return StreamAsync(agileBoard.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="AgileBoardColumn"/> by its unique identifier for the specified agile board.
            /// </summary>
            /// <param name="agileBoardId">The unique identifier of the agile board.</param>
            /// <param name="agileBoardColumnId">The unique identifier of the agile board column.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="AgileBoardColumn"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<AgileBoardColumn?> GetAsync(long agileBoardId, long agileBoardColumnId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<AgileBoardColumn>(agileBoardId, "agile_board_columns", new AgileBoardColumnQuery().WithId(agileBoardColumnId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="AgileBoardColumn"/> record for the specified agile board.
            /// </summary>
            /// <param name="agileBoard">The agile board for which to retrieve the agile board column.</param>
            /// <param name="agileBoardColumnId">The unique identifier of the agile board column.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="AgileBoardColumn"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<AgileBoardColumn?> GetAsync(AgileBoard agileBoard, long agileBoardColumnId, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await GetAsync(agileBoard.Id, agileBoardColumnId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="AgileBoardColumn"/> to an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoardId">The identifier of the agile board.</param>
            /// <param name="agileBoardColumn">The agile board column to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="AgileBoardColumn"/>.</returns>
            public async Task<AgileBoardColumn> CreateAsync(long agileBoardId, AgileBoardColumn agileBoardColumn, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(agileBoardId, "agile_board_columns", agileBoardColumn, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="AgileBoardColumn"/> to an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board to which the agile board column is added.</param>
            /// <param name="agileBoardColumn">The agile board column to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="AgileBoardColumn"/>.</returns>
            public async Task<AgileBoardColumn> CreateAsync(AgileBoard agileBoard, AgileBoardColumn agileBoardColumn, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await CreateAsync(agileBoard.Id, agileBoardColumn, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="AgileBoardColumn"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoardId">The identifier of the agile board.</param>
            /// <param name="agileBoardColumn">The agile board column to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="AgileBoardColumn"/>.</returns>
            public async Task<AgileBoardColumn> UpdateAsync(long agileBoardId, AgileBoardColumn agileBoardColumn, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(agileBoardId, "agile_board_columns", agileBoardColumn, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="AgileBoardColumn"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board with which the agile board column is associated.</param>
            /// <param name="agileBoardColumn">The agile board column to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="AgileBoardColumn"/>.</returns>
            public async Task<AgileBoardColumn> UpdateAsync(AgileBoard agileBoard, AgileBoardColumn agileBoardColumn, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await UpdateAsync(agileBoard.Id, agileBoardColumn, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="AgileBoardColumn"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoardId">The identifier of the agile board.</param>
            /// <param name="agileBoardColumnId">The identifier of the agile board column to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long agileBoardId, long agileBoardColumnId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(agileBoardId, "agile_board_columns", agileBoardColumnId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="AgileBoardColumn"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoardId">The identifier of the agile board.</param>
            /// <param name="agileBoardColumn">The agile board column to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long agileBoardId, AgileBoardColumn agileBoardColumn, CancellationToken ct = default)
            {
                if (agileBoardColumn is null)
                    throw new ArgumentNullException(nameof(agileBoardColumn));

                return await DeleteAsync(agileBoardId, agileBoardColumn.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="AgileBoardColumn"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board from which the agile board column is removed.</param>
            /// <param name="agileBoardColumn">The agile board column to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(AgileBoard agileBoard, AgileBoardColumn agileBoardColumn, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                if (agileBoardColumn is null)
                    throw new ArgumentNullException(nameof(agileBoardColumn));

                return await DeleteAsync(agileBoard.Id, agileBoardColumn.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="AgileBoardColumn"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board from which the agile board column is removed.</param>
            /// <param name="agileBoardColumnId">The identifier of the agile board column to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(AgileBoard agileBoard, long agileBoardColumnId, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await DeleteAsync(agileBoard.Id, agileBoardColumnId, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="AgileBoard"/>.
        /// </summary>
        public sealed class CustomerRepresentativeSLAsClient
        {
            private readonly AgileBoardClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomerRepresentativeSLAsClient"/> class.
            /// </summary>
            internal CustomerRepresentativeSLAsClient(AgileBoardClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified agile board using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="agileBoardId">The unique identifier of the agile board for which to retrieve the customer representative sl as.</param>
            /// <param name="query">The query that defines which customer representative sl as to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(long agileBoardId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceLevelAgreement>(agileBoardId, "customer_representative_slas", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified agile board using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board for which to retrieve the customer representative sl as.</param>
            /// <param name="query">The query that defines which customer representative sl as to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(AgileBoard agileBoard, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await GetAsync(agileBoard.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified agile board using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="agileBoardId">The unique identifier of the agile board for which to enumerate the customer representative sl as.</param>
            /// <param name="query">The query that defines which customer representative sl as to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(long agileBoardId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceLevelAgreement>(agileBoardId, "customer_representative_slas", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified agile board using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board for which to enumerate the customer representative sl as.</param>
            /// <param name="query">The query that defines which customer representative sl as to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(AgileBoard agileBoard, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return StreamAsync(agileBoard.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceLevelAgreement"/> to an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoardId">The identifier of the agile board.</param>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long agileBoardId, long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(agileBoardId, "customer_representative_slas", serviceLevelAgreementId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceLevelAgreement"/> to an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoardId">The identifier of the agile board.</param>
            /// <param name="serviceLevelAgreement">The service level agreement to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long agileBoardId, ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(agileBoardId, serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceLevelAgreement"/> to an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board from which the service level agreement is removed.</param>
            /// <param name="serviceLevelAgreement">The service level agreement to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(AgileBoard agileBoard, ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(agileBoard.Id, serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceLevelAgreement"/> to an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board from which the service level agreement is removed.</param>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(AgileBoard agileBoard, long serviceLevelAgreementId, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await AddAsync(agileBoard.Id, serviceLevelAgreementId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceLevelAgreement"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoardId">The identifier of the agile board.</param>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long agileBoardId, long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(agileBoardId, "customer_representative_slas", serviceLevelAgreementId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceLevelAgreement"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoardId">The identifier of the agile board.</param>
            /// <param name="serviceLevelAgreement">The service level agreement to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long agileBoardId, ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(agileBoardId, serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceLevelAgreement"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board from which the service level agreement is removed.</param>
            /// <param name="serviceLevelAgreement">The service level agreement to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(AgileBoard agileBoard, ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(agileBoard.Id, serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceLevelAgreement"/> associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board from which the service level agreement is removed.</param>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(AgileBoard agileBoard, long serviceLevelAgreementId, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await RemoveAsync(agileBoard.Id, serviceLevelAgreementId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all customer representative service level agreements associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoardId">The identifier of the agile board.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long agileBoardId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(agileBoardId, "customer_representative_slas", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all customer representative service level agreements associated with an <see cref="AgileBoard"/>.
            /// </summary>
            /// <param name="agileBoard">The agile board from which all customer representative service level agreements are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(AgileBoard agileBoard, CancellationToken ct = default)
            {
                if (agileBoard is null)
                    throw new ArgumentNullException(nameof(agileBoard));

                return await RemoveAllAsync(agileBoard.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
