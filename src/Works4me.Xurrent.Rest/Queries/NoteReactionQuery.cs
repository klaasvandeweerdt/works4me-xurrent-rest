using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="NoteReaction"/> records.
    /// </summary>
    public sealed class NoteReactionQuery
        : Query<NoteReactionQuery, NoteReaction.PredefinedFilter, NoteReaction.Field, NoteReaction.FilterField, NoteReaction.OrderField>
    {
    }
}
