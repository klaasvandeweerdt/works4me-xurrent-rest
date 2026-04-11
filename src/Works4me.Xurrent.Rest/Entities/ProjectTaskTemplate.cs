using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent project task template object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ProjectTaskTemplate : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ProjectTaskTemplate"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The assign to project manager field.
            /// </summary>
            [XurrentEnum("assign_to_project_manager")]
            AssignToProjectManager,

            /// <summary>
            /// The assign to requester field.
            /// </summary>
            [XurrentEnum("assign_to_requester")]
            AssignToRequester,

            /// <summary>
            /// The assign to requester business unit manager field.
            /// </summary>
            [XurrentEnum("assign_to_requester_business_unit_manager")]
            AssignToRequesterBusinessUnitManager,

            /// <summary>
            /// The assign to requester manager field.
            /// </summary>
            [XurrentEnum("assign_to_requester_manager")]
            AssignToRequesterManager,

            /// <summary>
            /// The assign to service owner field.
            /// </summary>
            [XurrentEnum("assign_to_service_owner")]
            AssignToServiceOwner,

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
            /// The copy notes to project field.
            /// </summary>
            [XurrentEnum("copy_notes_to_project")]
            CopyNotesToProject,

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
            /// The effort class field.
            /// </summary>
            [XurrentEnum("effort_class")]
            EffortClass,

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
            /// The planned effort project manager field.
            /// </summary>
            [XurrentEnum("planned_effort_project_manager")]
            PlannedEffortProjectManager,

            /// <summary>
            /// The planned effort requester field.
            /// </summary>
            [XurrentEnum("planned_effort_requester")]
            PlannedEffortRequester,

            /// <summary>
            /// The planned effort requester business unit manager field.
            /// </summary>
            [XurrentEnum("planned_effort_requester_business_unit_manager")]
            PlannedEffortRequesterBusinessUnitManager,

            /// <summary>
            /// The planned effort requester manager field.
            /// </summary>
            [XurrentEnum("planned_effort_requester_manager")]
            PlannedEffortRequesterManager,

            /// <summary>
            /// The planned effort service owner field.
            /// </summary>
            [XurrentEnum("planned_effort_service_owner")]
            PlannedEffortServiceOwner,

            /// <summary>
            /// The required approvals field.
            /// </summary>
            [XurrentEnum("required_approvals")]
            RequiredApprovals,

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
            /// The team field.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// The times applied field.
            /// </summary>
            [XurrentEnum("times_applied")]
            TimesApplied,

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
            /// The work hours are 24x7 field.
            /// </summary>
            [XurrentEnum("work_hours_are_24x7")]
            WorkHoursAre24x7
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ProjectTaskTemplate"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by whether the project task template is disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

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
        /// Represents the predefined filters of a <see cref="ProjectTaskTemplate"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled project task templates.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled project task templates.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ProjectTaskTemplate"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

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
            /// Sorts by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts by the number of times the template was applied.
            /// </summary>
            [XurrentEnum("times_applied")]
            TimesApplied,

            /// <summary>
            /// Sorts by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private bool? _assignToProjectManager;
        private bool? _assignToRequester;
        private bool? _assignToRequesterBusinessUnitManager;
        private bool? _assignToRequesterManager;
        private bool? _assignToServiceOwner;
        private List<Attachment>? _attachments;
        private ProjectTaskCategory? _category;
        private bool? _copyNotesToProject;
        private DateTime? _createdAt;
        private bool? _disabled;
        private EffortClass? _effortClass;
        private string? _instructions;
        private ObservableCollection<AttachmentReference>? _instructionsAttachments;
        private AttachmentReferenceWriter? _instructionsAttachmentsWriter;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private int? _plannedDuration;
        private int? _plannedEffort;
        private int? _plannedEffortProjectManager;
        private int? _plannedEffortRequester;
        private int? _plannedEffortRequesterBusinessUnitManager;
        private int? _plannedEffortRequesterManager;
        private int? _plannedEffortServiceOwner;
        private int? _requiredApprovals;
        private SkillPool? _skillPool;
        private string? _source;
        private string? _sourceID;
        private string? _subject;
        private Organization? _supplier;
        private Team? _team;
        private int? _timesApplied;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;
        private bool? _workHoursAre24x7;

        /// <summary>
        /// Gets or sets a value indicating whether the project manager is assigned to project tasks created using the template.
        /// </summary>
        [XurrentField("assign_to_project_manager")]
        public bool? AssignToProjectManager
        {
            get => _assignToProjectManager;
            set => _assignToProjectManager = SetValue("assign_to_project_manager", _assignToProjectManager, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the requester is assigned to project tasks created using the template.
        /// </summary>
        [XurrentField("assign_to_requester")]
        public bool? AssignToRequester
        {
            get => _assignToRequester;
            set => _assignToRequester = SetValue("assign_to_requester", _assignToRequester, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the requester business unit manager is assigned to project tasks created using the template.
        /// </summary>
        [XurrentField("assign_to_requester_business_unit_manager")]
        public bool? AssignToRequesterBusinessUnitManager
        {
            get => _assignToRequesterBusinessUnitManager;
            set => _assignToRequesterBusinessUnitManager = SetValue("assign_to_requester_business_unit_manager", _assignToRequesterBusinessUnitManager, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the requester manager is assigned to project tasks created using the template.
        /// </summary>
        [XurrentField("assign_to_requester_manager")]
        public bool? AssignToRequesterManager
        {
            get => _assignToRequesterManager;
            set => _assignToRequesterManager = SetValue("assign_to_requester_manager", _assignToRequesterManager, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the service owner is assigned to project tasks created using the template.
        /// </summary>
        [XurrentField("assign_to_service_owner")]
        public bool? AssignToServiceOwner
        {
            get => _assignToServiceOwner;
            set => _assignToServiceOwner = SetValue("assign_to_service_owner", _assignToServiceOwner, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the project task template.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the category that is applied when a project task is created using the template.
        /// </summary>
        [XurrentField("category")]
        public ProjectTaskCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether notes are copied to the project.
        /// </summary>
        [XurrentField("copy_notes_to_project")]
        public bool? CopyNotesToProject
        {
            get => _copyNotesToProject;
            set => _copyNotesToProject = SetValue("copy_notes_to_project", _copyNotesToProject, value);
        }

        /// <summary>
        /// Gets the date and time when the project task template was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the project task template is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the effort class that is applied by default.
        /// </summary>
        [XurrentField("effort_class")]
        public EffortClass? EffortClass
        {
            get => _effortClass;
            set => _effortClass = SetValue("effort_class", _effortClass, value);
        }

        /// <summary>
        /// Gets or sets the instructions of the project task template.
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
        /// Sets the note applied to project tasks created using the template.<br />
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
        /// Gets or sets the planned duration, expressed in minutes, for project tasks created using the template.
        /// </summary>
        [XurrentField("planned_duration")]
        public int? PlannedDuration
        {
            get => _plannedDuration;
            set => _plannedDuration = SetValue("planned_duration", _plannedDuration, value);
        }

        /// <summary>
        /// Gets or sets the planned effort, expressed in minutes, for project tasks created using the template.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            set => _plannedEffort = SetValue("planned_effort", _plannedEffort, value);
        }

        /// <summary>
        /// Gets or sets the planned effort, expressed in minutes, for the project manager.
        /// </summary>
        [XurrentField("planned_effort_project_manager")]
        public int? PlannedEffortProjectManager
        {
            get => _plannedEffortProjectManager;
            set => _plannedEffortProjectManager = SetValue("planned_effort_project_manager", _plannedEffortProjectManager, value);
        }

        /// <summary>
        /// Gets or sets the planned effort, expressed in minutes, for the requester.
        /// </summary>
        [XurrentField("planned_effort_requester")]
        public int? PlannedEffortRequester
        {
            get => _plannedEffortRequester;
            set => _plannedEffortRequester = SetValue("planned_effort_requester", _plannedEffortRequester, value);
        }

        /// <summary>
        /// Gets or sets the planned effort, expressed in minutes, for the requester business unit manager.
        /// </summary>
        [XurrentField("planned_effort_requester_business_unit_manager")]
        public int? PlannedEffortRequesterBusinessUnitManager
        {
            get => _plannedEffortRequesterBusinessUnitManager;
            set => _plannedEffortRequesterBusinessUnitManager = SetValue("planned_effort_requester_business_unit_manager", _plannedEffortRequesterBusinessUnitManager, value);
        }

        /// <summary>
        /// Gets or sets the planned effort, expressed in minutes, for the requester manager.
        /// </summary>
        [XurrentField("planned_effort_requester_manager")]
        public int? PlannedEffortRequesterManager
        {
            get => _plannedEffortRequesterManager;
            set => _plannedEffortRequesterManager = SetValue("planned_effort_requester_manager", _plannedEffortRequesterManager, value);
        }

        /// <summary>
        /// Gets or sets the planned effort, expressed in minutes, for the service owner.
        /// </summary>
        [XurrentField("planned_effort_service_owner")]
        public int? PlannedEffortServiceOwner
        {
            get => _plannedEffortServiceOwner;
            set => _plannedEffortServiceOwner = SetValue("planned_effort_service_owner", _plannedEffortServiceOwner, value);
        }

        /// <summary>
        /// Gets or sets the number of required approvals for approval project tasks created using the template.
        /// </summary>
        [XurrentField("required_approvals")]
        public int? RequiredApprovals
        {
            get => _requiredApprovals;
            set => _requiredApprovals = SetValue("required_approvals", _requiredApprovals, value);
        }

        /// <summary>
        /// Gets or sets the skill pool that is applied when a project task is created using the template.
        /// </summary>
        [XurrentField("skill_pool")]
        public SkillPool? SkillPool
        {
            get => _skillPool;
            set => _skillPool = SetValue("skill_pool", _skillPool, value);
        }

        /// <summary>
        /// Gets or sets the source of the project task template.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the project task template.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the subject applied to project tasks created using the template.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets or sets the supplier applied to project tasks created using the template.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the team applied to project tasks created using the template.
        /// </summary>
        [XurrentField("team")]
        public Team? Team
        {
            get => _team;
            set => _team = SetValue("team", _team, value);
        }

        /// <summary>
        /// Gets the number of times the project task template was applied.
        /// </summary>
        [XurrentField("times_applied")]
        public int? TimesApplied
        {
            get => _timesApplied;
            internal set => _timesApplied = value;
        }

        /// <summary>
        /// Gets or sets the UI extension applied to project tasks created using the template.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            set => _uiExtension = SetValue("ui_extension", _uiExtension, value);
        }

        /// <summary>
        /// Gets the date and time when the project task template was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
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
        /// Creates a new project task template instance.
        /// </summary>
        public ProjectTaskTemplate()
        {
        }

        /// <summary>
        /// Creates a new project task template instance.
        /// </summary>
        /// <param name="id">The unique identifier of the project task template.</param>
        public ProjectTaskTemplate(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new project task template instance.
        /// </summary>
        /// <param name="category">The category of the project task template.</param>
        /// <param name="subject">The subject of the project task template.</param>
        public ProjectTaskTemplate(ProjectTaskCategory category, string subject)
        {
            _category = SetValue("category", category);
            _subject = SetValue("subject", subject);
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
    }
}
