using System;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a reference to a Xurrent attachment.
    /// </summary>
    /// <remarks>
    /// For more details about attachment references, see the <see href="https://developer.xurrent.com/v1/general/data_types/#attachments">Xurrent Developer Documentation</see>.
    /// </remarks>
    public sealed class AttachmentReference
    {
        private string _key;
        private bool _inline;

        /// <summary>
        /// Gets or sets the key of the attachment.
        /// </summary>
        /// <value>
        /// A string representing the attachment key, which uniquely identifies the attachment.
        /// </value>
        [XurrentField("key")]
        public string Key
        {
            get => _key;
            set => _key = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the attachment is inline.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the attachment is inline; otherwise, <see langword="false"/>.
        /// </value>
        [XurrentField("inline")]
        public bool Inline
        {
            get => _inline;
            set => _inline = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentReference"/>.
        /// </summary>
        public AttachmentReference()
        {
            _key = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentReference"/> class with the specified key.
        /// </summary>
        /// <param name="key">The key of the attachment.</param>
        public AttachmentReference(string key)
        {
            _key = key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentReference"/> class with the specified key and inline status.
        /// </summary>
        /// <param name="key">The key of the attachment.</param>
        /// <param name="inline">Indicates whether the attachment is inline.</param>
        public AttachmentReference(string key, bool inline)
        {
            _key = key;
            _inline = inline;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentReference"/> class with the specified key and inline status.
        /// </summary>
        /// <param name="uploadResponse">The attachment upload response.</param>
        /// <param name="inline">Indicates whether the attachment is inline.</param>
        public AttachmentReference(AttachmentUploadResponse uploadResponse, bool inline)
        {
            if (uploadResponse is null)
                throw new ArgumentNullException(nameof(uploadResponse));

            _key = uploadResponse.Key;
            _inline = inline;
        }
    }
}
