using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent effort class object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class EffortClass : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="EffortClass"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The cost multiplier field.
            /// </summary>
            [XurrentEnum("cost_multiplier")]
            CostMultiplier,

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
            /// The position field.
            /// </summary>
            [XurrentEnum("position")]
            Position,

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
        /// Represents the filterable fields of an <see cref="EffortClass"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters effort classes by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters effort classes by disabled state.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters effort classes by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters effort classes by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters effort classes by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters effort classes by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters effort classes by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of an <see cref="EffortClass"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled effort classes.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled effort classes.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order an <see cref="EffortClass"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts effort classes by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts effort classes by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts effort classes by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts effort classes by position.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// Sorts effort classes by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts effort classes by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private decimal? _costMultiplier;
        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _name;
        private int? _position;
        private string? _source;
        private string? _sourceID;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets the cost multiplier applied to time entries with this effort class.
        /// </summary>
        [XurrentField("cost_multiplier")]
        public decimal? CostMultiplier
        {
            get => _costMultiplier;
            set => _costMultiplier = SetValue("cost_multiplier", _costMultiplier, value);
        }

        /// <summary>
        /// Gets the date and time at which the effort class was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the effort class is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the name of the effort class.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the position of the effort class in a sorted list.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            set => _position = SetValue("position", _position, value);
        }

        /// <summary>
        /// Gets or sets the source of the effort class.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the effort class.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time at which the effort class was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new effort class instance.
        /// </summary>
        public EffortClass()
        {
        }

        /// <summary>
        /// Creates a new effort class instance.
        /// </summary>
        /// <param name="id">The unique identifier of the effort class.</param>
        public EffortClass(long id)
        {
            Id = id;
        }
    }
}
