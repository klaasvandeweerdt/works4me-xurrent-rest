using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent waiting for customer rule object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class WaitingForCustomerRules : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="WaitingForCustomerRules"/> object.
        /// </summary>
        public enum Field
        {
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
            /// The nr of business days field.
            /// </summary>
            [XurrentEnum("nr_of_business_days")]
            NrOfBusinessDays,

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
        private int? _nrOfBusinessDays;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time at which the waiting for customer rule was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the number of business days.
        /// </summary>
        [XurrentField("nr_of_business_days")]
        public int? NrOfBusinessDays
        {
            get => _nrOfBusinessDays;
            set => _nrOfBusinessDays = SetValue("nr_of_business_days", _nrOfBusinessDays, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the waiting for customer rule.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new waiting for customer rules instance.
        /// </summary>
        public WaitingForCustomerRules()
        {
        }

        /// <summary>
        /// Creates a new waiting for customer rules instance.
        /// </summary>
        /// <param name="id">The unique identifier of the waiting for customer rules.</param>
        public WaitingForCustomerRules(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new waiting for customer rules instance.
        /// </summary>
        /// <param name="nrOfBusinessDays">The nr of business days of the waiting for customer rules.</param>
        public WaitingForCustomerRules(int nrOfBusinessDays)
        {
            _nrOfBusinessDays = SetValue("nr_of_business_days", nrOfBusinessDays);
        }
    }
}
