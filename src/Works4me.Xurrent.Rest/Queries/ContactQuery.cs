using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Contact"/> records.
    /// </summary>
    public sealed class ContactQuery
        : Query<ContactQuery, Contact.PredefinedFilter, Contact.Field, Contact.FilterField, Contact.OrderField>
    {
    }
}
