using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various knowledge article statuses.
    /// </summary>
    public enum KnowledgeArticleStatus
    {
        /// <summary>
        /// Indicates that the knowledge article is a work in progress.
        /// </summary>
        [XurrentEnum("work_in_progress")]
        WorkInProgress,

        /// <summary>
        /// Indicates that the knowledge article is not validated.
        /// </summary>
        [XurrentEnum("not_validated")]
        NotValidated,

        /// <summary>
        /// Indicates that the knowledge article is validated.
        /// </summary>
        [XurrentEnum("validated")]
        Validated,

        /// <summary>
        /// Indicates that the knowledge article is archived.
        /// </summary>
        [XurrentEnum("archived")]
        Archived
    }
}
