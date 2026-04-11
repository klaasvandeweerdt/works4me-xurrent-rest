using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a controlled way to add or replace attachment references on a parent object.
    /// </summary>
    public sealed class AttachmentReferenceWriter
    {
        private readonly Func<ObservableCollection<AttachmentReference>> _getter;
        private readonly Action<ObservableCollection<AttachmentReference>> _setter;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentReferenceWriter"/> class.
        /// </summary>
        /// <param name="getter">A function that returns the current collection of <see cref="AttachmentReference"/> instances.</param>
        /// <param name="setter">An action that replaces the current collection of <see cref="AttachmentReference"/> instances.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="getter"/> or <paramref name="setter"/> is <see langword="null"/>.</exception>
        public AttachmentReferenceWriter(Func<ObservableCollection<AttachmentReference>> getter, Action<ObservableCollection<AttachmentReference>> setter)
        {
            if (getter is null)
                throw new ArgumentNullException(nameof(getter));
            if (setter is null)
                throw new ArgumentNullException(nameof(setter));

            _getter = getter;
            _setter = setter;
        }

        /// <summary>
        /// Adds a new attachment reference using the specified attachment key.
        /// </summary>
        /// <param name="key">The key of the attachment.</param>
        /// <param name="inline">Indicates whether the attachment should be rendered inline.</param>
        public void Add(string key, bool inline)
        {
            _getter().Add(new AttachmentReference(key, inline));
        }

        /// <summary>
        /// Adds a new attachment reference using the result of an attachment upload.
        /// </summary>
        /// <param name="uploadResponse">The attachment upload response.</param>
        /// <param name="inline">Indicates whether the attachment should be rendered inline.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="uploadResponse"/> is <see langword="null"/>.</exception>
        public void Add(AttachmentUploadResponse uploadResponse, bool inline)
        {
            if (uploadResponse is null)
                throw new ArgumentNullException(nameof(uploadResponse));

            _getter().Add(new AttachmentReference(uploadResponse, inline));
        }

        /// <summary>
        /// Adds an existing attachment reference to the collection.
        /// </summary>
        /// <param name="attachment">The attachment reference to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="attachment"/> is <see langword="null"/>.</exception>
        public void Add(AttachmentReference attachment)
        {
            if (attachment is null)
                throw new ArgumentNullException(nameof(attachment));

            _getter().Add(attachment);
        }

        /// <summary>
        /// Adds multiple attachment references to the collection.
        /// </summary>
        /// <param name="attachments">A sequence of <see cref="AttachmentReference"/> instances to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="attachments"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when the sequence contains a <see langword="null"/> element.</exception>
        public void Add(IEnumerable<AttachmentReference> attachments)
        {
            if (attachments is null)
                throw new ArgumentNullException(nameof(attachments));

            foreach (AttachmentReference attachment in attachments)
            {
                if (attachment is null)
                    throw new ArgumentException("Sequence contains null.", nameof(attachments));

                _getter().Add(attachment);
            }
        }

        /// <summary>
        /// Replaces the current attachment references with the specified collection.
        /// </summary>
        /// <param name="attachments">A sequence of <see cref="AttachmentReference"/> instances to set.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="attachments"/> is <see langword="null"/>.</exception>
        public void Set(IEnumerable<AttachmentReference> attachments)
        {
            if (attachments is null)
                throw new ArgumentNullException(nameof(attachments));

            _setter(new ObservableCollection<AttachmentReference>(attachments));
        }
    }
}
