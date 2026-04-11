using System;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the status of a Xurrent export operation.
    /// </summary>
    public sealed class BulkExportResponse
    {
        /// <summary>
        /// The state.
        /// </summary>
        [XurrentField("state")]
        public ImportExportStatus State { get; internal set; } = ImportExportStatus.Queued;

        /// <summary>
        /// The type or types.
        /// </summary>
        [XurrentField("type")]
        public string? Type { get; internal set; }

        /// <summary>
        /// The progress.
        /// </summary>
        [XurrentField("line")]
        public string? Line { get; internal set; }

        /// <summary>
        /// The download URL.
        /// </summary>
        [XurrentField("url")]
        public Uri? Url { get; internal set; }

        /// <summary>
        /// The expiration date.
        /// </summary>
        [XurrentField("expires_at")]
        public DateTime? ExpiresAt { get; internal set; }

        /// <summary>
        /// Additional failure rate limit failure information.
        /// </summary>
        [XurrentField("rate_limit_exceeded")]
        public string? RateLimitExceeded { get; internal set; }

        /// <summary>
        /// A link to the export log file.
        /// </summary>
        [XurrentField("logfile")]
        public string? LogFile { get; internal set; }
    }
}
