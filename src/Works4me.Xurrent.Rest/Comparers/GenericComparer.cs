using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Works4me.Xurrent.Rest.Comparers
{
    internal static class GenericComparer
    {
        /// <summary>
        /// Compares two objects.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>True if the objects are considered equal, false otherwise.</returns>
        internal static bool Compare(object? x, object? y)
        {
            if (x is null && y is null)
                return true;

            if (x is null || y is null)
                return false;

            if (x is IRecord xIdentifier && y is IRecord yIdentifier)
                return xIdentifier.Id == yIdentifier.Id;

            if (x is IEnumerable xEnumerable && y is IEnumerable yEnumerable)
                return CompareEnumerables(xEnumerable, yEnumerable);

            return EqualityComparer<object>.Default.Equals(x, y);
        }

        /// <summary>
        /// Compares two enumerables for equality by their elements.
        /// </summary>
        /// <param name="x">The first enumerable.</param>
        /// <param name="y">The second enumerable.</param>
        /// <returns>True if all elements are equal in order, false otherwise.</returns>
        private static bool CompareEnumerables(IEnumerable x, IEnumerable y)
        {
            if (x is ICollection xCollection && y is ICollection yCollection)
            {
                if (xCollection.Count != yCollection.Count)
                    return false;
            }

            return x.Cast<object>().SequenceEqual(y.Cast<object>(), new ObjectEqualityComparer());
        }
    }
}
