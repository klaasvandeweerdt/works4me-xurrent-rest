using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various workflow task note behavior options.
    /// </summary>
    public enum WorkflowTaskNoteBehavior
    {
        /// <summary>
        /// Indicates that the workflow task note behavior is hidden.
        /// </summary>
        [XurrentEnum("hidden")]
        Hidden,

        /// <summary>
        /// Indicates that the workflow task note is optional on completion.
        /// </summary>
        [XurrentEnum("optional_on_completion")]
        OptionalOnCompletion,

        /// <summary>
        /// Indicates that the workflow task note is optional on approval.
        /// </summary>
        [XurrentEnum("optional_on_approval")]
        OptionalOnApproval,

        /// <summary>
        /// Indicates that the workflow task note is required on completion.
        /// </summary>
        [XurrentEnum("required_on_completion")]
        RequiredOnCompletion,

        /// <summary>
        /// Indicates that the workflow task note is required on approval.
        /// </summary>
        [XurrentEnum("required_on_approval")]
        RequiredOnApproval
    }
}
