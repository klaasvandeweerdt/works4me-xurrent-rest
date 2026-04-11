using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent invoice object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Invoice : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="Invoice"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The amortization end field.
            /// </summary>
            [XurrentEnum("amortization_end")]
            AmortizationEnd,

            /// <summary>
            /// The amortization start field.
            /// </summary>
            [XurrentEnum("amortization_start")]
            AmortizationStart,

            /// <summary>
            /// The amortize field.
            /// </summary>
            [XurrentEnum("amortize")]
            Amortize,

            /// <summary>
            /// The amount field.
            /// </summary>
            [XurrentEnum("amount")]
            Amount,

            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The configuration items identifiers field.
            /// </summary>
            [XurrentEnum("ci_ids", IgnoreInFieldSelection = true)]
            ConfigurationItemsIdentifiers,

            /// <summary>
            /// The contract field.
            /// </summary>
            [XurrentEnum("contract", IgnoreInFieldSelection = true)]
            Contract,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The currency field.
            /// </summary>
            [XurrentEnum("currency")]
            Currency,

            /// <summary>
            /// The depreciation method field.
            /// </summary>
            [XurrentEnum("depreciation_method")]
            DepreciationMethod,

            /// <summary>
            /// The depreciation start field.
            /// </summary>
            [XurrentEnum("depreciation_start")]
            DepreciationStart,

            /// <summary>
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

            /// <summary>
            /// The financial identifier field.
            /// </summary>
            [XurrentEnum("financialID")]
            FinancialID,

            /// <summary>
            /// The first line support agreement field.
            /// </summary>
            [XurrentEnum("flsa", IgnoreInFieldSelection = true)]
            Flsa,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The invoice date field.
            /// </summary>
            [XurrentEnum("invoice_date")]
            InvoiceDate,

            /// <summary>
            /// The invoice nr field.
            /// </summary>
            [XurrentEnum("invoice_nr")]
            InvoiceNr,

            /// <summary>
            /// The invoice type field.
            /// </summary>
            [XurrentEnum("invoice_type")]
            InvoiceType,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The po nr field.
            /// </summary>
            [XurrentEnum("po_nr")]
            PoNr,

            /// <summary>
            /// The project field.
            /// </summary>
            [XurrentEnum("project", IgnoreInFieldSelection = true)]
            Project,

            /// <summary>
            /// The quantity field.
            /// </summary>
            [XurrentEnum("quantity")]
            Quantity,

            /// <summary>
            /// The rate field.
            /// </summary>
            [XurrentEnum("rate")]
            Rate,

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
            /// The service level agreement field.
            /// </summary>
            [XurrentEnum("sla", IgnoreInFieldSelection = true)]
            Sla,

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
            /// The unit price field.
            /// </summary>
            [XurrentEnum("unit_price")]
            UnitPrice,

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
            /// The workflow field.
            /// </summary>
            [XurrentEnum("workflow", IgnoreInFieldSelection = true)]
            Workflow
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="Invoice"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters invoices by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters invoices by description.
            /// </summary>
            [XurrentEnum("description")]
            Description,

            /// <summary>
            /// Filters invoices by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters invoices by invoice date.
            /// </summary>
            [XurrentEnum("invoice_date")]
            InvoiceDate,

            /// <summary>
            /// Filters invoices by invoice number.
            /// </summary>
            [XurrentEnum("invoice_nr")]
            InvoiceNr,

            /// <summary>
            /// Filters invoices by invoice type.
            /// </summary>
            [XurrentEnum("invoice_type")]
            InvoiceType,

            /// <summary>
            /// Filters invoices by purchase order number.
            /// </summary>
            [XurrentEnum("po_nr")]
            PoNr,

            /// <summary>
            /// Filters invoices by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters invoices by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters invoices by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
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
        /// Represents the fields used to order an <see cref="Invoice"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts invoices by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts invoices by description.
            /// </summary>
            [XurrentEnum("description")]
            Description,

            /// <summary>
            /// Sorts invoices by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts invoices by invoice date.
            /// </summary>
            [XurrentEnum("invoice_date")]
            InvoiceDate,

            /// <summary>
            /// Sorts invoices by invoice number.
            /// </summary>
            [XurrentEnum("invoice_nr")]
            InvoiceNr,

            /// <summary>
            /// Sorts invoices by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts invoices by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private DateTime? _amortizationEnd;
        private DateTime? _amortizationStart;
        private bool? _amortize;
        private decimal? _amount;
        private List<Attachment>? _attachments;
        private ObservableCollection<long>? _configurationItemsIdentifiers;
        private Contract? _contract;
        private DateTime? _createdAt;
        private Currency? _currency;
        private ProductDepreciationMethod? _depreciationMethod;
#if (NET6_0_OR_GREATER)
        private DateOnly? _depreciationStart;
#else
        private DateTime? _depreciationStart;
#endif
        private string? _description;
        private string? _financialID;
        private FirstLineSupportAgreement? _flsa;
#if (NET6_0_OR_GREATER)
        private DateOnly? _invoiceDate;
#else
        private DateTime? _invoiceDate;
#endif
        private string? _invoiceNr;
        private string? _invoiceType;
        private string? _poNr;
        private Project? _project;
        private decimal? _quantity;
        private int? _rate;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private decimal? _salvageValue;
        private Currency? _salvageValueCurrency;
        private Service? _service;
        private ServiceLevelAgreement? _sla;
        private string? _source;
        private string? _sourceID;
        private Organization? _supplier;
        private decimal? _unitPrice;
        private DateTime? _updatedAt;
        private int? _usefulLife;
        private Workflow? _workflow;

        /// <summary>
        /// Gets or sets the end date of the period over which the invoice is amortized.
        /// </summary>
        [XurrentField("amortization_end")]
        public DateTime? AmortizationEnd
        {
            get => _amortizationEnd;
            set => _amortizationEnd = SetValue("amortization_end", _amortizationEnd, value);
        }

        /// <summary>
        /// Gets or sets the start date of the period over which the invoice is amortized.
        /// </summary>
        [XurrentField("amortization_start")]
        public DateTime? AmortizationStart
        {
            get => _amortizationStart;
            set => _amortizationStart = SetValue("amortization_start", _amortizationStart, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the invoice amount is amortized.
        /// </summary>
        [XurrentField("amortize")]
        public bool? Amortize
        {
            get => _amortize;
            set => _amortize = SetValue("amortize", _amortize, value);
        }

        /// <summary>
        /// Gets the total amount of the invoice.
        /// </summary>
        [XurrentField("amount")]
        public decimal? Amount
        {
            get => _amount;
            internal set => _amount = value;
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Sets the identifiers of configuration items to be linked to the invoice during creation.<br />
        /// This property is only supported when creating an invoice.
        /// </summary>
        [XurrentField("ci_ids")]
        public ObservableCollection<long> ConfigurationItemsIdentifiers
        {
            get => GetCollection(ref _configurationItemsIdentifiers, OnConfigurationItemsIdentifiersChanged);
            set => SetCollection(ref _configurationItemsIdentifiers, "ci_ids", value, OnConfigurationItemsIdentifiersChanged);
        }

        /// <summary>
        /// Gets the contract linked to the invoice.
        /// </summary>
        [XurrentField("contract")]
        public Contract? Contract
        {
            get => _contract;
            internal set => _contract = value;
        }

        /// <summary>
        /// Gets the date and time when the invoice was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the currency of the invoice amount.
        /// </summary>
        [XurrentField("currency")]
        public Currency? Currency
        {
            get => _currency;
            set => _currency = SetValue("currency", _currency, value);
        }

        /// <summary>
        /// Gets or sets the depreciation method applied to the invoice.
        /// </summary>
        [XurrentField("depreciation_method")]
        public ProductDepreciationMethod? DepreciationMethod
        {
            get => _depreciationMethod;
            set => _depreciationMethod = SetValue("depreciation_method", _depreciationMethod, value);
        }

        /// <summary>
        /// Gets or sets the date on which depreciation starts.
        /// </summary>
        [XurrentField("depreciation_start")]
#if (NET6_0_OR_GREATER)
        public DateOnly? DepreciationStart
#else
        public DateTime? DepreciationStart
#endif
        {
            get => _depreciationStart;
            set => _depreciationStart = SetValue("depreciation_start", _depreciationStart, value);
        }

        /// <summary>
        /// Gets or sets the description of the invoice.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        /// <summary>
        /// Gets or sets the financial system identifier of the invoice.
        /// </summary>
        [XurrentField("financialID")]
        public string? FinancialID
        {
            get => _financialID;
            set => _financialID = SetValue("financialID", _financialID, value);
        }

        /// <summary>
        /// Gets the first line support agreement linked to the invoice.
        /// </summary>
        [XurrentField("flsa")]
        public FirstLineSupportAgreement? Flsa
        {
            get => _flsa;
            internal set => _flsa = value;
        }

        /// <summary>
        /// Gets or sets the invoice date.
        /// </summary>
        [XurrentField("invoice_date")]
#if (NET6_0_OR_GREATER)
        public DateOnly? InvoiceDate
#else
        public DateTime? InvoiceDate
#endif
        {
            get => _invoiceDate;
            set => _invoiceDate = SetValue("invoice_date", _invoiceDate, value);
        }

        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        [XurrentField("invoice_nr")]
        public string? InvoiceNr
        {
            get => _invoiceNr;
            set => _invoiceNr = SetValue("invoice_nr", _invoiceNr, value);
        }

        /// <summary>
        /// Gets the type of record linked to the invoice.
        /// </summary>
        [XurrentField("invoice_type")]
        public string? InvoiceType
        {
            get => _invoiceType;
            internal set => _invoiceType = value;
        }

        /// <summary>
        /// Gets or sets the purchase order number.
        /// </summary>
        [XurrentField("po_nr")]
        public string? PoNr
        {
            get => _poNr;
            set => _poNr = SetValue("po_nr", _poNr, value);
        }

        /// <summary>
        /// Gets the project linked to the invoice.
        /// </summary>
        [XurrentField("project")]
        public Project? Project
        {
            get => _project;
            internal set => _project = value;
        }

        /// <summary>
        /// Gets or sets the quantity of acquired units.
        /// </summary>
        [XurrentField("quantity")]
        public decimal? Quantity
        {
            get => _quantity;
            set => _quantity = SetValue("quantity", _quantity, value);
        }

        /// <summary>
        /// Gets or sets the depreciation rate.
        /// </summary>
        [XurrentField("rate")]
        public int? Rate
        {
            get => _rate;
            set => _rate = SetValue("rate", _rate, value);
        }

        /// <summary>
        /// Gets or sets the remarks of the invoice.
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
        /// Sets the attachments used for the remarks field.<br />
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
        /// Gets or sets the salvage value of the invoice.
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
        /// Gets the service linked to the invoice.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            internal set => _service = value;
        }

        /// <summary>
        /// Gets the service level agreement linked to the invoice.
        /// </summary>
        [XurrentField("sla")]
        public ServiceLevelAgreement? Sla
        {
            get => _sla;
            internal set => _sla = value;
        }

        /// <summary>
        /// Gets or sets the source of the invoice.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the invoice.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the supplier organization of the invoice.
        /// </summary>
        [XurrentField("supplier")]
        public Organization? Supplier
        {
            get => _supplier;
            set => _supplier = SetValue("supplier", _supplier, value);
        }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        [XurrentField("unit_price")]
        public decimal? UnitPrice
        {
            get => _unitPrice;
            set => _unitPrice = SetValue("unit_price", _unitPrice, value);
        }

        /// <summary>
        /// Gets the date and time when the invoice was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the useful life in years.
        /// </summary>
        [XurrentField("useful_life")]
        public int? UsefulLife
        {
            get => _usefulLife;
            set => _usefulLife = SetValue("useful_life", _usefulLife, value);
        }

        /// <summary>
        /// Gets the workflow linked to the invoice.
        /// </summary>
        [XurrentField("workflow")]
        public Workflow? Workflow
        {
            get => _workflow;
            internal set => _workflow = value;
        }

        /// <summary>
        /// Creates a new invoice instance.
        /// </summary>
        public Invoice()
        {
        }

        /// <summary>
        /// Creates a new invoice instance.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice.</param>
        public Invoice(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new invoice instance.
        /// </summary>
        /// <param name="depreciationMethod">The depreciation method of the invoice.</param>
        /// <param name="depreciationStart">The depreciation start of the invoice.</param>
        /// <param name="invoiceDate">The invoice date of the invoice.</param>
        /// <param name="invoiceNr">The invoice nr of the invoice.</param>
        /// <param name="quantity">The quantity of the invoice.</param>
#if (NET6_0_OR_GREATER)
        public Invoice(ProductDepreciationMethod depreciationMethod, DateOnly depreciationStart, DateOnly invoiceDate, string invoiceNr, decimal quantity)
#else
        public Invoice(ProductDepreciationMethod depreciationMethod, DateTime depreciationStart, DateTime invoiceDate, string invoiceNr, decimal quantity)
#endif
        {
            _depreciationMethod = SetValue("depreciation_method", depreciationMethod);
            _depreciationStart = SetValue("depreciation_start", depreciationStart);
            _invoiceDate = SetValue("invoice_date", invoiceDate);
            _invoiceNr = SetValue("invoice_nr", invoiceNr);
            _quantity = SetValue("quantity", quantity);
        }

        private void OnConfigurationItemsIdentifiersChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<long> collection)
                MarkCollectionChanged(collection, "ci_ids");
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }
    }
}
