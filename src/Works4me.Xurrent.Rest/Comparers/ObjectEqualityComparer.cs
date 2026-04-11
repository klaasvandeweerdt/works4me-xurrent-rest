using System;
using System.Collections.Generic;

namespace Works4me.Xurrent.Rest.Comparers
{
    /// <summary>
    /// Custom equality comparer for objects.
    /// </summary>
    internal sealed class ObjectEqualityComparer : IEqualityComparer<object>
    {
        /// <summary>
        /// Determines whether two objects are equal.
        /// </summary>
        /// <param name="x">The first object to compare. Can be <see langword="null"/>.</param>
        /// <param name="y">The second object to compare. Can be <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the specified objects are equal; otherwise <see langword="false"/>.
        /// </returns>
        public new bool Equals(object? x, object? y)
        {
            if (x is null && y is null)
                return true;

            if (x is null || y is null)
                return false;

            Type xType = Nullable.GetUnderlyingType(x.GetType()) ?? x.GetType();
            Type yType = Nullable.GetUnderlyingType(y.GetType()) ?? y.GetType();

            return xType == yType && GenericComparer.Compare(x, y);
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The object for which to generate a hash code. Can be <see langword="null"/>.</param>
        /// <returns>
        /// A hash code for the specified object, or <c>0</c> if the object is <see langword="null"/>.
        /// </returns>
        public int GetHashCode(object? obj)
        {
            if (obj == null)
                return 0;

            Type underlyingType = Nullable.GetUnderlyingType(obj.GetType()) ?? obj.GetType();
            return underlyingType.GetHashCode() ^ obj.GetHashCode();
        }
    }
}
