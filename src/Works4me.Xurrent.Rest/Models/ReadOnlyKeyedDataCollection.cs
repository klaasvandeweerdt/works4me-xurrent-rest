using System;
using System.Collections;
using System.Collections.Generic;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a read-only wrapper around a <see cref="KeyedDataCollection{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of data item, which must implement <see cref="IMergeKeyProvider"/>.</typeparam>
    public sealed class ReadOnlyKeyedDataCollection<T> : IReadOnlyKeyedDataCollection<T> where T : IMergeKeyProvider
    {
        private readonly KeyedDataCollection<T> inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyKeyedDataCollection{T}"/> class.
        /// </summary>
        /// <param name="dataList">The <see cref="KeyedDataCollection{T}"/> to wrap.</param>
        internal ReadOnlyKeyedDataCollection(KeyedDataCollection<T> dataList)
        {
            if (dataList is null)
                throw new ArgumentNullException(nameof(dataList));
            inner = dataList;
        }

        /// <inheritdoc/>
        public T this[long key]
        {
            get => inner[key];
        }

        /// <inheritdoc/>
        public int Count
        {
            get => inner.Count;
        }

        /// <inheritdoc/>
        public bool Contains(long key)
        {
            return inner.Contains(key);
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return inner.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return inner.GetEnumerator();
        }
    }
}
