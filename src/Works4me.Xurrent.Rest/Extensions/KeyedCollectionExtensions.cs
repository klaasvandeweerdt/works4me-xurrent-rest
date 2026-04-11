#if NETFRAMEWORK || NETSTANDARD2_0
using System;
using System.Collections.ObjectModel;

namespace Works4me.Xurrent.Rest.Extensions
{
    /// <summary>
    /// A set of <see cref="KeyedCollection{TKey,TItem}"/> extension methods.
    /// </summary>
    public static class KeyedCollectionExtensions
    {
        /// <summary>
        /// Attempts to retrieve the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the collection. Must be non-nullable.</typeparam>
        /// <typeparam name="TItem">The type of the items stored in the collection.</typeparam>
        /// <param name="collection">The keyed collection to search.</param>
        /// <param name="key">The key whose value to retrieve.</param>
        /// <param name="value">When this method returns, contains the item associated with the specified key,if the key is found; otherwise, the default value for <typeparamref name="TItem"/>.</param>
        /// <returns><see langword="true"/> if the key was found; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="collection"/> is <see langword="null"/>.</exception>
        public static bool TryGetValue<TKey, TItem>(this KeyedCollection<TKey, TItem> collection, TKey key, out TItem value)
            where TKey : notnull
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            if (collection.Contains(key))
            {
                value = collection[key];
                return true;
            }

            value = default!;
            return false;
        }
    }
}
#endif
