namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// An attachment upload response.
    /// </summary>
    public class AttachmentUploadResponse
    {
        /// <summary>
        /// The S3 file storage reference key.
        /// </summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// The file size.
        /// </summary>
        public long Size { get; set; }
    }
}
