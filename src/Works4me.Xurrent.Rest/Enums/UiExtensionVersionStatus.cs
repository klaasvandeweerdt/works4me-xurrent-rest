using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various UI extension version statuses.
    /// </summary>
    public enum UiExtensionVersionStatus
    {
        /// <summary>
        /// Indicates that the UI extension version is being prepared.
        /// </summary>
        [XurrentEnum("being_prepared")]
        BeingPrepared,

        /// <summary>
        /// Indicates that the UI extension version is active.
        /// </summary>
        [XurrentEnum("active")]
        Active,

        /// <summary>
        /// Indicates that the UI extension version is archived.
        /// </summary>
        [XurrentEnum("archived")]
        Archived
    }
}
