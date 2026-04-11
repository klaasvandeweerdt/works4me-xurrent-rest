using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent waiting for customer follow up object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class WaitingForCustomerFollowUp : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="WaitingForCustomerFollowUp"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The auto complete field.
            /// </summary>
            [XurrentEnum("auto_complete")]
            AutoComplete,

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
        /// Represents the filterable fields of a <see cref="WaitingForCustomerFollowUp"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters waiting for customer follow-ups by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters waiting for customer follow-ups by whether they are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters waiting for customer follow-ups by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters waiting for customer follow-ups by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters waiting for customer follow-ups by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters waiting for customer follow-ups by identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters waiting for customer follow-ups by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="WaitingForCustomerFollowUp"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled waiting for customer follow-ups.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled waiting for customer follow-ups.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="WaitingForCustomerFollowUp"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts waiting for customer follow-ups by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts waiting for customer follow-ups by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts waiting for customer follow-ups by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts waiting for customer follow-ups by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts waiting for customer follow-ups by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private bool? _autoComplete;
        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _name;
        private string? _source;
        private string? _sourceID;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets a value indicating whether the request is automatically completed when the last waiting for customer rule is triggered.
        /// </summary>
        [XurrentField("auto_complete")]
        public bool? AutoComplete
        {
            get => _autoComplete;
            set => _autoComplete = SetValue("auto_complete", _autoComplete, value);
        }

        /// <summary>
        /// Gets the date and time when the waiting for customer follow-up was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the waiting for customer follow-up is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the name of the waiting for customer follow-up.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the source of the waiting for customer follow-up.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the waiting for customer follow-up.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time when the waiting for customer follow-up was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new waiting for customer follow up instance.
        /// </summary>
        public WaitingForCustomerFollowUp()
        {
        }

        /// <summary>
        /// Creates a new waiting for customer follow up instance.
        /// </summary>
        /// <param name="id">The unique identifier of the waiting for customer follow up.</param>
        public WaitingForCustomerFollowUp(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new waiting for customer follow up instance.
        /// </summary>
        /// <param name="name">The name of the waiting for customer follow up.</param>
        public WaitingForCustomerFollowUp(string name)
        {
            _name = SetValue("name", name);
        }
    }
}
