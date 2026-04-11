using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various request action types.
    /// </summary>
    public enum RequestActionType
    {
        /// <summary>
        /// Represents the access request action type.
        /// </summary>
        [XurrentEnum("access")]
        Access,

        /// <summary>
        /// Represents the compliance request action type.
        /// </summary>
        [XurrentEnum("compliance")]
        Compliance,

        /// <summary>
        /// Represents the configuration request action type.
        /// </summary>
        [XurrentEnum("configuration")]
        Configuration,

        /// <summary>
        /// Represents the creation request action type.
        /// </summary>
        [XurrentEnum("creation")]
        Creation,

        /// <summary>
        /// Represents the information request action type.
        /// </summary>
        [XurrentEnum("information")]
        Information,

        /// <summary>
        /// Represents the installation request action type.
        /// </summary>
        [XurrentEnum("installation")]
        Installation,

        /// <summary>
        /// Represents the modification request action type.
        /// </summary>
        [XurrentEnum("modification")]
        Modification,

        /// <summary>
        /// Represents the offboarding request action type.
        /// </summary>
        [XurrentEnum("offboarding")]
        Offboarding,

        /// <summary>
        /// Represents the onboarding request action type.
        /// </summary>
        [XurrentEnum("onboarding")]
        Onboarding,

        /// <summary>
        /// Represents the other request action type.
        /// </summary>
        [XurrentEnum("other")]
        Other,

        /// <summary>
        /// Represents the procurement request action type.
        /// </summary>
        [XurrentEnum("procurement")]
        Procurement,

        /// <summary>
        /// Represents the relocation request action type.
        /// </summary>
        [XurrentEnum("relocation")]
        Relocation,

        /// <summary>
        /// Represents the removal request action type.
        /// </summary>
        [XurrentEnum("removal")]
        Removal,

        /// <summary>
        /// Represents the renewal request action type.
        /// </summary>
        [XurrentEnum("renewal")]
        Renewal,

        /// <summary>
        /// Represents the replacement request action type.
        /// </summary>
        [XurrentEnum("replacement")]
        Replacement,

        /// <summary>
        /// Represents the reporting request action type.
        /// </summary>
        [XurrentEnum("reporting")]
        Reporting,

        /// <summary>
        /// Represents the reset request action type.
        /// </summary>
        [XurrentEnum("reset")]
        Reset,

        /// <summary>
        /// Represents the restoration request action type.
        /// </summary>
        [XurrentEnum("restoration")]
        Restoration,

        /// <summary>
        /// Represents the scheduling request action type.
        /// </summary>
        [XurrentEnum("scheduling")]
        Scheduling,

        /// <summary>
        /// Represents the training request action type.
        /// </summary>
        [XurrentEnum("training")]
        Training,

        /// <summary>
        /// Represents the transfer request action type.
        /// </summary>
        [XurrentEnum("transfer")]
        Transfer,

        /// <summary>
        /// Represents the troubleshoot request action type.
        /// </summary>
        [XurrentEnum("troubleshoot")]
        Troubleshoot,

        /// <summary>
        /// Represents the upgrade request action type.
        /// </summary>
        [XurrentEnum("upgrade")]
        Upgrade
    }
}
