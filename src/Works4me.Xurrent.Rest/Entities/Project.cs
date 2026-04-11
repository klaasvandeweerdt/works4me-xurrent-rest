using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent project object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Project : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Project"/> object.
        /// </summary>
        public enum Field
        {
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
            /// The cost of effort field.
            /// </summary>
            [XurrentEnum("cost_of_effort")]
            CostOfEffort,

            /// <summary>
            /// The cost of purchases field.
            /// </summary>
            [XurrentEnum("cost_of_purchases")]
            CostOfPurchases,

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
            /// The customer field.
            /// </summary>
            [XurrentEnum("customer")]
            Customer,

            /// <summary>
            /// The effort field.
            /// </summary>
            [XurrentEnum("effort")]
            Effort,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

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
            /// The program field.
            /// </summary>
            [XurrentEnum("program")]
            Program,

            /// <summary>
            /// The resolution duration field.
            /// </summary>
            [XurrentEnum("resolution_duration")]
            ResolutionDuration,

            /// <summary>
            /// The risk level field.
            /// </summary>
            [XurrentEnum("risk_level")]
            RiskLevel,

            /// <summary>
            /// The roi field.
            /// </summary>
            [XurrentEnum("roi")]
            Roi,

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
            /// The time zone field.
            /// </summary>
            [XurrentEnum("time_zone")]
            TimeZone,

            /// <summary>
            /// The total cost field.
            /// </summary>
            [XurrentEnum("total_cost")]
            TotalCost,

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
            /// The value field.
            /// </summary>
            [XurrentEnum("value")]
            Value,

            /// <summary>
            /// The value currency field.
            /// </summary>
            [XurrentEnum("value_currency")]
            ValueCurrency,

            /// <summary>
            /// The work hours field.
            /// </summary>
            [XurrentEnum("work_hours")]
            WorkHours
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Project"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters projects by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Filters projects by completion date.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Filters projects by completion target date.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Filters projects by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters projects by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters projects by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Filters projects by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters projects by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters projects by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters projects by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Filters projects by last updated date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Project"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all completed projects.
            /// </summary>
            [XurrentEnum("completed")]
            Completed,

            /// <summary>
            /// Lists all projects that are managed by the API user.
            /// </summary>
            [XurrentEnum("managed_by_me")]
            ManagedByMe,

            /// <summary>
            /// Lists all open projects.
            /// </summary>
            [XurrentEnum("open")]
            Open
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Project"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts projects by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Sorts projects by completion date.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Sorts projects by completion target date.
            /// </summary>
            [XurrentEnum("completion_target_at")]
            CompletionTargetAt,

            /// <summary>
            /// Sorts projects by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts projects by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts projects by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Sorts projects by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts projects by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts projects by subject.
            /// </summary>
            [XurrentEnum("subject")]
            Subject,

            /// <summary>
            /// Sorts projects by last updated date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private string? _category;
        private DateTime? _completedAt;
        private ProjectCompletionReason? _completionReason;
        private DateTime? _completionTargetAt;
        private decimal? _costOfEffort;
        private decimal? _costOfPurchases;
        private DateTime? _createdAt;
        private Organization? _customer;
        private int? _effort;
        private ProjectJustification? _justification;
        private Person? _manager;
        private string? _note;
        private ObservableCollection<AttachmentReference>? _noteAttachments;
        private AttachmentReferenceWriter? _noteAttachmentsWriter;
        private string? _program;
        private int? _resolutionDuration;
        private string? _riskLevel;
        private int? _roi;
        private Service? _service;
        private string? _source;
        private string? _sourceID;
        private ProjectStatus? _status;
        private string? _subject;
        private string? _timeZone;
        private decimal? _totalCost;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;
        private decimal? _value;
        private Currency? _valueCurrency;
        private Calendar? _workHours;

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
        /// Gets or sets the project category reference of the project.<br />
        /// This value must be the reference field of the related project category.
        /// </summary>
        [XurrentField("category")]
        public string? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets the date and time at which the project was completed.
        /// </summary>
        [XurrentField("completed_at")]
        public DateTime? CompletedAt
        {
            get => _completedAt;
            internal set => _completedAt = value;
        }

        /// <summary>
        /// Gets or sets the completion reason reference of the project.
        /// </summary>
        [XurrentField("completion_reason")]
        public ProjectCompletionReason? CompletionReason
        {
            get => _completionReason;
            set => _completionReason = SetValue("completion_reason", _completionReason, value);
        }

        /// <summary>
        /// Gets the completion target date and time of the project.
        /// </summary>
        [XurrentField("completion_target_at")]
        public DateTime? CompletionTargetAt
        {
            get => _completionTargetAt;
            internal set => _completionTargetAt = value;
        }

        /// <summary>
        /// Gets or sets the estimated cost of effort for the project.
        /// </summary>
        [XurrentField("cost_of_effort")]
        public decimal? CostOfEffort
        {
            get => _costOfEffort;
            set => _costOfEffort = SetValue("cost_of_effort", _costOfEffort, value);
        }

        /// <summary>
        /// Gets or sets the estimated cost of purchases for the project.
        /// </summary>
        [XurrentField("cost_of_purchases")]
        public decimal? CostOfPurchases
        {
            get => _costOfPurchases;
            set => _costOfPurchases = SetValue("cost_of_purchases", _costOfPurchases, value);
        }

        /// <summary>
        /// Gets the date and time at which the project was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the customer organization of the project.
        /// </summary>
        [XurrentField("customer")]
        public Organization? Customer
        {
            get => _customer;
            set => _customer = SetValue("customer", _customer, value);
        }

        /// <summary>
        /// Gets or sets the estimated effort, in hours.
        /// </summary>
        [XurrentField("effort")]
        public int? Effort
        {
            get => _effort;
            set => _effort = SetValue("effort", _effort, value);
        }

        /// <summary>
        /// Gets or sets the justification reference of the project.
        /// </summary>
        [XurrentField("justification")]
        public ProjectJustification? Justification
        {
            get => _justification;
            set => _justification = SetValue("justification", _justification, value);
        }

        /// <summary>
        /// Gets or sets the manager of the project.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Sets the note of the project.<br />
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
        /// Gets or sets the program that the project is a part of.
        /// </summary>
        [XurrentField("program")]
        public string? Program
        {
            get => _program;
            set => _program = SetValue("program", _program, value);
        }

        /// <summary>
        /// Gets the number of minutes it took to complete the project.
        /// </summary>
        [XurrentField("resolution_duration")]
        public int? ResolutionDuration
        {
            get => _resolutionDuration;
            set => _resolutionDuration = SetValue("resolution_duration", _resolutionDuration, value);
        }

        /// <summary>
        /// Gets or sets the project risk level reference of the project.<br />
        /// This value must be the reference field of the related project risk level.
        /// </summary>
        [XurrentField("risk_level")]
        public string? RiskLevel
        {
            get => _riskLevel;
            set => _riskLevel = SetValue("risk_level", _riskLevel, value);
        }

        /// <summary>
        /// Gets or sets the estimated return on investment percentage of the project.
        /// </summary>
        [XurrentField("roi")]
        public int? Roi
        {
            get => _roi;
            set => _roi = SetValue("roi", _roi, value);
        }

        /// <summary>
        /// Gets or sets the service of the project.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the source of the project.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the project.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the status reference of the project.
        /// </summary>
        [XurrentField("status")]
        public ProjectStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the subject of the project.
        /// </summary>
        [XurrentField("subject")]
        public string? Subject
        {
            get => _subject;
            set => _subject = SetValue("subject", _subject, value);
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the project.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the total estimated cost of the project.
        /// </summary>
        [XurrentField("total_cost")]
        public decimal? TotalCost
        {
            get => _totalCost;
            internal set => _totalCost = value;
        }

        /// <summary>
        /// Gets the UI extension of the project.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time at which the project was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the value of the project.
        /// </summary>
        [XurrentField("value")]
        public decimal? Value
        {
            get => _value;
            set => _value = SetValue("value", _value, value);
        }

        /// <summary>
        /// Gets or sets the currency reference of the project value.
        /// </summary>
        [XurrentField("value_currency")]
        public Currency? ValueCurrency
        {
            get => _valueCurrency;
            set => _valueCurrency = SetValue("value_currency", _valueCurrency, value);
        }

        /// <summary>
        /// Gets or sets the work hours calendar of the project.
        /// </summary>
        [XurrentField("work_hours")]
        public Calendar? WorkHours
        {
            get => _workHours;
            set => _workHours = SetValue("work_hours", _workHours, value);
        }

        /// <summary>
        /// Creates a new project instance.
        /// </summary>
        public Project()
        {
        }

        /// <summary>
        /// Creates a new project instance.
        /// </summary>
        /// <param name="id">The unique identifier of the project.</param>
        public Project(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new project instance.
        /// </summary>
        /// <param name="customer">The customer of the project.</param>
        /// <param name="justification">The justification of the project.</param>
        /// <param name="manager">The manager of the project.</param>
        /// <param name="program">The program of the project.</param>
        /// <param name="service">The service of the project.</param>
        /// <param name="timeZone">The time zone of the project.</param>
        /// <param name="workHours">The work hours of the project.</param>
        public Project(Organization customer, ProjectJustification justification, Person manager, string program, Service service, string timeZone, Calendar workHours)
        {
            _customer = SetValue("customer", customer);
            _justification = SetValue("justification", justification);
            _manager = SetValue("manager", manager);
            _program = SetValue("program", program);
            _service = SetValue("service", service);
            _timeZone = SetValue("time_zone", timeZone);
            _workHours = SetValue("work_hours", workHours);
        }

        private void OnNoteAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "note_attachments");
        }
    }
}
