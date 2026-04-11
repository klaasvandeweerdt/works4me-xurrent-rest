using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Note"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/notes/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed partial class NoteClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="NoteReaction"/> records related to an <see cref="Note"/>.
        /// </summary>
        public ReactionsClient Reactions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteClient"/> class.
        /// </summary>
        internal NoteClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "notes/"))
        {
            Reactions = new ReactionsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Note"/> using the specified <see cref="NoteQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which notes to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Note"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(NoteQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Note>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Note"/> items as an asynchronous stream using the specified <see cref="NoteQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which notes to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Note> StreamAsync(NoteQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Note>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Note"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the note.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Note"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Note?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Note>(new NoteQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="NoteReaction"/> records related to an <see cref="Note"/>.
        /// </summary>
        public sealed partial class ReactionsClient
        {
            private readonly NoteClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ReactionsClient"/> class.
            /// </summary>
            internal ReactionsClient(NoteClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="NoteReaction"/> records for the specified note using an <see cref="NoteReactionQuery"/>.
            /// </summary>
            /// <param name="noteId">The unique identifier of the note for which to retrieve the reactions.</param>
            /// <param name="query">The query that defines which reactions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="NoteReaction"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<NoteReaction>> GetAsync(long noteId, NoteReactionQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<NoteReaction>(noteId, "note_reactions", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="NoteReaction"/> records for the specified note using an <see cref="NoteReactionQuery"/>.
            /// </summary>
            /// <param name="note">The note for which to retrieve the reactions.</param>
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
            /// Enumerates <see cref="NoteReaction"/> items as an asynchronous stream for the specified note using an <see cref="NoteReactionQuery"/>.
            /// </summary>
            /// <param name="noteId">The unique identifier of the note for which to enumerate the reactions.</param>
            /// <param name="query">The query that defines which reactions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="NoteReaction"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<NoteReaction> StreamAsync(long noteId, NoteReactionQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<NoteReaction>(noteId, "note_reactions", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="NoteReaction"/> items as an asynchronous stream for the specified note using an <see cref="NoteReactionQuery"/>.
            /// </summary>
            /// <param name="note">The note for which to enumerate the reactions.</param>
            /// <param name="query">The query that defines which reactions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="NoteReaction"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<NoteReaction> StreamAsync(Note note, NoteReactionQuery query, CancellationToken ct = default)
            {
                if (note is null)
                    throw new ArgumentNullException(nameof(note));

                return StreamAsync(note.Id, query, ct);
            }
        }
    }
}
