using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent calendar object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Calendar : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Calendar"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The calendar hours field.
            /// </summary>
            [XurrentEnum("calendar_hours")]
            CalendarHours,

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
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Calendar"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters calendars by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters calendars by disabled status.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters calendars by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters calendars by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters calendars by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters calendars by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Calendar"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled calendars.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled calendars.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Calendar"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts calendars by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts calendars by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts calendars by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts calendars by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts calendars by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<CalendarHour>? _calendarHours;
        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _name;
        private string? _source;
        private string? _sourceID;
        private DateTime? _updatedAt;

        [XurrentField("calendar_hours")]
        internal List<CalendarHour>? CalendarHoursCollection
        {
            get => _calendarHours;
            set => _calendarHours = value;
        }

        /// <summary>
        /// Gets the read-only aggregated calendar hours.
        /// </summary>
        public ReadOnlyCollection<CalendarHour>? CalendarHours
        {
            get => _calendarHours is null ? null : new ReadOnlyCollection<CalendarHour>(_calendarHours);
        }

        /// <summary>
        /// Gets the date and time at which the calendar was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the calendar may no longer be related to other records.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the name of the calendar.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the source of the calendar.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the calendar.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the calendar.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new calendar instance.
        /// </summary>
        public Calendar()
        {
        }

        /// <summary>
        /// Creates a new calendar instance.
        /// </summary>
        /// <param name="id">The unique identifier of the calendar.</param>
        public Calendar(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new calendar instance.
        /// </summary>
        /// <param name="name">The name of the calendar.</param>
        public Calendar(string name)
        {
            _name = SetValue("name", name);
        }
    }
}
