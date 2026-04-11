using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent time entry object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class TimeEntry : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="TimeEntry"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The activity identifier field.
            /// </summary>
            [XurrentEnum("activityID")]
            ActivityID,

            /// <summary>
            /// The agreement identifier field.
            /// </summary>
            [XurrentEnum("agreementID")]
            AgreementID,

            /// <summary>
            /// The charge field.
            /// </summary>
            [XurrentEnum("charge")]
            Charge,

            /// <summary>
            /// The charge currency field.
            /// </summary>
            [XurrentEnum("charge_currency")]
            ChargeCurrency,

            /// <summary>
            /// The charge rate field.
            /// </summary>
            [XurrentEnum("charge_rate")]
            ChargeRate,

            /// <summary>
            /// The charge type field.
            /// </summary>
            [XurrentEnum("charge_type")]
            ChargeType,

            /// <summary>
            /// The correction field.
            /// </summary>
            [XurrentEnum("correction")]
            Correction,

            /// <summary>
            /// The cost field.
            /// </summary>
            [XurrentEnum("cost")]
            Cost,

            /// <summary>
            /// The cost currency field.
            /// </summary>
            [XurrentEnum("cost_currency")]
            CostCurrency,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The customer field.
            /// </summary>
            [XurrentEnum("customer")]
            Customer,

            /// <summary>
            /// The date field.
            /// </summary>
            [XurrentEnum("date")]
            Date,

            /// <summary>
            /// The deleted field.
            /// </summary>
            [XurrentEnum("deleted")]
            Deleted,

            /// <summary>
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

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
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The note identifier field.
            /// </summary>
            [XurrentEnum("note_id")]
            NoteId,

            /// <summary>
            /// The note node identifier field.
            /// </summary>
            [XurrentEnum("note_nodeID", IgnoreInFieldSelection = true)]
            NoteNodeID,

            /// <summary>
            /// The organization field.
            /// </summary>
            [XurrentEnum("organization")]
            Organization,

            /// <summary>
            /// The person field.
            /// </summary>
            [XurrentEnum("person")]
            Person,

            /// <summary>
            /// The problem field.
            /// </summary>
            [XurrentEnum("problem", IgnoreInFieldSelection = true)]
            Problem,

            /// <summary>
            /// The project task field.
            /// </summary>
            [XurrentEnum("project_task", IgnoreInFieldSelection = true)]
            ProjectTask,

            /// <summary>
            /// The rate identifier field.
            /// </summary>
            [XurrentEnum("rateID")]
            RateID,

            /// <summary>
            /// The request field.
            /// </summary>
            [XurrentEnum("request", IgnoreInFieldSelection = true)]
            Request,

            /// <summary>
            /// The service field.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// The service level agreement field.
            /// </summary>
            [XurrentEnum("sla")]
            ServiceLevelAgreement,

            /// <summary>
            /// The started at field.
            /// </summary>
            [XurrentEnum("started_at")]
            StartedAt,

            /// <summary>
            /// The time allocation field.
            /// </summary>
            [XurrentEnum("time_allocation")]
            TimeAllocation,

            /// <summary>
            /// The time spent field.
            /// </summary>
            [XurrentEnum("time_spent")]
            TimeSpent,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The workflow task field.
            /// </summary>
            [XurrentEnum("task", IgnoreInFieldSelection = true)]
            WorkflowTask
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="TimeEntry"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters time entries by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters time entries by date.
            /// </summary>
            [XurrentEnum("date")]
            Date,

            /// <summary>
            /// Filters time entries by deletion status.
            /// </summary>
            [XurrentEnum("deleted")]
            Deleted,

            /// <summary>
            /// Filters time entries by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters time entries by person.
            /// </summary>
            [XurrentEnum("person")]
            Person,

            /// <summary>
            /// Filters time entries by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters time entries by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters time entries by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the absence of supported predefined filters for a query.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="TimeEntry"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts time entries by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts time entries by date.
            /// </summary>
            [XurrentEnum("date")]
            Date,

            /// <summary>
            /// Sorts time entries by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts time entries by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private string? _activityID;
        private string? _agreementID;
        private decimal? _charge;
        private Currency? _chargeCurrency;
        private decimal? _chargeRate;
        private ServiceOfferingChargeType? _chargeType;
        private bool? _correction;
        private decimal? _cost;
        private Currency? _costCurrency;
        private DateTime? _createdAt;
        private Organization? _customer;
#if (NET6_0_OR_GREATER)
        private DateOnly? _date;
#else
        private DateTime? _date;
#endif
        private bool? _deleted;
        private string? _description;
        private EffortClass? _effortClass;
        private long? _noteId;
        private string? _noteNodeID;
        private Organization? _organization;
        private Person? _person;
        private Problem? _problem;
        private ProjectTask? _projectTask;
        private string? _rateID;
        private Request? _request;
        private Service? _service;
        private ServiceLevelAgreement? _serviceLevelAgreement;
        private DateTime? _startedAt;
        private TimeAllocation? _timeAllocation;
        private int? _timeSpent;
        private DateTime? _updatedAt;
        private WorkflowTask? _workflowTask;

        /// <summary>
        /// Gets the identifier of the activity associated with the time entry.
        /// </summary>
        [XurrentField("activityID")]
        public string? ActivityID
        {
            get => _activityID;
            internal set => _activityID = value;
        }

        /// <summary>
        /// Gets the identifier of the agreement associated with the time entry.
        /// </summary>
        [XurrentField("agreementID")]
        public string? AgreementID
        {
            get => _agreementID;
            internal set => _agreementID = value;
        }

        /// <summary>
        /// Gets the charge amount of the time entry.
        /// </summary>
        [XurrentField("charge")]
        public decimal? Charge
        {
            get => _charge;
            internal set => _charge = value;
        }

        /// <summary>
        /// Gets the currency in which the charge amount is expressed.
        /// </summary>
        [XurrentField("charge_currency")]
        public Currency? ChargeCurrency
        {
            get => _chargeCurrency;
            internal set => _chargeCurrency = value;
        }

        /// <summary>
        /// Gets the charge rate applied to the time entry.
        /// </summary>
        [XurrentField("charge_rate")]
        public decimal? ChargeRate
        {
            get => _chargeRate;
            internal set => _chargeRate = value;
        }

        /// <summary>
        /// Gets the charge type applied to the time entry.
        /// </summary>
        [XurrentField("charge_type")]
        public ServiceOfferingChargeType? ChargeType
        {
            get => _chargeType;
            internal set => _chargeType = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the time entry is a correction.
        /// </summary>
        [XurrentField("correction")]
        public bool? Correction
        {
            get => _correction;
            set => _correction = SetValue("correction", _correction, value);
        }

        /// <summary>
        /// Gets the cost amount of the time entry.
        /// </summary>
        [XurrentField("cost")]
        public decimal? Cost
        {
            get => _cost;
            internal set => _cost = value;
        }

        /// <summary>
        /// Gets the currency in which the cost amount is expressed.
        /// </summary>
        [XurrentField("cost_currency")]
        public Currency? CostCurrency
        {
            get => _costCurrency;
            internal set => _costCurrency = value;
        }

        /// <summary>
        /// Gets the date and time when the time entry was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the customer organization for which the time was spent.
        /// </summary>
        [XurrentField("customer")]
        public Organization? Customer
        {
            get => _customer;
            set => _customer = SetValue("customer", _customer, value);
        }

        /// <summary>
        /// Gets or sets the date on which the time was spent.
        /// </summary>
        [XurrentField("date")]
#if (NET6_0_OR_GREATER)
        public DateOnly? Date
#else
        public DateTime? Date
#endif
        {
            get => _date;
            set => _date = SetValue("date", _date, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the time entry is deleted.
        /// </summary>
        [XurrentField("deleted")]
        public bool? Deleted
        {
            get => _deleted;
            set => _deleted = SetValue("deleted", _deleted, value);
        }

        /// <summary>
        /// Gets or sets the description of the time entry.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        /// <summary>
        /// Gets or sets the effort class associated with the time entry.
        /// </summary>
        [XurrentField("effort_class")]
        public EffortClass? EffortClass
        {
            get => _effortClass;
            set => _effortClass = SetValue("effort_class", _effortClass, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the note linked to the time entry.
        /// </summary>
        [XurrentField("note_id")]
        public long? NoteId
        {
            get => _noteId;
            set => _noteId = SetValue("note_id", _noteId, value);
        }

        /// <summary>
        /// Gets the node identifier of the note linked to the time entry.
        /// </summary>
        [XurrentField("note_nodeID")]
        public string? NoteNodeID
        {
            get => _noteNodeID;
            internal set => _noteNodeID = value;
        }

        /// <summary>
        /// Gets or sets the organization associated with the time entry.
        /// </summary>
        [XurrentField("organization")]
        public Organization? Organization
        {
            get => _organization;
            set => _organization = SetValue("organization", _organization, value);
        }

        /// <summary>
        /// Gets or sets the person who registered the time entry.
        /// </summary>
        [XurrentField("person")]
        public Person? Person
        {
            get => _person;
            set => _person = SetValue("person", _person, value);
        }

        /// <summary>
        /// Gets or sets the problem associated with the time entry.
        /// </summary>
        [XurrentField("problem")]
        public Problem? Problem
        {
            get => _problem;
            set => _problem = SetValue("problem", _problem, value);
        }

        /// <summary>
        /// Gets or sets the project task associated with the time entry.
        /// </summary>
        [XurrentField("project_task")]
        public ProjectTask? ProjectTask
        {
            get => _projectTask;
            set => _projectTask = SetValue("project_task", _projectTask, value);
        }

        /// <summary>
        /// Gets the identifier of the rate applied to the time entry.
        /// </summary>
        [XurrentField("rateID")]
        public string? RateID
        {
            get => _rateID;
            internal set => _rateID = value;
        }

        /// <summary>
        /// Gets or sets the request associated with the time entry.
        /// </summary>
        [XurrentField("request")]
        public Request? Request
        {
            get => _request;
            set => _request = SetValue("request", _request, value);
        }

        /// <summary>
        /// Gets or sets the service for which the time was spent.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets the service level agreement associated with the time entry.
        /// </summary>
        [XurrentField("sla")]
        public ServiceLevelAgreement? ServiceLevelAgreement
        {
            get => _serviceLevelAgreement;
            internal set => _serviceLevelAgreement = value;
        }

        /// <summary>
        /// Gets or sets the date and time when the time entry was started.
        /// </summary>
        [XurrentField("started_at")]
        public DateTime? StartedAt
        {
            get => _startedAt;
            set => _startedAt = SetValue("started_at", _startedAt, value);
        }

        /// <summary>
        /// Gets or sets the time allocation on which the time was spent.
        /// </summary>
        [XurrentField("time_allocation")]
        public TimeAllocation? TimeAllocation
        {
            get => _timeAllocation;
            set => _timeAllocation = SetValue("time_allocation", _timeAllocation, value);
        }

        /// <summary>
        /// Gets or sets the number of minutes spent.
        /// </summary>
        [XurrentField("time_spent")]
        public int? TimeSpent
        {
            get => _timeSpent;
            set => _timeSpent = SetValue("time_spent", _timeSpent, value);
        }

        /// <summary>
        /// Gets the date and time when the time entry was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the workflow task associated with the time entry.
        /// </summary>
        [XurrentField("task")]
        public WorkflowTask? WorkflowTask
        {
            get => _workflowTask;
            set => _workflowTask = SetValue("task", _workflowTask, value);
        }

        /// <summary>
        /// Creates a new time entry instance.
        /// </summary>
        public TimeEntry()
        {
        }

        /// <summary>
        /// Creates a new time entry instance.
        /// </summary>
        /// <param name="id">The unique identifier of the time entry.</param>
        public TimeEntry(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new time entry instance.
        /// </summary>
        /// <param name="customer">The customer of the time entry.</param>
        /// <param name="date">The date of the time entry.</param>
        /// <param name="description">The description of the time entry.</param>
        /// <param name="person">The person of the time entry.</param>
#if (NET6_0_OR_GREATER)
        public TimeEntry(Organization customer, DateOnly date, string description, Person person)
#else
        public TimeEntry(Organization customer, DateTime date, string description, Person person)
#endif
        {
            _customer = SetValue("customer", customer);
            _date = SetValue("date", date);
            _description = SetValue("description", description);
            _person = SetValue("person", person);
        }
    }
}
