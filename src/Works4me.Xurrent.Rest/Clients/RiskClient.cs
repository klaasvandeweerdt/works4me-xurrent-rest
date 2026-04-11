using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Risk"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/risks/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class RiskClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Note"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public NotesClient Notes { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Organization"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public OrganizationsClient Organizations { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Project"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public ProjectsClient Projects { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Service"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public ServicesClient Services { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiskClient"/> class.
        /// </summary>
        internal RiskClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "risks/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Notes = new NotesClient(this);
            Organizations = new OrganizationsClient(this);
            Projects = new ProjectsClient(this);
            Services = new ServicesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Risk"/> using the specified <see cref="RiskQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which risks to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Risk"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Risk>> GetAsync(RiskQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Risk>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Risk"/> items as an asynchronous stream using the specified <see cref="RiskQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which risks to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Risk"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Risk> StreamAsync(RiskQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Risk>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Risk"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the risk.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Risk"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Risk?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Risk>(new RiskQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Risk"/>.
        /// </summary>
        /// <param name="risk">The risk to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Risk"/>.</returns>
        public async Task<Risk> CreateAsync(Risk risk, CancellationToken ct = default)
        {
            return await PostItemAsync(risk, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Risk"/>.
        /// </summary>
        /// <param name="risk">The risk to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Risk"/>.</returns>
        public async Task<Risk> UpdateAsync(Risk risk, CancellationToken ct = default)
        {
            return await PatchItemAsync(risk, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly RiskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(RiskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified risk using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long riskId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(riskId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified risk using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Risk risk, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await GetAsync(risk.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified risk using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long riskId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(riskId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified risk using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Risk risk, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return StreamAsync(risk.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Note"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public sealed class NotesClient
        {
            private readonly RiskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotesClient"/> class.
            /// </summary>
            internal NotesClient(RiskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified risk using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(long riskId, NoteQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Note>(riskId, "notes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified risk using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(Risk risk, NoteQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await GetAsync(risk.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified risk using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(long riskId, NoteQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Note>(riskId, "notes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified risk using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(Risk risk, NoteQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return StreamAsync(risk.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(long riskId, NoteCreate noteCreate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(riskId, "notes", noteCreate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk to which the note create is added.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(Risk risk, NoteCreate noteCreate, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await CreateAsync(risk.Id, noteCreate, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Organization"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public sealed class OrganizationsClient
        {
            private readonly RiskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="OrganizationsClient"/> class.
            /// </summary>
            internal OrganizationsClient(RiskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified risk using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to retrieve the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(long riskId, OrganizationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Organization>(riskId, "organizations", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified risk using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to retrieve the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(Risk risk, OrganizationQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await GetAsync(risk.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified risk using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to enumerate the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(long riskId, OrganizationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Organization>(riskId, "organizations", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified risk using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to enumerate the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(Risk risk, OrganizationQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return StreamAsync(risk.Id, query, ct);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long riskId, long organizationId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(riskId, "organizations", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long riskId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(riskId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the organization is removed.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Risk risk, Organization organization, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(risk.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Risk risk, long organizationId, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await AddAsync(risk.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long riskId, long organizationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(riskId, "organizations", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long riskId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(riskId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the organization is removed.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Risk risk, Organization organization, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(risk.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Risk risk, long organizationId, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await RemoveAsync(risk.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all organizations associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long riskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(riskId, "organizations", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all organizations associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which all organizations are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Risk risk, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await RemoveAllAsync(risk.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Project"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public sealed class ProjectsClient
        {
            private readonly RiskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ProjectsClient"/> class.
            /// </summary>
            internal ProjectsClient(RiskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Project"/> records for the specified risk using an <see cref="ProjectQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to retrieve the projects.</param>
            /// <param name="query">The query that defines which projects to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Project"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Project>> GetAsync(long riskId, ProjectQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Project>(riskId, "projects", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Project"/> records for the specified risk using an <see cref="ProjectQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to retrieve the projects.</param>
            /// <param name="query">The query that defines which projects to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Project"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Project>> GetAsync(Risk risk, ProjectQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await GetAsync(risk.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Project"/> items as an asynchronous stream for the specified risk using an <see cref="ProjectQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to enumerate the projects.</param>
            /// <param name="query">The query that defines which projects to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Project"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Project> StreamAsync(long riskId, ProjectQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Project>(riskId, "projects", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Project"/> items as an asynchronous stream for the specified risk using an <see cref="ProjectQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to enumerate the projects.</param>
            /// <param name="query">The query that defines which projects to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Project"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Project> StreamAsync(Risk risk, ProjectQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return StreamAsync(risk.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Project"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="projectId">The identifier of the project to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long riskId, long projectId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(riskId, "projects", projectId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Project"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="project">The project to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long riskId, Project project, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await AddAsync(riskId, project.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Project"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the project is removed.</param>
            /// <param name="project">The project to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Risk risk, Project project, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await AddAsync(risk.Id, project.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Project"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the project is removed.</param>
            /// <param name="projectId">The identifier of the project to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Risk risk, long projectId, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await AddAsync(risk.Id, projectId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Project"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="projectId">The identifier of the project to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long riskId, long projectId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(riskId, "projects", projectId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Project"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="project">The project to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long riskId, Project project, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAsync(riskId, project.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Project"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the project is removed.</param>
            /// <param name="project">The project to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Risk risk, Project project, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAsync(risk.Id, project.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Project"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the project is removed.</param>
            /// <param name="projectId">The identifier of the project to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Risk risk, long projectId, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await RemoveAsync(risk.Id, projectId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all projects associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long riskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(riskId, "projects", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all projects associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which all projects are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Risk risk, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await RemoveAllAsync(risk.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Service"/> records related to an <see cref="Risk"/>.
        /// </summary>
        public sealed class ServicesClient
        {
            private readonly RiskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServicesClient"/> class.
            /// </summary>
            internal ServicesClient(RiskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Service"/> records for the specified risk using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to retrieve the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Service"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Service>> GetAsync(long riskId, ServiceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Service>(riskId, "services", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Service"/> records for the specified risk using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to retrieve the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Service"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Service>> GetAsync(Risk risk, ServiceQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await GetAsync(risk.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Service"/> items as an asynchronous stream for the specified risk using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="riskId">The unique identifier of the risk for which to enumerate the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Service"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Service> StreamAsync(long riskId, ServiceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Service>(riskId, "services", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Service"/> items as an asynchronous stream for the specified risk using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="risk">The risk for which to enumerate the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Service"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Service> StreamAsync(Risk risk, ServiceQuery query, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return StreamAsync(risk.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="serviceId">The identifier of the service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long riskId, long serviceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(riskId, "services", serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="service">The service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long riskId, Service service, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await AddAsync(riskId, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the service is removed.</param>
            /// <param name="service">The service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Risk risk, Service service, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await AddAsync(risk.Id, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the service is removed.</param>
            /// <param name="serviceId">The identifier of the service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Risk risk, long serviceId, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await AddAsync(risk.Id, serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="serviceId">The identifier of the service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long riskId, long serviceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(riskId, "services", serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="service">The service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long riskId, Service service, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await RemoveAsync(riskId, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the service is removed.</param>
            /// <param name="service">The service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Risk risk, Service service, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await RemoveAsync(risk.Id, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which the service is removed.</param>
            /// <param name="serviceId">The identifier of the service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Risk risk, long serviceId, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await RemoveAsync(risk.Id, serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all services associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="riskId">The identifier of the risk.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long riskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(riskId, "services", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all services associated with a <see cref="Risk"/>.
            /// </summary>
            /// <param name="risk">The risk from which all services are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Risk risk, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await RemoveAllAsync(risk.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
