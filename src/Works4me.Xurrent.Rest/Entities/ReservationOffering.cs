using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent reservation offering object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ReservationOffering : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ReservationOffering"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The allow repeat field.
            /// </summary>
            [XurrentEnum("allow_repeat")]
            AllowRepeat,

            /// <summary>
            /// The calendar field.
            /// </summary>
            [XurrentEnum("calendar")]
            Calendar,

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
            /// The filters field.
            /// </summary>
            [XurrentEnum("filters")]
            Filters,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The initial status field.
            /// </summary>
            [XurrentEnum("initial_status")]
            InitialStatus,

            /// <summary>
            /// The max advance duration field.
            /// </summary>
            [XurrentEnum("max_advance_duration")]
            MaxAdvanceDuration,

            /// <summary>
            /// The max duration field.
            /// </summary>
            [XurrentEnum("max_duration")]
            MaxDuration,

            /// <summary>
            /// The min advance duration field.
            /// </summary>
            [XurrentEnum("min_advance_duration")]
            MinAdvanceDuration,

            /// <summary>
            /// The min duration field.
            /// </summary>
            [XurrentEnum("min_duration")]
            MinDuration,

            /// <summary>
            /// The multi day field.
            /// </summary>
            [XurrentEnum("multi_day")]
            MultiDay,

            /// <summary>
            /// The name field.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The preparation duration field.
            /// </summary>
            [XurrentEnum("preparation_duration")]
            PreparationDuration,

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
            /// The step duration field.
            /// </summary>
            [XurrentEnum("step_duration")]
            StepDuration,

            /// <summary>
            /// The time zone field.
            /// </summary>
            [XurrentEnum("time_zone")]
            TimeZone,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ReservationOffering"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by whether the reservation offering is disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters by the name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters by the source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ReservationOffering"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled reservation offerings.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled reservation offerings.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ReservationOffering"/> object.
        /// </summary>
        public enum OrderField
        {
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
            /// Sorts by the name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private bool? _allowRepeat;
        private Calendar? _calendar;
        private DateTime? _createdAt;
        private bool? _disabled;
        private ObservableCollection<string>? _filters;
        private ServiceOfferingStatus? _initialStatus;
        private int? _maxAdvanceDuration;
        private int? _maxDuration;
        private int? _minAdvanceDuration;
        private int? _minDuration;
        private bool? _multiDay;
        private string? _name;
        private int? _preparationDuration;
        private ServiceInstance? _serviceInstance;
        private string? _source;
        private string? _sourceID;
        private int? _stepDuration;
        private string? _timeZone;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets a value indicating whether recurrent reservations can be created for this offering.
        /// </summary>
        [XurrentField("allow_repeat")]
        public bool? AllowRepeat
        {
            get => _allowRepeat;
            set => _allowRepeat = SetValue("allow_repeat", _allowRepeat, value);
        }

        /// <summary>
        /// Gets or sets the calendar that defines the hours during which configuration items are available.
        /// </summary>
        [XurrentField("calendar")]
        public Calendar? Calendar
        {
            get => _calendar;
            set => _calendar = SetValue("calendar", _calendar, value);
        }

        /// <summary>
        /// Gets the date and time when the reservation offering was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the reservation offering is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the filters that can be used to limit the available configuration items.
        /// </summary>
        [XurrentField("filters")]
        public ObservableCollection<string> Filters
        {
            get => GetCollection(ref _filters, OnFiltersChanged);
            set => SetCollection(ref _filters, "filters", value, OnFiltersChanged);
        }

        /// <summary>
        /// Gets or sets the initial status applied to reservations created using this offering.
        /// </summary>
        [XurrentField("initial_status")]
        public ServiceOfferingStatus? InitialStatus
        {
            get => _initialStatus;
            set => _initialStatus = SetValue("initial_status", _initialStatus, value);
        }

        /// <summary>
        /// Gets or sets the maximum amount of time in advance that a reservation can be scheduled.
        /// </summary>
        [XurrentField("max_advance_duration")]
        public int? MaxAdvanceDuration
        {
            get => _maxAdvanceDuration;
            set => _maxAdvanceDuration = SetValue("max_advance_duration", _maxAdvanceDuration, value);
        }

        /// <summary>
        /// Gets or sets the maximum duration for which a configuration item can be reserved.
        /// </summary>
        [XurrentField("max_duration")]
        public int? MaxDuration
        {
            get => _maxDuration;
            set => _maxDuration = SetValue("max_duration", _maxDuration, value);
        }

        /// <summary>
        /// Gets or sets the minimum advance notice required before a reservation can start.
        /// </summary>
        [XurrentField("min_advance_duration")]
        public int? MinAdvanceDuration
        {
            get => _minAdvanceDuration;
            set => _minAdvanceDuration = SetValue("min_advance_duration", _minAdvanceDuration, value);
        }

        /// <summary>
        /// Gets or sets the minimum duration of a reservation.
        /// </summary>
        [XurrentField("min_duration")]
        public int? MinDuration
        {
            get => _minDuration;
            set => _minDuration = SetValue("min_duration", _minDuration, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether reservations can span multiple days.
        /// </summary>
        [XurrentField("multi_day")]
        public bool? MultiDay
        {
            get => _multiDay;
            set => _multiDay = SetValue("multi_day", _multiDay, value);
        }

        /// <summary>
        /// Gets or sets the name of the reservation offering.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the time required to prepare a configuration item between reservations.
        /// </summary>
        [XurrentField("preparation_duration")]
        public int? PreparationDuration
        {
            get => _preparationDuration;
            set => _preparationDuration = SetValue("preparation_duration", _preparationDuration, value);
        }

        /// <summary>
        /// Gets or sets the service instance required to use the reservation offering.
        /// </summary>
        [XurrentField("service_instance")]
        public ServiceInstance? ServiceInstance
        {
            get => _serviceInstance;
            set => _serviceInstance = SetValue("service_instance", _serviceInstance, value);
        }

        /// <summary>
        /// Gets or sets the source of the reservation offering.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the reservation offering.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the time increment used for reservation durations.
        /// </summary>
        [XurrentField("step_duration")]
        public int? StepDuration
        {
            get => _stepDuration;
            set => _stepDuration = SetValue("step_duration", _stepDuration, value);
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the reservation offering.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the date and time when the reservation offering was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new reservation offering instance.
        /// </summary>
        public ReservationOffering()
        {
        }

        /// <summary>
        /// Creates a new reservation offering instance.
        /// </summary>
        /// <param name="id">The unique identifier of the reservation offering.</param>
        public ReservationOffering(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new reservation offering instance.
        /// </summary>
        /// <param name="calendar">The calendar of the reservation offering.</param>
        /// <param name="initialStatus">The initial status of the reservation offering.</param>
        /// <param name="maxDuration">The max duration of the reservation offering.</param>
        /// <param name="minDuration">The min duration of the reservation offering.</param>
        /// <param name="serviceInstance">The service instance of the reservation offering.</param>
        /// <param name="stepDuration">The step duration of the reservation offering.</param>
        /// <param name="timeZone">The time zone of the reservation offering.</param>
        public ReservationOffering(Calendar calendar, ServiceOfferingStatus initialStatus, int maxDuration, int minDuration, ServiceInstance serviceInstance, int stepDuration, string timeZone)
        {
            _calendar = SetValue("calendar", calendar);
            _initialStatus = SetValue("initial_status", initialStatus);
            _maxDuration = SetValue("max_duration", maxDuration);
            _minDuration = SetValue("min_duration", minDuration);
            _serviceInstance = SetValue("service_instance", serviceInstance);
            _stepDuration = SetValue("step_duration", stepDuration);
            _timeZone = SetValue("time_zone", timeZone);
        }

        private void OnFiltersChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<string> collection)
                MarkCollectionChanged(collection, "filters");
        }
    }
}
