using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent workflow objects.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Workflow : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Workflow"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The actual effort field.
            /// </summary>
            [XurrentEnum("actual_effort")]
            ActualEffort,

            /// <summary>
            /// The actual vs planned effort percentage field.
            /// </summary>
            [XurrentEnum("actual_vs_planned_effort_percentage")]
            ActualVsPlannedEffortPercentage,

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
            /// The justification field.
            /// </summary>
            [XurrentEnum("justification")]
            Justification,

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
            /// The planned effort field.
            /// </summary>
            [XurrentEnum("planned_effort")]
            PlannedEffort,

            /// <summary>
            /// The prevent request completion field.
            /// </summary>
            [XurrentEnum("prevent_request_completion")]
            PreventRequestCompletion,

            /// <summary>
            /// The project field.
            /// </summary>
            [XurrentEnum("project")]
            Project,

            /// <summary>
            /// The release field.
            /// </summary>
            [XurrentEnum("release")]
            Release,

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
            /// The template field.
            /// </summary>
            [XurrentEnum("template")]
            Template,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The workflow type field.
            /// </summary>
            [XurrentEnum("workflow_type")]
            WorkflowType
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Workflow"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters workflows by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Filters workflows by completion date and time.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Filters workflows by completion target date and time.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Filters workflows by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters workflows by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters workflows by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Filters workflows by manager.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

            /// <summary>
            /// Filters workflows by project.
            /// </summary>
            [XurrentEnum("project")]
            Project,

            /// <summary>
            /// Filters workflows by release.
            /// </summary>
            [XurrentEnum("release")]
            Release,

            /// <summary>
            /// Filters workflows by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Filters workflows by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters workflows by identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters workflows by start date and time.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// Filters workflows by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters workflows by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Filters workflows by workflow template.
            /// </summary>
            [XurrentEnum("template")]
            Template,

            /// <summary>
            /// Filters workflows by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Workflow"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all completed workflows.
            /// </summary>
            [XurrentEnum("completed")]
            Completed,

            /// <summary>
            /// Lists all workflows managed by the API user.
            /// </summary>
            [XurrentEnum("managed_by_me")]
            ManagedByMe,

            /// <summary>
            /// Lists all open workflows.
            /// </summary>
            [XurrentEnum("open")]
            Open
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Workflow"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts workflows by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Sorts workflows by the date and time at which they were completed.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Sorts workflows by completion target date and time.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Sorts workflows by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts workflows by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts workflows by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Sorts workflows by manager.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

            /// <summary>
            /// Sorts workflows by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Sorts workflows by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts workflows by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts workflows by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts workflows by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private int? _actualEffort;
        private int? _actualVsPlannedEffortPercentage;
        private List<Attachment>? _attachments;
        private WorkflowCategory? _category;
        private DateTime? _completedAt;
        private WorkflowCompletionReason? _completionReason;
        private DateTime? _completionTargetAt;
        private DateTime? _createdAt;
        private WorkflowImpact? _impact;
        private WorkflowJustification? _justification;
        private Person? _manager;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private int? _plannedEffort;
        private bool? _preventRequestCompletion;
        private Project? _project;
        private Release? _release;
        private int? _resolutionDuration;
        private Service? _service;
        private string? _source;
        private string? _sourceID;
        private DateTime? _startAt;
        private WorkflowStatus? _status;
        private string? _subject;
        private WorkflowTemplate? _template;
        private DateTime? _updatedAt;
        private string? _workflowType;

        /// <summary>
        /// Gets the total actual effort spent on the workflow.
        /// </summary>
        [XurrentField("actual_effort")]
        public int? ActualEffort
        {
            get => _actualEffort;
            internal set => _actualEffort = value;
        }

        /// <summary>
        /// Gets the actual effort as a percentage of the planned effort.
        /// </summary>
        [XurrentField("actual_vs_planned_effort_percentage")]
        public int? ActualVsPlannedEffortPercentage
        {
            get => _actualVsPlannedEffortPercentage;
            internal set => _actualVsPlannedEffortPercentage = value;
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the attachments associated with the workflow.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the category of the workflow.
        /// </summary>
        [XurrentField("category")]
        public WorkflowCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets the date and time at which the workflow was completed.
        /// </summary>
        [XurrentField("completed_at")]
        public DateTime? CompletedAt
        {
            get => _completedAt;
            internal set => _completedAt = value;
        }

        /// <summary>
        /// Gets or sets the completion reason of the workflow.
        /// </summary>
        [XurrentField("completion_reason")]
        public WorkflowCompletionReason? CompletionReason
        {
            get => _completionReason;
            set => _completionReason = SetValue("completion_reason", _completionReason, value);
        }

        /// <summary>
        /// Gets the target date and time for completion of the workflow.
        /// </summary>
        [XurrentField("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => _completionTargetAt;
            internal set => _completionTargetAt = value;
        }

        /// <summary>
        /// Gets the date and time at which the workflow was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the impact of the workflow.
        /// </summary>
        [XurrentField("impact")]
        public WorkflowImpact? Impact
        {
            get => _impact;
            set => _impact = SetValue("impact", _impact, value);
        }

        /// <summary>
        /// Gets or sets the justification of the workflow.
        /// </summary>
        [XurrentField("justification")]
        public WorkflowJustification? Justification
        {
            get => _justification;
            set => _justification = SetValue("justification", _justification, value);
        }

        /// <summary>
        /// Gets or sets the manager responsible for the workflow.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Gets or sets the note of the workflow.<br />
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
        /// Gets the planned effort for the workflow.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            internal set => _plannedEffort = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether completion of related requests is prevented.
        /// </summary>
        [XurrentField("prevent_request_completion")]
        public bool? PreventRequestCompletion
        {
            get => _preventRequestCompletion;
            set => _preventRequestCompletion = SetValue("prevent_request_completion", _preventRequestCompletion, value);
        }

        /// <summary>
        /// Gets or sets the project associated with the workflow.
        /// </summary>
        [XurrentField("project")]
        public Project? Project
        {
            get => _project;
            set => _project = SetValue("project", _project, value);
        }

        /// <summary>
        /// Gets or sets the release associated with the workflow.
        /// </summary>
        [XurrentField("release")]
        public Release? Release
        {
            get => _release;
            set => _release = SetValue("release", _release, value);
        }

        /// <summary>
        /// Gets the resolution duration of the workflow in minutes.
        /// </summary>
        [XurrentField("resolution_duration")]
        public int? ResolutionDuration
        {
            get => _resolutionDuration;
            internal set => _resolutionDuration = value;
        }

        /// <summary>
        /// Gets or sets the service associated with the workflow.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the source of the workflow.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the workflow in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the date and time at which the workflow starts.
        /// </summary>
        [XurrentField("start_at")]
        public DateTime? StartAt
        {
            get => _startAt;
            set => _startAt = SetValue("start_at", _startAt, value);
        }

        /// <summary>
        /// Gets or sets the status of the workflow.
        /// </summary>
        [XurrentField("status")]
        public WorkflowStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the subject of the workflow.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets or sets the workflow template used to create the workflow.
        /// </summary>
        [XurrentField("template")]
        public WorkflowTemplate? Template
        {
            get => _template;
            set => _template = SetValue("template", _template, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the workflow.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the reference of the type of the workflow.
        /// </summary>
        [XurrentField("workflow_type")]
        public string? WorkflowType
        {
            get => _workflowType;
            set => _workflowType = SetValue("workflow_type", _workflowType, value);
        }

        /// <summary>
        /// Creates a new workflow instance.
        /// </summary>
        public Workflow()
        {
        }

        /// <summary>
        /// Creates a new workflow instance.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow.</param>
        public Workflow(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new workflow instance.
        /// </summary>
        /// <param name="category">The category of the workflow.</param>
        /// <param name="justification">The justification of the workflow.</param>
        /// <param name="manager">The manager of the workflow.</param>
        /// <param name="service">The service of the workflow.</param>
        /// <param name="subject">The subject of the workflow.</param>
        /// <param name="template">The template of the workflow.</param>
        /// <param name="workflowType">The workflow type of the workflow.</param>
        public Workflow(WorkflowCategory category, WorkflowJustification justification, Person manager, Service service, string subject, WorkflowTemplate template, string workflowType)
        {
            _category = SetValue("category", category);
            _justification = SetValue("justification", justification);
            _manager = SetValue("manager", manager);
            _service = SetValue("service", service);
            _subject = SetValue("subject", subject);
            _template = SetValue("template", template);
            _workflowType = SetValue("workflow_type", workflowType);
        }

        private void OnNoteAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "note_attachments");
        }
    }
}
