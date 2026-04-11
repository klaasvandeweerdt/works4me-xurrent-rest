using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various configuration item statuses.
    /// </summary>
    public enum ConfigurationItemStatus
    {
        /// <summary>
        /// Represents a configuration item that is ordered.
        /// </summary>
        [XurrentEnum("ordered")]
        Ordered,

        /// <summary>
        /// Represents a configuration item that is being built.
        /// </summary>
        [XurrentEnum("being_built")]
        BeingBuilt,

        /// <summary>
        /// Represents a configuration item that is in stock.
        /// </summary>
        [XurrentEnum("in_stock")]
        InStock,

        /// <summary>
        /// Represents a configuration item that is reserved.
        /// </summary>
        [XurrentEnum("reserved")]
        Reserved,

        /// <summary>
        /// Represents a configuration item that is in transit.
        /// </summary>
        [XurrentEnum("in_transit")]
        InTransit,

        /// <summary>
        /// Represents a configuration item that is installed.
        /// </summary>
        [XurrentEnum("installed")]
        Installed,

        /// <summary>
        /// Represents a configuration item that is being tested.
        /// </summary>
        [XurrentEnum("being_tested")]
        BeingTested,

        /// <summary>
        /// Represents a configuration item that is on standby for continuity.
        /// </summary>
        [XurrentEnum("standby_for_continuity")]
        StandbyForContinuity,

        /// <summary>
        /// Represents a configuration item that is lent out.
        /// </summary>
        [XurrentEnum("lent_out")]
        LentOut,

        /// <summary>
        /// Represents a configuration item that is in production.
        /// </summary>
        [XurrentEnum("in_production")]
        InProduction,

        /// <summary>
        /// Represents a configuration item that is undergoing maintenance.
        /// </summary>
        [XurrentEnum("undergoing_maintenance")]
        UndergoingMaintenance,

        /// <summary>
        /// Represents a configuration item that is broken down.
        /// </summary>
        [XurrentEnum("broken_down")]
        BrokenDown,

        /// <summary>
        /// Represents a configuration item that is being repaired.
        /// </summary>
        [XurrentEnum("being_repaired")]
        BeingRepaired,

        /// <summary>
        /// Represents a configuration item that is archived.
        /// </summary>
        [XurrentEnum("archived")]
        Archived,

        /// <summary>
        /// Represents a configuration item that is to be removed.
        /// </summary>
        [XurrentEnum("to_be_removed")]
        ToBeRemoved,

        /// <summary>
        /// Represents a configuration item that is lost or stolen.
        /// </summary>
        [XurrentEnum("lost_or_stolen")]
        LostOrStolen,

        /// <summary>
        /// Represents a configuration item that is removed.
        /// </summary>
        [XurrentEnum("removed")]
        Removed
    }
}
