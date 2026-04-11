namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Defines a contract for providing a merge key used to identify items across paged or partial data responses.
    /// </summary>
    /// <remarks>
    /// A merge key uniquely represents the logical identity of an item, allowing merging logic to detect duplicates and determine whether an item should be added or replace an existing entry in a result collection.
    /// </remarks>
    public interface IMergeKeyProvider
    {
        /// <summary>
        /// Returns a key used for merging paged or partial data responses.
        /// </summary>
        /// <returns>A <see cref="long"/> representing the merge key or unique identifier for this item.</returns>
        long GetMergeKey();
    }
}
