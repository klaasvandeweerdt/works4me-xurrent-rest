using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent person object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Person : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Person"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The addresses field.
            /// </summary>
            [XurrentEnum("addresses")]
            Addresses,

            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The authentication identifier field.
            /// </summary>
            [XurrentEnum("authenticationID")]
            AuthenticationID,

            /// <summary>
            /// The auto translation field.
            /// </summary>
            [XurrentEnum("auto_translation")]
            AutoTranslation,

            /// <summary>
            /// The contacts field.
            /// </summary>
            [XurrentEnum("contacts")]
            Contacts,

            /// <summary>
            /// The cost per hour field.
            /// </summary>
            [XurrentEnum("cost_per_hour")]
            CostPerHour,

            /// <summary>
            /// The cost per hour currency field.
            /// </summary>
            [XurrentEnum("cost_per_hour_currency")]
            CostPerHourCurrency,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The custom fields field.
            /// </summary>
            [XurrentEnum("custom_fields")]
            CustomFields,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The do not translate languages field.
            /// </summary>
            [XurrentEnum("do_not_translate_languages")]
            DoNotTranslateLanguages,

            /// <summary>
            /// The employee identifier field.
            /// </summary>
            [XurrentEnum("employeeID")]
            EmployeeID,

            /// <summary>
            /// The exclude team notifications field.
            /// </summary>
            [XurrentEnum("exclude_team_notifications")]
            ExcludeTeamNotifications,

            /// <summary>
            /// The guest field.
            /// </summary>
            [XurrentEnum("guest")]
            Guest,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The information field.
            /// </summary>
            [XurrentEnum("information")]
            Information,

            /// <summary>
            /// The information attachments field.
            /// </summary>
            [XurrentEnum("information_attachments", IgnoreInFieldSelection = true)]
            InformationAttachments,

            /// <summary>
            /// The job title field.
            /// </summary>
            [XurrentEnum("job_title")]
            JobTitle,

            /// <summary>
            /// The locale field.
            /// </summary>
            [XurrentEnum("locale")]
            Locale,

            /// <summary>
            /// The location field.
            /// </summary>
            [XurrentEnum("location")]
            Location,

            /// <summary>
            /// The manager field.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

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
            /// The oauth person enablement field.
            /// </summary>
            [XurrentEnum("oauth_person_enablement")]
            OauthPersonEnablement,

            /// <summary>
            /// The organization field.
            /// </summary>
            [XurrentEnum("organization")]
            Organization,

            /// <summary>
            /// The picture uri field.
            /// </summary>
            [XurrentEnum("picture_uri")]
            PictureUri,

            /// <summary>
            /// The primary email field.
            /// </summary>
            [XurrentEnum("primary_email")]
            PrimaryEmail,

            /// <summary>
            /// The send email notifications field.
            /// </summary>
            [XurrentEnum("send_email_notifications")]
            SendEmailNotifications,

            /// <summary>
            /// The show notification popup field.
            /// </summary>
            [XurrentEnum("show_notification_popup")]
            ShowNotificationPopup,

            /// <summary>
            /// The site field.
            /// </summary>
            [XurrentEnum("site")]
            Site,

            /// <summary>
            /// The source field.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// The source identifier field.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// The support identifier field.
            /// </summary>
            [XurrentEnum("supportID")]
            SupportID,

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
            /// The user interface extension field.
            /// </summary>
            [XurrentEnum("ui_extension")]
            UiExtension,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The vip field.
            /// </summary>
            [XurrentEnum("vip")]
            Vip,

            /// <summary>
            /// The work hours field.
            /// </summary>
            [XurrentEnum("work_hours")]
            WorkHours
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Person"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters people by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters people by whether they are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters people by their employee identifier.
            /// </summary>
            [XurrentEnum("employeeID")]
            EmployeeID,

            /// <summary>
            /// Filters people by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters people by their manager.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

            /// <summary>
            /// Filters people by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters people by their organization.
            /// </summary>
            [XurrentEnum("organization")]
            Organization,

            /// <summary>
            /// Filters people by their primary email address.
            /// </summary>
            [XurrentEnum("primary_email")]
            PrimaryEmail,

            /// <summary>
            /// Filters people by their roles.
            /// </summary>
            [XurrentEnum("roles")]
            Roles,

            /// <summary>
            /// Filters people by their site.
            /// </summary>
            [XurrentEnum("site")]
            Site,

            /// <summary>
            /// Filters people by their external source identifier.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters people by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters people by their support identifier.
            /// </summary>
            [XurrentEnum("supportID")]
            SupportID,

            /// <summary>
            /// Filters people by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Person"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// List all people registered in the directory account of the support domain account from which the data is requested.
            /// </summary>
            [XurrentEnum("directory")]
            Directory,

            /// <summary>
            /// List all disabled people.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// List all enabled people.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled,

            /// <summary>
            /// List all internal people.
            /// </summary>
            [XurrentEnum("internal")]
            Internal,

            /// <summary>
            /// List all people registered in the account from which the data is requested (and not the related directory account).
            /// </summary>
            [XurrentEnum("support_domain")]
            SupportDomain
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Person"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts people by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts people by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts people by their manager.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

            /// <summary>
            /// Sorts people by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts people by their organization.
            /// </summary>
            [XurrentEnum("organization")]
            Organization,

            /// <summary>
            /// Sorts people by their site.
            /// </summary>
            [XurrentEnum("site")]
            Site,

            /// <summary>
            /// Sorts people by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts people by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Address>? _addresses;
        private List<Attachment>? _attachments;
        private string? _authenticationID;
        private bool? _autoTranslation;
        private List<Contact>? _contacts;
        private decimal? _costPerHour;
        private Currency? _costPerHourCurrency;
        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _doNotTranslateLanguages;
        private string? _employeeID;
        private bool? _excludeTeamNotifications;
        private bool? _guest;
        private string? _information;
        private ObservableCollection<AttachmentReference>? _informationAttachments;
        private AttachmentReferenceWriter? _informationAttachmentsWriter;
        private string? _jobTitle;
        private string? _locale;
        private string? _location;
        private Person? _manager;
        private string? _name;
        private bool? _oauthPersonEnablement;
        private Organization? _organization;
        private Uri? _pictureUri;
        private string? _primaryEmail;
        private SendEmailNotifications? _sendEmailNotifications;
        private ShowNotificationPopup? _showNotificationPopup;
        private Site? _site;
        private string? _source;
        private string? _sourceID;
        private string? _supportID;
        private bool? _timeFormat24h;
        private string? _timeZone;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;
        private bool? _vip;
        private Calendar? _workHours;

        [XurrentField("addresses")]
        internal List<Address>? AddressesCollection
        {
            get => _addresses;
            set => _addresses = value;
        }

        /// <summary>
        /// Gets the home and mailing addresses of the person.
        /// </summary>
        public ReadOnlyCollection<Address>? Addresses
        {
            get => _addresses is null ? null : new ReadOnlyCollection<Address>(_addresses);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated read-only collection of all attachments.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the identifier used to uniquely identify the user for single sign-on.
        /// </summary>
        [XurrentField("authenticationID")]
        public string? AuthenticationID
        {
            get => _authenticationID;
            set => _authenticationID = SetValue("authenticationID", _authenticationID, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether translations are offered for texts written in languages other than the selected languages.<br />
        /// Such texts are translated automatically into the language selected for the person.
        /// </summary>
        [XurrentField("auto_translation")]
        public bool? AutoTranslation
        {
            get => _autoTranslation;
            set => _autoTranslation = SetValue("auto_translation", _autoTranslation, value);
        }

        [XurrentField("contacts")]
        internal List<Contact>? ContactsCollection
        {
            get => _contacts;
            set => _contacts = value;
        }

        /// <summary>
        /// Gets the aggregated read-only collection of all contacts.
        /// </summary>
        public ReadOnlyCollection<Contact>? Contacts
        {
            get => _contacts is null ? null : new ReadOnlyCollection<Contact>(_contacts);
        }

        /// <summary>
        /// Gets or sets the estimated total cost per work hour for the service provider organization.
        /// </summary>
        [XurrentField("cost_per_hour")]
        public decimal? CostPerHour
        {
            get => _costPerHour;
            set => _costPerHour = SetValue("cost_per_hour", _costPerHour, value);
        }

        /// <summary>
        /// Gets or sets the currency of the cost per hour value.
        /// </summary>
        [XurrentField("cost_per_hour_currency")]
        public Currency? CostPerHourCurrency
        {
            get => _costPerHourCurrency;
            set => _costPerHourCurrency = SetValue("cost_per_hour_currency", _costPerHourCurrency, value);
        }

        /// <summary>
        /// Gets the date and time at which the person was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the person may no longer be related to other records.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the languages that should not be translated automatically for the person.<br />
        /// This field can contain a comma-separated list of language codes.
        /// </summary>
        [XurrentField("do_not_translate_languages")]
        public string? DoNotTranslateLanguages
        {
            get => _doNotTranslateLanguages;
            set => _doNotTranslateLanguages = SetValue("do_not_translate_languages", _doNotTranslateLanguages, value);
        }

        /// <summary>
        /// Gets or sets the unique employee identifier of the person.
        /// </summary>
        [XurrentField("employeeID")]
        public string? EmployeeID
        {
            get => _employeeID;
            set => _employeeID = SetValue("employeeID", _employeeID, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the person wants to receive team notifications.
        /// </summary>
        [XurrentField("exclude_team_notifications")]
        public bool? ExcludeTeamNotifications
        {
            get => _excludeTeamNotifications;
            set => _excludeTeamNotifications = SetValue("exclude_team_notifications", _excludeTeamNotifications, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the person was registered as a guest in self service.
        /// </summary>
        [XurrentField("guest")]
        public bool? Guest
        {
            get => _guest;
            set => _guest = SetValue("guest", _guest, value);
        }

        /// <summary>
        /// Gets or sets additional information about the person.
        /// </summary>
        [XurrentField("information")]
        public string? Information
        {
            get => _information;
            set => _information = SetValue("information", _information, value);
        }

        [XurrentField("information_attachments")]
        internal ObservableCollection<AttachmentReference> InformationAttachmentsCollection
        {
            get => GetCollection(ref _informationAttachments, OnInformationAttachmentsChanged);
            set => SetCollection(ref _informationAttachments, "information_attachments", value, OnInformationAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the information field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter InformationAttachments
        {
            get
            {
                _informationAttachmentsWriter ??= new AttachmentReferenceWriter(() => InformationAttachmentsCollection, c => InformationAttachmentsCollection = c);
                return _informationAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the job title of the person.
        /// </summary>
        [XurrentField("job_title")]
        public string? JobTitle
        {
            get => _jobTitle;
            set => _jobTitle = SetValue("job_title", _jobTitle, value);
        }

        /// <summary>
        /// Gets or sets the language preference of the person.
        /// </summary>
        [XurrentField("locale")]
        public string? Locale
        {
            get => _locale;
            set => _locale = SetValue("locale", _locale, value);
        }

        /// <summary>
        /// Gets or sets the name or number of the room, cubicle, or area where the person has their primary workspace.
        /// </summary>
        [XurrentField("location")]
        public string? Location
        {
            get => _location;
            set => _location = SetValue("location", _location, value);
        }

        /// <summary>
        /// Gets or sets the manager or supervisor to whom the person reports.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the OAuth person is enabled.<br />
        /// An enabled OAuth person is mentionable and visible in suggest fields.
        /// </summary>
        [XurrentField("oauth_person_enablement")]
        public bool? OauthPersonEnablement
        {
            get => _oauthPersonEnablement;
            set => _oauthPersonEnablement = SetValue("oauth_person_enablement", _oauthPersonEnablement, value);
        }

        /// <summary>
        /// Gets or sets the organization for which the person works.
        /// </summary>
        [XurrentField("organization")]
        public Organization? Organization
        {
            get => _organization;
            set => _organization = SetValue("organization", _organization, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the person.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the primary email address used for email notifications.<br />
        /// This email address uniquely identifies the person within the account.
        /// </summary>
        [XurrentField("primary_email")]
        public string? PrimaryEmail
        {
            get => _primaryEmail;
            set => _primaryEmail = SetValue("primary_email", _primaryEmail, value);
        }

        /// <summary>
        /// Gets or sets when email notifications are sent to the person.
        /// </summary>
        [XurrentField("send_email_notifications")]
        public SendEmailNotifications? SendEmailNotifications
        {
            get => _sendEmailNotifications;
            set => _sendEmailNotifications = SetValue("send_email_notifications", _sendEmailNotifications, value);
        }

        /// <summary>
        /// Gets or sets when notification popups are shown to the person.
        /// </summary>
        [XurrentField("show_notification_popup")]
        public ShowNotificationPopup? ShowNotificationPopup
        {
            get => _showNotificationPopup;
            set => _showNotificationPopup = SetValue("show_notification_popup", _showNotificationPopup, value);
        }

        /// <summary>
        /// Gets or sets the site where the person is stationed.
        /// </summary>
        [XurrentField("site")]
        public Site? Site
        {
            get => _site;
            set => _site = SetValue("site", _site, value);
        }

        /// <summary>
        /// Gets or sets the source of the person.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the person.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the support identifier used by the service desk.
        /// </summary>
        [XurrentField("supportID")]
        public string? SupportID
        {
            get => _supportID;
            set => _supportID = SetValue("supportID", _supportID, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether times are displayed using the 24-hour format.
        /// </summary>
        [XurrentField("time_format_24h")]
        public bool? TimeFormat24h
        {
            get => _timeFormat24h;
            set => _timeFormat24h = SetValue("time_format_24h", _timeFormat24h, value);
        }

        /// <summary>
        /// Gets or sets the time zone in which the person normally resides.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the UI extension that is applied to the person.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the person.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the person is marked as a very important person.
        /// </summary>
        [XurrentField("vip")]
        public bool? Vip
        {
            get => _vip;
            set => _vip = SetValue("vip", _vip, value);
        }

        /// <summary>
        /// Gets or sets the calendar that represents the work hours of the person.
        /// </summary>
        [XurrentField("work_hours")]
        public Calendar? WorkHours
        {
            get => _workHours;
            set => _workHours = SetValue("work_hours", _workHours, value);
        }

        /// <summary>
        /// Creates a new person instance.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Creates a new person instance.
        /// </summary>
        /// <param name="id">The unique identifier of the person.</param>
        public Person(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new person instance.
        /// </summary>
        /// <param name="name">The name of the person.</param>
        /// <param name="primaryEmail">The primary email of the person.</param>
        public Person(string name, string primaryEmail)
        {
            _name = SetValue("name", name);
            _primaryEmail = SetValue("primary_email", primaryEmail);
        }

        private void OnInformationAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "information_attachments");
        }
    }
}
