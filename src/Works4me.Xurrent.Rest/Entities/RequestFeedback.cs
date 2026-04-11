using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent request feedback object.
    /// </summary>
    public sealed class RequestFeedback : ObservableItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="RequestFeedback"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The requested by field.
            /// </summary>
            [XurrentEnum("requested_by")]
            RequestedBy,

            /// <summary>
            /// The requested for field.
            /// </summary>
            [XurrentEnum("requested_for")]
            RequestedFor
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

        private RequestFeedbackEntry? _requestedBy;
        private RequestFeedbackEntry? _requestedFor;

        /// <summary>
        /// Gets the feedback entry for the person who requested the request.
        /// </summary>
        [XurrentField("requested_by")]
        public RequestFeedbackEntry? RequestedBy
        {
            get => _requestedBy;
            internal set => _requestedBy = value;
        }

        /// <summary>
        /// Gets the feedback entry for the person for whom the request was made.
        /// </summary>
        [XurrentField("requested_for")]
        public RequestFeedbackEntry? RequestedFor
        {
            get => _requestedFor;
            internal set => _requestedFor = value;
        }
    }
}
