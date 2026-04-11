using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represent a Xurrent out of office period object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class OutOfOfficePeriod : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="OutOfOfficePeriod"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The approval delegate field.
            /// </summary>
            [XurrentEnum("approval_delegate")]
            ApprovalDelegate,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The effort class field.
            /// </summary>
            [XurrentEnum("effort_class")]
            EffortClass,

            /// <summary>
            /// The end at field.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

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
            /// The person field.
            /// </summary>
            [XurrentEnum("person")]
            Person,

            /// <summary>
            /// The reason field.
            /// </summary>
            [XurrentEnum("reason")]
            Reason,

            /// <summary>
            /// The source field.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// The source identifier field.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// The start at field.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// The time allocation field.
            /// </summary>
            [XurrentEnum("time_allocation")]
            TimeAllocation,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="OutOfOfficePeriod"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters out of office periods by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters out of office periods by end date and time.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

            /// <summary>
            /// Filters out of office periods by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters out of office periods by person.
            /// </summary>
            [XurrentEnum("person")]
            Person,

            /// <summary>
            /// Filters out of office periods by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters out of office periods by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters out of office periods by start date and time.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// Filters out of office periods by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of an <see cref="OutOfOfficePeriod"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all out of office periods for which the end time is in the past.
            /// </summary>
            [XurrentEnum("completed")]
            Completed,

            /// <summary>
            /// Lists all out of office periods for which the end time is in the future.
            /// </summary>
            [XurrentEnum("open")]
            Open
        }

        /// <summary>
        /// Represents the fields used to order an <see cref="OutOfOfficePeriod"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts out-of-office periods by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts out-of-office periods by their end date and time.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

            /// <summary>
            /// Sorts out-of-office periods by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts out-of-office periods by the identifier of the person.
            /// </summary>
            [XurrentEnum("person_id")]
            PersonId,

            /// <summary>
            /// Sorts out-of-office periods by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts out-of-office periods by their start date and time.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// Sorts out-of-office periods by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private Person? _approvalDelegate;
        private DateTime? _createdAt;
        private EffortClass? _effortClass;
        private DateTime? _endAt;
        private Person? _person;
        private string? _reason;
        private string? _source;
        private string? _sourceID;
        private DateTime? _startAt;
        private TimeAllocation? _timeAllocation;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets the approval delegate for the out of office period.
        /// </summary>
        [XurrentField("approval_delegate")]
        public Person? ApprovalDelegate
        {
            get => _approvalDelegate;
            set => _approvalDelegate = SetValue("approval_delegate", _approvalDelegate, value);
        }

        /// <summary>
        /// Gets the date and time when the out of office period was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the effort class used to generate time entries for the out of office period.
        /// </summary>
        [XurrentField("effort_class")]
        public EffortClass? EffortClass
        {
            get => _effortClass;
            set => _effortClass = SetValue("effort_class", _effortClass, value);
        }

        /// <summary>
        /// Gets or sets the end date and time of the out of office period.
        /// </summary>
        [XurrentField("end_at")]
        public DateTime? EndAt
        {
            get => _endAt;
            set => _endAt = SetValue("end_at", _endAt, value);
        }

        /// <summary>
        /// Gets or sets the person who is out of office.
        /// </summary>
        [XurrentField("person")]
        public Person? Person
        {
            get => _person;
            set => _person = SetValue("person", _person, value);
        }

        /// <summary>
        /// Gets or sets the reason for the out of office period.
        /// </summary>
        [XurrentField("reason")]
        public string? Reason
        {
            get => _reason;
            set => _reason = SetValue("reason", _reason, value);
        }

        /// <summary>
        /// Gets or sets the source of the out of office period.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the out of office period.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the start date and time of the out of office period.
        /// </summary>
        [XurrentField("start_at")]
        public DateTime? StartAt
        {
            get => _startAt;
            set => _startAt = SetValue("start_at", _startAt, value);
        }

        /// <summary>
        /// Gets or sets the time allocation used to generate time entries for the out of office period.
        /// </summary>
        [XurrentField("time_allocation")]
        public TimeAllocation? TimeAllocation
        {
            get => _timeAllocation;
            set => _timeAllocation = SetValue("time_allocation", _timeAllocation, value);
        }

        /// <summary>
        /// Gets the date and time when the out of office period was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new out of office period instance.
        /// </summary>
        public OutOfOfficePeriod()
        {
        }

        /// <summary>
        /// Creates a new out of office period instance.
        /// </summary>
        /// <param name="id">The unique identifier of the out of office period.</param>
        public OutOfOfficePeriod(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new out of office period instance.
        /// </summary>
        /// <param name="endAt">The end at of the out of office period.</param>
        /// <param name="person">The person of the out of office period.</param>
        /// <param name="startAt">The start at of the out of office period.</param>
        public OutOfOfficePeriod(DateTime endAt, Person person, DateTime startAt)
        {
            _endAt = SetValue("end_at", endAt);
            _person = SetValue("person", person);
            _startAt = SetValue("start_at", startAt);
        }
    }
}
