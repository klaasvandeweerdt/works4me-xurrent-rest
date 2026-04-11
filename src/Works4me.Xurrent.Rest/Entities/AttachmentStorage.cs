using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent attachment storage object.
    /// </summary>
    public sealed class AttachmentStorage : ObservableItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AttachmentStorage"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The allowed extensions field.
            /// </summary>
            [XurrentEnum("allowed_extensions")]
            AllowedExtensions,

            /// <summary>
            /// The provider field.
            /// </summary>
            [XurrentEnum("provider")]
            Provider,

            /// <summary>
            /// The size limit field.
            /// </summary>
            [XurrentEnum("size_limit")]
            SizeLimit,

            /// <summary>
            /// The upload parameters field.
            /// </summary>
            [XurrentEnum("s3")]
            UploadParameters,

            /// <summary>
            /// The upload uri field.
            /// </summary>
            [XurrentEnum("upload_uri")]
            UploadUri
        }

        /// <summary>
        /// Represents the absence of supported filters for a query.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the absence of supported predefined filters for a query.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the absence of supported ordering fields for a query.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Specifies that no ordering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        private List<string>? _allowedExtensions;
        private string? _provider;
        private long? _sizeLimit;
        private AttachmentUploadParameters? _uploadParameters;
        private Uri? _uploadUri;

        [XurrentField("allowed_extensions")]
        internal List<string>? AllowedExtensionsCollection
        {
            get => _allowedExtensions;
            set => _allowedExtensions = value;
        }

        /// <summary>
        /// Gets the permitted file extensions for uploads.
        /// </summary>
        public ReadOnlyCollection<string>? AllowedExtensions
        {
            get => _allowedExtensions is null ? null : new ReadOnlyCollection<string>(_allowedExtensions);
        }

        /// <summary>
        /// Gets the type of storage provider in use.
        /// </summary>
        [XurrentField("provider")]
        public string? Provider
        {
            get => _provider;
            internal set => _provider = value;
        }

        /// <summary>
        /// Gets the maximum allowed upload size in bytes.
        /// </summary>
        [XurrentField("size_limit")]
        public long? SizeLimit
        {
            get => _sizeLimit;
            internal set => _sizeLimit = value;
        }

        /// <summary>
        /// Gets the required parameters and values that must be included in an upload POST to the <c>uploadUri</c>.
        /// </summary>
        [XurrentField("s3")]
        public AttachmentUploadParameters? UploadParameters
        {
            get => _uploadParameters;
            internal set => _uploadParameters = value;
        }

        /// <summary>
        /// Gets or sets the URI to which attachments must be uploaded.
        /// </summary>
        [XurrentField("upload_uri")]
        public Uri? UploadUri
        {
            get => _uploadUri;
            set => _uploadUri = SetValue("upload_uri", _uploadUri, value);
        }
    }
}
