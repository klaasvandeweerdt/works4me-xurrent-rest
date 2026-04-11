namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents identity information for an item returned by the Xurrent REST API.
    /// </summary>
    public interface IRecord
    {
        /// <summary>
        /// Gets the instance- and environment-specific identifier assigned to the item.
        /// </summary>
        /// <value>A <see cref="long"/> representing a unique identifier within the current Xurrent instance and environment.</value>
        long Id { get; }

        /// <summary>
        /// Gets the globally unique identifier of the item.
        /// </summary>
        /// <value>A <see cref="string"/> that uniquely identifies the item across all Xurrent instances and environments.</value>
        string NodeID { get; }

        /// <summary>
        /// The 4me account in which the object exists. <br />
        /// The value will be <see langword="null"/> unless the account of the resource is different from the account of the authenticated user.
        /// </summary>
        Account? Account { get; }
    }
}
