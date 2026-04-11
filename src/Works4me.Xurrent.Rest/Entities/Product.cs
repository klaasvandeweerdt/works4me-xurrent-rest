using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent product object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Product : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Product"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The brand field.
            /// </summary>
            [XurrentEnum("brand")]
            Brand,

            /// <summary>
            /// The category field.
            /// </summary>
            [XurrentEnum("category")]
            Category,

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
            /// The depreciation method field.
            /// </summary>
            [XurrentEnum("depreciation_method")]
            DepreciationMethod,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

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
            /// The model field.
            /// </summary>
            [XurrentEnum("model")]
            Model,

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
            /// The picture uri field.
            /// </summary>
            [XurrentEnum("picture_uri")]
            PictureUri,

            /// <summary>
            /// The product identifier field.
            /// </summary>
            [XurrentEnum("productID")]
            ProductID,

            /// <summary>
            /// The rate field.
            /// </summary>
            [XurrentEnum("rate")]
            Rate,

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
            /// The salvage value field.
            /// </summary>
            [XurrentEnum("salvage_value")]
            SalvageValue,

            /// <summary>
            /// The salvage value currency field.
            /// </summary>
            [XurrentEnum("salvage_value_currency")]
            SalvageValueCurrency,

            /// <summary>
            /// The service field.
            /// </summary>
            [XurrentEnum("service")]
            Service,

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
            /// The useful life field.
            /// </summary>
            [XurrentEnum("useful_life")]
            UsefulLife,

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
        /// Represents the filterable fields of a <see cref="Product"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters products by category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Filters products by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters products by whether they are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters products by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters products by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters products by rule set.
            /// </summary>
            [XurrentEnum("rule_set")]
            RuleSet,

            /// <summary>
            /// Filters products by associated service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Filters products by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters products by identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters products by support team.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// Filters products by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Product"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled products.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled products.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled,

            /// <summary>
            /// Lists all products whose support team is one of the teams the API user is a member of.
            /// </summary>
            [XurrentEnum("supported_by_my_teams")]
            SupportedByMyTeams
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Product"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts products by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts products by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts products by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts products by the service they are associated with.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Sorts products by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts products by their support team.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// Sorts products by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private string? _brand;
        private string? _category;
        private DateTime? _createdAt;
        private ProductDepreciationMethod? _depreciationMethod;
        private bool? _disabled;
        private Organization? _financialOwner;
        private string? _model;
        private string? _name;
        private Uri? _pictureUri;
        private string? _productID;
        private int? _rate;
        private Recurrence? _recurrence;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private ProductCategoryRuleSet? _ruleSet;
        private decimal? _salvageValue;
        private Currency? _salvageValueCurrency;
        private Service? _service;
        private string? _source;
        private string? _sourceID;
        private Organization? _supplier;
        private Team? _supportTeam;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;
        private int? _usefulLife;
        private Person? _workflowManager;
        private WorkflowTemplate? _workflowTemplate;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments of the product.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the brand of the product.
        /// </summary>
        [XurrentField("brand")]
        public string? Brand
        {
            get => _brand;
            set => _brand = SetValue("brand", _brand, value);
        }

        /// <summary>
        /// Gets or sets the product category reference of the product.<br />
        /// This value must be the reference field of the related product category.
        /// </summary>
        [XurrentField("category")]
        public string? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets the date and time at which the product was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the depreciation method applied to configuration items based on the product.
        /// </summary>
        [XurrentField("depreciation_method")]
        public ProductDepreciationMethod? DepreciationMethod
        {
            get => _depreciationMethod;
            set => _depreciationMethod = SetValue("depreciation_method", _depreciationMethod, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the product is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the financial owner organization of the product.
        /// </summary>
        [XurrentField("financial_owner")]
        public Organization? FinancialOwner
        {
            get => _financialOwner;
            set => _financialOwner = SetValue("financial_owner", _financialOwner, value);
        }

        /// <summary>
        /// Gets or sets the model of the product.
        /// </summary>
        [XurrentField("model")]
        public string? Model
        {
            get => _model;
            set => _model = SetValue("model", _model, value);
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the URI of the image file for the product.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the manufacturer product identifier of the product.
        /// </summary>
        [XurrentField("productID")]
        public string? ProductID
        {
            get => _productID;
            set => _productID = SetValue("productID", _productID, value);
        }

        /// <summary>
        /// Gets or sets the yearly depreciation rate for the product.
        /// </summary>
        [XurrentField("rate")]
        public int? Rate
        {
            get => _rate;
            set => _rate = SetValue("rate", _rate, value);
        }

        /// <summary>
        /// Gets the recurrence settings of the product.
        /// </summary>
        [XurrentField("recurrence")]
        public Recurrence? Recurrence
        {
            get => _recurrence;
            internal set => _recurrence = value;
        }

        /// <summary>
        /// Gets or sets the remarks of the product.
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
        /// Gets the product category rule set of the product.
        /// </summary>
        [XurrentField("rule_set")]
        public ProductCategoryRuleSet? RuleSet
        {
            get => _ruleSet;
            internal set => _ruleSet = value;
        }

        /// <summary>
        /// Gets or sets the salvage value of configuration items based on the product.
        /// </summary>
        [XurrentField("salvage_value")]
        public decimal? SalvageValue
        {
            get => _salvageValue;
            set => _salvageValue = SetValue("salvage_value", _salvageValue, value);
        }

        /// <summary>
        /// Gets or sets the currency of the salvage value.
        /// </summary>
        [XurrentField("salvage_value_currency")]
        public Currency? SalvageValueCurrency
        {
            get => _salvageValueCurrency;
            set => _salvageValueCurrency = SetValue("salvage_value_currency", _salvageValueCurrency, value);
        }

        /// <summary>
        /// Gets or sets the service typically associated with the product.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier of the product.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the product in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the supplier organization of the product.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the support team responsible for the product.
        /// </summary>
        [XurrentField("support_team")]
        public Team? SupportTeam
        {
            get => _supportTeam;
            set => _supportTeam = SetValue("support_team", _supportTeam, value);
        }

        /// <summary>
        /// Gets or sets the UI extension associated with the product.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            set => _uiExtension = SetValue("ui_extension", _uiExtension, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the product.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the useful life of configuration items based on the product in years.
        /// </summary>
        [XurrentField("useful_life")]
        public int? UsefulLife
        {
            get => _usefulLife;
            set => _usefulLife = SetValue("useful_life", _usefulLife, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for coordinating workflows for the product.
        /// </summary>
        [XurrentField("workflow_manager")]
        public Person? WorkflowManager
        {
            get => _workflowManager;
            set => _workflowManager = SetValue("workflow_manager", _workflowManager, value);
        }

        /// <summary>
        /// Gets or sets the workflow template used to maintain configuration items created from the product.
        /// </summary>
        [XurrentField("workflow_template")]
        public WorkflowTemplate? WorkflowTemplate
        {
            get => _workflowTemplate;
            set => _workflowTemplate = SetValue("workflow_template", _workflowTemplate, value);
        }

        /// <summary>
        /// Creates a new product instance.
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// Creates a new product instance.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        public Product(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new product instance.
        /// </summary>
        /// <param name="category">The category of the product.</param>
        /// <param name="model">The model of the product.</param>
        /// <param name="name">The name of the product.</param>
        public Product(string category, string model, string name)
        {
            _category = SetValue("category", category);
            _model = SetValue("model", model);
            _name = SetValue("name", name);
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }
    }
}
