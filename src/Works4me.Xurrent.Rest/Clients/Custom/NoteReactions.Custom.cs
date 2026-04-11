using System;
using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class NoteReactionClient
    {
        private NoteClient? _notesClient;

        /// <summary>
        /// Retrieves a collection of <see cref="NoteReaction"/> records for the specified note using the specified query.
        /// </summary>
        /// <param name="noteId">The unique identifier of the note.</param>
        /// <param name="query">The query that defines which reactions to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="NoteReaction"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<NoteReaction>> GetAsync(long noteId, NoteReactionQuery query, CancellationToken ct = default)
        {
            _notesClient ??= Context.GetClient<NoteClient>();
            return await _notesClient.Reactions.GetAsync(noteId, query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="NoteReaction"/> records for the specified note using the specified query.
        /// </summary>
        /// <param name="note">The note for which to retrieve reactions.</param>
        /// <param name="query">The query that defines which reactions to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="NoteReaction"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<NoteReaction>> GetAsync(Note note, NoteReactionQuery query, CancellationToken ct = default)
        {
            if (note is null)
                throw new ArgumentNullException(nameof(note));

            return await GetAsync(note.Id, query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new reaction for the specified note.
        /// </summary>
        /// <param name="noteId">The identifier of the note to which the reaction will be added.</param>
        /// <param name="noteReaction">The emoji reaction to add to the note.</param>
        /// <param name="ct">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="NoteReaction"/>.</returns>
        public async Task<NoteReaction> CreateAsync(long noteId, NoteReactionEmoji noteReaction, CancellationToken ct = default)
        {
            return await PostItemAsync(new NoteReaction()
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
            return await DeleteItemAsync(noteReactionId, ct).ConfigureAwait(false);
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
