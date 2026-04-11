using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent standard service request activity identifier object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class StandardServiceRequestActivityID : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="StandardServiceRequestActivityID"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The activity identifier field.
            /// </summary>
            [XurrentEnum("activityID")]
            ActivityID,

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
            /// The standard service request field.
            /// </summary>
            [XurrentEnum("standard_service_request")]
            StandardServiceRequest
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

        private string? _activityID;
        private StandardServiceRequest? _standardServiceRequest;

        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        [XurrentField("activityID")]
        public string? ActivityID
        {
            get => _activityID;
            set => _activityID = SetValue("activityID", _activityID, value);
        }

        /// <summary>
        /// Gets or sets the standard service request associated with the activity identifier.
        /// </summary>
        [XurrentField("standard_service_request")]
        public StandardServiceRequest? StandardServiceRequest
        {
            get => _standardServiceRequest;
            set => _standardServiceRequest = SetValue("standard_service_request", _standardServiceRequest, value);
        }

        /// <summary>
        /// Creates a new standard service request activity identifier instance.
        /// </summary>
        public StandardServiceRequestActivityID()
        {
        }

        /// <summary>
        /// Creates a new standard service request activity identifier instance.
        /// </summary>
        /// <param name="id">The unique identifier of the standard service request activity identifier.</param>
        public StandardServiceRequestActivityID(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new standard service request activity identifier instance.
        /// </summary>
        /// <param name="activityID">The activity identifier of the standard service request activity identifier.</param>
        public StandardServiceRequestActivityID(string activityID)
        {
            _activityID = SetValue("activityID", activityID);
        }
    }
}
