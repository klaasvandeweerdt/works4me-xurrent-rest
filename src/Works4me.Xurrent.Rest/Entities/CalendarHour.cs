using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent calendar hour object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class CalendarHour : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="CalendarHour"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The time from field.
            /// </summary>
            [XurrentEnum("time_from")]
            TimeFrom,

            /// <summary>
            /// The time until field.
            /// </summary>
            [XurrentEnum("time_until")]
            TimeUntil,

            /// <summary>
            /// The weekday field.
            /// </summary>
            [XurrentEnum("weekday")]
            Weekday
        }

        /// <summary>
        /// Represents the absence of supported filters for a query.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the absence of supported predefined filters for a query.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the absence of supported ordering fields for a query.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Specifies that no ordering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        private TimeSpan? _timeFrom;
        private TimeSpan? _timeUntil;
        private Weekday? _weekday;

        /// <summary>
        /// The time at which the calendar becomes active on the given weekday.
        /// </summary>
        [XurrentField("time_from")]
        public TimeSpan? TimeFrom
        {
            get => _timeFrom;
            set => _timeFrom = SetValue("time_from", _timeFrom, value);
        }

        /// <summary>
        /// The time at which the calendar stops being active on the given weekday.
        /// </summary>
        [XurrentField("time_until")]
        public TimeSpan? TimeUntil
        {
            get => _timeUntil;
            set => _timeUntil = SetValue("time_until", _timeUntil, value);
        }

        /// <summary>
        /// The day of the week.
        /// </summary>
        [XurrentField("weekday")]
        public Weekday? Weekday
        {
            get => _weekday;
            set => _weekday = SetValue("weekday", _weekday, value);
        }

        /// <summary>
        /// Creates a new calendar hour instance.
        /// </summary>
        public CalendarHour()
        {
        }

        /// <summary>
        /// Creates a new calendar hour instance.
        /// </summary>
        /// <param name="id">The unique identifier of the calendar hour.</param>
        public CalendarHour(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new calendar hour instance.
        /// </summary>
        /// <param name="timeFrom">The time from of the calendar hour.</param>
        /// <param name="timeUntil">The time until of the calendar hour.</param>
        /// <param name="weekday">The weekday of the calendar hour.</param>
        public CalendarHour(TimeSpan timeFrom, TimeSpan timeUntil, Weekday weekday)
        {
            _timeFrom = SetValue("time_from", timeFrom);
            _timeUntil = SetValue("time_until", timeUntil);
            _weekday = SetValue("weekday", weekday);
        }
    }
}
