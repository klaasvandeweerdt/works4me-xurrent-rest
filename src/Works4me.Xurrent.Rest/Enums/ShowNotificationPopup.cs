using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various notification popup options.
    /// </summary>
    public enum ShowNotificationPopup
    {
        /// <summary>
        /// Indicates that notification popups are always shown.
        /// </summary>
        [XurrentEnum("always")]
        Always,

        /// <summary>
        /// Indicates that notification popups are shown only for important notifications.
        /// </summary>
        [XurrentEnum("important_only")]
        ImportantOnly,

        /// <summary>
        /// Indicates that notification popups are never shown.
        /// </summary>
        [XurrentEnum("never")]
        Never
    }
}
