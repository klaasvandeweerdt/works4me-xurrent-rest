using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various contact labels.
    /// </summary>
    public enum ContactLabel
    {
        /// <summary>
        /// Represents a general contact label.
        /// </summary>
        [XurrentEnum("general")]
        General,

        /// <summary>
        /// Represents a service desk contact label.
        /// </summary>
        [XurrentEnum("service_desk")]
        ServiceDesk,

        /// <summary>
        /// Represents a work contact label.
        /// </summary>
        [XurrentEnum("work")]
        Work,

        /// <summary>
        /// Represents a mobile contact label.
        /// </summary>
        [XurrentEnum("mobile")]
        Mobile,

        /// <summary>
        /// Represents a home contact label.
        /// </summary>
        [XurrentEnum("home")]
        Home,

        /// <summary>
        /// Represents a personal contact label.
        /// </summary>
        [XurrentEnum("personal")]
        Personal,

        /// <summary>
        /// Represents an emergency contact label.
        /// </summary>
        [XurrentEnum("emergency")]
        Emergency,

        /// <summary>
        /// Represents a fax contact label.
        /// </summary>
        [XurrentEnum("fax")]
        Fax,

        /// <summary>
        /// Represents a service desk fax contact label.
        /// </summary>
        [XurrentEnum("service_desk_fax")]
        ServiceDeskFax,

        /// <summary>
        /// Represents a work chat contact label.
        /// </summary>
        [XurrentEnum("chat_workchat")]
        WorkChat,

        /// <summary>
        /// Represents a Microsoft Teams contact label.
        /// </summary>
        [XurrentEnum("chat_teams")]
        Teams,

        /// <summary>
        /// Represents a Slack contact label.
        /// </summary>
        [XurrentEnum("chat_slack")]
        Slack,

        /// <summary>
        /// Represents a Skype contact label.
        /// </summary>
        [XurrentEnum("chat_skype")]
        Skype
    }
}
