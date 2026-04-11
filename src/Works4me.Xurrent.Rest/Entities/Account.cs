using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent account object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Account : ObservableItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="Account"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The currency field.
            /// </summary>
            [XurrentEnum("currency")]
            Currency,

            /// <summary>
            /// The directory account field.
            /// </summary>
            [XurrentEnum("directory_account")]
            DirectoryAccount,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The locale field.
            /// </summary>
            [XurrentEnum("locale")]
            Locale,

            /// <summary>
            /// The name field.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// The organization field.
            /// </summary>
            [XurrentEnum("organization")]
            Organization,

            /// <summary>
            /// The owner field.
            /// </summary>
            [XurrentEnum("owner")]
            Owner,

            /// <summary>
            /// The plan field.
            /// </summary>
            [XurrentEnum("plan")]
            Plan,

            /// <summary>
            /// The strong privacy field.
            /// </summary>
            [XurrentEnum("strong_privacy")]
            StrongPrivacy,

            /// <summary>
            /// The time format 24 h field.
            /// </summary>
            [XurrentEnum("time_format_24h")]
            TimeFormat24h,

            /// <summary>
            /// The time zone field.
            /// </summary>
            [XurrentEnum("time_zone")]
            TimeZone,

            /// <summary>
            /// The url field.
            /// </summary>
            [XurrentEnum("url")]
            Url
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

        private Currency? _currency;
        private Account? _directoryAccount;
        private string? _id;
        private string? _locale;
        private string? _name;
        private Organization? _organization;
        private Person? _owner;
        private AccountPlan? _plan;
        private bool? _strongPrivacy;
        private bool? _timeFormat24h;
        private string? _timeZone;
        private Uri? _url;

        /// <summary>
        /// Gets the currency used by the account.
        /// </summary>
        [XurrentField("currency")]
        public Currency? Currency
        {
            get => _currency;
            internal set => _currency = value;
        }

        /// <summary>
        /// Gets the directory account associated with the account.
        /// </summary>
        [XurrentField("directory_account")]
        public Account? DirectoryAccount
        {
            get => _directoryAccount;
            internal set => _directoryAccount = value;
        }

        /// <summary>
        /// Gets the unique identifier of the account.
        /// </summary>
        [XurrentField("id")]
        public string? Id
        {
            get => _id;
            set => _id = SetValue("id", _id, value);
        }

        /// <summary>
        /// Gets the locale configured for the account.
        /// </summary>
        [XurrentField("locale")]
        public string? Locale
        {
            get => _locale;
            internal set => _locale = value;
        }

        /// <summary>
        /// Gets the name of the account.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            internal set => _name = value;
        }

        /// <summary>
        /// Gets the organization associated with the account.
        /// </summary>
        [XurrentField("organization")]
        public Organization? Organization
        {
            get => _organization;
            internal set => _organization = value;
        }

        /// <summary>
        /// Gets the owner of the account.
        /// </summary>
        [XurrentField("owner")]
        public Person? Owner
        {
            get => _owner;
            internal set => _owner = value;
        }

        /// <summary>
        /// Gets the subscription plan of the account.
        /// </summary>
        [XurrentField("plan")]
        public AccountPlan? Plan
        {
            get => _plan;
            internal set => _plan = value;
        }

        /// <summary>
        /// Gets a value indicating whether strong privacy is enabled for the account.
        /// </summary>
        [XurrentField("strong_privacy")]
        public bool? StrongPrivacy
        {
            get => _strongPrivacy;
            internal set => _strongPrivacy = value;
        }

        /// <summary>
        /// Gets a value indicating whether the account uses a 24-hour time format.
        /// </summary>
        [XurrentField("time_format_24h")]
        public bool? TimeFormat24h
        {
            get => _timeFormat24h;
            internal set => _timeFormat24h = value;
        }

        /// <summary>
        /// Gets the time zone configured for the account.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            internal set => _timeZone = value;
        }

        /// <summary>
        /// Gets the URL of the account.
        /// </summary>
        [XurrentField("url")]
        public Uri? Url
        {
            get => _url;
            internal set => _url = value;
        }

        /// <summary>
        /// Creates a new account instance.
        /// </summary>
        public Account()
        {
        }

        /// <summary>
        /// Creates a new account instance.
        /// </summary>
        /// <param name="id">The account identifier.</param>
        public Account(string id)
        {
            _id = id;
        }

        /// <inheritdoc/>
        public override long GetMergeKey()
        {
            return Id is null ? GetHashCode() : StringComparer.Ordinal.GetHashCode(Id);
        }
    }
}
