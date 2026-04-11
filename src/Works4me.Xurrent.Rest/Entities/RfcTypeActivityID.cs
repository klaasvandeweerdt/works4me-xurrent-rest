using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent RFC type activity ID object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class RfcTypeActivityID : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="RfcTypeActivityID"/> object.
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
            /// The rfc type field.
            /// </summary>
            [XurrentEnum("rfc_type")]
            RfcType
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
        private string? _rfcType;

        /// <summary>
        /// Gets the activity identifier.
        /// </summary>
        [XurrentField("activityID")]
        public string? ActivityID
        {
            get => _activityID;
            internal set => _activityID = value;
        }

        /// <summary>
        /// Gets the RFC type reference of the activity identifier.
        /// </summary>
        [XurrentField("rfc_type")]
        public string? RfcType
        {
            get => _rfcType;
            internal set => _rfcType = value;
        }

        /// <summary>
        /// Creates a new rfc type activity identifier instance.
        /// </summary>
        public RfcTypeActivityID()
        {
        }

        /// <summary>
        /// Creates a new rfc type activity identifier instance.
        /// </summary>
        /// <param name="id">The unique identifier of the rfc type activity identifier.</param>
        public RfcTypeActivityID(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new rfc type activity identifier instance.
        /// </summary>
        /// <param name="activityID">The activity identifier of the rfc type activity identifier.</param>
        public RfcTypeActivityID(string activityID)
        {
            _activityID = SetValue("activityID", activityID);
        }
    }
}
