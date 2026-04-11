using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent request object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Request : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Request"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The addressed field.
            /// </summary>
            [XurrentEnum("addressed")]
            Addressed,

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
            /// The assignment count field.
            /// </summary>
            [XurrentEnum("assignment_count")]
            AssignmentCount,

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
            /// The closure code field.
            /// </summary>
            [XurrentEnum("closure_code")]
            ClosureCode,

            /// <summary>
            /// The completed at field.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// The completion reason field.
            /// </summary>
            [XurrentEnum("completion_reason")]
            CompletionReason,

            /// <summary>
            /// The configuration item field.
            /// </summary>
            [XurrentEnum("ci", IgnoreInFieldSelection = true)]
            ConfigurationItem,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The created by field.
            /// </summary>
            [XurrentEnum("created_by")]
            CreatedBy,

            /// <summary>
            /// The custom fields field.
            /// </summary>
            [XurrentEnum("custom_fields")]
            CustomFields,

            /// <summary>
            /// The desired completion at field.
            /// </summary>
            [XurrentEnum("desired_completion_at")]
            DesiredCompletionAt,

            /// <summary>
            /// The downtime end at field.
            /// </summary>
            [XurrentEnum("downtime_end_at")]
            DowntimeEndAt,

            /// <summary>
            /// The downtime start at field.
            /// </summary>
            [XurrentEnum("downtime_start_at")]
            DowntimeStartAt,

            /// <summary>
            /// The feedback field.
            /// </summary>
            [XurrentEnum("feedback")]
            Feedback,

            /// <summary>
            /// The feedback on knowledge article field.
            /// </summary>
            [XurrentEnum("feedback_on_knowledge_article")]
            FeedbackOnKnowledgeArticle,

            /// <summary>
            /// The grouped into field.
            /// </summary>
            [XurrentEnum("grouped_into")]
            GroupedInto,

            /// <summary>
            /// The grouping field.
            /// </summary>
            [XurrentEnum("grouping")]
            Grouping,

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
            /// The internal note field.
            /// </summary>
            [XurrentEnum("internal_note", IgnoreInFieldSelection = true)]
            InternalNote,

            /// <summary>
            /// The internal note attachments field.
            /// </summary>
            [XurrentEnum("internal_note_attachments", IgnoreInFieldSelection = true)]
            InternalNoteAttachments,

            /// <summary>
            /// The knowledge article field.
            /// </summary>
            [XurrentEnum("knowledge_article")]
            KnowledgeArticle,

            /// <summary>
            /// The major incident status field.
            /// </summary>
            [XurrentEnum("major_incident_status")]
            MajorIncidentStatus,

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
            /// The next target at field.
            /// </summary>
            [XurrentEnum("next_target_at")]
            NextTargetAt,

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
            /// The organization field.
            /// </summary>
            [XurrentEnum("organization")]
            Organization,

            /// <summary>
            /// The planned effort field.
            /// </summary>
            [XurrentEnum("planned_effort")]
            PlannedEffort,

            /// <summary>
            /// The problem field.
            /// </summary>
            [XurrentEnum("problem")]
            Problem,

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
            /// The provider not accountable field.
            /// </summary>
            [XurrentEnum("provider_not_accountable")]
            ProviderNotAccountable,

            /// <summary>
            /// The provider was not accountable field.
            /// </summary>
            [XurrentEnum("provider_was_not_accountable")]
            ProviderWasNotAccountable,

            /// <summary>
            /// The reopen count field.
            /// </summary>
            [XurrentEnum("reopen_count")]
            ReopenCount,

            /// <summary>
            /// The requested by field.
            /// </summary>
            [XurrentEnum("requested_by")]
            RequestedBy,

            /// <summary>
            /// The requested for field.
            /// </summary>
            [XurrentEnum("requested_for")]
            RequestedFor,

            /// <summary>
            /// The requester resolution target at field.
            /// </summary>
            [XurrentEnum("requester_resolution_target_at")]
            RequesterResolutionTargetAt,

            /// <summary>
            /// The reservation field.
            /// </summary>
            [XurrentEnum("reservation")]
            Reservation,

            /// <summary>
            /// The resolution duration field.
            /// </summary>
            [XurrentEnum("resolution_duration")]
            ResolutionDuration,

            /// <summary>
            /// The resolution target at field.
            /// </summary>
            [XurrentEnum("resolution_target_at")]
            ResolutionTargetAt,

            /// <summary>
            /// The response target at field.
            /// </summary>
            [XurrentEnum("response_target_at")]
            ResponseTargetAt,

            /// <summary>
            /// The reviewed field.
            /// </summary>
            [XurrentEnum("reviewed")]
            Reviewed,

            /// <summary>
            /// The rfc type field.
            /// </summary>
            [XurrentEnum("rfc_type")]
            RfcType,

            /// <summary>
            /// The satisfaction field.
            /// </summary>
            [XurrentEnum("satisfaction")]
            Satisfaction,

            /// <summary>
            /// The service instance field.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

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
            /// The summary field.
            /// </summary>
            [XurrentEnum("summary")]
            Summary,

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
            /// The support domain field.
            /// </summary>
            [XurrentEnum("support_domain", IgnoreInFieldSelection = true)]
            SupportDomain,

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
            /// The workflow field.
            /// </summary>
            [XurrentEnum("workflow")]
            Workflow,

            /// <summary>
            /// The workflow task field.
            /// </summary>
            [XurrentEnum("task")]
            WorkflowTask
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Request"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Filters by the completion date.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by the creator.
            /// </summary>
            [XurrentEnum("created_by")]
            CreatedBy,

            /// <summary>
            /// Filters by the request into which the request is grouped.
            /// </summary>
            [XurrentEnum("grouped_into")]
            GroupedInto,

            /// <summary>
            /// Filters by the grouping.
            /// </summary>
            [XurrentEnum("grouping")]
            Grouping,

            /// <summary>
            /// Filters by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Filters by knowledge article.
            /// </summary>
            [XurrentEnum("knowledge_article")]
            KnowledgeArticle,

            /// <summary>
            /// Filters by major incident status.
            /// </summary>
            [XurrentEnum("major_incident_status")]
            MajorIncidentStatus,

            /// <summary>
            /// Filters by member.
            /// </summary>
            [XurrentEnum("member")]
            Member,

            /// <summary>
            /// Filters by the next target date.
            /// </summary>
            [XurrentEnum("next_target_at")]
            NextTargetAt,

            /// <summary>
            /// Filters by organization.
            /// </summary>
            [XurrentEnum("organization")]
            Organization,

            /// <summary>
            /// Filters by the requesting person.
            /// </summary>
            [XurrentEnum("requested_by")]
            RequestedBy,

            /// <summary>
            /// Filters by the person for whom the request was made.
            /// </summary>
            [XurrentEnum("requested_for")]
            RequestedFor,

            /// <summary>
            /// Filters by service instance.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

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
            /// Filters by the supplier request identifier.
            /// </summary>
            [XurrentEnum("supplier_requestID")]
            SupplierRequestID,

            /// <summary>
            /// Filters by team.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// Filters by request template.
            /// </summary>
            [XurrentEnum("template")]
            Template,

            /// <summary>
            /// Filters by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// Filters by workflow.
            /// </summary>
            [XurrentEnum("workflow")]
            Workflow
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Request"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all requests that are assigned to the API user.
            /// </summary>
            [XurrentEnum("assigned_to_me")]
            AssignedToMe,

            /// <summary>
            /// Lists all requests that are assigned to one of the teams the API user is a member of.
            /// </summary>
            [XurrentEnum("assigned_to_my_team")]
            AssignedToMyTeam,

            /// <summary>
            /// Lists all completed requests.
            /// </summary>
            [XurrentEnum("completed")]
            Completed,

            /// <summary>
            /// Lists all open requests.
            /// </summary>
            [XurrentEnum("open")]
            Open,

            /// <summary>
            /// Lists all requests completed less than six months ago that are linked to a service instance of a service for which the API user is the problem manager.
            /// </summary>
            [XurrentEnum("problem_management_review")]
            ProblemManagementReview,

            /// <summary>
            /// Lists all requests that are requested by or requested for the API user.
            /// </summary>
            [XurrentEnum("requested_by_or_for_me")]
            RequestedByOrForMe,

            /// <summary>
            /// Lists all requests for which one of the API user's teams can be held accountable.
            /// </summary>
            [XurrentEnum("sla_accountability")]
            SlaAccountability,

            /// <summary>
            /// Lists all requests that are requested by the API user and have the status Waiting for Customer.
            /// </summary>
            [XurrentEnum("waiting_for_me")]
            WaitingForMe
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Request"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Sorts by the completion date.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Sorts by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Sorts by member.
            /// </summary>
            [XurrentEnum("member")]
            Member,

            /// <summary>
            /// Sorts by the next target date.
            /// </summary>
            [XurrentEnum("next_target_at")]
            NextTargetAt,

            /// <summary>
            /// Sorts by service instance.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

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
            /// Sorts by team.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// Sorts by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private bool? _addressed;
        private AgileBoard? _agileBoard;
        private AgileBoardColumn? _agileBoardColumn;
        private int? _agileBoardColumnPosition;
        private int? _assignmentCount;
        private List<Attachment>? _attachments;
        private RequestCategory? _category;
        private ObservableCollection<string>? _checkedItems;
        private ClosureCode? _closureCode;
        private DateTime? _completedAt;
        private RequestCompletionReason? _completionReason;
        private ConfigurationItem? _configurationItem;
        private DateTime? _createdAt;
        private Person? _createdBy;
        private DateTime? _desiredCompletionAt;
        private DateTime? _downtimeEndAt;
        private DateTime? _downtimeStartAt;
        private RequestFeedback? _feedback;
        private KnowledgeArticle? _feedbackOnKnowledgeArticle;
        private Request? _groupedInto;
        private RequestGrouping? _grouping;
        private RequestImpact? _impact;
        private string? _internalNote;
        private ObservableCollection<AttachmentReference>? _internalNoteAttachments;
        private AttachmentReferenceWriter? _internalNoteAttachmentsWriter;
        private KnowledgeArticle? _knowledgeArticle;
        private RequestMajorIncidentStatus? _majorIncidentStatus;
        private Person? _member;
        private bool? _newAssignment;
        private DateTime? _nextTargetAt;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private Organization? _organization;
        private int? _plannedEffort;
        private Problem? _problem;
        private ProductBacklog? _productBacklog;
        private int? _productBacklogPosition;
        private Project? _project;
        private bool? _providerNotAccountable;
        private bool? _providerWasNotAccountable;
        private int? _reopenCount;
        private Person? _requestedBy;
        private Person? _requestedFor;
        private DateTime? _requesterResolutionTargetAt;
        private Reservation? _reservation;
        private int? _resolutionDuration;
        private DateTime? _resolutionTargetAt;
        private DateTime? _responseTargetAt;
        private bool? _reviewed;
        private string? _rfcType;
        private FeedbackSatisfaction? _satisfaction;
        private ServiceInstance? _serviceInstance;
        private string? _source;
        private string? _sourceID;
        private RequestStatus? _status;
        private string? _subject;
        private string? _summary;
        private Organization? _supplier;
        private string? _supplierRequestID;
        private string? _supportDomain;
        private Team? _team;
        private RequestTemplate? _template;
        private int? _timeSpent;
        private EffortClass? _timeSpentEffortClass;
        private DateTime? _updatedAt;
        private bool? _urgent;
        private DateTime? _waitingUntil;
        private Workflow? _workflow;
        private WorkflowTask? _workflowTask;

        /// <summary>
        /// Gets or sets a value indicating whether the request has been addressed after dissatisfaction.
        /// </summary>
        [XurrentField("addressed")]
        public bool? Addressed
        {
            get => _addressed;
            set => _addressed = SetValue("addressed", _addressed, value);
        }

        /// <summary>
        /// Gets or sets the agile board on which the request is placed.
        /// </summary>
        [XurrentField("agile_board")]
        public AgileBoard? AgileBoard
        {
            get => _agileBoard;
            set => _agileBoard = SetValue("agile_board", _agileBoard, value);
        }

        /// <summary>
        /// Gets or sets the agile board column on which the request is placed.
        /// </summary>
        [XurrentField("agile_board_column")]
        public AgileBoardColumn? AgileBoardColumn
        {
            get => _agileBoardColumn;
            set => _agileBoardColumn = SetValue("agile_board_column", _agileBoardColumn, value);
        }

        /// <summary>
        /// Gets or sets the position of the request within the agile board column.
        /// </summary>
        [XurrentField("agile_board_column_position")]
        public int? AgileBoardColumnPosition
        {
            get => _agileBoardColumnPosition;
            set => _agileBoardColumnPosition = SetValue("agile_board_column_position", _agileBoardColumnPosition, value);
        }

        /// <summary>
        /// Gets the number of times the request was assigned to a team.
        /// </summary>
        [XurrentField("assignment_count")]
        public int? AssignmentCount
        {
            get => _assignmentCount;
            internal set => _assignmentCount = value;
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the request.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the category of the request.
        /// </summary>
        [XurrentField("category")]
        public RequestCategory? Category
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
        /// Gets or sets the closure code of the request.
        /// </summary>
        [XurrentField("closure_code")]
        public ClosureCode? ClosureCode
        {
            get => _closureCode;
            set => _closureCode = SetValue("closure_code", _closureCode, value);
        }

        /// <summary>
        /// Gets or sets the date and time when the request was completed.
        /// </summary>
        [XurrentField("completed_at")]
        public DateTime? CompletedAt
        {
            get => _completedAt;
            set => _completedAt = SetValue("completed_at", _completedAt, value);
        }

        /// <summary>
        /// Gets or sets the completion reason of the request.
        /// </summary>
        [XurrentField("completion_reason")]
        public RequestCompletionReason? CompletionReason
        {
            get => _completionReason;
            set => _completionReason = SetValue("completion_reason", _completionReason, value);
        }

        /// <summary>
        /// Sets the configuration item related to the request.<br />
        /// Setting this property replaces all configuration items currently related to the request.<br />
        /// This property is write-only.
        /// </summary>
        [XurrentField("ci")]
        public ConfigurationItem? ConfigurationItem
        {
            get => _configurationItem;
            set => _configurationItem = SetValue("ci", _configurationItem, value);
        }

        /// <summary>
        /// Gets the date and time when the request was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the person who created the request.
        /// </summary>
        [XurrentField("created_by")]
        public Person? CreatedBy
        {
            get => _createdBy;
            set => _createdBy = SetValue("created_by", _createdBy, value);
        }

        /// <summary>
        /// Gets or sets the desired completion date and time of the request.
        /// </summary>
        [XurrentField("desired_completion_at")]
        public DateTime? DesiredCompletionAt
        {
            get => _desiredCompletionAt;
            set => _desiredCompletionAt = SetValue("desired_completion_at", _desiredCompletionAt, value);
        }

        /// <summary>
        /// Gets or sets the date and time when downtime ended.
        /// </summary>
        [XurrentField("downtime_end_at")]
        public DateTime? DowntimeEndAt
        {
            get => _downtimeEndAt;
            set => _downtimeEndAt = SetValue("downtime_end_at", _downtimeEndAt, value);
        }

        /// <summary>
        /// Gets or sets the date and time when downtime started.
        /// </summary>
        [XurrentField("downtime_start_at")]
        public DateTime? DowntimeStartAt
        {
            get => _downtimeStartAt;
            set => _downtimeStartAt = SetValue("downtime_start_at", _downtimeStartAt, value);
        }

        /// <summary>
        /// Gets the feedback information associated with the request.
        /// </summary>
        [XurrentField("feedback")]
        public RequestFeedback? Feedback
        {
            get => _feedback;
            internal set => _feedback = value;
        }

        /// <summary>
        /// Gets or sets the knowledge article the request provides feedback on.
        /// </summary>
        [XurrentField("feedback_on_knowledge_article")]
        public KnowledgeArticle? FeedbackOnKnowledgeArticle
        {
            get => _feedbackOnKnowledgeArticle;
            set => _feedbackOnKnowledgeArticle = SetValue("feedback_on_knowledge_article", _feedbackOnKnowledgeArticle, value);
        }

        /// <summary>
        /// Gets or sets the request group to which this request belongs.
        /// </summary>
        [XurrentField("grouped_into")]
        public Request? GroupedInto
        {
            get => _groupedInto;
            set => _groupedInto = SetValue("grouped_into", _groupedInto, value);
        }

        /// <summary>
        /// Gets the grouping of the request.
        /// </summary>
        [XurrentField("grouping")]
        public RequestGrouping? Grouping
        {
            get => _grouping;
            internal set => _grouping = value;
        }

        /// <summary>
        /// Gets or sets the impact of the request.
        /// </summary>
        [XurrentField("impact")]
        public RequestImpact? Impact
        {
            get => _impact;
            set => _impact = SetValue("impact", _impact, value);
        }

        /// <summary>
        /// Gets or sets the internal note of the request.<br />
        /// This property is write-only.
        /// </summary>
        [XurrentField("internal_note")]
        public string? InternalNote
        {
            get => _internalNote;
            set => _internalNote = SetValue("internal_note", _internalNote, value);
        }

        [XurrentField("internal_note_attachments")]
        internal ObservableCollection<AttachmentReference> InternalNoteAttachmentsCollection
        {
            get => GetCollection(ref _internalNoteAttachments, OnInternalNoteAttachmentsChanged);
            set => SetCollection(ref _internalNoteAttachments, "internal_note_attachments", value, OnInternalNoteAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the internal note field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter InternalNoteAttachments
        {
            get
            {
                _internalNoteAttachmentsWriter ??= new AttachmentReferenceWriter(() => InternalNoteAttachmentsCollection, c => InternalNoteAttachmentsCollection = c);
                return _internalNoteAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the knowledge article associated with the request.
        /// </summary>
        [XurrentField("knowledge_article")]
        public KnowledgeArticle? KnowledgeArticle
        {
            get => _knowledgeArticle;
            set => _knowledgeArticle = SetValue("knowledge_article", _knowledgeArticle, value);
        }

        /// <summary>
        /// Gets or sets the major incident status of the request.
        /// </summary>
        [XurrentField("major_incident_status")]
        public RequestMajorIncidentStatus? MajorIncidentStatus
        {
            get => _majorIncidentStatus;
            set => _majorIncidentStatus = SetValue("major_incident_status", _majorIncidentStatus, value);
        }

        /// <summary>
        /// Gets or sets the member assigned to the request.
        /// </summary>
        [XurrentField("member")]
        public Person? Member
        {
            get => _member;
            set => _member = SetValue("member", _member, value);
        }

        /// <summary>
        /// Gets a value indicating whether the request has a new assignment.
        /// </summary>
        [XurrentField("new_assignment")]
        public bool? NewAssignment
        {
            get => _newAssignment;
            internal set => _newAssignment = value;
        }

        /// <summary>
        /// Gets the next target date and time for the request.
        /// </summary>
        [XurrentField("next_target_at")]
        public DateTime? NextTargetAt
        {
            get => _nextTargetAt;
            internal set => _nextTargetAt = value;
        }

        /// <summary>
        /// Gets or sets the note of the request.<br />
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
        /// Gets the organization associated with the request.
        /// </summary>
        [XurrentField("organization")]
        public Organization? Organization
        {
            get => _organization;
            internal set => _organization = value;
        }

        /// <summary>
        /// Gets or sets the planned effort, expressed in minutes.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            set => _plannedEffort = SetValue("planned_effort", _plannedEffort, value);
        }

        /// <summary>
        /// Gets or sets the problem associated with the request.
        /// </summary>
        [XurrentField("problem")]
        public Problem? Problem
        {
            get => _problem;
            set => _problem = SetValue("problem", _problem, value);
        }

        /// <summary>
        /// Gets or sets the product backlog associated with the request.
        /// </summary>
        [XurrentField("product_backlog")]
        public ProductBacklog? ProductBacklog
        {
            get => _productBacklog;
            set => _productBacklog = SetValue("product_backlog", _productBacklog, value);
        }

        /// <summary>
        /// Gets or sets the product backlog position of the request.
        /// </summary>
        [XurrentField("product_backlog_position")]
        public int? ProductBacklogPosition
        {
            get => _productBacklogPosition;
            set => _productBacklogPosition = SetValue("product_backlog_position", _productBacklogPosition, value);
        }

        /// <summary>
        /// Gets or sets the project associated with the request.
        /// </summary>
        [XurrentField("project")]
        public Project? Project
        {
            get => _project;
            set => _project = SetValue("project", _project, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the provider is not accountable.
        /// </summary>
        [XurrentField("provider_not_accountable")]
        public bool? ProviderNotAccountable
        {
            get => _providerNotAccountable;
            set => _providerNotAccountable = SetValue("provider_not_accountable", _providerNotAccountable, value);
        }

        /// <summary>
        /// Gets a value indicating whether the provider was not accountable.
        /// </summary>
        [XurrentField("provider_was_not_accountable")]
        public bool? ProviderWasNotAccountable
        {
            get => _providerWasNotAccountable;
            internal set => _providerWasNotAccountable = value;
        }

        /// <summary>
        /// Gets the number of times the request was reopened.
        /// </summary>
        [XurrentField("reopen_count")]
        public int? ReopenCount
        {
            get => _reopenCount;
            internal set => _reopenCount = value;
        }

        /// <summary>
        /// Gets or sets the person who requested the request.
        /// </summary>
        [XurrentField("requested_by")]
        public Person? RequestedBy
        {
            get => _requestedBy;
            set => _requestedBy = SetValue("requested_by", _requestedBy, value);
        }

        /// <summary>
        /// Gets or sets the person for whom the request was made.
        /// </summary>
        [XurrentField("requested_for")]
        public Person? RequestedFor
        {
            get => _requestedFor;
            set => _requestedFor = SetValue("requested_for", _requestedFor, value);
        }

        /// <summary>
        /// Gets the requester resolution target date and time.
        /// </summary>
        [XurrentField("requester_resolution_target_at")]
        public DateTime? RequesterResolutionTargetAt
        {
            get => _requesterResolutionTargetAt;
            internal set => _requesterResolutionTargetAt = value;
        }

        /// <summary>
        /// Gets or sets the reservation associated with the request.
        /// </summary>
        [XurrentField("reservation")]
        public Reservation? Reservation
        {
            get => _reservation;
            set => _reservation = SetValue("reservation", _reservation, value);
        }

        /// <summary>
        /// Gets the resolution duration, expressed in minutes.
        /// </summary>
        [XurrentField("resolution_duration")]
        public int? ResolutionDuration
        {
            get => _resolutionDuration;
            internal set => _resolutionDuration = value;
        }

        /// <summary>
        /// Gets the resolution target date and time.
        /// </summary>
        [XurrentField("resolution_target_at")]
        public DateTime? ResolutionTargetAt
        {
            get => _resolutionTargetAt;
            internal set => _resolutionTargetAt = value;
        }

        /// <summary>
        /// Gets the response target date and time.
        /// </summary>
        [XurrentField("response_target_at")]
        public DateTime? ResponseTargetAt
        {
            get => _responseTargetAt;
            internal set => _responseTargetAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the request has been reviewed.
        /// </summary>
        [XurrentField("reviewed")]
        public bool? Reviewed
        {
            get => _reviewed;
            set => _reviewed = SetValue("reviewed", _reviewed, value);
        }

        /// <summary>
        /// Gets or sets the RFC type reference of the request.<br />
        /// This value must be the reference field of the related RFC type.
        /// </summary>
        [XurrentField("rfc_type")]
        public string? RfcType
        {
            get => _rfcType;
            set => _rfcType = SetValue("rfc_type", _rfcType, value);
        }

        /// <summary>
        /// Gets the satisfaction feedback for the request.
        /// </summary>
        [XurrentField("satisfaction")]
        public FeedbackSatisfaction? Satisfaction
        {
            get => _satisfaction;
            internal set => _satisfaction = value;
        }

        /// <summary>
        /// Gets or sets the service instance associated with the request.
        /// </summary>
        [XurrentField("service_instance")]
        public ServiceInstance? ServiceInstance
        {
            get => _serviceInstance;
            set => _serviceInstance = SetValue("service_instance", _serviceInstance, value);
        }

        /// <summary>
        /// Gets or sets the source of the request.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the request.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the status of the request.
        /// </summary>
        [XurrentField("status")]
        public RequestStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the subject of the request.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets the AI-generated summary of the request.
        /// </summary>
        [XurrentField("summary")]
        public string? Summary
        {
            get => _summary;
            internal set => _summary = value;
        }

        /// <summary>
        /// Gets or sets the supplier associated with the request.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the supplier request identifier.
        /// </summary>
        [XurrentField("supplier_requestID")]
        public string? SupplierRequestID
        {
            get => _supplierRequestID;
            set => _supplierRequestID = SetValue("supplier_requestID", _supplierRequestID, value);
        }

        /// <summary>
        /// Sets the support domain in which the request is registered.<br />
        /// This property can only be used when creating a request.<br />
        /// This property is write-only.
        /// </summary>
        [XurrentField("support_domain")]
        public string? SupportDomain
        {
            get => _supportDomain;
            set => _supportDomain = SetValue("support_domain", _supportDomain, value);
        }

        /// <summary>
        /// Gets or sets the team assigned to the request.
        /// </summary>
        [XurrentField("team")]
        public Team? Team
        {
            get => _team;
            set => _team = SetValue("team", _team, value);
        }

        /// <summary>
        /// Gets or sets the request template applied to the request.
        /// </summary>
        [XurrentField("template")]
        public RequestTemplate? Template
        {
            get => _template;
            set => _template = SetValue("template", _template, value);
        }

        /// <summary>
        /// Sets the time spent, expressed in minutes.<br />
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
        /// Gets the date and time when the request was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the request is urgent.
        /// </summary>
        [XurrentField("urgent")]
        public bool? Urgent
        {
            get => _urgent;
            set => _urgent = SetValue("urgent", _urgent, value);
        }

        /// <summary>
        /// Gets or sets the date and time until which the request is waiting.
        /// </summary>
        [XurrentField("waiting_until")]
        public DateTime? WaitingUntil
        {
            get => _waitingUntil;
            set => _waitingUntil = SetValue("waiting_until", _waitingUntil, value);
        }

        /// <summary>
        /// Gets or sets the workflow associated with the request.
        /// </summary>
        [XurrentField("workflow")]
        public Workflow? Workflow
        {
            get => _workflow;
            set => _workflow = SetValue("workflow", _workflow, value);
        }

        /// <summary>
        /// Gets or sets the workflow task associated with the request.
        /// </summary>
        [XurrentField("task")]
        public WorkflowTask? WorkflowTask
        {
            get => _workflowTask;
            set => _workflowTask = SetValue("task", _workflowTask, value);
        }

        /// <summary>
        /// Creates a new request instance.
        /// </summary>
        public Request()
        {
        }

        /// <summary>
        /// Creates a new request instance.
        /// </summary>
        /// <param name="id">The unique identifier of the request.</param>
        public Request(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new request instance.
        /// </summary>
        /// <param name="category">The category of the request.</param>
        /// <param name="createdBy">The created by of the request.</param>
        /// <param name="requestedBy">The requested by of the request.</param>
        /// <param name="subject">The subject of the request.</param>
        /// <param name="team">The team of the request.</param>
        public Request(RequestCategory category, Person createdBy, Person requestedBy, string subject, Team team)
        {
            _category = SetValue("category", category);
            _createdBy = SetValue("created_by", createdBy);
            _requestedBy = SetValue("requested_by", requestedBy);
            _subject = SetValue("subject", subject);
            _team = SetValue("team", team);
        }

        private void OnCheckedItemsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<string> collection)
                MarkCollectionChanged(collection, "checked_items");
        }

        private void OnInternalNoteAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "internal_note_attachments");
        }

        private void OnNoteAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "note_attachments");
        }
    }
}
