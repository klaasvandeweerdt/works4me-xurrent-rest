using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent problem object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Problem : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Problem"/> object.
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
            /// The analysis target at field.
            /// </summary>
            [XurrentEnum("analysis_target_at")]
            AnalysisTargetAt,

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
            /// The knowledge article field.
            /// </summary>
            [XurrentEnum("knowledge_article")]
            KnowledgeArticle,

            /// <summary>
            /// The known error field.
            /// </summary>
            [XurrentEnum("known_error")]
            KnownError,

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
            /// The planned effort field.
            /// </summary>
            [XurrentEnum("planned_effort")]
            PlannedEffort,

            /// <summary>
            /// The product backlog field.
            /// </summary>
            [XurrentEnum("product_backlog")]
            ProductBacklog,

            /// <summary>
            /// The product backlog position field.
            /// </summary>
            [XurrentEnum("product_backlog_position")]
            ProductBacklogPosition,

            /// <summary>
            /// The project field.
            /// </summary>
            [XurrentEnum("project")]
            Project,

            /// <summary>
            /// The resolution duration field.
            /// </summary>
            [XurrentEnum("resolution_duration")]
            ResolutionDuration,

            /// <summary>
            /// The service field.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// The solved at field.
            /// </summary>
            [XurrentEnum("solved_at")]
            SolvedAt,

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
            /// The user interface extension field.
            /// </summary>
            [XurrentEnum("ui_extension")]
            UiExtension,

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
            /// The workaround field.
            /// </summary>
            [XurrentEnum("workaround")]
            Workaround,

            /// <summary>
            /// The workaround attachments field.
            /// </summary>
            [XurrentEnum("workaround_attachments", IgnoreInFieldSelection = true)]
            WorkaroundAttachments,

            /// <summary>
            /// The workflow field.
            /// </summary>
            [XurrentEnum("workflow")]
            Workflow
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Problem"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters problems by analysis target date and time.
            /// </summary>
            [XurrentEnum("analysis_target_at")]
            AnalysisTargetAt,

            /// <summary>
            /// Filters problems by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters problems by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters problems by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Filters problems by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Filters problems by solved date and time.
            /// </summary>
            [XurrentEnum("solved_at")]
            SolvedAt,

            /// <summary>
            /// Filters problems by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters problems by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters problems by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters problems by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Filters problems by last updated date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Problem"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all active problems.
            /// </summary>
            [XurrentEnum("active")]
            Active,

            /// <summary>
            /// Lists all problems that are assigned to the API user.
            /// </summary>
            [XurrentEnum("assigned_to_me")]
            AssignedToMe,

            /// <summary>
            /// Lists all problems that are assigned to one of the teams that the API user is a member of.
            /// </summary>
            [XurrentEnum("assigned_to_my_team")]
            AssignedToMyTeam,

            /// <summary>
            /// Lists all known error problems.
            /// </summary>
            [XurrentEnum("known_errors")]
            KnownErrors,

            /// <summary>
            /// Lists all problems managed by the API user.
            /// </summary>
            [XurrentEnum("managed_by_me")]
            ManagedByMe,

            /// <summary>
            /// Lists all progress halted problems.
            /// </summary>
            [XurrentEnum("progress_halted")]
            ProgressHalted,

            /// <summary>
            /// Lists all solved problems.
            /// </summary>
            [XurrentEnum("solved")]
            Solved
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Problem"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts problems by analysis target date and time.
            /// </summary>
            [XurrentEnum("analysis_target_at")]
            AnalysisTargetAt,

            /// <summary>
            /// Sorts problems by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts problems by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts problems by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Sorts problems by known error status.
            /// </summary>
            [XurrentEnum("known_error")]
            KnownError,

            /// <summary>
            /// Sorts problems by member.
            /// </summary>
            [XurrentEnum("member")]
            Member,

            /// <summary>
            /// Sorts problems by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Sorts problems by solved date and time.
            /// </summary>
            [XurrentEnum("solved_at")]
            SolvedAt,

            /// <summary>
            /// Sorts problems by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts problems by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts problems by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts problems by team.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// Sorts problems by last updated date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private AgileBoard? _agileBoard;
        private AgileBoardColumn? _agileBoardColumn;
        private int? _agileBoardColumnPosition;
        private DateTime? _analysisTargetAt;
        private List<Attachment>? _attachments;
        private ProblemCategory? _category;
        private DateTime? _createdAt;
        private ProblemImpact? _impact;
        private KnowledgeArticle? _knowledgeArticle;
        private bool? _knownError;
        private Person? _manager;
        private Person? _member;
        private bool? _newAssignment;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private int? _plannedEffort;
        private ProductBacklog? _productBacklog;
        private int? _productBacklogPosition;
        private Project? _project;
        private int? _resolutionDuration;
        private Service? _service;
        private DateTime? _solvedAt;
        private string? _source;
        private string? _sourceID;
        private ProblemStatus? _status;
        private string? _subject;
        private Organization? _supplier;
        private string? _supplierRequestID;
        private Team? _team;
        private int? _timeSpent;
        private EffortClass? _timeSpentEffortClass;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;
        private bool? _urgent;
        private DateTime? _waitingUntil;
        private string? _workaround;
        private ObservableCollection<AttachmentReference>? _workaroundAttachments;
        private AttachmentReferenceWriter? _workaroundAttachmentsWriter;
        private Workflow? _workflow;

        /// <summary>
        /// Gets or sets the agile board on which the problem is placed.
        /// </summary>
        [XurrentField("agile_board")]
        public AgileBoard? AgileBoard
        {
            get => _agileBoard;
            set => _agileBoard = SetValue("agile_board", _agileBoard, value);
        }

        /// <summary>
        /// Gets or sets the agile board column on which the problem is placed.
        /// </summary>
        [XurrentField("agile_board_column")]
        public AgileBoardColumn? AgileBoardColumn
        {
            get => _agileBoardColumn;
            set => _agileBoardColumn = SetValue("agile_board_column", _agileBoardColumn, value);
        }

        /// <summary>
        /// Gets or sets the position of the problem within the agile board column.
        /// </summary>
        [XurrentField("agile_board_column_position")]
        public int? AgileBoardColumnPosition
        {
            get => _agileBoardColumnPosition;
            set => _agileBoardColumnPosition = SetValue("agile_board_column_position", _agileBoardColumnPosition, value);
        }

        /// <summary>
        /// Gets or sets the analysis target date and time of the problem.
        /// </summary>
        [XurrentField("analysis_target_at")]
        public DateTime? AnalysisTargetAt
        {
            get => _analysisTargetAt;
            set => _analysisTargetAt = SetValue("analysis_target_at", _analysisTargetAt, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the category of the problem.
        /// </summary>
        [XurrentField("category")]
        public ProblemCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets the date and time when the problem was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the impact of the problem.
        /// </summary>
        [XurrentField("impact")]
        public ProblemImpact? Impact
        {
            get => _impact;
            set => _impact = SetValue("impact", _impact, value);
        }

        /// <summary>
        /// Gets or sets the knowledge article associated with the problem.
        /// </summary>
        [XurrentField("knowledge_article")]
        public KnowledgeArticle? KnowledgeArticle
        {
            get => _knowledgeArticle;
            set => _knowledgeArticle = SetValue("knowledge_article", _knowledgeArticle, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the problem is a known error.
        /// </summary>
        [XurrentField("known_error")]
        public bool? KnownError
        {
            get => _knownError;
            set => _knownError = SetValue("known_error", _knownError, value);
        }

        /// <summary>
        /// Gets or sets the manager responsible for the problem.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Gets or sets the member to whom the problem is assigned.
        /// </summary>
        [XurrentField("member")]
        public Person? Member
        {
            get => _member;
            set => _member = SetValue("member", _member, value);
        }

        /// <summary>
        /// Gets a value indicating whether the problem has a new assignment.
        /// </summary>
        [XurrentField("new_assignment")]
        public bool? NewAssignment
        {
            get => _newAssignment;
            internal set => _newAssignment = value;
        }

        /// <summary>
        /// Sets the note of the problem.<br />
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
        /// Gets or sets the planned effort, in minutes.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            set => _plannedEffort = SetValue("planned_effort", _plannedEffort, value);
        }

        /// <summary>
        /// Gets or sets the product backlog on which the problem is placed.
        /// </summary>
        [XurrentField("product_backlog")]
        public ProductBacklog? ProductBacklog
        {
            get => _productBacklog;
            set => _productBacklog = SetValue("product_backlog", _productBacklog, value);
        }

        /// <summary>
        /// Gets or sets the position of the problem on the product backlog.
        /// </summary>
        [XurrentField("product_backlog_position")]
        public int? ProductBacklogPosition
        {
            get => _productBacklogPosition;
            set => _productBacklogPosition = SetValue("product_backlog_position", _productBacklogPosition, value);
        }

        /// <summary>
        /// Gets or sets the project associated with the problem.
        /// </summary>
        [XurrentField("project")]
        public Project? Project
        {
            get => _project;
            set => _project = SetValue("project", _project, value);
        }

        /// <summary>
        /// Gets the number of minutes it took to complete the problem.
        /// </summary>
        [XurrentField("resolution_duration")]
        public int? ResolutionDuration
        {
            get => _resolutionDuration;
            set => _resolutionDuration = SetValue("resolution_duration", _resolutionDuration, value);
        }

        /// <summary>
        /// Gets or sets the service associated with the problem.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets the date and time when the problem was solved.
        /// </summary>
        [XurrentField("solved_at")]
        public DateTime? SolvedAt
        {
            get => _solvedAt;
            internal set => _solvedAt = value;
        }

        /// <summary>
        /// Gets or sets the source of the problem.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the problem.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the status of the problem.
        /// </summary>
        [XurrentField("status")]
        public ProblemStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the subject of the problem.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets or sets the supplier associated with the problem.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the supplier request identifier of the problem.
        /// </summary>
        [XurrentField("supplier_requestID")]
        public string? SupplierRequestID
        {
            get => _supplierRequestID;
            set => _supplierRequestID = SetValue("supplier_requestID", _supplierRequestID, value);
        }

        /// <summary>
        /// Gets or sets the team to which the problem is assigned.
        /// </summary>
        [XurrentField("team")]
        public Team? Team
        {
            get => _team;
            set => _team = SetValue("team", _team, value);
        }

        /// <summary>
        /// Sets the number of minutes spent on the problem.<br />
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
        /// Gets the UI extension associated with the problem.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time when the problem was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the problem is urgent.
        /// </summary>
        [XurrentField("urgent")]
        public bool? Urgent
        {
            get => _urgent;
            set => _urgent = SetValue("urgent", _urgent, value);
        }

        /// <summary>
        /// Gets or sets the date and time until which the problem is waiting.
        /// </summary>
        [XurrentField("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => _waitingUntil;
            set => _waitingUntil = SetValue("waiting_until", _waitingUntil, value);
        }

        /// <summary>
        /// Gets or sets the workaround of the problem.
        /// </summary>
        [XurrentField("workaround")]
        public string? Workaround
        {
            get => _workaround;
            set => _workaround = SetValue("workaround", _workaround, value);
        }

        [XurrentField("workaround_attachments")]
        internal ObservableCollection<AttachmentReference> WorkaroundAttachmentsCollection
        {
            get => GetCollection(ref _workaroundAttachments, OnWorkaroundAttachmentsChanged);
            set => SetCollection(ref _workaroundAttachments, "workaround_attachments", value, OnWorkaroundAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the workaround field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter WorkaroundAttachments
        {
            get
            {
                _workaroundAttachmentsWriter ??= new AttachmentReferenceWriter(() => WorkaroundAttachmentsCollection, c => WorkaroundAttachmentsCollection = c);
                return _workaroundAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the workflow associated with the problem.
        /// </summary>
        [XurrentField("workflow")]
        public Workflow? Workflow
        {
            get => _workflow;
            set => _workflow = SetValue("workflow", _workflow, value);
        }

        /// <summary>
        /// Creates a new problem instance.
        /// </summary>
        public Problem()
        {
        }

        /// <summary>
        /// Creates a new problem instance.
        /// </summary>
        /// <param name="id">The unique identifier of the problem.</param>
        public Problem(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new problem instance.
        /// </summary>
        /// <param name="impact">The impact of the problem.</param>
        /// <param name="manager">The manager of the problem.</param>
        /// <param name="service">The service of the problem.</param>
        /// <param name="subject">The subject of the problem.</param>
        /// <param name="team">The team of the problem.</param>
        public Problem(ProblemImpact impact, Person manager, Service service, string subject, Team team)
        {
            _impact = SetValue("impact", impact);
            _manager = SetValue("manager", manager);
            _service = SetValue("service", service);
            _subject = SetValue("subject", subject);
            _team = SetValue("team", team);
        }

        private void OnNoteAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "note_attachments");
        }

        private void OnWorkaroundAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "workaround_attachments");
        }
    }
}
