using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various note medium values.
    /// </summary>
    public enum NoteMedium
    {
        /// <summary>
        /// Indicates that the note uses the default medium.
        /// </summary>
        [XurrentEnum("default")]
        Default,

        /// <summary>
        /// Indicates that the note was created from an email.
        /// </summary>
        [XurrentEnum("email")]
        Email,

        /// <summary>
        /// Indicates that the note was created from an outbound email.
        /// </summary>
        [XurrentEnum("outbound_email")]
        OutboundEmail,

        /// <summary>
        /// Indicates that the note was created by the system.
        /// </summary>
        [XurrentEnum("system")]
        System,

        /// <summary>
        /// Indicates that the note is used as a reference.
        /// </summary>
        [XurrentEnum("reference")]
        Reference,

        /// <summary>
        /// Indicates that the note content has been redacted.
        /// </summary>
        [XurrentEnum("redacted")]
        Redacted,

        /// <summary>
        /// Indicates that the note was created by an automation medium.
        /// </summary>
        [XurrentEnum("automation")]
        Automation,

        /// <summary>
        /// Indicates that the note was created by an AI medium.
        /// </summary>
        [XurrentEnum("ai")]
        Ai
    }
}
