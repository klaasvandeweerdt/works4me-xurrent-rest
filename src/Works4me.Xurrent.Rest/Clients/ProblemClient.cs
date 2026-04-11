using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Problem"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/problems/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ProblemClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Note"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public NotesClient Notes { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Request"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public RequestsClient Requests { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public SprintBacklogItemsClient SprintBacklogItems { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemClient"/> class.
        /// </summary>
        internal ProblemClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "problems/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
            Notes = new NotesClient(this);
            Requests = new RequestsClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
            SprintBacklogItems = new SprintBacklogItemsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Problem"/> using the specified <see cref="ProblemQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which problems to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Problem"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Problem>> GetAsync(ProblemQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Problem>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Problem"/> items as an asynchronous stream using the specified <see cref="ProblemQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which problems to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Problem"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Problem> StreamAsync(ProblemQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Problem>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Problem"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the problem.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Problem"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Problem?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Problem>(new ProblemQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Archive a <see cref="Problem"/>.<br />
        /// The problem must be disabled.
        /// </summary>
        /// <param name="problem">The problem to archive.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The archived <see cref="Problem"/>.</returns>
        public async Task<Problem> ArchiveAsync(Problem problem, CancellationToken ct = default)
        {
            return await PostItemAsync(problem, "archive", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Problem"/>.
        /// </summary>
        /// <param name="problem">The problem to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Problem"/>.</returns>
        public async Task<Problem> CreateAsync(Problem problem, CancellationToken ct = default)
        {
            return await PostItemAsync(problem, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Problem"/>.
        /// </summary>
        /// <param name="problemId">The identifier of the problem to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Problem"/>.</returns>
        public async Task<Problem> RestoreAsync(long problemId, CancellationToken ct = default)
        {
            return await PostItemAsync(new Problem(problemId), "restore", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Problem"/>.
        /// </summary>
        /// <param name="reference">The reference to the problem to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Problem"/>.</returns>
        public async Task<Problem> RestoreAsync(ResourceReference reference, CancellationToken ct = default)
        {
            if (reference is null)
                throw new ArgumentNullException(nameof(reference));

            if (!reference.Id.HasValue)
                throw new ArgumentException("The archive reference must have a valid identifier.", nameof(reference));

            return await RestoreAsync(reference.Id.Value, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Trash a <see cref="Problem"/>.<br />
        /// The problem must be disabled.
        /// </summary>
        /// <param name="problem">The problem to trash.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The trashed <see cref="Problem"/>.</returns>
        public async Task<Problem> TrashAsync(Problem problem, CancellationToken ct = default)
        {
            return await PostItemAsync(problem, "trash", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Problem"/>.
        /// </summary>
        /// <param name="problem">The problem to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Problem"/>.</returns>
        public async Task<Problem> UpdateAsync(Problem problem, CancellationToken ct = default)
        {
            return await PatchItemAsync(problem, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ProblemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ProblemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified problem using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long problemId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(problemId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified problem using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Problem problem, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await GetAsync(problem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified problem using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long problemId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(problemId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified problem using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Problem problem, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return StreamAsync(problem.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly ProblemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(ProblemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified problem using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long problemId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(problemId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified problem using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(Problem problem, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await GetAsync(problem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified problem using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long problemId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(problemId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified problem using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(Problem problem, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return StreamAsync(problem.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long problemId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(problemId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long problemId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(problemId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Problem problem, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(problem.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Problem problem, long configurationItemId, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await AddAsync(problem.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long problemId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(problemId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long problemId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(problemId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Problem problem, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(problem.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Problem problem, long configurationItemId, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAsync(problem.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long problemId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(problemId, "cis", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which all configuration items are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Problem problem, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAllAsync(problem.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Note"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public sealed class NotesClient
        {
            private readonly ProblemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotesClient"/> class.
            /// </summary>
            internal NotesClient(ProblemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified problem using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(long problemId, NoteQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Note>(problemId, "notes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified problem using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(Problem problem, NoteQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await GetAsync(problem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified problem using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(long problemId, NoteQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Note>(problemId, "notes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified problem using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(Problem problem, NoteQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return StreamAsync(problem.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(long problemId, NoteCreate noteCreate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(problemId, "notes", noteCreate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem to which the note create is added.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(Problem problem, NoteCreate noteCreate, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await CreateAsync(problem.Id, noteCreate, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Request"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public sealed class RequestsClient
        {
            private readonly ProblemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RequestsClient"/> class.
            /// </summary>
            internal RequestsClient(ProblemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified problem using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(long problemId, RequestQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Request>(problemId, "requests", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified problem using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(Problem problem, RequestQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await GetAsync(problem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified problem using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(long problemId, RequestQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Request>(problemId, "requests", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified problem using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(Problem problem, RequestQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return StreamAsync(problem.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="requestId">The identifier of the request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long problemId, long requestId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(problemId, "requests", requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="request">The request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long problemId, Request request, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await AddAsync(problemId, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the request is removed.</param>
            /// <param name="request">The request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Problem problem, Request request, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await AddAsync(problem.Id, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the request is removed.</param>
            /// <param name="requestId">The identifier of the request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Problem problem, long requestId, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await AddAsync(problem.Id, requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="requestId">The identifier of the request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long problemId, long requestId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(problemId, "requests", requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="request">The request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long problemId, Request request, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await RemoveAsync(problemId, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the request is removed.</param>
            /// <param name="request">The request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Problem problem, Request request, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await RemoveAsync(problem.Id, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the request is removed.</param>
            /// <param name="requestId">The identifier of the request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Problem problem, long requestId, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAsync(problem.Id, requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all requests associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long problemId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(problemId, "requests", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all requests associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which all requests are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Problem problem, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAllAsync(problem.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly ProblemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(ProblemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified problem using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long problemId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(problemId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified problem using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(Problem problem, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await GetAsync(problem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified problem using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long problemId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(problemId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified problem using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(Problem problem, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return StreamAsync(problem.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long problemId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(problemId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long problemId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(problemId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Problem problem, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(problem.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Problem problem, long serviceInstanceId, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await AddAsync(problem.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long problemId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(problemId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long problemId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(problemId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Problem problem, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(problem.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Problem problem, long serviceInstanceId, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAsync(problem.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problemId">The identifier of the problem.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long problemId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(problemId, "service_instances", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="Problem"/>.
            /// </summary>
            /// <param name="problem">The problem from which all service instances are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Problem problem, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAllAsync(problem.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="Problem"/>.
        /// </summary>
        public sealed class SprintBacklogItemsClient
        {
            private readonly ProblemClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SprintBacklogItemsClient"/> class.
            /// </summary>
            internal SprintBacklogItemsClient(ProblemClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified problem using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to retrieve the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(long problemId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SprintBacklogItem>(problemId, "sprint_backlog_items", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified problem using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to retrieve the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(Problem problem, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await GetAsync(problem.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified problem using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="problemId">The unique identifier of the problem for which to enumerate the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(long problemId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SprintBacklogItem>(problemId, "sprint_backlog_items", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified problem using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="problem">The problem for which to enumerate the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(Problem problem, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return StreamAsync(problem.Id, query, ct);
            }
        }
    }
}
