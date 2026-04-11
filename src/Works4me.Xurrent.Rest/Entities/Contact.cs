using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent contact object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Contact : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Contact"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The chat field.
            /// </summary>
            [XurrentEnum("chat", IgnoreInFieldSelection = true)]
            Chat,

            /// <summary>
            /// The email field.
            /// </summary>
            [XurrentEnum("email", IgnoreInFieldSelection = true)]
            Email,

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
            /// The telephone field.
            /// </summary>
            [XurrentEnum("telephone", IgnoreInFieldSelection = true)]
            Telephone,

            /// <summary>
            /// The verified field.
            /// </summary>
            [XurrentEnum("verified", IgnoreInFieldSelection = true)]
            Verified,

            /// <summary>
            /// The website field.
            /// </summary>
            [XurrentEnum("website", IgnoreInFieldSelection = true)]
            Website
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

        private string? _chat;
        private string? _email;
        private bool? _integration;
        private AddressLabel? _label;
        private string? _telephone;
        private bool? _verified;
        private Uri? _website;

        /// <summary>
        /// Gets or sets the link that can be used to start a direct chat with the person.<br />
        /// A separate link can be entered for each chat application that the person uses.
        /// </summary>
        [XurrentField("chat")]
        public string? Chat
        {
            get => _chat;
            set => _chat = SetValue("chat", _chat, value);
        }

        /// <summary>
        /// Gets or sets the work or personal email address of the person.
        /// </summary>
        [XurrentField("email")]
        public string? Email
        {
            get => _email;
            set => _email = SetValue("email", _email, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the contact is marked as an integration contact.<br />
        /// When set to <see langword="true"/>, the contact is displayed as read-only in the user interface to prevent users from updating it.
        /// </summary>
        [XurrentField("integration")]
        public bool? Integration
        {
            get => _integration;
            set => _integration = SetValue("integration", _integration, value);
        }

        /// <summary>
        /// Gets or sets the label of the contact details.
        /// </summary>
        [XurrentField("label")]
        public AddressLabel? Label
        {
            get => _label;
            set => _label = SetValue("label", _label, value);
        }

        /// <summary>
        /// Gets or sets the work, mobile, home, or fax number of the person.
        /// </summary>
        [XurrentField("telephone")]
        public string? Telephone
        {
            get => _telephone;
            set => _telephone = SetValue("telephone", _telephone, value);
        }

        /// <summary>
        /// Gets a value indicating whether the email address has been verified.
        /// </summary>
        [XurrentField("verified")]
        public bool? Verified
        {
            get => _verified;
            internal set => _verified = value;
        }

        /// <summary>
        /// Gets or sets the work or personal website URL of the person.
        /// </summary>
        [XurrentField("website")]
        public Uri? Website
        {
            get => _website;
            set => _website = SetValue("website", _website, value);
        }

        /// <summary>
        /// Creates a new contact instance.
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Creates a new contact instance.
        /// </summary>
        /// <param name="id">The unique identifier of the contact.</param>
        public Contact(long id)
        {
            Id = id;
        }
    }
}
