using System;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a special-case timestamp with an associated token text and underlying <see cref="DateTime"/> value.
    /// </summary>
    public readonly struct SpecialTimestamp : IEquatable<SpecialTimestamp>
    {
        /// <summary>
        /// The token text (e.g., "best_effort").
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The underlying DateTime value.
        /// </summary>
        public DateTime Value { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="SpecialTimestamp"/> with the specified text token and <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="text">The token text (e.g., "best_effort").</param>
        /// <param name="value">The <see cref="DateTime"/> value associated with this token.</param>

        public SpecialTimestamp(string text, DateTime value)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Value = value;
        }

        /// <summary>
        /// Determines whether this instance is equal to another <see cref="SpecialTimestamp"/>.
        /// </summary>
        /// <param name="other">The other <see cref="SpecialTimestamp"/> to compare with.</param>
        /// <returns><see langword="true"/> if both <see cref="Text"/> and <see cref="Value"/> are equal; otherwise, <see langword="false"/>.</returns>

        public bool Equals(SpecialTimestamp other)
        {
            return Text == other.Text && Value == other.Value;
        }

        /// <summary>
        /// Determines whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="SpecialTimestamp"/> and equal to this instance; otherwise, <see langword="false"/>.</returns>

        public override bool Equals(object? obj)
        {
            return obj is SpecialTimestamp other && Equals(other);
        }

        /// <summary>
        /// Returns a hash code for this <see cref="SpecialTimestamp"/>.
        /// </summary>
        /// <returns>An integer representing the hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + StringComparer.Ordinal.GetHashCode(Text);
                hash = hash * 31 + Value.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Determines whether two <see cref="SpecialTimestamp"/> instances are equal.
        /// </summary>
        /// <param name="left">The left-hand <see cref="SpecialTimestamp"/>.</param>
        /// <param name="right">The right-hand <see cref="SpecialTimestamp"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(SpecialTimestamp left, SpecialTimestamp right)
        {
            return left.Equals(right); ;
        }

        /// <summary>
        /// Determines whether two <see cref="SpecialTimestamp"/> instances are not equal.
        /// </summary>
        /// <param name="left">The left-hand <see cref="SpecialTimestamp"/>.</param>
        /// <param name="right">The right-hand <see cref="SpecialTimestamp"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <see langword="false"/>.</returns>

        public static bool operator !=(SpecialTimestamp left, SpecialTimestamp right)
        {
            return !left.Equals(right);
        }

    }
}
