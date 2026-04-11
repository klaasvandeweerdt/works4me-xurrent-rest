using System;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="NoteReaction"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/notes/note_reactions/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed partial class NoteReactionClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoteReactionClient"/> class.
        /// </summary>
        internal NoteReactionClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "note_reactions/"))
        {
        }
    }
}
