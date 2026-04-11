using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent configuration item object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ConfigurationItem : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ConfigurationItem"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The alternate names field.
            /// </summary>
            [XurrentEnum("alternate_names")]
            AlternateNames,

            /// <summary>
            /// The asset identifier field.
            /// </summary>
            [XurrentEnum("assetID")]
            AssetID,

            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

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
            /// The financial owner field.
            /// </summary>
            [XurrentEnum("financial_owner")]
            FinancialOwner,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The in use since field.
            /// </summary>
            [XurrentEnum("in_use_since")]
            InUseSince,

            /// <summary>
            /// The label field.
            /// </summary>
            [XurrentEnum("label")]
            Label,

            /// <summary>
            /// The license expiry date field.
            /// </summary>
            [XurrentEnum("license_expiry_date")]
            LicenseExpiryDate,

            /// <summary>
            /// The license type field.
            /// </summary>
            [XurrentEnum("license_type")]
            LicenseType,

            /// <summary>
            /// The location field.
            /// </summary>
            [XurrentEnum("location")]
            Location,

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
            /// The nr of cores field.
            /// </summary>
            [XurrentEnum("nr_of_cores")]
            NrOfCores,

            /// <summary>
            /// The nr of licenses field.
            /// </summary>
            [XurrentEnum("nr_of_licenses")]
            NrOfLicenses,

            /// <summary>
            /// The nr of processors field.
            /// </summary>
            [XurrentEnum("nr_of_processors")]
            NrOfProcessors,

            /// <summary>
            /// The product field.
            /// </summary>
            [XurrentEnum("product")]
            Product,

            /// <summary>
            /// The recurrence field.
            /// </summary>
            [XurrentEnum("recurrence")]
            Recurrence,

            /// <summary>
            /// The remarks field.
            /// </summary>
            [XurrentEnum("remarks")]
            Remarks,

            /// <summary>
            /// The remarks attachments field.
            /// </summary>
            [XurrentEnum("remarks_attachments", IgnoreInFieldSelection = true)]
            RemarksAttachments,

            /// <summary>
            /// The rule set field.
            /// </summary>
            [XurrentEnum("rule_set")]
            RuleSet,

            /// <summary>
            /// The serial nr field.
            /// </summary>
            [XurrentEnum("serial_nr")]
            SerialNr,

            /// <summary>
            /// The service field.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// The site field.
            /// </summary>
            [XurrentEnum("site")]
            Site,

            /// <summary>
            /// The site license field.
            /// </summary>
            [XurrentEnum("site_license")]
            SiteLicense,

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
            /// The status field.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// The supplier field.
            /// </summary>
            [XurrentEnum("supplier")]
            Supplier,

            /// <summary>
            /// The support team field.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// The system identifier field.
            /// </summary>
            [XurrentEnum("systemID")]
            SystemID,

            /// <summary>
            /// The temporary license field.
            /// </summary>
            [XurrentEnum("temporary_license")]
            TemporaryLicense,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The warranty expiry date field.
            /// </summary>
            [XurrentEnum("warranty_expiry_date")]
            WarrantyExpiryDate,

            /// <summary>
            /// The workflow manager field.
            /// </summary>
            [XurrentEnum("workflow_manager")]
            WorkflowManager,

            /// <summary>
            /// The workflow template field.
            /// </summary>
            [XurrentEnum("workflow_template")]
            WorkflowTemplate
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ConfigurationItem"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters configuration items by asset identifier.
            /// </summary>
            [XurrentEnum("assetID")]
            AssetID,

            /// <summary>
            /// Filters configuration items by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters configuration items by financial owner.
            /// </summary>
            [XurrentEnum("financial_owner")]
            FinancialOwner,

            /// <summary>
            /// Filters configuration items by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters configuration items by label.
            /// </summary>
            [XurrentEnum("label")]
            Label,

            /// <summary>
            /// Filters configuration items by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters configuration items by product.
            /// </summary>
            [XurrentEnum("product")]
            Product,

            /// <summary>
            /// Filters configuration items by product category rule set.
            /// </summary>
            [XurrentEnum("rule_set")]
            RuleSet,

            /// <summary>
            /// Filters configuration items by serial number.
            /// </summary>
            [XurrentEnum("serial_nr")]
            SerialNr,

            /// <summary>
            /// Filters configuration items by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Filters configuration items by site.
            /// </summary>
            [XurrentEnum("site")]
            Site,

            /// <summary>
            /// Filters configuration items by external source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters configuration items by external source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters configuration items by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters configuration items by support team.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// Filters configuration items by system identifier.
            /// </summary>
            [XurrentEnum("systemID")]
            SystemID,

            /// <summary>
            /// Filters configuration items by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ConfigurationItem"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all active configuration items.
            /// </summary>
            [XurrentEnum("active")]
            Active,

            /// <summary>
            /// Lists all inactive configuration items.
            /// </summary>
            [XurrentEnum("inactive")]
            Inactive,

            /// <summary>
            /// Lists all configuration items for which the support team is one of the teams the API user is a member of.
            /// </summary>
            [XurrentEnum("supported_by_my_teams")]
            SupportedByMyTeams
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ConfigurationItem"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts configuration items by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts configuration items by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts configuration items by label.
            /// </summary>
            [XurrentEnum("label")]
            Label,

            /// <summary>
            /// Sorts configuration items by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts configuration items by external source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts configuration items by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts configuration items by support team.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// Sorts configuration items by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private ObservableCollection<string>? _alternateNames;
        private string? _assetID;
        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private Organization? _financialOwner;
        private DateTime? _inUseSince;
        private string? _label;
        private DateTime? _licenseExpiryDate;
        private ConfigurationItemLicenseType? _licenseType;
        private string? _location;
        private string? _name;
        private int? _nrOfCores;
        private int? _nrOfLicenses;
        private int? _nrOfProcessors;
        private Product? _product;
        private Recurrence? _recurrence;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private ProductCategoryRuleSet? _ruleSet;
        private string? _serialNr;
        private Service? _service;
        private Site? _site;
        private bool? _siteLicense;
        private string? _source;
        private string? _sourceID;
        private ConfigurationItemStatus? _status;
        private Organization? _supplier;
        private Team? _supportTeam;
        private string? _systemID;
        private bool? _temporaryLicense;
        private DateTime? _updatedAt;
#if (NET6_0_OR_GREATER)
        private DateOnly? _warrantyExpiryDate;
#else
        private DateTime? _warrantyExpiryDate;
#endif
        private Person? _workflowManager;
        private WorkflowTemplate? _workflowTemplate;

        /// <summary>
        /// Gets or sets the alternate names by which the configuration item is also known.
        /// </summary>
        [XurrentField("alternate_names")]
        public ObservableCollection<string> AlternateNames
        {
            get => GetCollection(ref _alternateNames, OnAlternateNamesChanged);
            set => SetCollection(ref _alternateNames, "alternate_names", value, OnAlternateNamesChanged);
        }

        /// <summary>
        /// Gets or sets the asset identifier of the configuration item.
        /// </summary>
        [XurrentField("assetID")]
        public string? AssetID
        {
            get => _assetID;
            set => _assetID = SetValue("assetID", _assetID, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments of the configuration item.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the configuration item was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the financial owner organization of the configuration item.
        /// </summary>
        [XurrentField("financial_owner")]
        public Organization? FinancialOwner
        {
            get => _financialOwner;
            set => _financialOwner = SetValue("financial_owner", _financialOwner, value);
        }

        /// <summary>
        /// Gets or sets the date on which the configuration item started to incur expenses or depreciation.
        /// </summary>
        [XurrentField("in_use_since")]
        public DateTime? InUseSince
        {
            get => _inUseSince;
            set => _inUseSince = SetValue("in_use_since", _inUseSince, value);
        }

        /// <summary>
        /// Gets or sets the label assigned to the configuration item.
        /// </summary>
        [XurrentField("label")]
        public string? Label
        {
            get => _label;
            set => _label = SetValue("label", _label, value);
        }

        /// <summary>
        /// Gets or sets the date through which the license certificate is valid.
        /// </summary>
        [XurrentField("license_expiry_date")]
        public DateTime? LicenseExpiryDate
        {
            get => _licenseExpiryDate;
            set => _licenseExpiryDate = SetValue("license_expiry_date", _licenseExpiryDate, value);
        }

        /// <summary>
        /// Gets or sets the license type covered by the license certificate.
        /// </summary>
        [XurrentField("license_type")]
        public ConfigurationItemLicenseType? LicenseType
        {
            get => _licenseType;
            set => _licenseType = SetValue("license_type", _licenseType, value);
        }

        /// <summary>
        /// Gets or sets the location of the configuration item.
        /// </summary>
        [XurrentField("location")]
        public string? Location
        {
            get => _location;
            set => _location = SetValue("location", _location, value);
        }

        /// <summary>
        /// Gets or sets the name of the configuration item.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the total number of processor cores installed in the configuration item.
        /// </summary>
        [XurrentField("nr_of_cores")]
        public int? NrOfCores
        {
            get => _nrOfCores;
            set => _nrOfCores = SetValue("nr_of_cores", _nrOfCores, value);
        }

        /// <summary>
        /// Gets or sets the number of licenses covered by the license certificate.
        /// </summary>
        [XurrentField("nr_of_licenses")]
        public int? NrOfLicenses
        {
            get => _nrOfLicenses;
            set => _nrOfLicenses = SetValue("nr_of_licenses", _nrOfLicenses, value);
        }

        /// <summary>
        /// Gets or sets the number of processors installed in the configuration item.
        /// </summary>
        [XurrentField("nr_of_processors")]
        public int? NrOfProcessors
        {
            get => _nrOfProcessors;
            set => _nrOfProcessors = SetValue("nr_of_processors", _nrOfProcessors, value);
        }

        /// <summary>
        /// Gets or sets the product related to the configuration item.
        /// </summary>
        [XurrentField("product")]
        public Product? Product
        {
            get => _product;
            set => _product = SetValue("product", _product, value);
        }

        /// <summary>
        /// Gets or sets the recurrence settings of the configuration item.
        /// </summary>
        [XurrentField("recurrence")]
        public Recurrence? Recurrence
        {
            get => _recurrence;
            internal set => _recurrence = value;
        }

        /// <summary>
        /// Gets or sets additional remarks for the configuration item.
        /// </summary>
        [XurrentField("remarks")]
        public string? Remarks
        {
            get => _remarks;
            set => _remarks = SetValue("remarks", _remarks, value);
        }

        [XurrentField("remarks_attachments")]
        internal ObservableCollection<AttachmentReference> RemarksAttachmentsCollection
        {
            get => GetCollection(ref _remarksAttachments, OnRemarksAttachmentsChanged);
            set => SetCollection(ref _remarksAttachments, "remarks_attachments", value, OnRemarksAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the remarks field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter RemarksAttachments
        {
            get
            {
                _remarksAttachmentsWriter ??= new AttachmentReferenceWriter(() => RemarksAttachmentsCollection, c => RemarksAttachmentsCollection = c);
                return _remarksAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets the product category rule set of the configuration item.
        /// </summary>
        [XurrentField("rule_set")]
        public ProductCategoryRuleSet? RuleSet
        {
            get => _ruleSet;
            internal set => _ruleSet = value;
        }

        /// <summary>
        /// Gets or sets the serial number of the configuration item.
        /// </summary>
        [XurrentField("serial_nr")]
        public string? SerialNr
        {
            get => _serialNr;
            set => _serialNr = SetValue("serial_nr", _serialNr, value);
        }

        /// <summary>
        /// Gets or sets the service associated with the configuration item.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the site at which the configuration item is located.
        /// </summary>
        [XurrentField("site")]
        public Site? Site
        {
            get => _site;
            set => _site = SetValue("site", _site, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the license certificate is restricted to specific sites.
        /// </summary>
        [XurrentField("site_license")]
        public bool? SiteLicense
        {
            get => _siteLicense;
            set => _siteLicense = SetValue("site_license", _siteLicense, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier of the configuration item.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the configuration item in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the status of the configuration item.
        /// </summary>
        [XurrentField("status")]
        public ConfigurationItemStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the supplier from which the configuration item was obtained.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the support team responsible for the configuration item.
        /// </summary>
        [XurrentField("support_team")]
        public Team? SupportTeam
        {
            get => _supportTeam;
            set => _supportTeam = SetValue("support_team", _supportTeam, value);
        }

        /// <summary>
        /// Gets or sets the system identifier of the configuration item.
        /// </summary>
        [XurrentField("systemID")]
        public string? SystemID
        {
            get => _systemID;
            set => _systemID = SetValue("systemID", _systemID, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the license certificate is temporary.
        /// </summary>
        [XurrentField("temporary_license")]
        public bool? TemporaryLicense
        {
            get => _temporaryLicense;
            set => _temporaryLicense = SetValue("temporary_license", _temporaryLicense, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the configuration item.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the date through which the warranty coverage is valid.
        /// </summary>
        [XurrentField("warranty_expiry_date")]
#if (NET6_0_OR_GREATER)
        public DateOnly? WarrantyExpiryDate
#else
        public DateTime? WarrantyExpiryDate
#endif
        {
            get => _warrantyExpiryDate;
            set => _warrantyExpiryDate = SetValue("warranty_expiry_date", _warrantyExpiryDate, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for coordinating workflows for the configuration item.
        /// </summary>
        [XurrentField("workflow_manager")]
        public Person? WorkflowManager
        {
            get => _workflowManager;
            set => _workflowManager = SetValue("workflow_manager", _workflowManager, value);
        }

        /// <summary>
        /// Gets or sets the workflow template used to maintain the configuration item.
        /// </summary>
        [XurrentField("workflow_template")]
        public WorkflowTemplate? WorkflowTemplate
        {
            get => _workflowTemplate;
            set => _workflowTemplate = SetValue("workflow_template", _workflowTemplate, value);
        }

        /// <summary>
        /// Creates a new configuration item instance.
        /// </summary>
        public ConfigurationItem()
        {
        }

        /// <summary>
        /// Creates a new configuration item instance.
        /// </summary>
        /// <param name="id">The unique identifier of the configuration item.</param>
        public ConfigurationItem(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new configuration item instance.
        /// </summary>
        /// <param name="product">The product of the configuration item.</param>
        /// <param name="status">The status of the configuration item.</param>
        public ConfigurationItem(Product product, ConfigurationItemStatus status)
        {
            _product = SetValue("product", product);
            _status = SetValue("status", status);
        }

        private void OnAlternateNamesChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<string> collection)
                MarkCollectionChanged(collection, "alternate_names");
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }
    }
}
