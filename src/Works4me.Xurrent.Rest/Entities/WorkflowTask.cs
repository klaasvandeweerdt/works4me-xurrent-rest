using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent workflow task object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class WorkflowTask : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="WorkflowTask"/> object.
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
            /// The failure task field.
            /// </summary>
            [XurrentEnum("failure_task")]
            FailureTask,

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
            /// The impact field.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

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
            /// The member field.
            /// </summary>
            [XurrentEnum("member")]
            Member,

            /// <summary>
            /// The new assignment field.
            /// </summary>
            [XurrentEnum("new_assignment")]
            NewAssignment,

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
            /// The predecessors field.
            /// </summary>
            [XurrentEnum("predecessor", IgnoreInFieldSelection = true)]
            Predecessors,

            /// <summary>
            /// The provider not accountable field.
            /// </summary>
            [XurrentEnum("provider_not_accountable")]
            ProviderNotAccountable,

            /// <summary>
            /// The rejection count field.
            /// </summary>
            [XurrentEnum("rejection_count")]
            RejectionCount,

            /// <summary>
            /// The request field.
            /// </summary>
            [XurrentEnum("request")]
            Request,

            /// <summary>
            /// The request service instance field.
            /// </summary>
            [XurrentEnum("request_service_instance")]
            RequestServiceInstance,

            /// <summary>
            /// The request template field.
            /// </summary>
            [XurrentEnum("request_template")]
            RequestTemplate,

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
            /// The successors field.
            /// </summary>
            [XurrentEnum("successor", IgnoreInFieldSelection = true)]
            Successors,

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
            [XurrentEnum("waiting_until")]
            WaitingUntil,

            /// <summary>
            /// The work hours are 24x7 field.
            /// </summary>
            [XurrentEnum("work_hours_are_24x7")]
            WorkHoursAre24x7,

            /// <summary>
            /// The workflow field.
            /// </summary>
            [XurrentEnum("workflow")]
            Workflow
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="WorkflowTask"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters workflow tasks by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Filters workflow tasks by completion target date and time.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Filters workflow tasks by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters workflow tasks by finish date and time.
            /// </summary>
            [XurrentEnum("finished_at")]
            FinishedAt,

            /// <summary>
            /// Filters workflow tasks by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters workflow tasks by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Filters workflow tasks by assigned member.
            /// </summary>
            [XurrentEnum("member")]
            Member,

            /// <summary>
            /// Filters workflow tasks by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters workflow tasks by identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters workflow tasks by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters workflow tasks by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Filters workflow tasks by team.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// Filters workflow tasks by workflow task template.
            /// </summary>
            [XurrentEnum("template")]
            Template,

            /// <summary>
            /// Filters workflow tasks by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// Filters workflow tasks by workflow.
            /// </summary>
            [XurrentEnum("workflow")]
            Workflow
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="WorkflowTask"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all approval tasks that are assigned to the API user and are not in the Registered status.
            /// </summary>
            [XurrentEnum("approval_by_me")]
            ApprovalByMe,

            /// <summary>
            /// Lists all tasks that are assigned to the API user.
            /// </summary>
            [XurrentEnum("assigned_to_me")]
            AssignedToMe,

            /// <summary>
            /// Lists all tasks that are assigned to one of the teams the API user is a member of.
            /// </summary>
            [XurrentEnum("assigned_to_my_team")]
            AssignedToMyTeam,

            /// <summary>
            /// Lists all finished tasks.
            /// </summary>
            [XurrentEnum("finished")]
            Finished,

            /// <summary>
            /// Lists all tasks that are part of a workflow managed by the API user.
            /// </summary>
            [XurrentEnum("managed_by_me")]
            ManagedByMe,

            /// <summary>
            /// Lists all open tasks.
            /// </summary>
            [XurrentEnum("open")]
            Open
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="WorkflowTask"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts workflow tasks by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Sorts workflow tasks by completion target date and time.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Sorts workflow tasks by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts workflow tasks by finish date and time.
            /// </summary>
            [XurrentEnum("finished_at")]
            FinishedAt,

            /// <summary>
            /// Sorts workflow tasks by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts workflow tasks by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Sorts workflow tasks by assigned member.
            /// </summary>
            [XurrentEnum("member")]
            Member,

            /// <summary>
            /// Sorts workflow tasks by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts workflow tasks by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts workflow tasks by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts workflow tasks by team.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// Sorts workflow tasks by the date and time of their last update.
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
        private WorkflowTaskCategory? _category;
        private ObservableCollection<string>? _checkedItems;
        private DateTime? _completionTargetAt;
        private DateTime? _createdAt;
        private WorkflowTask? _failureTask;
        private DateTime? _finishedAt;
        private WorkflowImpact? _impact;
        private string? _instructions;
        private ObservableCollection<AttachmentReference>? _instructionsAttachments;
        private AttachmentReferenceWriter? _instructionsAttachmentsWriter;
        private Person? _manager;
        private Person? _member;
        private bool? _newAssignment;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private WorkflowPhase? _phase;
        private int? _plannedDuration;
        private int? _plannedEffort;
        private ObservableCollection<WorkflowTask>? _predecessors;
        private bool? _providerNotAccountable;
        private int? _rejectionCount;
        private Request? _request;
        private ServiceInstance? _requestServiceInstance;
        private RequestTemplate? _requestTemplate;
        private int? _requiredApprovals;
        private int? _resolutionDuration;
        private SkillPool? _skillPool;
        private string? _source;
        private string? _sourceID;
        private DateTime? _startAt;
        private WorkflowTaskStatus? _status;
        private string? _subject;
        private ObservableCollection<WorkflowTask>? _successors;
        private Organization? _supplier;
        private string? _supplierRequestID;
        private Team? _team;
        private WorkflowTaskTemplate? _template;
        private int? _timeSpent;
        private EffortClass? _timeSpentEffortClass;
        private DateTime? _updatedAt;
        private bool? _urgent;
        private DateTime? _waitingUntil;
        private bool? _workHoursAre24x7;
        private Workflow? _workflow;

        /// <summary>
        /// Gets or sets the agile board on which the workflow task is placed.
        /// </summary>
        [XurrentField("agile_board")]
        public AgileBoard? AgileBoard
        {
            get => _agileBoard;
            set => _agileBoard = SetValue("agile_board", _agileBoard, value);
        }

        /// <summary>
        /// Gets or sets the agile board column on which the workflow task is placed.
        /// </summary>
        [XurrentField("agile_board_column")]
        public AgileBoardColumn? AgileBoardColumn
        {
            get => _agileBoardColumn;
            set => _agileBoardColumn = SetValue("agile_board_column", _agileBoardColumn, value);
        }

        /// <summary>
        /// Gets or sets the position of the workflow task within the agile board column.
        /// </summary>
        [XurrentField("agile_board_column_position")]
        public int? AgileBoardColumnPosition
        {
            get => _agileBoardColumnPosition;
            set => _agileBoardColumnPosition = SetValue("agile_board_column_position", _agileBoardColumnPosition, value);
        }

        /// <summary>
        /// Gets the date and time at which the workflow task is expected to be assigned.
        /// </summary>
        [XurrentField("anticipated_assignment_at")]
        public DateTime? AnticipatedAssignmentAt
        {
            get => _anticipatedAssignmentAt;
            internal set => _anticipatedAssignmentAt = value;
        }

        /// <summary>
        /// Gets the date and time at which the workflow task was assigned.
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
        /// Gets the attachments associated with the workflow task.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the category of the workflow task.
        /// </summary>
        [XurrentField("category")]
        public WorkflowTaskCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets or sets the checked checklist item names for the workflow task.
        /// </summary>
        [XurrentField("checked_items")]
        public ObservableCollection<string> CheckedItems
        {
            get => GetCollection(ref _checkedItems, OnCheckedItemsChanged);
            set => SetCollection(ref _checkedItems, "checked_items", value, OnCheckedItemsChanged);
        }

        /// <summary>
        /// Gets the target date and time for completion of the workflow task.
        /// </summary>
        [XurrentField("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => _completionTargetAt;
            internal set => _completionTargetAt = value;
        }

        /// <summary>
        /// Gets the date and time at which the workflow task was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the workflow task that is assigned when this task is failed or rejected.
        /// </summary>
        [XurrentField("failure_task")]
        public WorkflowTask? FailureTask
        {
            get => _failureTask;
            set => _failureTask = SetValue("failure_task", _failureTask, value);
        }

        /// <summary>
        /// Gets the date and time at which the workflow task was finished.
        /// </summary>
        [XurrentField("finished_at")]
        public DateTime? FinishedAt
        {
            get => _finishedAt;
            internal set => _finishedAt = value;
        }

        /// <summary>
        /// Gets or sets the impact of the workflow task.
        /// </summary>
        [XurrentField("impact")]
        public WorkflowImpact? Impact
        {
            get => _impact;
            set => _impact = SetValue("impact", _impact, value);
        }

        /// <summary>
        /// Gets or sets the instructions of the workflow task.
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
        /// Gets or sets the manager responsible for the workflow task.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Gets or sets the member to whom the workflow task is assigned.
        /// </summary>
        [XurrentField("member")]
        public Person? Member
        {
            get => _member;
            set => _member = SetValue("member", _member, value);
        }

        /// <summary>
        /// Gets a value indicating whether the workflow task represents a new assignment.
        /// </summary>
        [XurrentField("new_assignment")]
        public bool? NewAssignment
        {
            get => _newAssignment;
            internal set => _newAssignment = value;
        }

        /// <summary>
        /// Gets or sets the note of the workflow task.<br />
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
        /// Gets or sets the workflow phase to which the workflow task belongs.
        /// </summary>
        [XurrentField("phase")]
        public WorkflowPhase? Phase
        {
            get => _phase;
            set => _phase = SetValue("phase", _phase, value);
        }

        /// <summary>
        /// Gets or sets the planned duration of the workflow task in minutes.
        /// </summary>
        [XurrentField("planned_duration")]
        public int? PlannedDuration
        {
            get => _plannedDuration;
            set => _plannedDuration = SetValue("planned_duration", _plannedDuration, value);
        }

        /// <summary>
        /// Gets or sets the planned effort of the workflow task in minutes.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            set => _plannedEffort = SetValue("planned_effort", _plannedEffort, value);
        }

        /// <summary>
        /// Sets the predecessor workflow tasks.<br />
        /// This property is write-only.<br />
        /// Retrieve predecessor workflow tasks via the <see cref="WorkflowTaskClient.Predecessors"/> methods.
        /// </summary>
        [XurrentField("predecessor")]
        public ObservableCollection<WorkflowTask> Predecessors
        {
            get => GetCollection(ref _predecessors, OnPredecessorsChanged);
            set => SetCollection(ref _predecessors, "predecessor", value, OnPredecessorsChanged);
        }

        /// <summary>
        /// Gets a value indicating whether the provider is not accountable for the workflow task.
        /// </summary>
        [XurrentField("provider_not_accountable")]
        public bool? ProviderNotAccountable
        {
            get => _providerNotAccountable;
            internal set => _providerNotAccountable = value;
        }

        /// <summary>
        /// Gets the number of times the workflow task was rejected.
        /// </summary>
        [XurrentField("rejection_count")]
        public int? RejectionCount
        {
            get => _rejectionCount;
            internal set => _rejectionCount = value;
        }

        /// <summary>
        /// Gets or sets the request associated with the workflow task.
        /// </summary>
        [XurrentField("request")]
        public Request? Request
        {
            get => _request;
            set => _request = SetValue("request", _request, value);
        }

        /// <summary>
        /// Gets or sets the service instance used when generating a request from the workflow task.
        /// </summary>
        [XurrentField("request_service_instance")]
        public ServiceInstance? RequestServiceInstance
        {
            get => _requestServiceInstance;
            set => _requestServiceInstance = SetValue("request_service_instance", _requestServiceInstance, value);
        }

        /// <summary>
        /// Gets or sets the request template used to generate a request from the workflow task.
        /// </summary>
        [XurrentField("request_template")]
        public RequestTemplate? RequestTemplate
        {
            get => _requestTemplate;
            set => _requestTemplate = SetValue("request_template", _requestTemplate, value);
        }

        /// <summary>
        /// Gets or sets the number of required approvals for the workflow task.
        /// </summary>
        [XurrentField("required_approvals")]
        public int? RequiredApprovals
        {
            get => _requiredApprovals;
            set => _requiredApprovals = SetValue("required_approvals", _requiredApprovals, value);
        }

        /// <summary>
        /// Gets the resolution duration of the workflow task in minutes.
        /// </summary>
        [XurrentField("resolution_duration")]
        public int? ResolutionDuration
        {
            get => _resolutionDuration;
            internal set => _resolutionDuration = value;
        }

        /// <summary>
        /// Gets or sets the skill pool to which the workflow task is assigned.
        /// </summary>
        [XurrentField("skill_pool")]
        public SkillPool? SkillPool
        {
            get => _skillPool;
            set => _skillPool = SetValue("skill_pool", _skillPool, value);
        }

        /// <summary>
        /// Gets or sets the source of the workflow task.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the workflow task in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the date and time at which the workflow task starts.
        /// </summary>
        [XurrentField("start_at")]
        public DateTime? StartAt
        {
            get => _startAt;
            set => _startAt = SetValue("start_at", _startAt, value);
        }

        /// <summary>
        /// Gets or sets the status of the workflow task.
        /// </summary>
        [XurrentField("status")]
        public WorkflowTaskStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the subject of the workflow task.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Sets the successor workflow tasks.<br />
        /// This property is write-only.<br />
        /// Retrieve successor workflow tasks via the <see cref="WorkflowTaskClient.Successors"/> methods.
        /// </summary>
        [XurrentField("successor")]
        public ObservableCollection<WorkflowTask> Successors
        {
            get => GetCollection(ref _successors, OnSuccessorsChanged);
            set => SetCollection(ref _successors, "successor", value, OnSuccessorsChanged);
        }

        /// <summary>
        /// Gets or sets the supplier organization for the workflow task.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the supplier request identifier of the workflow task.
        /// </summary>
        [XurrentField("supplier_requestID")]
        public string? SupplierRequestID
        {
            get => _supplierRequestID;
            set => _supplierRequestID = SetValue("supplier_requestID", _supplierRequestID, value);
        }

        /// <summary>
        /// Gets or sets the team to which the workflow task is assigned.
        /// </summary>
        [XurrentField("team")]
        public Team? Team
        {
            get => _team;
            set => _team = SetValue("team", _team, value);
        }

        /// <summary>
        /// Gets or sets the workflow task template used to create the workflow task.
        /// </summary>
        [XurrentField("template")]
        public WorkflowTaskTemplate? Template
        {
            get => _template;
            set => _template = SetValue("template", _template, value);
        }

        /// <summary>
        /// Sets the time spent on the workflow task.
        /// </summary>
        [XurrentField("time_spent")]
        public int? TimeSpent
        {
            get => _timeSpent;
            set => _timeSpent = SetValue("time_spent", _timeSpent, value);
        }

        /// <summary>
        /// Sets the effort class used for time spent on the workflow task.
        /// </summary>
        [XurrentField("time_spent_effort_class")]
        public EffortClass? TimeSpentEffortClass
        {
            get => _timeSpentEffortClass;
            set => _timeSpentEffortClass = SetValue("time_spent_effort_class", _timeSpentEffortClass, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the workflow task.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the workflow task is urgent.
        /// </summary>
        [XurrentField("urgent")]
        public bool? Urgent
        {
            get => _urgent;
            set => _urgent = SetValue("urgent", _urgent, value);
        }

        /// <summary>
        /// Gets or sets the date and time until which the workflow task remains waiting.
        /// </summary>
        [XurrentField("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => _waitingUntil;
            set => _waitingUntil = SetValue("waiting_until", _waitingUntil, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the workflow task uses 24x7 work hours.
        /// </summary>
        [XurrentField("work_hours_are_24x7")]
        public bool? WorkHoursAre24x7
        {
            get => _workHoursAre24x7;
            set => _workHoursAre24x7 = SetValue("work_hours_are_24x7", _workHoursAre24x7, value);
        }

        /// <summary>
        /// Gets or sets the workflow to which the workflow task belongs.
        /// </summary>
        [XurrentField("workflow")]
        public Workflow? Workflow
        {
            get => _workflow;
            set => _workflow = SetValue("workflow", _workflow, value);
        }

        /// <summary>
        /// Creates a new workflow task instance.
        /// </summary>
        public WorkflowTask()
        {
        }

        /// <summary>
        /// Creates a new workflow task instance.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow task.</param>
        public WorkflowTask(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new workflow task instance.
        /// </summary>
        /// <param name="category">The category of the workflow task.</param>
        /// <param name="subject">The subject of the workflow task.</param>
        /// <param name="workflow">The workflow of the workflow task.</param>
        public WorkflowTask(WorkflowTaskCategory category, string subject, Workflow workflow)
        {
            _category = SetValue("category", category);
            _subject = SetValue("subject", subject);
            _workflow = SetValue("workflow", workflow);
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

        private void OnPredecessorsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<WorkflowTask> collection)
                MarkCollectionChanged(collection, "predecessor");
        }

        private void OnSuccessorsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<WorkflowTask> collection)
                MarkCollectionChanged(collection, "successor");
        }
    }
}
