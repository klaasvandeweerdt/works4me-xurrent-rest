using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent request template object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class RequestTemplate : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="RequestTemplate"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The action type field.
            /// </summary>
            [XurrentEnum("action_type")]
            ActionType,

            /// <summary>
            /// The asset selection field.
            /// </summary>
            [XurrentEnum("asset_selection")]
            AssetSelection,

            /// <summary>
            /// The assign after workflow completion field.
            /// </summary>
            [XurrentEnum("assign_after_workflow_completion")]
            AssignAfterWorkflowCompletion,

            /// <summary>
            /// The assign to self field.
            /// </summary>
            [XurrentEnum("assign_to_self")]
            AssignToSelf,

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
            /// The completion reason field.
            /// </summary>
            [XurrentEnum("completion_reason")]
            CompletionReason,

            /// <summary>
            /// The configuration item field.
            /// </summary>
            [XurrentEnum("ci")]
            ConfigurationItem,

            /// <summary>
            /// The copy subject to requests field.
            /// </summary>
            [XurrentEnum("copy_subject_to_requests")]
            CopySubjectToRequests,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

            /// <summary>
            /// The desired completion field.
            /// </summary>
            [XurrentEnum("desired_completion")]
            DesiredCompletion,

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
            /// The end users field.
            /// </summary>
            [XurrentEnum("end_users")]
            EndUsers,

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
            /// The keywords field.
            /// </summary>
            [XurrentEnum("keywords")]
            Keywords,

            /// <summary>
            /// The localized keywords field.
            /// </summary>
            [XurrentEnum("localized_keywords", IgnoreInFieldSelection = true)]
            LocalizedKeywords,

            /// <summary>
            /// The localized note field.
            /// </summary>
            [XurrentEnum("localized_note", IgnoreInFieldSelection = true)]
            LocalizedNote,

            /// <summary>
            /// The localized registration hints field.
            /// </summary>
            [XurrentEnum("localized_registration_hints", IgnoreInFieldSelection = true)]
            LocalizedRegistrationHints,

            /// <summary>
            /// The localized subject field.
            /// </summary>
            [XurrentEnum("localized_subject", IgnoreInFieldSelection = true)]
            LocalizedSubject,

            /// <summary>
            /// The member field.
            /// </summary>
            [XurrentEnum("member")]
            Member,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The note field.
            /// </summary>
            [XurrentEnum("note")]
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
            /// The registration hints field.
            /// </summary>
            [XurrentEnum("registration_hints")]
            RegistrationHints,

            /// <summary>
            /// The registration hints attachments field.
            /// </summary>
            [XurrentEnum("registration_hints_attachments", IgnoreInFieldSelection = true)]
            RegistrationHintsAttachments,

            /// <summary>
            /// The rfc type field.
            /// </summary>
            [XurrentEnum("rfc_type")]
            RfcType,

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
            /// The specialists field.
            /// </summary>
            [XurrentEnum("specialists")]
            Specialists,

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
            /// The support hours field.
            /// </summary>
            [XurrentEnum("support_hours")]
            SupportHours,

            /// <summary>
            /// The team field.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// The time zone field.
            /// </summary>
            [XurrentEnum("time_zone")]
            TimeZone,

            /// <summary>
            /// The times applied field.
            /// </summary>
            [XurrentEnum("times_applied")]
            TimesApplied,

            /// <summary>
            /// The translate subject field.
            /// </summary>
            [XurrentEnum("translate_subject")]
            TranslateSubject,

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
            /// The workflow manager field.
            /// </summary>
            [XurrentEnum("workflow_manager")]
            WorkflowManager,

            /// <summary>
            /// The workflow template field.
            /// </summary>
            [XurrentEnum("workflow_template")]
            WorkflowTemplate
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="RequestTemplate"/> object.
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
            /// Filters by whether the request template is disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

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
            /// Filters by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

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
            UpdatedAt,

            /// <summary>
            /// Filters by workflow template.
            /// </summary>
            [XurrentEnum("workflow_template")]
            WorkflowTemplate
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="RequestTemplate"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled request templates.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled request templates.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="RequestTemplate"/> object.
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
            /// Sorts by impact.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// Sorts by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

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

        private RequestActionType? _actionType;
        private bool? _assetSelection;
        private bool? _assignAfterWorkflowCompletion;
        private bool? _assignToSelf;
        private List<Attachment>? _attachments;
        private RequestCategory? _category;
        private RequestCompletionReason? _completionReason;
        private ConfigurationItem? _configurationItem;
        private bool? _copySubjectToRequests;
        private DateTime? _createdAt;
        private string? _description;
        private int? _desiredCompletion;
        private bool? _disabled;
        private EffortClass? _effortClass;
        private bool? _endUsers;
        private RequestImpact? _impact;
        private string? _instructions;
        private ObservableCollection<AttachmentReference>? _instructionsAttachments;
        private AttachmentReferenceWriter? _instructionsAttachmentsWriter;
        private string? _keywords;
        private string? _localizedKeywords;
        private string? _localizedNote;
        private string? _localizedRegistrationHints;
        private string? _localizedSubject;
        private Person? _member;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private int? _plannedEffort;
        private string? _registrationHints;
        private ObservableCollection<AttachmentReference>? _registrationHintsAttachments;
        private AttachmentReferenceWriter? _registrationHintsAttachmentsWriter;
        private string? _rfcType;
        private Service? _service;
        private string? _source;
        private string? _sourceID;
        private bool? _specialists;
        private RequestStatus? _status;
        private string? _subject;
        private Organization? _supplier;
        private Calendar? _supportHours;
        private Team? _team;
        private string? _timeZone;
        private int? _timesApplied;
        private bool? _translateSubject;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;
        private bool? _urgent;
        private Person? _workflowManager;
        private WorkflowTemplate? _workflowTemplate;

        /// <summary>
        /// Gets or sets the request action type.
        /// </summary>
        [XurrentField("action_type")]
        public RequestActionType? ActionType
        {
            get => _actionType;
            set => _actionType = SetValue("action_type", _actionType, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether a configuration item must be selected when the template is applied.
        /// </summary>
        [XurrentField("asset_selection")]
        public bool? AssetSelection
        {
            get => _assetSelection;
            set => _assetSelection = SetValue("asset_selection", _assetSelection, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the request is assigned to the specified team after the workflow is completed.
        /// </summary>
        [XurrentField("assign_after_workflow_completion")]
        public bool? AssignAfterWorkflowCompletion
        {
            get => _assignAfterWorkflowCompletion;
            set => _assignAfterWorkflowCompletion = SetValue("assign_after_workflow_completion", _assignAfterWorkflowCompletion, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the member is set to the person registering the request.
        /// </summary>
        [XurrentField("assign_to_self")]
        public bool? AssignToSelf
        {
            get => _assignToSelf;
            set => _assignToSelf = SetValue("assign_to_self", _assignToSelf, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the request template.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the category that is applied when a request is created using the template.
        /// </summary>
        [XurrentField("category")]
        public RequestCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets or sets the completion reason that is applied when a request is created using the template.
        /// </summary>
        [XurrentField("completion_reason")]
        public RequestCompletionReason? CompletionReason
        {
            get => _completionReason;
            set => _completionReason = SetValue("completion_reason", _completionReason, value);
        }

        /// <summary>
        /// Gets or sets the configuration item associated with the request template.
        /// </summary>
        [XurrentField("ci")]
        public ConfigurationItem? ConfigurationItem
        {
            get => _configurationItem;
            set => _configurationItem = SetValue("ci", _configurationItem, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the template subject is copied to a request when its subject is empty.
        /// </summary>
        [XurrentField("copy_subject_to_requests")]
        public bool? CopySubjectToRequests
        {
            get => _copySubjectToRequests;
            set => _copySubjectToRequests = SetValue("copy_subject_to_requests", _copySubjectToRequests, value);
        }

        /// <summary>
        /// Gets the date and time when the request template was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the description of the request template.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        /// <summary>
        /// Gets or sets the desired completion time for requests created using the template.
        /// </summary>
        [XurrentField("desired_completion")]
        public int? DesiredCompletion
        {
            get => _desiredCompletion;
            set => _desiredCompletion = SetValue("desired_completion", _desiredCompletion, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the request template is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the effort class of the request template.
        /// </summary>
        [XurrentField("effort_class")]
        public EffortClass? EffortClass
        {
            get => _effortClass;
            set => _effortClass = SetValue("effort_class", _effortClass, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the request template is available to end users.
        /// </summary>
        [XurrentField("end_users")]
        public bool? EndUsers
        {
            get => _endUsers;
            set => _endUsers = SetValue("end_users", _endUsers, value);
        }

        /// <summary>
        /// Gets or sets the impact that is applied when a request is created using the template.
        /// </summary>
        [XurrentField("impact")]
        public RequestImpact? Impact
        {
            get => _impact;
            set => _impact = SetValue("impact", _impact, value);
        }

        /// <summary>
        /// Gets or sets the instructions of the request template.
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
        /// Gets or sets the keywords used to find the request template.
        /// </summary>
        [XurrentField("keywords")]
        public string? Keywords
        {
            get => _keywords;
            set => _keywords = SetValue("keywords", _keywords, value);
        }

        /// <summary>
        /// Gets the localized keywords in the current language.
        /// </summary>
        [XurrentField("localized_keywords")]
        public string? LocalizedKeywords
        {
            get => _localizedKeywords;
            internal set => _localizedKeywords = value;
        }

        /// <summary>
        /// Gets the localized note in the current language.
        /// </summary>
        [XurrentField("localized_note")]
        public string? LocalizedNote
        {
            get => _localizedNote;
            internal set => _localizedNote = value;
        }

        /// <summary>
        /// Gets the localized registration hints in the current language.
        /// </summary>
        [XurrentField("localized_registration_hints")]
        public string? LocalizedRegistrationHints
        {
            get => _localizedRegistrationHints;
            internal set => _localizedRegistrationHints = value;
        }

        /// <summary>
        /// Gets the localized subject in the current language.
        /// </summary>
        [XurrentField("localized_subject")]
        public string? LocalizedSubject
        {
            get => _localizedSubject;
            internal set => _localizedSubject = value;
        }

        /// <summary>
        /// Gets or sets the member that is applied when a request is created using the template.
        /// </summary>
        [XurrentField("member")]
        public Person? Member
        {
            get => _member;
            set => _member = SetValue("member", _member, value);
        }

        /// <summary>
        /// Gets or sets the note that is applied when a request is created using the template.
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
        /// Gets or sets the planned effort, expressed in minutes, for requests created using the template.
        /// </summary>
        [XurrentField("planned_effort")]
        public int? PlannedEffort
        {
            get => _plannedEffort;
            set => _plannedEffort = SetValue("planned_effort", _plannedEffort, value);
        }

        /// <summary>
        /// Gets or sets the registration hints of the request template.
        /// </summary>
        [XurrentField("registration_hints")]
        public string? RegistrationHints
        {
            get => _registrationHints;
            set => _registrationHints = SetValue("registration_hints", _registrationHints, value);
        }

        [XurrentField("registration_hints_attachments")]
        internal ObservableCollection<AttachmentReference> RegistrationHintsAttachmentsCollection
        {
            get => GetCollection(ref _registrationHintsAttachments, OnRegistrationHintsAttachmentsChanged);
            set => SetCollection(ref _registrationHintsAttachments, "registration_hints_attachments", value, OnRegistrationHintsAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the registration hints field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter RegistrationHintsAttachments
        {
            get
            {
                _registrationHintsAttachmentsWriter ??= new AttachmentReferenceWriter(() => RegistrationHintsAttachmentsCollection, c => RegistrationHintsAttachmentsCollection = c);
                return _registrationHintsAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the RFC type reference of the request template.<br />
        /// This value must be the reference field of the related RFC type.
        /// </summary>
        [XurrentField("rfc_type")]
        public string? RfcType
        {
            get => _rfcType;
            set => _rfcType = SetValue("rfc_type", _rfcType, value);
        }

        /// <summary>
        /// Gets or sets the service associated with the request template.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the source of the request template.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the request template.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the request template is available to specialists.
        /// </summary>
        [XurrentField("specialists")]
        public bool? Specialists
        {
            get => _specialists;
            set => _specialists = SetValue("specialists", _specialists, value);
        }

        /// <summary>
        /// Gets or sets the status that is applied when a request is created using the template.
        /// </summary>
        [XurrentField("status")]
        public RequestStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the subject of the request template.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets or sets the supplier that is applied when a request is created using the template.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the calendar used to calculate the desired completion for requests created using the template.
        /// </summary>
        [XurrentField("support_hours")]
        public Calendar? SupportHours
        {
            get => _supportHours;
            set => _supportHours = SetValue("support_hours", _supportHours, value);
        }

        /// <summary>
        /// Gets or sets the team that is applied when a request is created using the template.
        /// </summary>
        [XurrentField("team")]
        public Team? Team
        {
            get => _team;
            set => _team = SetValue("team", _team, value);
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the request template.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the number of times the request template was applied.
        /// </summary>
        [XurrentField("times_applied")]
        public int? TimesApplied
        {
            get => _timesApplied;
            internal set => _timesApplied = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the subject of requests created from this template is automatically translated to the viewer's language.<br />
        /// When <see langword="false"/>, the subject is always displayed in its original language.
        /// </summary>
        [XurrentField("translate_subject")]
        public bool? TranslateSubject
        {
            get => _translateSubject;
            set => _translateSubject = SetValue("translate_subject", _translateSubject, value);
        }

        /// <summary>
        /// Gets or sets the UI extension associated with the request template.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            set => _uiExtension = SetValue("ui_extension", _uiExtension, value);
        }

        /// <summary>
        /// Gets the date and time when the request template was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether requests created using the template are marked as urgent.
        /// </summary>
        [XurrentField("urgent")]
        public bool? Urgent
        {
            get => _urgent;
            set => _urgent = SetValue("urgent", _urgent, value);
        }

        /// <summary>
        /// Gets or sets the workflow manager associated with the request template.
        /// </summary>
        [XurrentField("workflow_manager")]
        public Person? WorkflowManager
        {
            get => _workflowManager;
            set => _workflowManager = SetValue("workflow_manager", _workflowManager, value);
        }

        /// <summary>
        /// Gets or sets the workflow template associated with the request template.
        /// </summary>
        [XurrentField("workflow_template")]
        public WorkflowTemplate? WorkflowTemplate
        {
            get => _workflowTemplate;
            set => _workflowTemplate = SetValue("workflow_template", _workflowTemplate, value);
        }

        /// <summary>
        /// Creates a new request template instance.
        /// </summary>
        public RequestTemplate()
        {
        }

        /// <summary>
        /// Creates a new request template instance.
        /// </summary>
        /// <param name="id">The unique identifier of the request template.</param>
        public RequestTemplate(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new request template instance.
        /// </summary>
        /// <param name="subject">The subject of the request template.</param>
        public RequestTemplate(string subject)
        {
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

        private void OnRegistrationHintsAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "registration_hints_attachments");
        }
    }
}
