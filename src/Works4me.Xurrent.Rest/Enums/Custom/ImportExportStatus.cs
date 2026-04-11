using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// The Xurrent import and export states.
    /// </summary>
    public enum ImportExportStatus
    {
        /// <summary>
        /// The import or export job is done.
        /// </summary>
        [XurrentEnum("done")]
        Done,
        /// <summary>
        /// The import or export job failed due to an error.
        /// </summary>
        [XurrentEnum("error")]
        Error,
        /// <summary>
        /// The import or export job failed.
        /// </summary>
        [XurrentEnum("failed")]
        Failed,
        /// <summary>
        /// The import or export job is being processed.
        /// </summary>
        [XurrentEnum("processing")]
        Processing,
        /// <summary>
        /// The import or export job is queued.
        /// </summary>
        [XurrentEnum("queued")]
        Queued,
        /// <summary>
        /// The import or export job is scheduled.
        /// </summary>
        [XurrentEnum("scheduled")]
        Scheduled
    }
}
