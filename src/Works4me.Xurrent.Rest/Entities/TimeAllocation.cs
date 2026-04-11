using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent time allocation object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class TimeAllocation : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="TimeAllocation"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The customer category field.
            /// </summary>
            [XurrentEnum("customer_category")]
            CustomerCategory,

            /// <summary>
            /// The description category field.
            /// </summary>
            [XurrentEnum("description_category")]
            DescriptionCategory,

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
            /// The group field.
            /// </summary>
            [XurrentEnum("group")]
            Group,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The localized group field.
            /// </summary>
            [XurrentEnum("localized_group", IgnoreInFieldSelection = true)]
            LocalizedGroup,

            /// <summary>
            /// The localized name field.
            /// </summary>
            [XurrentEnum("localized_name", IgnoreInFieldSelection = true)]
            LocalizedName,

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
            /// The service category field.
            /// </summary>
            [XurrentEnum("service_category")]
            ServiceCategory,

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
        /// Represents the filterable fields of a <see cref="TimeAllocation"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters time allocations by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters time allocations by disabled status.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters time allocations by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters time allocations by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters time allocations by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters time allocations by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters time allocations by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="TimeAllocation"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled time allocations.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled time allocations.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="TimeAllocation"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts time allocations by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts time allocations by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts time allocations alphabetically by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts time allocations by the external source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts time allocations by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private DateTime? _createdAt;
        private TimeAllocationCustomerCategory? _customerCategory;
        private TimeAllocationDescriptionCategory? _descriptionCategory;
        private bool? _disabled;
        private EffortClass? _effortClass;
        private string? _group;
        private string? _localizedGroup;
        private string? _localizedName;
        private string? _name;
        private TimeAllocationServiceCategory? _serviceCategory;
        private string? _source;
        private string? _sourceID;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time at which the time allocation was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the customer category behavior for the time allocation.
        /// </summary>
        [XurrentField("customer_category")]
        public TimeAllocationCustomerCategory? CustomerCategory
        {
            get => _customerCategory;
            set => _customerCategory = SetValue("customer_category", _customerCategory, value);
        }

        /// <summary>
        /// Gets or sets the description category behavior for the time allocation.
        /// </summary>
        [XurrentField("description_category")]
        public TimeAllocationDescriptionCategory? DescriptionCategory
        {
            get => _descriptionCategory;
            set => _descriptionCategory = SetValue("description_category", _descriptionCategory, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the time allocation is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the default effort class for the time allocation.
        /// </summary>
        [XurrentField("effort_class")]
        public EffortClass? EffortClass
        {
            get => _effortClass;
            set => _effortClass = SetValue("effort_class", _effortClass, value);
        }

        /// <summary>
        /// Gets or sets the group of the time allocation.
        /// </summary>
        [XurrentField("group")]
        public string? Group
        {
            get => _group;
            set => _group = SetValue("group", _group, value);
        }

        /// <summary>
        /// Gets the localized group of the time allocation.
        /// </summary>
        [XurrentField("localized_group")]
        public string? LocalizedGroup
        {
            get => _localizedGroup;
            internal set => _localizedGroup = value;
        }

        /// <summary>
        /// Gets the localized name of the time allocation.
        /// </summary>
        [XurrentField("localized_name")]
        public string? LocalizedName
        {
            get => _localizedName;
            internal set => _localizedName = value;
        }

        /// <summary>
        /// Gets or sets the name of the time allocation.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the service category behavior for the time allocation.
        /// </summary>
        [XurrentField("service_category")]
        public TimeAllocationServiceCategory? ServiceCategory
        {
            get => _serviceCategory;
            set => _serviceCategory = SetValue("service_category", _serviceCategory, value);
        }

        /// <summary>
        /// Gets or sets the source of the time allocation.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the time allocation in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the time allocation.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new time allocation instance.
        /// </summary>
        public TimeAllocation()
        {
        }

        /// <summary>
        /// Creates a new time allocation instance.
        /// </summary>
        /// <param name="id">The unique identifier of the time allocation.</param>
        public TimeAllocation(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new time allocation instance.
        /// </summary>
        /// <param name="customerCategory">The customer category of the time allocation.</param>
        /// <param name="descriptionCategory">The description category of the time allocation.</param>
        /// <param name="serviceCategory">The service category of the time allocation.</param>
        public TimeAllocation(TimeAllocationCustomerCategory customerCategory, TimeAllocationDescriptionCategory descriptionCategory, TimeAllocationServiceCategory serviceCategory)
        {
            _customerCategory = SetValue("customer_category", customerCategory);
            _descriptionCategory = SetValue("description_category", descriptionCategory);
            _serviceCategory = SetValue("service_category", serviceCategory);
        }
    }
}
