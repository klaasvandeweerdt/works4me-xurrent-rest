using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent reservation object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Reservation : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Reservation"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The configuration item field.
            /// </summary>
            [XurrentEnum("ci")]
            ConfigurationItem,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The end at field.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

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
            /// The only this occurrence field.
            /// </summary>
            [XurrentEnum("only_this_occurrence")]
            OnlyThisOccurrence,

            /// <summary>
            /// The person field.
            /// </summary>
            [XurrentEnum("person")]
            Person,

            /// <summary>
            /// The preparation start at field.
            /// </summary>
            [XurrentEnum("preparation_start_at")]
            PreparationStartAt,

            /// <summary>
            /// The recurrence field.
            /// </summary>
            [XurrentEnum("recurrence")]
            Recurrence,

            /// <summary>
            /// The request field.
            /// </summary>
            [XurrentEnum("request")]
            Request,

            /// <summary>
            /// The reservation offering field.
            /// </summary>
            [XurrentEnum("reservation_offering")]
            ReservationOffering,

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
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Reservation"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by the end date.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

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
            /// Filters by the start date.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// Filters by the status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Reservation"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all reservations that are ended or canceled.
            /// </summary>
            [XurrentEnum("completed")]
            Completed,

            /// <summary>
            /// Lists all reservations that are not ended or canceled.
            /// </summary>
            [XurrentEnum("open")]
            Open
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Reservation"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts by the end date.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

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
            /// Sorts by the start date.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// Sorts by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private ConfigurationItem? _configurationItem;
        private DateTime? _createdAt;
        private DateTime? _endAt;
        private string? _name;
        private bool? _onlyThisOccurrence;
        private Person? _person;
        private DateTime? _preparationStartAt;
        private Recurrence? _recurrence;
        private Request? _request;
        private ReservationOffering? _reservationOffering;
        private string? _source;
        private string? _sourceID;
        private DateTime? _startAt;
        private ReservationStatus? _status;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets the configuration item that is reserved.
        /// </summary>
        [XurrentField("ci")]
        public ConfigurationItem? ConfigurationItem
        {
            get => _configurationItem;
            set => _configurationItem = SetValue("ci", _configurationItem, value);
        }

        /// <summary>
        /// Gets the date and time when the reservation was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the date and time when the reservation ends.
        /// </summary>
        [XurrentField("end_at")]
        public DateTime? EndAt
        {
            get => _endAt;
            set => _endAt = SetValue("end_at", _endAt, value);
        }

        /// <summary>
        /// Gets or sets the name of the reservation.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether only this occurrence is affected.
        /// </summary>
        [XurrentField("only_this_occurrence")]
        public bool? OnlyThisOccurrence
        {
            get => _onlyThisOccurrence;
            set => _onlyThisOccurrence = SetValue("only_this_occurrence", _onlyThisOccurrence, value);
        }

        /// <summary>
        /// Gets or sets the person for whom the reservation is made.
        /// </summary>
        [XurrentField("person")]
        public Person? Person
        {
            get => _person;
            set => _person = SetValue("person", _person, value);
        }

        /// <summary>
        /// Gets the date and time when preparation for the reservation starts.
        /// </summary>
        [XurrentField("preparation_start_at")]
        public DateTime? PreparationStartAt
        {
            get => _preparationStartAt;
            internal set => _preparationStartAt = value;
        }

        /// <summary>
        /// Gets the recurrence settings of the reservation.
        /// </summary>
        [XurrentField("recurrence")]
        public Recurrence? Recurrence
        {
            get => _recurrence;
            internal set => _recurrence = value;
        }

        /// <summary>
        /// Gets or sets the request associated with the reservation.
        /// </summary>
        [XurrentField("request")]
        public Request? Request
        {
            get => _request;
            set => _request = SetValue("request", _request, value);
        }

        /// <summary>
        /// Gets or sets the reservation offering associated with the reservation.
        /// </summary>
        [XurrentField("reservation_offering")]
        public ReservationOffering? ReservationOffering
        {
            get => _reservationOffering;
            set => _reservationOffering = SetValue("reservation_offering", _reservationOffering, value);
        }

        /// <summary>
        /// Gets or sets the source of the reservation.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the reservation.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the date and time when the reservation starts.
        /// </summary>
        [XurrentField("start_at")]
        public DateTime? StartAt
        {
            get => _startAt;
            set => _startAt = SetValue("start_at", _startAt, value);
        }

        /// <summary>
        /// Gets or sets the status of the reservation.
        /// </summary>
        [XurrentField("status")]
        public ReservationStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets the date and time when the reservation was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new reservation instance.
        /// </summary>
        public Reservation()
        {
        }

        /// <summary>
        /// Creates a new reservation instance.
        /// </summary>
        /// <param name="id">The unique identifier of the reservation.</param>
        public Reservation(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new reservation instance.
        /// </summary>
        /// <param name="configurationItem">The configuration item of the reservation.</param>
        /// <param name="endAt">The end at of the reservation.</param>
        /// <param name="person">The person of the reservation.</param>
        /// <param name="startAt">The start at of the reservation.</param>
        /// <param name="status">The status of the reservation.</param>
        public Reservation(ConfigurationItem configurationItem, DateTime endAt, Person person, DateTime startAt, ReservationStatus status)
        {
            _configurationItem = SetValue("ci", configurationItem);
            _endAt = SetValue("end_at", endAt);
            _person = SetValue("person", person);
            _startAt = SetValue("start_at", startAt);
            _status = SetValue("status", status);
        }
    }
}
