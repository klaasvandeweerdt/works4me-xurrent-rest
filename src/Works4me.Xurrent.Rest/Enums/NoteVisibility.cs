using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various note visibility values.
    /// </summary>
    public enum NoteVisibility
    {
        /// <summary>
        /// Indicates that the note is visible to end users.
        /// </summary>
        [XurrentEnum("end_user")]
        EndUser,

        /// <summary>
        /// Indicates that the note is visible to specialists.
        /// </summary>
        [XurrentEnum("specialist")]
        Specialist,

        /// <summary>
        /// Indicates that the note is visible for audit purposes.
        /// </summary>
        [XurrentEnum("audit")]
        Audit
    }
}
