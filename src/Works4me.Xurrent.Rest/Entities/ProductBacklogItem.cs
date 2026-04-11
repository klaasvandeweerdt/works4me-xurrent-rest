using System;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent product backlog item object.
    /// </summary>
    public sealed class ProductBacklogItem : ObservableItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ProductBacklogItem"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The estimate field.
            /// </summary>
            [XurrentEnum("estimate", IgnoreInFieldSelection = true)]
            Estimate,

            /// <summary>
            /// The position field.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// The problem field.
            /// </summary>
            [XurrentEnum("problem", IgnoreInFieldSelection = true)]
            Problem,

            /// <summary>
            /// The request field.
            /// </summary>
            [XurrentEnum("request", IgnoreInFieldSelection = true)]
            Request,

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

        private DateTime? _createdAt;
        private int? _estimate;
        private int? _position;
        private Problem? _problem;
        private Request? _request;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time at which the product backlog item was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the estimate of the product backlog item.
        /// </summary>
        [XurrentField("estimate")]
        public int? Estimate
        {
            get => _estimate;
            internal set => _estimate = value;
        }

        /// <summary>
        /// Gets the position of the product backlog item relative to other items in the product backlog.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            internal set => _position = value;
        }

        /// <summary>
        /// Gets the problem associated with the product backlog item.
        /// </summary>
        [XurrentField("problem")]
        public Problem? Problem
        {
            get => _problem;
            internal set => _problem = value;
        }

        /// <summary>
        /// Gets the request associated with the product backlog item.
        /// </summary>
        [XurrentField("request")]
        public Request? Request
        {
            get => _request;
            internal set => _request = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the product backlog item.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }
    }
}
