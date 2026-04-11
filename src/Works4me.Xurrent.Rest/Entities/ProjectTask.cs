using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent project task object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ProjectTask : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ProjectTask"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The agile board field.
            /// </summary>
            [XurrentEnum("agile_board")]
            AgileBoard,

            /// <summary>
            /// The agile board column field.
            /// </summary>
            [XurrentEnum("agile_board_column")]
            AgileBoardColumn,

            /// <summary>
            /// The agile board column position field.
            /// </summary>
            [XurrentEnum("agile_board_column_position")]
            AgileBoardColumnPosition,

            /// <summary>
            /// The anticipated assignment at field.
            /// </summary>
            [XurrentEnum("anticipated_assignment_at")]
            AnticipatedAssignmentAt,

            /// <summary>
            /// The assigned at field.
            /// </summary>
            [XurrentEnum("assigned_at")]
            AssignedAt,

            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The category field.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// The checked items field.
            /// </summary>
            [XurrentEnum("checked_items")]
            CheckedItems,

            /// <summary>
            /// The completion target at field.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The custom fields field.
            /// </summary>
            [XurrentEnum("custom_fields")]
            CustomFields,

            /// <summary>
            /// The deadline field.
            /// </summary>
            [XurrentEnum("deadline")]
            Deadline,

            /// <summary>
            /// The finished at field.
            /// </summary>
            [XurrentEnum("finished_at")]
            FinishedAt,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The instructions field.
            /// </summary>
            [XurrentEnum("instructions")]
            Instructions,

            /// <summary>
            /// The instructions attachments field.
            /// </summary>
            [XurrentEnum("instructions_attachments", IgnoreInFieldSelection = true)]
            InstructionsAttachments,

            /// <summary>
            /// The manager field.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The note field.
            /// </summary>
            [XurrentEnum("note", IgnoreInFieldSelection = true)]
            Note,

            /// <summary>
            /// The note attachments field.
            /// </summary>
            [XurrentEnum("note_attachments", IgnoreInFieldSelection = true)]
            NoteAttachments,

            /// <summary>
            /// The phase field.
            /// </summary>
            [XurrentEnum("phase")]
            Phase,

            /// <summary>
            /// The planned duration field.
            /// </summary>
            [XurrentEnum("planned_duration")]
            PlannedDuration,

            /// <summary>
            /// The planned effort field.
            /// </summary>
            [XurrentEnum("planned_effort")]
            PlannedEffort,

            /// <summary>
            /// The predecessor field.
            /// </summary>
            [XurrentEnum("predecessor", IgnoreInFieldSelection = true)]
            Predecessor,

            /// <summary>
            /// The project field.
            /// </summary>
            [XurrentEnum("project")]
            Project,

            /// <summary>
            /// The required approvals field.
            /// </summary>
            [XurrentEnum("required_approvals")]
            RequiredApprovals,

            /// <summary>
            /// The resolution duration field.
            /// </summary>
            [XurrentEnum("resolution_duration")]
            ResolutionDuration,

            /// <summary>
            /// The skill pool field.
            /// </summary>
            [XurrentEnum("skill_pool")]
            SkillPool,

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
            /// The status field.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// The subject field.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// The successor field.
            /// </summary>
            [XurrentEnum("successor", IgnoreInFieldSelection = true)]
            Successor,

            /// <summary>
            /// The supplier field.
            /// </summary>
            [XurrentEnum("supplier")]
            Supplier,

            /// <summary>
            /// The supplier request identifier field.
            /// </summary>
            [XurrentEnum("supplier_requestID")]
            SupplierRequestID,

            /// <summary>
            /// The team field.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// The template field.
            /// </summary>
            [XurrentEnum("template")]
            Template,

            /// <summary>
            /// The time spent field.
            /// </summary>
            [XurrentEnum("time_spent", IgnoreInFieldSelection = true)]
            TimeSpent,

            /// <summary>
            /// The time spent effort class field.
            /// </summary>
            [XurrentEnum("time_spent_effort_class", IgnoreInFieldSelection = true)]
            TimeSpentEffortClass,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The urgent field.
            /// </summary>
            [XurrentEnum("urgent")]
            Urgent,

            /// <summary>
            /// The waiting until field.
            /// </summary>
            [XurrentEnum("waiting_until", IgnoreInFieldSelection = true)]
            WaitingUntil,

            /// <summary>
            /// The work hours are 24x7 field.
            /// </summary>
            [XurrentEnum("work_hours_are_24x7")]
            WorkHoursAre24x7
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ProjectTask"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Filters by the completion target date.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by the finished date.
            /// </summary>
            [XurrentEnum("finished_at")]
            FinishedAt,

            /// <summary>
            /// Filters by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Filters by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ProjectTask"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all project tasks that are assigned to the API user.
            /// </summary>
            [XurrentEnum("assigned_to_me")]
            AssignedToMe,

            /// <summary>
            /// Lists all finished project tasks.
            /// </summary>
            [XurrentEnum("finished")]
            Finished,

            /// <summary>
            /// Lists all project tasks managed by the API user.
            /// </summary>
            [XurrentEnum("managed_by_me")]
            ManagedByMe,

            /// <summary>
            /// Lists all open project tasks.
            /// </summary>
            [XurrentEnum("open")]
            Open,

            /// <summary>
            /// Lists all project tasks that are assigned to the API user and have an open status.
            /// </summary>
            [XurrentEnum("open_to_me")]
            OpenToMe
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ProjectTask"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Sorts by the completion target date.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Sorts by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts by the finished date.
            /// </summary>
            [XurrentEnum("finished_at")]
            FinishedAt,

            /// <summary>
            /// Sorts by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private AgileBoard? _agileBoard;
        private AgileBoardColumn? _agileBoardColumn;
        private int? _agileBoardColumnPosition;
        private DateTime? _anticipatedAssignmentAt;
        private DateTime? _assignedAt;
        private List<Attachment>? _attachments;
        private ProjectTaskCategory? _category;
        private ObservableCollection<string>? _checkedItems;
        private DateTime? _completionTargetAt;
        private DateTime? _createdAt;
        private DateTime? _deadline;
        private DateTime? _finishedAt;
        private string? _instructions;
        private ObservableCollection<AttachmentReference>? _instructionsAttachments;
        private AttachmentReferenceWriter? _instructionsAttachmentsWriter;
        private Person? _manager;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private ProjectPhase? _phase;
        private int? _plannedDuration;
        private int? _plannedEffort;
        private ObservableCollection<ProjectTask>? _predecessor;
        private Project? _project;
        private int? _requiredApprovals;
        private int? _resolutionDuration;
        private SkillPool? _skillPool;
        private string? _source;
        private string? _sourceID;
        private DateTime? _startAt;
        private ProjectTaskStatus? _status;
        private string? _subject;
        private ObservableCollection<ProjectTask>? _successor;
        private Organization? _supplier;
        private string? _supplierRequestID;
        private Team? _team;
        private ProjectTaskTemplate? _template;
        private int? _timeSpent;
        private EffortClass? _timeSpentEffortClass;
        private DateTime? _updatedAt;
        private bool? _urgent;
        private DateTime? _waitingUntil;
        private bool? _workHoursAre24x7;

        /// <summary>
        /// Gets or sets the agile board on which the project task is placed.
        /// </summary>
        [XurrentField("agile_board")]
        public AgileBoard? AgileBoard
        {
            get => _agileBoard;
            set => _agileBoard = SetValue("agile_board", _agileBoard, value);
        }

        /// <summary>
        /// Gets or sets the agile board column on which the project task is placed.
        /// </summary>
        [XurrentField("agile_board_column")]
        public AgileBoardColumn? AgileBoardColumn
        {
            get => _agileBoardColumn;
            set => _agileBoardColumn = SetValue("agile_board_column", _agileBoardColumn, value);
        }

        /// <summary>
        /// Gets or sets the position of the project task within the agile board column.
        /// </summary>
        [XurrentField("agile_board_column_position")]
        public int? AgileBoardColumnPosition
        {
            get => _agileBoardColumnPosition;
            set => _agileBoardColumnPosition = SetValue("agile_board_column_position", _agileBoardColumnPosition, value);
        }

        /// <summary>
        /// Gets the anticipated assignment date and time of the project task.
        /// </summary>
        [XurrentField("anticipated_assignment_at")]
        public DateTime? AnticipatedAssignmentAt
        {
            get => _anticipatedAssignmentAt;
            internal set => _anticipatedAssignmentAt = value;
        }

        /// <summary>
        /// Gets the date and time when the project task was assigned.
        /// </summary>
        [XurrentField("assigned_at")]
        public DateTime? AssignedAt
        {
            get => _assignedAt;
            internal set => _assignedAt = value;
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the project task.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the category of the project task.
        /// </summary>
        [XurrentField("category")]
        public ProjectTaskCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets or sets the names of checked checklist items.
        /// </summary>
        [XurrentField("checked_items")]
        public ObservableCollection<string> CheckedItems
        {
            get => GetCollection(ref _checkedItems, OnCheckedItemsChanged);
            set => SetCollection(ref _checkedItems, "checked_items", value, OnCheckedItemsChanged);
        }

        /// <summary>
        /// Gets or sets the completion target date and time of the project task.
        /// </summary>
        [XurrentField("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => _completionTargetAt;
            set => _completionTargetAt = SetValue("completion_target_at", _completionTargetAt, value);
        }

        /// <summary>
        /// Gets the date and time when the project task was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the deadline date and time of the project task.
        /// </summary>
        [XurrentField("deadline")]
        public DateTime? Deadline
        {
            get => _deadline;
            set => _deadline = SetValue("deadline", _deadline, value);
        }

        /// <summary>
        /// Gets the date and time when the project task was finished.
        /// </summary>
        [XurrentField("finished_at")]
        public DateTime? FinishedAt
        {
            get => _finishedAt;
            internal set => _finishedAt = value;
        }

        /// <summary>
        /// Gets or sets the instructions of the project task.
        /// </summary>
        [XurrentField("instructions")]
        public string? Instructions
        {
            get => _instructions;
            set => _instructions = SetValue("instructions", _instructions, value);
        }

        [XurrentField("instructions_attachments")]
        internal ObservableCollection<AttachmentReference> InstructionsAttachmentsCollection
        {
            get => GetCollection(ref _instructionsAttachments, OnInstructionsAttachmentsChanged);
            set => SetCollection(ref _instructionsAttachments, "instructions_attachments", value, OnInstructionsAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the instructions field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter InstructionsAttachments
        {
            get
            {
                _instructionsAttachmentsWriter ??= new AttachmentReferenceWriter(() => InstructionsAttachmentsCollection, c => InstructionsAttachmentsCollection = c);
                return _instructionsAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the manager responsible for the project task.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            internal set => _manager = value;
        }

        /// <summary>
        /// Sets the note of the project task.<br />
        /// This property is write-only.
        /// </summary>
        [XurrentField("note")]
        public string? Note
        {
            get => _note;
            set => _note = SetValue("note", _note, value);
        }

        [XurrentField("note_attachments")]
        internal ObservableCollection<AttachmentReference> NoteAttachmentsCollection
        {
            get => GetCollection(ref _noteAttachments, OnNoteAttachmentsChanged);
            set => SetCollection(ref _noteAttachments, "note_attachments", value, OnNoteAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the note field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter NoteAttachments
        {
            get
            {
                _noteAttachmentsWriter ??= new AttachmentReferenceWriter(() => NoteAttachmentsCollection, c => NoteAttachmentsCollection = c);
                return _noteAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the project phase to which the project task belongs.
        /// </summary>
        [XurrentField("phase")]
        public ProjectPhase? Phase
        {
            get => _phase;
            internal set => _phase = value;
        }

        /// <summary>
        /// Gets or sets the planned duration, in minutes.
        /// </summary>
        [XurrentField("planned_duration")]
        public int? PlannedDuration
        {
            get => _plannedDuration;
            set => _plannedDuration = SetValue("planned_duration", _plannedDuration, value);
        }

        /// <summary>
        /// Gets or sets the planned effort, in minutes.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            set => _plannedEffort = SetValue("planned_effort", _plannedEffort, value);
        }

        /// <summary>
        /// Sets the predecessor project tasks.<br />
        /// This property is write-only.<br />
        /// Retrieve predecessor project tasks via the <see cref="ProjectTaskClient.Predecessors"/> methods.
        /// </summary>
        [XurrentField("predecessor")]
        public ObservableCollection<ProjectTask> Predecessor
        {
            get => GetCollection(ref _predecessor, OnPredecessorChanged);
            set => SetCollection(ref _predecessor, "predecessor", value, OnPredecessorChanged);
        }

        /// <summary>
        /// Gets or sets the project associated with the project task.
        /// </summary>
        [XurrentField("project")]
        public Project? Project
        {
            get => _project;
            set => _project = SetValue("project", _project, value);
        }

        /// <summary>
        /// Gets or sets the number of required approvals for the project task.
        /// </summary>
        [XurrentField("required_approvals")]
        public int? RequiredApprovals
        {
            get => _requiredApprovals;
            set => _requiredApprovals = SetValue("required_approvals", _requiredApprovals, value);
        }

        /// <summary>
        /// Gets the number of minutes it took to complete the project task.
        /// </summary>
        [XurrentField("resolution_duration")]
        public int? ResolutionDuration
        {
            get => _resolutionDuration;
            internal set => _resolutionDuration = value;
        }

        /// <summary>
        /// Gets or sets the skill pool assigned to the project task.
        /// </summary>
        [XurrentField("skill_pool")]
        public SkillPool? SkillPool
        {
            get => _skillPool;
            set => _skillPool = SetValue("skill_pool", _skillPool, value);
        }

        /// <summary>
        /// Gets or sets the source of the project task.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the project task.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the earliest start date and time of the project task.
        /// </summary>
        [XurrentField("start_at")]
        public DateTime? StartAt
        {
            get => _startAt;
            set => _startAt = SetValue("start_at", _startAt, value);
        }

        /// <summary>
        /// Gets or sets the status of the project task.
        /// </summary>
        [XurrentField("status")]
        public ProjectTaskStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the subject of the project task.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Sets the successor project tasks.<br />
        /// This property is write-only.<br />
        /// Retrieve successor project tasks via the <see cref="ProjectTaskClient.Successors"/> methods.
        /// </summary>
        [XurrentField("successor")]
        public ObservableCollection<ProjectTask> Successor
        {
            get => GetCollection(ref _successor, OnSuccessorChanged);
            set => SetCollection(ref _successor, "successor", value, OnSuccessorChanged);
        }

        /// <summary>
        /// Gets or sets the supplier associated with the project task.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the supplier request identifier of the project task.
        /// </summary>
        [XurrentField("supplier_requestID")]
        public string? SupplierRequestID
        {
            get => _supplierRequestID;
            set => _supplierRequestID = SetValue("supplier_requestID", _supplierRequestID, value);
        }

        /// <summary>
        /// Gets or sets the team assigned to the project task.
        /// </summary>
        [XurrentField("team")]
        public Team? Team
        {
            get => _team;
            set => _team = SetValue("team", _team, value);
        }

        /// <summary>
        /// Gets or sets the project task template used to create the project task.
        /// </summary>
        [XurrentField("template")]
        public ProjectTaskTemplate? Template
        {
            get => _template;
            set => _template = SetValue("template", _template, value);
        }

        /// <summary>
        /// Sets the number of minutes spent on the project task.<br />
        /// This property is write-only.
        /// </summary>
        [XurrentField("time_spent")]
        public int? TimeSpent
        {
            get => _timeSpent;
            set => _timeSpent = SetValue("time_spent", _timeSpent, value);
        }

        /// <summary>
        /// Sets the effort class used for time spent registration.<br />
        /// This property is write-only.
        /// </summary>
        [XurrentField("time_spent_effort_class")]
        public EffortClass? TimeSpentEffortClass
        {
            get => _timeSpentEffortClass;
            set => _timeSpentEffortClass = SetValue("time_spent_effort_class", _timeSpentEffortClass, value);
        }

        /// <summary>
        /// Gets the date and time when the project task was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the project task is urgent.
        /// </summary>
        [XurrentField("urgent")]
        public bool? Urgent
        {
            get => _urgent;
            set => _urgent = SetValue("urgent", _urgent, value);
        }

        /// <summary>
        /// Sets the date and time until which the project task is waiting.<br />
        /// This property is write-only.
        /// </summary>
        [XurrentField("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => _waitingUntil;
            set => _waitingUntil = SetValue("waiting_until", _waitingUntil, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether completion targets are calculated using a 24x7 calendar.
        /// </summary>
        [XurrentField("work_hours_are_24x7")]
        public bool? WorkHoursAre24x7
        {
            get => _workHoursAre24x7;
            set => _workHoursAre24x7 = SetValue("work_hours_are_24x7", _workHoursAre24x7, value);
        }

        /// <summary>
        /// Creates a new project task instance.
        /// </summary>
        public ProjectTask()
        {
        }

        /// <summary>
        /// Creates a new project task instance.
        /// </summary>
        /// <param name="id">The unique identifier of the project task.</param>
        public ProjectTask(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new project task instance.
        /// </summary>
        /// <param name="category">The category of the project task.</param>
        /// <param name="project">The project of the project task.</param>
        /// <param name="subject">The subject of the project task.</param>
        public ProjectTask(ProjectTaskCategory category, Project project, string subject)
        {
            _category = SetValue("category", category);
            _project = SetValue("project", project);
            _subject = SetValue("subject", subject);
        }

        private void OnCheckedItemsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<string> collection)
                MarkCollectionChanged(collection, "checked_items");
        }

        private void OnInstructionsAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "instructions_attachments");
        }

        private void OnNoteAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "note_attachments");
        }

        private void OnPredecessorChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<ProjectTask> collection)
                MarkCollectionChanged(collection, "predecessor");
        }

        private void OnSuccessorChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<ProjectTask> collection)
                MarkCollectionChanged(collection, "successor");
        }
    }
}
