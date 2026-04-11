using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent request watch object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Watch : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Watch"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The added by field.
            /// </summary>
            [XurrentEnum("added_by")]
            AddedBy,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

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
            /// The person field.
            /// </summary>
            [XurrentEnum("person")]
            Person,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the absence of supported filters for a query.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
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
        /// Represents the absence of supported ordering fields for a query.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Specifies that no ordering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        private Person? _addedBy;
        private DateTime? _createdAt;
        private Person? _person;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the person who added the watcher.
        /// </summary>
        [XurrentField("added_by")]
        public Person? AddedBy
        {
            get => _addedBy;
            internal set => _addedBy = value;
        }

        /// <summary>
        /// Gets the date and time when the watch was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the person who is selected as the watcher.
        /// </summary>
        [XurrentField("person")]
        public Person? Person
        {
            get => _person;
            set => _person = SetValue("person", _person, value);
        }

        /// <summary>
        /// Gets the date and time when the watch was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new watch instance.
        /// </summary>
        public Watch()
        {
        }

        /// <summary>
        /// Creates a new watch instance.
        /// </summary>
        /// <param name="id">The unique identifier of the watch.</param>
        public Watch(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new watch instance.
        /// </summary>
        /// <param name="person">The person of the watch.</param>
        public Watch(Person person)
        {
            _person = SetValue("person", person);
        }
    }
}
