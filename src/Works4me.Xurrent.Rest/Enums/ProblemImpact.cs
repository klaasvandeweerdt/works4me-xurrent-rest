using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various problem impact values.
    /// </summary>
    public enum ProblemImpact
    {
        /// <summary>
        /// Indicates that the problem impact does not degrade the service.
        /// </summary>
        [XurrentEnum("none")]
        None,

        /// <summary>
        /// Indicates that the problem impact degrades the service for one user.
        /// </summary>
        [XurrentEnum("low")]
        Low,

        /// <summary>
        /// Indicates that the problem impact brings the service down for one user.
        /// </summary>
        [XurrentEnum("medium")]
        Medium,

        /// <summary>
        /// Indicates that the problem impact degrades the service for several users.
        /// </summary>
        [XurrentEnum("high")]
        High,

        /// <summary>
        /// Indicates that the problem impact brings the service down for several users.
        /// </summary>
        [XurrentEnum("top")]
        Top
    }
}
