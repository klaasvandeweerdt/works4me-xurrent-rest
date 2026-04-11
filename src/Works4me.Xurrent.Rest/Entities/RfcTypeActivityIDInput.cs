using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent RRC type activityID input object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class RfcTypeActivityIDInput : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="RfcTypeActivityIDInput"/> object.
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
        private RfcType? _rfcType;

        /// <summary>
        /// Sets the activity identifier.
        /// </summary>
        [XurrentField("activityID")]
        public string? ActivityID
        {
            get => _activityID;
            set => _activityID = SetValue("activityID", _activityID, value);
        }

        /// <summary>
        /// Sets the RFC type associated with the activity identifier.
        /// </summary>
        [XurrentField("rfc_type")]
        public RfcType? RfcType
        {
            get => _rfcType;
            set => _rfcType = SetValue("rfc_type", _rfcType, value);
        }

        /// <summary>
        /// Creates a new rfc type activity identifier input instance.
        /// </summary>
        public RfcTypeActivityIDInput()
        {
        }

        /// <summary>
        /// Creates a new rfc type activity identifier input instance.
        /// </summary>
        /// <param name="id">The unique identifier of the rfc type activity identifier input.</param>
        public RfcTypeActivityIDInput(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new rfc type activity identifier input instance.
        /// </summary>
        /// <param name="activityID">The activity identifier of the rfc type activity identifier input.</param>
        /// <param name="rfcType">The rfc type of the rfc type activity identifier input.</param>
        public RfcTypeActivityIDInput(string activityID, RfcType rfcType)
        {
            _activityID = SetValue("activityID", activityID);
            _rfcType = SetValue("rfc_type", rfcType);
        }
    }
}
