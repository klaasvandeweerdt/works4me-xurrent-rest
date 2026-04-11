using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various project task note behavior values.
    /// </summary>
    public enum ProjectTaskNoteBehavior
    {
        /// <summary>
        /// Indicates that the project task note is hidden.
        /// </summary>
        [XurrentEnum("hidden")]
        Hidden,

        /// <summary>
        /// Indicates that the project task note is optional on completion.
        /// </summary>
        [XurrentEnum("optional_on_completion")]
        OptionalOnCompletion,

        /// <summary>
        /// Indicates that the project task note is optional on approval.
        /// </summary>
        [XurrentEnum("optional_on_approval")]
        OptionalOnApproval,

        /// <summary>
        /// Indicates that the project task note is required on completion.
        /// </summary>
        [XurrentEnum("required_on_completion")]
        RequiredOnCompletion,

        /// <summary>
        /// Indicates that the project task note is required on approval.
        /// </summary>
        [XurrentEnum("required_on_approval")]
        RequiredOnApproval
    }
}
