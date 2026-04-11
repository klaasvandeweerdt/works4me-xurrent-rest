using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Note"/> records.
    /// </summary>
    public sealed class NoteQuery
        : Query<NoteQuery, Note.PredefinedFilter, Note.Field, Note.FilterField, Note.OrderField>
    {
    }
}
