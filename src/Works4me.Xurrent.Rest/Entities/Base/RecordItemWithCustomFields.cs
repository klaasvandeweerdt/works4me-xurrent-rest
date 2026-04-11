using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// The base class with <c>Custom Fields</c> that tracks property and collection changes.
    /// </summary>
    public abstract class RecordItemWithCustomFields : RecordItem
    {
        private CustomFieldCollection? _customFields;
        private ObservableCollection<AttachmentReference>? _customFieldAttachments;
        private AttachmentReferenceWriter? _customFieldAttachmentWriter;

        /// <summary>
        /// Gets or sets the custom fields associated with this record.
        /// </summary>
        [XurrentField("custom_fields")]
        public CustomFieldCollection CustomFields
        {
            get => GetCollection(ref _customFields, OnCustomFieldsChanged, OnCustomFieldsChanged);
            set => SetCollection(ref _customFields, "custom_fields", value, OnCustomFieldsChanged, OnCustomFieldsChanged);
        }

        /// <summary>
        /// Gets or sets the attachment references associated with custom fields on this record.
        /// </summary>
        [XurrentField("custom_fields_attachments")]
        internal ObservableCollection<AttachmentReference> CustomFieldAttachmentsCollection
        {
            get => GetCollection(ref _customFieldAttachments, OnAttachmentsChanged);
            set => SetCollection(ref _customFieldAttachments, "custom_fields_attachments", value, OnAttachmentsChanged);
        }

        /// <summary>
        /// Provides a writer API for managing custom-field attachment references.
        /// </summary>
        public AttachmentReferenceWriter CustomFieldAttachments
        {
            get
            {
                _customFieldAttachmentWriter ??= new AttachmentReferenceWriter(() => CustomFieldAttachmentsCollection, c => CustomFieldAttachmentsCollection = c);
                return _customFieldAttachmentWriter;
            }
        }

        /// <summary>
        /// Marks the <c>custom_fields</c> collection as changed when the custom field collection is modified.
        /// </summary>
        private void OnCustomFieldsChanged(object? sender, EventArgs e)
        {
            if (sender is CustomFieldCollection collection)
                MarkCollectionChanged(collection, "custom_fields");
        }

        /// <summary>
        /// Marks the <c>custom_fields_attachments</c> collection as changed when the attachment reference collection is modified.
        /// </summary>
        private void OnAttachmentsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "custom_fields_attachments");
        }
    }
}
