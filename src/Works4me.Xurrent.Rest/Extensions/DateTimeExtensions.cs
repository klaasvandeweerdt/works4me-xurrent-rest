using System;

namespace Works4me.Xurrent.Rest.Extensions
{
    /// <summary>
    /// Provides extension methods to check whether a <see cref="DateTime"/> or nullable <see cref="DateTime"/> matches any of the predefined <see cref="SpecialTimestamps"/> values.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Determines whether the <paramref name="value"/> equals the <see cref="SpecialTimestamps.BestEffort"/> value.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> to check.</param>
        /// <returns><c>true</c> if <paramref name="value"/> equals <see cref="SpecialTimestamps.BestEffort"/>; otherwise, <c>false</c>.</returns>
        public static bool IsBestEffort(this DateTime value)
        {
            return value == SpecialTimestamps.BestEffort.Value;
        }

        /// <summary>
        /// Determines whether the <paramref name="value"/> equals the <see cref="SpecialTimestamps.NoTarget"/> value.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> to check.</param>
        /// <returns><c>true</c> if <paramref name="value"/> equals <see cref="SpecialTimestamps.NoTarget"/>; otherwise, <c>false</c>.</returns>
        public static bool IsNoTarget(this DateTime value)
        {
            return value == SpecialTimestamps.NoTarget.Value;
        }

        /// <summary>
        /// Determines whether the <paramref name="value"/> equals the <see cref="SpecialTimestamps.ClockStopped"/> value.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> to check.</param>
        /// <returns><c>true</c> if <paramref name="value"/> equals <see cref="SpecialTimestamps.ClockStopped"/>; otherwise, <c>false</c>.</returns>
        public static bool IsClockStopped(this DateTime value)
        {
            return value == SpecialTimestamps.ClockStopped.Value;
        }

        /// <summary>
        /// Determines whether the nullable <paramref name="value"/> has a value equal to the <see cref="SpecialTimestamps.BestEffort"/> value.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to check.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is not null and equals <see cref="SpecialTimestamps.BestEffort"/>; otherwise, <c>false</c>.</returns>
        public static bool IsBestEffort(this DateTime? value)
        {
            return value.HasValue && value.Value == SpecialTimestamps.BestEffort.Value;
        }

        /// <summary>
        /// Determines whether the nullable <paramref name="value"/> has a value equal to the <see cref="SpecialTimestamps.NoTarget"/> value.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to check.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is not null and equals <see cref="SpecialTimestamps.NoTarget"/>; otherwise, <c>false</c>.</returns>
        public static bool IsNoTarget(this DateTime? value)
        {
            return value.HasValue && value.Value == SpecialTimestamps.NoTarget.Value;
        }

        /// <summary>
        /// Determines whether the nullable <paramref name="value"/> has a value equal to the <see cref="SpecialTimestamps.ClockStopped"/> value.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to check.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is not null and equals <see cref="SpecialTimestamps.ClockStopped"/>; otherwise, <c>false</c>.</returns>

        public static bool IsClockStopped(this DateTime? value)
        {
            return value.HasValue && value.Value == SpecialTimestamps.ClockStopped.Value;
        }
    }
}
