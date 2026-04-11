using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent account using statement object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class UsageStatement : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="UsageStatement"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The billable users field.
            /// </summary>
            [XurrentEnum("billable_user_ids")]
            BillableUsers,

            /// <summary>
            /// The end date field.
            /// </summary>
            [XurrentEnum("end_date")]
            EndDate,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The month field.
            /// </summary>
            [XurrentEnum("month")]
            Month,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The plan field.
            /// </summary>
            [XurrentEnum("plan")]
            Plan,

            /// <summary>
            /// The start date field.
            /// </summary>
            [XurrentEnum("start_date")]
            StartDate,

            /// <summary>
            /// The user months field.
            /// </summary>
            [XurrentEnum("user_months")]
            UserMonths,

            /// <summary>
            /// The year field.
            /// </summary>
            [XurrentEnum("year")]
            Year
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

        private List<long>? _billableUsers;
#if (NET6_0_OR_GREATER)
        private DateOnly? _endDate;
#else
        private DateTime? _endDate;
#endif
        private int? _month;
        private AccountPlan? _plan;
#if (NET6_0_OR_GREATER)
        private DateOnly? _startDate;
#else
        private DateTime? _startDate;
#endif
        private int? _userMonths;
        private int? _year;

        [XurrentField("billable_user_ids")]
        internal List<long>? BillableUsersCollection
        {
            get => _billableUsers;
            set => _billableUsers = value;
        }

        /// <summary>
        /// Gets the identifiers of the people that were enabled and had a billable role during the billing period.
        /// </summary>
        public ReadOnlyCollection<long>? BillableUsers
        {
            get => _billableUsers is null ? null : new ReadOnlyCollection<long>(_billableUsers);
        }

        /// <summary>
        /// Gets the date on which the billing period ended.
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
        /// Gets the month for which the usage statement was generated.
        /// </summary>
        [XurrentField("month")]
        public int? Month
        {
            get => _month;
            internal set => _month = value;
        }

        /// <summary>
        /// Gets the account plan used for the billing period.
        /// </summary>
        [XurrentField("plan")]
        public AccountPlan? Plan
        {
            get => _plan;
            internal set => _plan = value;
        }

        /// <summary>
        /// Gets the date on which the billing period started.
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
        /// Gets the number of billable user months in the billing period.
        /// </summary>
        [XurrentField("user_months")]
        public int? UserMonths
        {
            get => _userMonths;
            internal set => _userMonths = value;
        }

        /// <summary>
        /// Gets the year for which the usage statement was generated.
        /// </summary>
        [XurrentField("year")]
        public int? Year
        {
            get => _year;
            internal set => _year = value;
        }

        /// <summary>
        /// Creates a new usage statement instance.
        /// </summary>
        public UsageStatement()
        {
        }

        /// <summary>
        /// Creates a new usage statement instance.
        /// </summary>
        /// <param name="id">The unique identifier of the usage statement.</param>
        public UsageStatement(long id)
        {
            Id = id;
        }
    }
}
