using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a keyed collection of <typeparamref name="T"/> items identified by a <see cref="long"/> merge key.
    /// When an item with an existing merge key is added, the existing item in the collection is updated.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the collection. The type must implement <see cref="IMergeKeyProvider"/> to provide a merge key for identifying items.</typeparam>
    internal sealed class KeyedDataCollection<T> : KeyedCollection<long, T>
        where T : notnull, IMergeKeyProvider
    {
        /// <summary>
        /// Initializes a new, empty <see cref="KeyedDataCollection{T}"/> instance.
        /// </summary>
        public KeyedDataCollection()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="KeyedDataCollection{T}"/> instance that contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">
        /// The collection whose elements are copied into the new <see cref="KeyedDataCollection{T}"/>.
        /// </param>
        public KeyedDataCollection(IEnumerable<T> collection)
        {
            AddRange(collection);
        }

        /// <summary>
        /// Enumerates the merge keys for items in the collection, in the same order as the items.
        /// </summary>
        public IEnumerable<long> Keys
        {
            get
            {
                foreach (T item in Items)
                    yield return GetKeyForItem(item);
            }
        }

        /// <summary>
        /// Retrieves the key for the given item by invoking its <see cref="IMergeKeyProvider.GetMergeKey"/> method.
        /// </summary>
        /// <param name="item">The data item whose merge key is to be retrieved.</param>
        /// <returns>The merge key value for the specified <paramref name="item"/>.</returns>
        protected override long GetKeyForItem(T item)
        {
            return item.GetMergeKey();
        }

        /// <summary>
        /// Adds a new item to the collection. If an item with the same merge key already exists, the existing item is updated in-place (sequence is preserved).
        /// </summary>
        /// <param name="item">The item to add or update.</param>
        public new void Add(T item)
        {
            int index = FindIndexByKey(item.GetMergeKey());

            if (index > -1)
                SetItem(index, item);
            else
                base.Add(item);
        }


        /// <summary>
        /// Inserts an item at the specified index. If an item with the same merge key already exists, the existing item is updated in-place and the requested <paramref name="index"/> is ignored for that case.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert the <paramref name="item"/> if it is new.</param>
        /// <param name="item">The item to insert or update.</param>
        protected override void InsertItem(int index, T item)
        {
            int existingIndex = FindIndexByKey(item.GetMergeKey());

            if (existingIndex > -1)
                SetItem(existingIndex, item);
            else
                base.InsertItem(index, item);
        }

        /// <summary>
        /// Adds a range of items to the collection. For each item, updates an existing item with the same merge key in-place, or adds it when not present.
        /// </summary>
        /// <param name="collection">The collection of items to add or update.</param>
        public void AddRange(IEnumerable<T>? collection)
        {
            if (collection is null)
                return;

            foreach (T item in collection)
                Add(item);
        }

        /// <summary>
        /// Determines whether the collection contains an item with the specified merge key.
        /// </summary>
        /// <param name="key">The merge key to locate.</param>
        /// <returns><see langword="true"/> if an item with the specified key exists; otherwise, <see langword="false"/>.</returns>
        public bool ContainsKey(long key)
        {
            return FindIndexByKey(key) > -1;
        }

        /// <summary>
        /// Finds the index of an item with the specified key.
        /// </summary>
        /// <param name="key">The key to locate.</param>
        /// <returns>
        /// The zero-based index of the first occurrence of an item with the specified key, or -1 if no such item exists.
        /// </returns>
        private int FindIndexByKey(long key)
        {
            for (int i = 0; i < Count; i++)
            {
                if (GetKeyForItem(Items[i]) == key)
                    return i;
            }

            return -1;
        }
    }
}
