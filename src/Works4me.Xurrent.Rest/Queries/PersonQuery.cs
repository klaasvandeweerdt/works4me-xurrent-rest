using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Person"/> records.
    /// </summary>
    public sealed class PersonQuery
        : Query<PersonQuery, Person.PredefinedFilter, Person.Field, Person.FilterField, Person.OrderField>
    {
    }
}
