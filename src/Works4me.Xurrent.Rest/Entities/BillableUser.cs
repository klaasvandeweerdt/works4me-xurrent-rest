using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent billable user object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class BillableUser : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="BillableUser"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The business unit field.
            /// </summary>
            [XurrentEnum("business_unit")]
            BusinessUnit,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The last visit field.
            /// </summary>
            [XurrentEnum("last_visit")]
            LastVisit,

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
            /// The organization field.
            /// </summary>
            [XurrentEnum("organization")]
            Organization,

            /// <summary>
            /// The primary email field.
            /// </summary>
            [XurrentEnum("primary_email")]
            PrimaryEmail,

            /// <summary>
            /// The region field.
            /// </summary>
            [XurrentEnum("region")]
            Region,

            /// <summary>
            /// The sign ins field.
            /// </summary>
            [XurrentEnum("sign_ins")]
            SignIns,

            /// <summary>
            /// The updates field.
            /// </summary>
            [XurrentEnum("updates")]
            Updates
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

        private string? _businessUnit;
        private DateTime? _lastVisit;
        private string? _name;
        private string? _organization;
        private string? _primaryEmail;
        private string? _region;
        private int? _signIns;
        private int? _updates;

        /// <summary>
        /// Gets the name of the business unit of the person's organization.
        /// </summary>
        [XurrentField("business_unit")]
        public string? BusinessUnit
        {
            get => _businessUnit;
            internal set => _businessUnit = value;
        }

        /// <summary>
        /// Gets the date and time at which the person last accessed the service.
        /// </summary>
        [XurrentField("last_visit")]
        public DateTime? LastVisit
        {
            get => _lastVisit;
            internal set => _lastVisit = value;
        }

        /// <summary>
        /// Gets the name of the person.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            internal set => _name = value;
        }

        /// <summary>
        /// Gets the organization name of the person.
        /// </summary>
        [XurrentField("organization")]
        public string? Organization
        {
            get => _organization;
            internal set => _organization = value;
        }

        /// <summary>
        /// Gets the primary email address of the person.
        /// </summary>
        [XurrentField("primary_email")]
        public string? PrimaryEmail
        {
            get => _primaryEmail;
            internal set => _primaryEmail = value;
        }

        /// <summary>
        /// Gets the name of the region of the person's organization.
        /// </summary>
        [XurrentField("region")]
        public string? Region
        {
            get => _region;
            internal set => _region = value;
        }

        /// <summary>
        /// Gets the total number of times the person has signed in.
        /// </summary>
        [XurrentField("sign_ins")]
        public int? SignIns
        {
            get => _signIns;
            internal set => _signIns = value;
        }

        /// <summary>
        /// Gets the number of record updates made by the person in the given month.
        /// </summary>
        [XurrentField("updates")]
        public int? Updates
        {
            get => _updates;
            internal set => _updates = value;
        }

        /// <summary>
        /// Creates a new billable user instance.
        /// </summary>
        public BillableUser()
        {
        }

        /// <summary>
        /// Creates a new billable user instance.
        /// </summary>
        /// <param name="id">The unique identifier of the billable user.</param>
        public BillableUser(long id)
        {
            Id = id;
        }
    }
}
