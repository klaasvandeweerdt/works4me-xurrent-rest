using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent workflow template object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class WorkflowTemplate : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="WorkflowTemplate"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The assign relations to workflow manager field.
            /// </summary>
            [XurrentEnum("assign_relations_to_workflow_manager")]
            AssignRelationsToWorkflowManager,

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
            /// The justification field.
            /// </summary>
            [XurrentEnum("justification")]
            Justification,

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
            /// The prevent request completion field.
            /// </summary>
            [XurrentEnum("prevent_request_completion")]
            PreventRequestCompletion,

            /// <summary>
            /// The recurrence field.
            /// </summary>
            [XurrentEnum("recurrence")]
            Recurrence,

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
            /// The subject field.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

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
            /// The workflow manager field.
            /// </summary>
            [XurrentEnum("workflow_manager")]
            WorkflowManager,

            /// <summary>
            /// The workflow type field.
            /// </summary>
            [XurrentEnum("workflow_type")]
            WorkflowType
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="WorkflowTemplate"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters workflow templates by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters workflow templates by disabled state.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters workflow templates by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters workflow templates by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Filters workflow templates by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters workflow templates by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters workflow templates by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Filters workflow templates by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="WorkflowTemplate"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled workflow templates.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled workflow templates.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="WorkflowTemplate"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts workflow templates by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts workflow templates by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts workflow templates by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Sorts workflow templates by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts workflow templates by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts workflow templates by number of times applied.
            /// </summary>
            [XurrentEnum("times_applied")]
            TimesApplied,

            /// <summary>
            /// Sorts workflow templates by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private bool? _assignRelationsToWorkflowManager;
        private List<Attachment>? _attachments;
        private WorkflowCategory? _category;
        private DateTime? _createdAt;
        private bool? _disabled;
        private WorkflowImpact? _impact;
        private string? _instructions;
        private ObservableCollection<AttachmentReference>? _instructionsAttachments;
        private AttachmentReferenceWriter? _instructionsAttachmentsWriter;
        private WorkflowJustification? _justification;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private bool? _preventRequestCompletion;
        private Recurrence? _recurrence;
        private Service? _service;
        private string? _source;
        private string? _sourceID;
        private string? _subject;
        private int? _timesApplied;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;
        private Person? _workflowManager;
        private string? _workflowType;

        /// <summary>
        /// Gets or sets a value indicating whether relations are assigned to the workflow manager when they are linked to the workflow.
        /// </summary>
        [XurrentField("assign_relations_to_workflow_manager")]
        public bool? AssignRelationsToWorkflowManager
        {
            get => _assignRelationsToWorkflowManager;
            set => _assignRelationsToWorkflowManager = SetValue("assign_relations_to_workflow_manager", _assignRelationsToWorkflowManager, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments of the workflow template.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the workflow category selected for workflows created from the template.
        /// </summary>
        [XurrentField("category")]
        public WorkflowCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets the date and time at which the workflow template was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the workflow template is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets the maximum workflow task impact defined by the task templates of the workflow template.
        /// </summary>
        [XurrentField("impact")]
        public WorkflowImpact? Impact
        {
            get => _impact;
            internal set => _impact = value;
        }

        /// <summary>
        /// Gets or sets the instructions shown when a workflow is created from the template.
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
        /// Gets or sets the workflow justification selected for workflows created from the template.
        /// </summary>
        [XurrentField("justification")]
        public WorkflowJustification? Justification
        {
            get => _justification;
            set => _justification = SetValue("justification", _justification, value);
        }

        /// <summary>
        /// Gets or sets the note copied to workflows created from the template.
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
        /// Gets or sets a value indicating whether completion of related requests is prevented.
        /// </summary>
        [XurrentField("prevent_request_completion")]
        public bool? PreventRequestCompletion
        {
            get => _preventRequestCompletion;
            set => _preventRequestCompletion = SetValue("prevent_request_completion", _preventRequestCompletion, value);
        }

        /// <summary>
        /// Gets the recurrence settings of the workflow template.
        /// </summary>
        [XurrentField("recurrence")]
        public Recurrence? Recurrence
        {
            get => _recurrence;
            internal set => _recurrence = value;
        }

        /// <summary>
        /// Gets or sets the service selected for workflows created from the template.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the source of the workflow template.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the workflow template.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the subject copied to workflows created from the template.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets the number of times the workflow template was applied.
        /// </summary>
        [XurrentField("times_applied")]
        public int? TimesApplied
        {
            get => _timesApplied;
            internal set => _timesApplied = value;
        }

        /// <summary>
        /// Gets or sets the UI extension added to workflows created from the template.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            set => _uiExtension = SetValue("ui_extension", _uiExtension, value);
        }

        /// <summary>
        /// Gets the date and time at which the workflow template was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the workflow manager responsible for workflows created from the template.
        /// </summary>
        [XurrentField("workflow_manager")]
        public Person? WorkflowManager
        {
            get => _workflowManager;
            set => _workflowManager = SetValue("workflow_manager", _workflowManager, value);
        }

        /// <summary>
        /// Gets or sets the workflow type reference value used by the workflow template.
        /// </summary>
        [XurrentField("workflow_type")]
        public string? WorkflowType
        {
            get => _workflowType;
            set => _workflowType = SetValue("workflow_type", _workflowType, value);
        }

        /// <summary>
        /// Creates a new workflow template instance.
        /// </summary>
        public WorkflowTemplate()
        {
        }

        /// <summary>
        /// Creates a new workflow template instance.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow template.</param>
        public WorkflowTemplate(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new workflow template instance.
        /// </summary>
        /// <param name="subject">The subject of the workflow template.</param>
        public WorkflowTemplate(string subject)
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
    }
}
