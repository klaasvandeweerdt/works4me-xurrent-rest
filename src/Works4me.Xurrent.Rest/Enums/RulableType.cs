using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various app offering automation rulable types.
    /// </summary>
    public enum RulableType
    {
        /// <summary>
        /// Indicates that the automation rule applies to configuration items.
        /// </summary>
        [XurrentEnum("Ci")]
        ConfigurationItem,

        /// <summary>
        /// Indicates that the automation rule applies to problems.
        /// </summary>
        [XurrentEnum("Problem")]
        Problem,

        /// <summary>
        /// Indicates that the automation rule applies to requests.
        /// </summary>
        [XurrentEnum("Req")]
        Request,

        /// <summary>
        /// Indicates that the automation rule applies to workflow tasks.
        /// </summary>
        [XurrentEnum("Task")]
        WorkflowTask
    }
}
