using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AttachmentStorage"/> records.
    /// </summary>
    public sealed class AttachmentStorageQuery
        : Query<AttachmentStorageQuery, AttachmentStorage.PredefinedFilter, AttachmentStorage.Field, AttachmentStorage.FilterField, AttachmentStorage.OrderField>
    {
    }
}
