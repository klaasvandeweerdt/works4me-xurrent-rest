using System;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent recurrence objects.
    /// </summary>
    public sealed class Recurrence : ObservableItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Recurrence"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The calendar field.
            /// </summary>
            [XurrentEnum("calendar")]
            Calendar,

            /// <summary>
            /// The day field.
            /// </summary>
            [XurrentEnum("day")]
            Day,

            /// <summary>
            /// The day of month field.
            /// </summary>
            [XurrentEnum("day_of_month")]
            DayOfMonth,

            /// <summary>
            /// The day of week field.
            /// </summary>
            [XurrentEnum("day_of_week")]
            DayOfWeek,

            /// <summary>
            /// The day of week day field.
            /// </summary>
            [XurrentEnum("day_of_week_day")]
            DayOfWeekDay,

            /// <summary>
            /// The day of week index field.
            /// </summary>
            [XurrentEnum("day_of_week_index")]
            DayOfWeekIndex,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The end date field.
            /// </summary>
            [XurrentEnum("end_date")]
            EndDate,

            /// <summary>
            /// The frequency field.
            /// </summary>
            [XurrentEnum("frequency")]
            Frequency,

            /// <summary>
            /// The ical field.
            /// </summary>
            [XurrentEnum("ical")]
            Ical,

            /// <summary>
            /// The interval field.
            /// </summary>
            [XurrentEnum("interval")]
            Interval,

            /// <summary>
            /// The last occurrence at field.
            /// </summary>
            [XurrentEnum("last_occurrence_at")]
            LastOccurrenceAt,

            /// <summary>
            /// The last occurrence errors field.
            /// </summary>
            [XurrentEnum("last_occurrence_errors")]
            LastOccurrenceErrors,

            /// <summary>
            /// The last occurrence object field.
            /// </summary>
            [XurrentEnum("last_occurrence_object")]
            LastOccurrenceObject,

            /// <summary>
            /// The month of year field.
            /// </summary>
            [XurrentEnum("month_of_year")]
            MonthOfYear,

            /// <summary>
            /// The next occurrence at field.
            /// </summary>
            [XurrentEnum("next_occurrence_at")]
            NextOccurrenceAt,

            /// <summary>
            /// The next occurrence errors field.
            /// </summary>
            [XurrentEnum("next_occurrence_errors")]
            NextOccurrenceErrors,

            /// <summary>
            /// The start date field.
            /// </summary>
            [XurrentEnum("start_date")]
            StartDate,

            /// <summary>
            /// The time of day field.
            /// </summary>
            [XurrentEnum("time_of_day")]
            TimeOfDay,

            /// <summary>
            /// The time zone field.
            /// </summary>
            [XurrentEnum("time_zone")]
            TimeZone
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

        private Calendar? _calendar;
        private string? _day;
        private string? _dayOfMonth;
        private bool? _dayOfWeek;
        private string? _dayOfWeekDay;
        private RecurrenceDayOfWeekIndex? _dayOfWeekIndex;
        private bool? _disabled;
#if (NET6_0_OR_GREATER)
        private DateOnly? _endDate;
#else
        private DateTime? _endDate;
#endif
        private RecurrenceFrequency? _frequency;
        private string? _ical;
        private int? _interval;
        private DateTime? _lastOccurrenceAt;
        private string? _lastOccurrenceErrors;
        private Workflow? _lastOccurrenceObject;
        private string? _monthOfYear;
        private DateTime? _nextOccurrenceAt;
        private string? _nextOccurrenceErrors;
#if (NET6_0_OR_GREATER)
        private DateOnly? _startDate;
#else
        private DateTime? _startDate;
#endif
        private TimeSpan? _timeOfDay;
        private string? _timeZone;

        /// <summary>
        /// Gets the calendar used to skip occurrences during off-hours and holidays.
        /// </summary>
        [XurrentField("calendar")]
        public Calendar? Calendar
        {
            get => _calendar;
            internal set => _calendar = value;
        }

        /// <summary>
        /// Gets the days of the week for the recurrence.
        /// </summary>
        [XurrentField("day")]
        public string? Day
        {
            get => _day;
            internal set => _day = value;
        }

        /// <summary>
        /// Gets the days of the month for the recurrence.
        /// </summary>
        [XurrentField("day_of_month")]
        public string? DayOfMonth
        {
            get => _dayOfMonth;
            internal set => _dayOfMonth = value;
        }

        /// <summary>
        /// Gets a value indicating whether the recurrence is based on days of the week.
        /// </summary>
        [XurrentField("day_of_week")]
        public bool? DayOfWeek
        {
            get => _dayOfWeek;
            internal set => _dayOfWeek = value;
        }

        /// <summary>
        /// Gets the days of the week used when the recurrence is based on days of the week.
        /// </summary>
        [XurrentField("day_of_week_day")]
        public string? DayOfWeekDay
        {
            get => _dayOfWeekDay;
            internal set => _dayOfWeekDay = value;
        }

        /// <summary>
        /// Gets the day of week index used when the recurrence is based on days of the week.
        /// </summary>
        [XurrentField("day_of_week_index")]
        public RecurrenceDayOfWeekIndex? DayOfWeekIndex
        {
            get => _dayOfWeekIndex;
            internal set => _dayOfWeekIndex = value;
        }

        /// <summary>
        /// Gets a value indicating whether the recurrence is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            internal set => _disabled = value;
        }

        /// <summary>
        /// Gets the end date of the recurrence.
        /// </summary>
        [XurrentField("end_date")]
#if (NET6_0_OR_GREATER)
        public DateOnly? EndDate
#else
        public DateTime? EndDate
#endif
        {
            get => _endDate;
            internal set => _endDate = value;
        }

        /// <summary>
        /// Gets the frequency of the recurrence.
        /// </summary>
        [XurrentField("frequency")]
        public RecurrenceFrequency? Frequency
        {
            get => _frequency;
            internal set => _frequency = value;
        }

        /// <summary>
        /// Gets the iCal representation of the recurrence.
        /// </summary>
        [XurrentField("ical")]
        public string? Ical
        {
            get => _ical;
            internal set => _ical = value;
        }

        /// <summary>
        /// Gets the interval applied to the recurrence frequency.
        /// </summary>
        [XurrentField("interval")]
        public int? Interval
        {
            get => _interval;
            internal set => _interval = value;
        }

        /// <summary>
        /// Gets the date and time at which the last occurrence was created.
        /// </summary>
        [XurrentField("last_occurrence_at")]
        public DateTime? LastOccurrenceAt
        {
            get => _lastOccurrenceAt;
            internal set => _lastOccurrenceAt = value;
        }

        /// <summary>
        /// Gets the validation errors that occurred during the last occurrence.
        /// </summary>
        [XurrentField("last_occurrence_errors")]
        public string? LastOccurrenceErrors
        {
            get => _lastOccurrenceErrors;
            internal set => _lastOccurrenceErrors = value;
        }

        /// <summary>
        /// Gets the object created during the last occurrence.
        /// </summary>
        [XurrentField("last_occurrence_object")]
        public Workflow? LastOccurrenceObject
        {
            get => _lastOccurrenceObject;
            internal set => _lastOccurrenceObject = value;
        }

        /// <summary>
        /// Gets the months of the year for the recurrence.
        /// </summary>
        [XurrentField("month_of_year")]
        public string? MonthOfYear
        {
            get => _monthOfYear;
            internal set => _monthOfYear = value;
        }

        /// <summary>
        /// Gets the date and time at which the next occurrence will be created.
        /// </summary>
        [XurrentField("next_occurrence_at")]
        public DateTime? NextOccurrenceAt
        {
            get => _nextOccurrenceAt;
            internal set => _nextOccurrenceAt = value;
        }

        /// <summary>
        /// Gets the validation errors that prevented the next occurrence from being scheduled.
        /// </summary>
        [XurrentField("next_occurrence_errors")]
        public string? NextOccurrenceErrors
        {
            get => _nextOccurrenceErrors;
            internal set => _nextOccurrenceErrors = value;
        }

        /// <summary>
        /// Gets the start date of the recurrence.
        /// </summary>
        [XurrentField("start_date")]
#if (NET6_0_OR_GREATER)
        public DateOnly? StartDate
#else
        public DateTime? StartDate
#endif
        {
            get => _startDate;
            internal set => _startDate = value;
        }

        /// <summary>
        /// Gets the time of day at which the recurrence starts.
        /// </summary>
        [XurrentField("time_of_day")]
        public TimeSpan? TimeOfDay
        {
            get => _timeOfDay;
            internal set => _timeOfDay = value;
        }

        /// <summary>
        /// Gets the time zone that applies to the recurrence.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            internal set => _timeZone = value;
        }
    }
}
