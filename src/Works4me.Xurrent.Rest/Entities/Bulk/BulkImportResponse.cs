using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the status of a Xurrent import operation.
    /// </summary>
    public sealed class BulkImportResponse
    {
        /// <summary>
        /// Gets the current state of the import operation.
        /// </summary>
        [XurrentField("state")]
        public ImportExportStatus State { get; internal set; } = ImportExportStatus.Queued;

        /// <summary>
        /// Gets the current progress of the import operation.
        /// </summary>
        [XurrentField("line")]
        public string? Line { get; internal set; }

        /// <summary>
        /// Gets the error message in case of failure.
        /// </summary>
        [XurrentField("message")]
        public string? Message { get; internal set; }

        /// <summary>
        /// Gets the results of the import operation, including counts of created, updated, deleted, unchanged items, failures, and errors.
        /// </summary>
        [XurrentField("results")]
        public ImportResults Results { get; internal set; } = new();

        /// <summary>
        /// Gets a link to the import log file.
        /// </summary>
        [XurrentField("logfile")]
        public string? LogFile { get; internal set; }
    }
}
