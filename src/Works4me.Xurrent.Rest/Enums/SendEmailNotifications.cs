using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various send email notification options.
    /// </summary>
    public enum SendEmailNotifications
    {
        /// <summary>
        /// Indicates that email notifications are always sent.
        /// </summary>
        [XurrentEnum("always")]
        Always,

        /// <summary>
        /// Indicates that email notifications are sent only when the user is offline.
        /// </summary>
        [XurrentEnum("when_offline")]
        WhenOffline,

        /// <summary>
        /// Indicates that email notifications are never sent.
        /// </summary>
        [XurrentEnum("never")]
        Never
    }
}
