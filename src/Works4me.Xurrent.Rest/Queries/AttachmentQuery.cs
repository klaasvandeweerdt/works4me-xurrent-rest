using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Attachment"/> records.
    /// </summary>
    public sealed class AttachmentQuery
        : Query<AttachmentQuery, Attachment.PredefinedFilter, Attachment.Field, Attachment.FilterField, Attachment.OrderField>
    {
    }
}
