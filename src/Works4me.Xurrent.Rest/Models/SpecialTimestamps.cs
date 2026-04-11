using System;
using System.Collections.Generic;
using System.Linq;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a set of predefined <see cref="SpecialTimestamp"/> instances for special-case timestamp values.
    /// </summary>
    public static class SpecialTimestamps
    {
        /// <summary>
        /// Represents a "best_effort" timestamp, using <c>new DateTime(1, 1, 1, 1, 1, 1, 111)</c>.
        /// </summary>
        public static readonly SpecialTimestamp BestEffort = new("best_effort", new DateTime(1, 1, 1, 1, 1, 1, 111));

        /// <summary>
        /// Represents a "no_target" timestamp, using <c>new DateTime(2, 2, 2, 2, 2, 2, 222)</c>.
        /// </summary>
        public static readonly SpecialTimestamp NoTarget = new("no_target", new DateTime(2, 2, 2, 2, 2, 2, 222));

        /// <summary>
        /// Represents a "clock_stopped" timestamp, using <c>new DateTime(3, 3, 3, 3, 3, 3, 333)</c>.
        /// </summary>
        public static readonly SpecialTimestamp ClockStopped = new("clock_stopped", new DateTime(3, 3, 3, 3, 3, 3, 333));

        /// <summary>
        /// A read-only list of all predefined <see cref="SpecialTimestamp"/> values.
        /// </summary>
        public static readonly IReadOnlyList<SpecialTimestamp> Values = new[] { BestEffort, NoTarget, ClockStopped };

        /// <summary>
        /// A dictionary mapping each special-timestamp text key to its corresponding <see cref="DateTime"/> value.
        /// </summary>
        public static readonly IReadOnlyDictionary<string, DateTime> TextToValue = Values.ToDictionary(s => s.Text, s => s.Value);

        /// <summary>
        /// A dictionary mapping each special <see cref="DateTime"/> value to its corresponding text key.
        /// </summary>
        public static readonly IReadOnlyDictionary<DateTime, string> ValueToText = Values.ToDictionary(s => s.Value, s => s.Text);
    }
}
