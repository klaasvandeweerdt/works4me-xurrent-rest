using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the set of form parameters required to perform a browser-based Amazon S3 POST upload using a pre-signed policy.
    /// </summary>
    public sealed class AttachmentUploadParameters
    {
        /// <summary>
        /// Gets or sets the access control list (ACL) that determines the permissions applied to the uploaded object.
        /// </summary>
        [XurrentField("acl")]
        public string Acl { get; set; } = default!;

        /// <summary>
        /// Gets or sets the object key (path and filename) under which the file will be stored in the S3 bucket.
        /// </summary>
        [XurrentField("key")]
        public string Key { get; set; } = default!;

        /// <summary>
        /// Gets or sets the Base64-encoded upload policy document that defines the conditions and expiration of the upload request.
        /// </summary>
        [XurrentField("policy")]
        public string Policy { get; set; } = default!;

        /// <summary>
        /// Gets or sets the HTTP status code that Amazon S3 should return upon a successful upload.
        /// </summary>
        [XurrentField("success_action_status")]
        public int SuccessActionStatus { get; set; }

        /// <summary>
        /// Gets or sets the AWS signing algorithm used to generate the request signature.
        /// </summary>
        [XurrentField("x-amz-algorithm")]
        public string XAmzAlgorithm { get; set; } = default!;

        /// <summary>
        /// Gets or sets the AWS credential scope, including the access key, date, region, service, and termination string.
        /// </summary>
        [XurrentField("x-amz-credential")]
        public string XAmzCredential { get; set; } = default!;

        /// <summary>
        /// Gets or sets the timestamp used by AWS to validate the request, formatted according to ISO 8601 basic format.
        /// </summary>
        [XurrentField("x-amz-date")]
        public string XAmzDate { get; set; } = default!;

        /// <summary>
        /// Gets or sets the server-side encryption method that Amazon S3 should apply to the uploaded object.
        /// </summary>
        [XurrentField("x-amz-server-side-encryption")]
        public string XAmzServerSideEncryption { get; set; } = default!;

        /// <summary>
        /// Gets or sets the cryptographic signature generated from the policy and credentials, used by Amazon S3 to authenticate the upload request.
        /// </summary>
        [XurrentField("x-amz-signature")]
        public string XAmzSignature { get; set; } = default!;
    }
}
