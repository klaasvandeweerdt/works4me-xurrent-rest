using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various request categories.
    /// </summary>
    public enum RequestCategory
    {
        /// <summary>
        /// Indicates that the request category is incident.
        /// </summary>
        [XurrentEnum("incident")]
        Incident,

        /// <summary>
        /// Indicates that the request category is rfc.
        /// </summary>
        [XurrentEnum("rfc")]
        Rfc,

        /// <summary>
        /// Indicates that the request category is rfi.
        /// </summary>
        [XurrentEnum("rfi")]
        Rfi,

        /// <summary>
        /// Indicates that the request category is reservation.
        /// </summary>
        [XurrentEnum("reservation")]
        Reservation,

        /// <summary>
        /// Indicates that the request category is order.
        /// </summary>
        [XurrentEnum("order")]
        Order,

        /// <summary>
        /// Indicates that the request category is fulfillment.
        /// </summary>
        [XurrentEnum("fulfillment")]
        Fulfillment,

        /// <summary>
        /// Indicates that the request category is complaint.
        /// </summary>
        [XurrentEnum("complaint")]
        Complaint,

        /// <summary>
        /// Indicates that the request category is compliment.
        /// </summary>
        [XurrentEnum("compliment")]
        Compliment,

        /// <summary>
        /// Indicates that the request category is other.
        /// </summary>
        [XurrentEnum("other")]
        Other,

        /// <summary>
        /// Indicates that the request category is case.
        /// </summary>
        [XurrentEnum("case")]
        Case
    }
}
