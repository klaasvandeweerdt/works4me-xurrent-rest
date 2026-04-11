using System;
using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class NoteClient
    {
        private ProblemClient? _problemClient;
        private ProjectClient? _projectClient;  
        private ProjectTaskClient? _projectTaskClient;
        private RequestClient? _requestClient;
        private ReleaseClient? _releaseClient;
        private RiskClient? _riskClient;
        private WorkflowClient? _workflowClient;
        private WorkflowTaskClient? _workflowTaskClient;

        /// <summary>
        /// Creates a new note for the specified problem.
        /// </summary>
        /// <param name="owner">The problem that will own the created note.</param>
        /// <param name="noteCreate">The note payload to create.</param>
        /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteCreate"/>.</returns>
        public async Task<NoteCreate> CreateAsync(Problem owner, NoteCreate noteCreate, CancellationToken ct = default)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _problemClient ??= Context.GetClient<ProblemClient>();

            return await _problemClient.Notes.CreateAsync(owner.Id, noteCreate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new note for the specified project.
        /// </summary>
        /// <param name="owner">The project that will own the created note.</param>
        /// <param name="noteCreate">The note payload to create.</param>
        /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteCreate"/>.</returns>
        public async Task<NoteCreate> CreateAsync(Project owner, NoteCreate noteCreate, CancellationToken ct = default)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _projectClient ??= Context.GetClient<ProjectClient>();

            return await _projectClient.Notes.CreateAsync(owner.Id, noteCreate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new note for the specified project task.
        /// </summary>
        /// <param name="owner">The project task that will own the created note.</param>
        /// <param name="noteCreate">The note payload to create.</param>
        /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteCreate"/>.</returns>
        public async Task<NoteCreate> CreateAsync(ProjectTask owner, NoteCreate noteCreate, CancellationToken ct = default)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _projectTaskClient ??= Context.GetClient<ProjectTaskClient>();

            return await _projectTaskClient.Notes.CreateAsync(owner.Id, noteCreate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new note for the specified release.
        /// </summary>
        /// <param name="owner">The release that will own the created note.</param>
        /// <param name="noteCreate">The note payload to create.</param>
        /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteCreate"/>.</returns>
        public async Task<NoteCreate> CreateAsync(Release owner, NoteCreate noteCreate, CancellationToken ct = default)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _releaseClient ??= Context.GetClient<ReleaseClient>();

            return await _releaseClient.Notes.CreateAsync(owner.Id, noteCreate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new note for the specified request.
        /// </summary>
        /// <param name="owner">The request that will own the created note.</param>
        /// <param name="noteCreate">The note payload to create.</param>
        /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteCreate"/>.</returns>
        public async Task<NoteCreate> CreateAsync(Request owner, NoteCreate noteCreate, CancellationToken ct = default)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _requestClient ??= Context.GetClient<RequestClient>();

            return await _requestClient.Notes.CreateAsync(owner.Id, noteCreate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new note for the specified risk.
        /// </summary>
        /// <param name="owner">The risk that will own the created note.</param>
        /// <param name="noteCreate">The note payload to create.</param>
        /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteCreate"/>.</returns>
        public async Task<NoteCreate> CreateAsync(Risk owner, NoteCreate noteCreate, CancellationToken ct = default)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _riskClient ??= Context.GetClient<RiskClient>();

            return await _riskClient.Notes.CreateAsync(owner.Id, noteCreate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new note for the specified workflow.
        /// </summary>
        /// <param name="owner">The workflow that will own the created note.</param>
        /// <param name="noteCreate">The note payload to create.</param>
        /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteCreate"/>.</returns>
        public async Task<NoteCreate> CreateAsync(Workflow owner, NoteCreate noteCreate, CancellationToken ct = default)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _workflowClient ??= Context.GetClient<WorkflowClient>();

            return await _workflowClient.Notes.CreateAsync(owner.Id, noteCreate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new note for the specified workflow task.
        /// </summary>
        /// <param name="owner">The workflow task that will own the created note.</param>
        /// <param name="noteCreate">The note payload to create.</param>
        /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteCreate"/>.</returns>
        public async Task<NoteCreate> CreateAsync(WorkflowTask owner, NoteCreate noteCreate, CancellationToken ct = default)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _workflowTaskClient ??= Context.GetClient<WorkflowTaskClient>();

            return await _workflowTaskClient.Notes.CreateAsync(owner.Id, noteCreate, ct).ConfigureAwait(false);
        }

        partial class ReactionsClient
        {
            private NoteReactionClient? _notesReactionClient;

            /// <summary>
            /// Creates a new reaction for the specified note.
            /// </summary>
            /// <param name="noteId">The identifier of the note to which the reaction will be added.</param>
            /// <param name="noteReaction">The emoji reaction to add to the note.</param>
            /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
            /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteReaction"/>.</returns>
            public async Task<NoteReaction> CreateAsync(long noteId, NoteReactionEmoji noteReaction, CancellationToken ct = default)
            {
                _notesReactionClient ??= _client.Context.GetClient<NoteReactionClient>();

                return await _notesReactionClient.PostItemAsync(new NoteReaction()
                {
                    Note = new Note(noteId),
                    Reaction = noteReaction
                }, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Creates a new reaction for the specified note.
            /// </summary>
            /// <param name="note">The note to which the reaction will be added.</param>
            /// <param name="noteReaction">The emoji reaction to add to the note.</param>
            /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
            /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteReaction"/>.</returns>
            public async Task<NoteReaction> CreateAsync(Note note, NoteReactionEmoji noteReaction, CancellationToken ct = default)
            {
                if (note is null)
                    throw new ArgumentNullException(nameof(note));

                return await CreateAsync(note.Id, noteReaction, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Deletes the specified note reaction.
            /// </summary>
            /// <param name="noteReactionId">The identifier of the note reaction to delete.</param>
            /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
            /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
            public async Task<bool> DeleteAsync(long noteReactionId, CancellationToken ct = default)
            {
                _notesReactionClient ??= _client.Context.GetClient<NoteReactionClient>();

                return await _notesReactionClient.DeleteItemAsync(noteReactionId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Deletes the specified note reaction.
            /// </summary>
            /// <param name="noteReaction">The note reaction to delete.</param>
            /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
            /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
            /// <exception cref="ArgumentNullException">Thrown when <paramref name="noteReaction"/> is <c>null</c>.</exception>
            public async Task<bool> DeleteAsync(NoteReaction noteReaction, CancellationToken ct = default)
            {
                if (noteReaction is null)
                    throw new ArgumentNullException(nameof(noteReaction));

                return await DeleteAsync(noteReaction.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
