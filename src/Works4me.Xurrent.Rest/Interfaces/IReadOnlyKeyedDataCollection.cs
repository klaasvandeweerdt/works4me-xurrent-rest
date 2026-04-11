using System.Collections.Generic;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a read-only collection of keyed data items that can be accessed by their merge key.
    /// </summary>
    /// <typeparam name="T">The type of data item, which must implement <see cref="IMergeKeyProvider"/>.</typeparam>
    public interface IReadOnlyKeyedDataCollection<T> : IReadOnlyCollection<T> where T : IMergeKeyProvider
    {
        /// <summary>
        /// Determines whether the collection contains an item with the specified merge key.
        /// </summary>
        /// <param name="key">The merge key of the item to locate.</param>
        /// <returns><see langword="true"/> if the collection contains an item with the specified key; otherwise, <see langword="false"/>.</returns>
        bool Contains(long key);

        /// <summary>
        /// Gets the item with the specified merge key.
        /// </summary>
        /// <param name="key">The merge key of the item to get.</param>
        /// <returns>The data item associated with the specified key.</returns>
        T this[long key] { get; }
    }
}
