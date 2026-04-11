using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent address object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Address : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="Address"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The city field.
            /// </summary>
            [XurrentEnum("city")]
            City,

            /// <summary>
            /// The country field.
            /// </summary>
            [XurrentEnum("country")]
            Country,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The integration field.
            /// </summary>
            [XurrentEnum("integration")]
            Integration,

            /// <summary>
            /// The label field.
            /// </summary>
            [XurrentEnum("label")]
            Label,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The state field.
            /// </summary>
            [XurrentEnum("state")]
            State,

            /// <summary>
            /// The street field.
            /// </summary>
            [XurrentEnum("address")]
            Street,

            /// <summary>
            /// The zip field.
            /// </summary>
            [XurrentEnum("zip")]
            Zip
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

        private string? _city;
        private string? _country;
        private bool? _integration;
        private AddressLabel? _label;
        private string? _state;
        private string? _street;
        private string? _zip;

        /// <summary>
        /// Gets or sets the city name.
        /// </summary>
        [XurrentField("city")]
        public string? City
        {
            get => _city;
            set => _city = SetValue("city", _city, value);
        }

        /// <summary>
        /// Gets or sets the two-letter country code.
        /// </summary>
        [XurrentField("country")]
        public string? Country
        {
            get => _country;
            set => _country = SetValue("country", _country, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the address is marked as an integration address.<br />
        /// When set to <see langword="true"/>, the address is displayed as read-only in the user interface to prevent users from updating it.
        /// </summary>
        [XurrentField("integration")]
        public bool? Integration
        {
            get => _integration;
            set => _integration = SetValue("integration", _integration, value);
        }

        /// <summary>
        /// Gets or sets the label of the address details.
        /// </summary>
        [XurrentField("label")]
        public AddressLabel? Label
        {
            get => _label;
            set => _label = SetValue("label", _label, value);
        }

        /// <summary>
        /// Gets or sets the state name.
        /// </summary>
        [XurrentField("state")]
        public string? State
        {
            get => _state;
            set => _state = SetValue("state", _state, value);
        }

        /// <summary>
        /// Gets or sets the address lines.
        /// </summary>
        [XurrentField("address")]
        public string? Street
        {
            get => _street;
            set => _street = SetValue("address", _street, value);
        }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        [XurrentField("zip")]
        public string? Zip
        {
            get => _zip;
            set => _zip = SetValue("zip", _zip, value);
        }

        /// <summary>
        /// Creates a new address instance.
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Creates a new address instance.
        /// </summary>
        /// <param name="id">The unique identifier of the address.</param>
        public Address(long id)
        {
            Id = id;
        }
    }
}
