using System;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the rate or cost limit information for an authentication token, including total limit, remaining quota, and reset timestamp.
    /// </summary>
    public sealed class AuthenticationTokenLimit
    {
        /// <summary>
        /// Gets the total number of requests or cost points allowed in the current period.
        /// </summary>
        public int Limit { get; internal set; } = int.MaxValue;

        /// <summary>
        /// Gets the number of remaining requests or cost points in the current period.
        /// </summary>
        public int Remaining { get; internal set; } = int.MaxValue;

        /// <summary>
        /// Gets the timestamp when the limit resets (start of the next window).
        /// </summary>
        public DateTimeOffset Reset { get; internal set; } = DateTimeOffset.MinValue;

        /// <summary>
        /// Creates a copy of this authentication token limit.
        /// </summary>
        /// <returns>A new <see cref="AuthenticationTokenLimit"/> instance with the same values.</returns>
        internal AuthenticationTokenLimit Clone()
        {
            return new AuthenticationTokenLimit
            {
                Limit = Limit,
                Remaining = Remaining,
                Reset = Reset
            };
        }
    }
}
