using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various contract categories.
    /// </summary>
    public enum ContractCategory
    {
        /// <summary>
        /// Indicates that the contract category is a lease contract.
        /// </summary>
        [XurrentEnum("lease_contract")]
        LeaseContract,

        /// <summary>
        /// Indicates that the contract category is a maintenance contract.
        /// </summary>
        [XurrentEnum("maintenance_contract")]
        MaintenanceContract,

        /// <summary>
        /// Indicates that the contract category is a support contract.
        /// </summary>
        [XurrentEnum("support_contract")]
        SupportContract,

        /// <summary>
        /// Indicates that the contract category is a support and maintenance contract.
        /// </summary>
        [XurrentEnum("support_and_maintenance_contract")]
        SupportAndMaintenanceContract,

        /// <summary>
        /// Indicates that the contract category is another type of contract.
        /// </summary>
        [XurrentEnum("other_type_of_contract")]
        OtherTypeOfContract
    }
}
