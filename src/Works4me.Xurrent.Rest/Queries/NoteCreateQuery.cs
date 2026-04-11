using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="NoteCreate"/> records.
    /// </summary>
    public sealed class NoteCreateQuery
        : Query<NoteCreateQuery, NoteCreate.PredefinedFilter, NoteCreate.Field, NoteCreate.FilterField, NoteCreate.OrderField>
    {
    }
}
