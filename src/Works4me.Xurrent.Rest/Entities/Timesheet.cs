using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent timesheet object.
    /// </summary>
    public sealed class Timesheet : ObservableItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Timesheet"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The completeness field.
            /// </summary>
            [XurrentEnum("completeness")]
            Completeness,

            /// <summary>
            /// The locked field.
            /// </summary>
            [XurrentEnum("locked")]
            Locked,

            /// <summary>
            /// The locked days field.
            /// </summary>
            [XurrentEnum("locked_days")]
            LockedDays,

            /// <summary>
            /// The name field.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// The person field.
            /// </summary>
            [XurrentEnum("person")]
            Person,

            /// <summary>
            /// The primary email field.
            /// </summary>
            [XurrentEnum("primary_email")]
            PrimaryEmail,

            /// <summary>
            /// The remaining time field.
            /// </summary>
            [XurrentEnum("remaining_time")]
            RemainingTime,

            /// <summary>
            /// The sum time spent field.
            /// </summary>
            [XurrentEnum("sum_time_spent")]
            SumTimeSpent,

            /// <summary>
            /// The workday field.
            /// </summary>
            [XurrentEnum("workday")]
            Workday,

            /// <summary>
            /// The workdays field.
            /// </summary>
            [XurrentEnum("workdays")]
            Workdays
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Timesheet"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters timesheets by month.
            /// </summary>
            [XurrentEnum("month_of")]
            MonthOf,

            /// <summary>
            /// Filters timesheets by organization identifier.
            /// </summary>
            [XurrentEnum("organization_id")]
            OrganizationId,

            /// <summary>
            /// Filters timesheets by person identifier.
            /// </summary>
            [XurrentEnum("person_id")]
            PersonId
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

        private int? _completeness;
        private bool? _locked;
        private string? _lockedDays;
        private string? _name;
        private Person? _person;
        private string? _primaryEmail;
        private int? _remainingTime;
        private int? _sumTimeSpent;
        private int? _workday;
        private float? _workdays;

        /// <summary>
        /// Gets the completeness status of the timesheet.
        /// </summary>
        [XurrentField("completeness")]
        public int? Completeness
        {
            get => _completeness;
            internal set => _completeness = value;
        }

        /// <summary>
        /// Gets a value indicating whether all days of the selected month are locked for the selected person.
        /// </summary>
        [XurrentField("locked")]
        public bool? Locked
        {
            get => _locked;
            internal set => _locked = value;
        }

        /// <summary>
        /// Gets a string representing the lock status of each day in the selected month.
        /// </summary>
        [XurrentField("locked_days")]
        public string? LockedDays
        {
            get => _lockedDays;
            internal set => _lockedDays = value;
        }

        /// <summary>
        /// Gets the name of the person for whom the timesheet was generated.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            internal set => _name = value;
        }

        /// <summary>
        /// Gets the person reference for whom the timesheet was generated.
        /// </summary>
        [XurrentField("person")]
        public Person? Person
        {
            get => _person;
            internal set => _person = value;
        }

        /// <summary>
        /// Gets the primary email address of the person for whom the timesheet was generated.
        /// </summary>
        [XurrentField("primary_email")]
        public string? PrimaryEmail
        {
            get => _primaryEmail;
            internal set => _primaryEmail = value;
        }

        /// <summary>
        /// Gets the remaining time in minutes for the selected week.
        /// </summary>
        [XurrentField("remaining_time")]
        public int? RemainingTime
        {
            get => _remainingTime;
            internal set => _remainingTime = value;
        }

        /// <summary>
        /// Gets the total number of minutes of time spent for the selected month.
        /// </summary>
        [XurrentField("sum_time_spent")]
        public int? SumTimeSpent
        {
            get => _sumTimeSpent;
            internal set => _sumTimeSpent = value;
        }

        /// <summary>
        /// Gets the number of minutes of a workday as specified in the timesheet settings of the organization.
        /// </summary>
        [XurrentField("workday")]
        public int? Workday
        {
            get => _workday;
            internal set => _workday = value;
        }

        /// <summary>
        /// Gets the total number of workdays calculated from the time spent and the configured workday length.
        /// </summary>
        [XurrentField("workdays")]
        public float? Workdays
        {
            get => _workdays;
            set => _workdays = SetValue("workdays", _workdays, value);
        }
    }
}
