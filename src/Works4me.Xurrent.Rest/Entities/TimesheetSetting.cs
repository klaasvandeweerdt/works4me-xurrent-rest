using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent timesheet setting object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class TimesheetSetting : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="TimesheetSetting"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The allocation time tracking field.
            /// </summary>
            [XurrentEnum("allocation_time_tracking")]
            AllocationTimeTracking,

            /// <summary>
            /// The allow workday overtime field.
            /// </summary>
            [XurrentEnum("allow_workday_overtime")]
            AllowWorkdayOvertime,

            /// <summary>
            /// The allow workweek overtime field.
            /// </summary>
            [XurrentEnum("allow_workweek_overtime")]
            AllowWorkweekOvertime,

            /// <summary>
            /// The assignment time tracking field.
            /// </summary>
            [XurrentEnum("assignment_time_tracking")]
            AssignmentTimeTracking,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The name field.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The notify on incomplete field.
            /// </summary>
            [XurrentEnum("notify_on_incomplete")]
            NotifyOnIncomplete,

            /// <summary>
            /// The percentage increment field.
            /// </summary>
            [XurrentEnum("percentage_increment")]
            PercentageIncrement,

            /// <summary>
            /// The problem effort class field.
            /// </summary>
            [XurrentEnum("problem_effort_class")]
            ProblemEffortClass,

            /// <summary>
            /// The project task effort class field.
            /// </summary>
            [XurrentEnum("project_task_effort_class")]
            ProjectTaskEffortClass,

            /// <summary>
            /// The request effort class field.
            /// </summary>
            [XurrentEnum("request_effort_class")]
            RequestEffortClass,

            /// <summary>
            /// The require note field.
            /// </summary>
            [XurrentEnum("require_note")]
            RequireNote,

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
            /// The task effort class field.
            /// </summary>
            [XurrentEnum("task_effort_class")]
            TaskEffortClass,

            /// <summary>
            /// The time allocation effort class field.
            /// </summary>
            [XurrentEnum("time_allocation_effort_class")]
            TimeAllocationEffortClass,

            /// <summary>
            /// The time increment field.
            /// </summary>
            [XurrentEnum("time_increment")]
            TimeIncrement,

            /// <summary>
            /// The unit field.
            /// </summary>
            [XurrentEnum("unit")]
            Unit,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The workday field.
            /// </summary>
            [XurrentEnum("workday")]
            Workday,

            /// <summary>
            /// The workweek field.
            /// </summary>
            [XurrentEnum("workweek")]
            Workweek
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="TimesheetSetting"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters timesheet settings by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters timesheet settings by disabled status.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters timesheet settings by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters timesheet settings by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters timesheet settings by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters timesheet settings by source reference.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters timesheet settings by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="TimesheetSetting"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled timesheet settings.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled timesheet settings.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="TimesheetSetting"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts timesheet settings by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts timesheet settings by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts timesheet settings by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts timesheet settings by source reference.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts timesheet settings by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private bool? _allocationTimeTracking;
        private bool? _allowWorkdayOvertime;
        private bool? _allowWorkweekOvertime;
        private bool? _assignmentTimeTracking;
        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _name;
        private bool? _notifyOnIncomplete;
        private PercentageIncrement? _percentageIncrement;
        private EffortClass? _problemEffortClass;
        private EffortClass? _projectTaskEffortClass;
        private EffortClass? _requestEffortClass;
        private bool? _requireNote;
        private string? _source;
        private string? _sourceID;
        private EffortClass? _taskEffortClass;
        private EffortClass? _timeAllocationEffortClass;
        private int? _timeIncrement;
        private TimesheetSettingUnit? _unit;
        private DateTime? _updatedAt;
        private int? _workday;
        private int? _workweek;

        /// <summary>
        /// Gets or sets a value indicating whether people can register time entries for time allocations linked to their organizations.
        /// </summary>
        [XurrentField("allocation_time_tracking")]
        public bool? AllocationTimeTracking
        {
            get => _allocationTimeTracking;
            set => _allocationTimeTracking = SetValue("allocation_time_tracking", _allocationTimeTracking, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether people are allowed to register more time for a single day than the configured workday duration.
        /// </summary>
        [XurrentField("allow_workday_overtime")]
        public bool? AllowWorkdayOvertime
        {
            get => _allowWorkdayOvertime;
            set => _allowWorkdayOvertime = SetValue("allow_workday_overtime", _allowWorkdayOvertime, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether people are allowed to register more time for a single week than the configured workweek duration.
        /// </summary>
        [XurrentField("allow_workweek_overtime")]
        public bool? AllowWorkweekOvertime
        {
            get => _allowWorkweekOvertime;
            set => _allowWorkweekOvertime = SetValue("allow_workweek_overtime", _allowWorkweekOvertime, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the time spent field is available on requests, problems, and tasks.
        /// </summary>
        [XurrentField("assignment_time_tracking")]
        public bool? AssignmentTimeTracking
        {
            get => _assignmentTimeTracking;
            set => _assignmentTimeTracking = SetValue("assignment_time_tracking", _assignmentTimeTracking, value);
        }

        /// <summary>
        /// Gets the date and time at which the timesheet setting was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the timesheet setting can no longer be related to other records.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the name of the timesheet setting.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether notifications are sent when a timesheet is incomplete.
        /// </summary>
        [XurrentField("notify_on_incomplete")]
        public bool? NotifyOnIncomplete
        {
            get => _notifyOnIncomplete;
            set => _notifyOnIncomplete = SetValue("notify_on_incomplete", _notifyOnIncomplete, value);
        }

        /// <summary>
        /// Gets or sets the minimum percentage of a workday that can be selected when registering a time entry.
        /// </summary>
        [XurrentField("percentage_increment")]
        public PercentageIncrement? PercentageIncrement
        {
            get => _percentageIncrement;
            set => _percentageIncrement = SetValue("percentage_increment", _percentageIncrement, value);
        }

        /// <summary>
        /// Gets or sets the default effort class used when registering time on a problem.
        /// </summary>
        [XurrentField("problem_effort_class")]
        public EffortClass? ProblemEffortClass
        {
            get => _problemEffortClass;
            set => _problemEffortClass = SetValue("problem_effort_class", _problemEffortClass, value);
        }

        /// <summary>
        /// Gets or sets the default effort class used when registering time on a project task.
        /// </summary>
        [XurrentField("project_task_effort_class")]
        public EffortClass? ProjectTaskEffortClass
        {
            get => _projectTaskEffortClass;
            set => _projectTaskEffortClass = SetValue("project_task_effort_class", _projectTaskEffortClass, value);
        }

        /// <summary>
        /// Gets or sets the default effort class used when registering time on a request.
        /// </summary>
        [XurrentField("request_effort_class")]
        public EffortClass? RequestEffortClass
        {
            get => _requestEffortClass;
            set => _requestEffortClass = SetValue("request_effort_class", _requestEffortClass, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether a note is required when registering time.
        /// </summary>
        [XurrentField("require_note")]
        public bool? RequireNote
        {
            get => _requireNote;
            set => _requireNote = SetValue("require_note", _requireNote, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the timesheet setting.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the external source reference identifier.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the default effort class used when registering time on a workflow task.
        /// </summary>
        [XurrentField("task_effort_class")]
        public EffortClass? TaskEffortClass
        {
            get => _taskEffortClass;
            set => _taskEffortClass = SetValue("task_effort_class", _taskEffortClass, value);
        }

        /// <summary>
        /// Gets or sets the default effort class used when registering time on a time allocation.
        /// </summary>
        [XurrentField("time_allocation_effort_class")]
        public EffortClass? TimeAllocationEffortClass
        {
            get => _timeAllocationEffortClass;
            set => _timeAllocationEffortClass = SetValue("time_allocation_effort_class", _timeAllocationEffortClass, value);
        }

        /// <summary>
        /// Gets or sets the minimum time increment, in minutes, that can be selected when registering a time entry.
        /// </summary>
        [XurrentField("time_increment")]
        public int? TimeIncrement
        {
            get => _timeIncrement;
            set => _timeIncrement = SetValue("time_increment", _timeIncrement, value);
        }

        /// <summary>
        /// Gets or sets the unit used to register time.
        /// </summary>
        [XurrentField("unit")]
        public TimesheetSettingUnit? Unit
        {
            get => _unit;
            set => _unit = SetValue("unit", _unit, value);
        }

        /// <summary>
        /// Gets the date and time at which the timesheet setting was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the duration of a workday in minutes.
        /// </summary>
        [XurrentField("workday")]
        public int? Workday
        {
            get => _workday;
            set => _workday = SetValue("workday", _workday, value);
        }

        /// <summary>
        /// Gets or sets the duration of a workweek in minutes.
        /// </summary>
        [XurrentField("workweek")]
        public int? Workweek
        {
            get => _workweek;
            set => _workweek = SetValue("workweek", _workweek, value);
        }

        /// <summary>
        /// Creates a new timesheet setting instance.
        /// </summary>
        public TimesheetSetting()
        {
        }

        /// <summary>
        /// Creates a new timesheet setting instance.
        /// </summary>
        /// <param name="id">The unique identifier of the timesheet setting.</param>
        public TimesheetSetting(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new timesheet setting instance.
        /// </summary>
        /// <param name="name">The name of the timesheet setting.</param>
        /// <param name="unit">The unit of the timesheet setting.</param>
        public TimesheetSetting(string name, TimesheetSettingUnit unit)
        {
            _name = SetValue("name", name);
            _unit = SetValue("unit", unit);
        }
    }
}
