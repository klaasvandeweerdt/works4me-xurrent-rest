using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent shop article object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ShopArticle : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ShopArticle"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The calendar field.
            /// </summary>
            [XurrentEnum("calendar")]
            Calendar,

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
            /// The delivery duration field.
            /// </summary>
            [XurrentEnum("delivery_duration")]
            DeliveryDuration,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The end at field.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

            /// <summary>
            /// The fulfillment template field.
            /// </summary>
            [XurrentEnum("fulfillment_template")]
            FulfillmentTemplate,

            /// <summary>
            /// The full description field.
            /// </summary>
            [XurrentEnum("full_description")]
            FullDescription,

            /// <summary>
            /// The full description attachments field.
            /// </summary>
            [XurrentEnum("full_description_attachments", IgnoreInFieldSelection = true)]
            FullDescriptionAttachments,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The is bundle field.
            /// </summary>
            [XurrentEnum("is_bundle")]
            IsBundle,

            /// <summary>
            /// The max quantity field.
            /// </summary>
            [XurrentEnum("max_quantity")]
            MaxQuantity,

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
            /// The price field.
            /// </summary>
            [XurrentEnum("price")]
            Price,

            /// <summary>
            /// The price currency field.
            /// </summary>
            [XurrentEnum("price_currency")]
            PriceCurrency,

            /// <summary>
            /// The product field.
            /// </summary>
            [XurrentEnum("product")]
            Product,

            /// <summary>
            /// The recurring period field.
            /// </summary>
            [XurrentEnum("recurring_period")]
            RecurringPeriod,

            /// <summary>
            /// The recurring price field.
            /// </summary>
            [XurrentEnum("recurring_price")]
            RecurringPrice,

            /// <summary>
            /// The recurring price currency field.
            /// </summary>
            [XurrentEnum("recurring_price_currency")]
            RecurringPriceCurrency,

            /// <summary>
            /// The reference field.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// The requires shipping field.
            /// </summary>
            [XurrentEnum("requires_shipping")]
            RequiresShipping,

            /// <summary>
            /// The short description field.
            /// </summary>
            [XurrentEnum("short_description")]
            ShortDescription,

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
            /// The start at field.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

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
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ShopArticle"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters shop articles by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters shop articles by disabled status.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters shop articles by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters shop articles by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters shop articles by reference.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Filters shop articles by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters shop articles by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters shop articles by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ShopArticle"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all shop articles that are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all shop articles that are enabled.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled,

            /// <summary>
            /// Lists all shop articles with information as it is offered in the shop.
            /// </summary>
            [XurrentEnum("on_offer")]
            OnOffer
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ShopArticle"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts shop articles by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts shop articles by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts shop articles by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts shop articles by reference.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Sorts shop articles by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts shop articles by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private Calendar? _calendar;
        private ShopArticleCategory? _category;
        private DateTime? _createdAt;
        private int? _deliveryDuration;
        private bool? _disabled;
        private DateTime? _endAt;
        private RequestTemplate? _fulfillmentTemplate;
        private string? _fullDescription;
        private ObservableCollection<AttachmentReference>? _fullDescriptionAttachments;
        private AttachmentReferenceWriter? _fullDescriptionAttachmentsWriter;
        private bool? _isBundle;
        private int? _maxQuantity;
        private string? _name;
        private Uri? _pictureUri;
        private decimal? _price;
        private Currency? _priceCurrency;
        private Product? _product;
        private ShopArticleRecurringPeriod? _recurringPeriod;
        private decimal? _recurringPrice;
        private Currency? _recurringPriceCurrency;
        private string? _reference;
        private bool? _requiresShipping;
        private string? _shortDescription;
        private string? _source;
        private string? _sourceID;
        private DateTime? _startAt;
        private string? _timeZone;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;

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
        /// Gets or sets the calendar that defines the work hours related to fulfillment and delivery.
        /// </summary>
        [XurrentField("calendar")]
        public Calendar? Calendar
        {
            get => _calendar;
            set => _calendar = SetValue("calendar", _calendar, value);
        }

        /// <summary>
        /// Gets or sets the category associated with the shop article.
        /// </summary>
        [XurrentField("category")]
        public ShopArticleCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets the date and time when the shop article was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the delivery duration of the shop article in minutes.
        /// </summary>
        [XurrentField("delivery_duration")]
        public int? DeliveryDuration
        {
            get => _deliveryDuration;
            set => _deliveryDuration = SetValue("delivery_duration", _deliveryDuration, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the shop article is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the date and time when the shop article is disabled.
        /// </summary>
        [XurrentField("end_at")]
        public DateTime? EndAt
        {
            get => _endAt;
            set => _endAt = SetValue("end_at", _endAt, value);
        }

        /// <summary>
        /// Gets or sets the fulfillment request template associated with the shop article.
        /// </summary>
        [XurrentField("fulfillment_template")]
        public RequestTemplate? FulfillmentTemplate
        {
            get => _fulfillmentTemplate;
            set => _fulfillmentTemplate = SetValue("fulfillment_template", _fulfillmentTemplate, value);
        }

        /// <summary>
        /// Gets or sets the full description of the shop article.
        /// </summary>
        [XurrentField("full_description")]
        public string? FullDescription
        {
            get => _fullDescription;
            set => _fullDescription = SetValue("full_description", _fullDescription, value);
        }

        [XurrentField("full_description_attachments")]
        internal ObservableCollection<AttachmentReference> FullDescriptionAttachmentsCollection
        {
            get => GetCollection(ref _fullDescriptionAttachments, OnFullDescriptionAttachmentsChanged);
            set => SetCollection(ref _fullDescriptionAttachments, "full_description_attachments", value, OnFullDescriptionAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the full description.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter FullDescriptionAttachments
        {
            get
            {
                _fullDescriptionAttachmentsWriter ??= new AttachmentReferenceWriter(() => FullDescriptionAttachmentsCollection, c => FullDescriptionAttachmentsCollection = c);
                return _fullDescriptionAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the shop article is a bundle composed of other shop articles.<br />
        /// The default value is <see langword="false"/>.<br />
        /// This property can only be set when the shop article is created.
        /// </summary>
        [XurrentField("is_bundle")]
        public bool? IsBundle
        {
            get => _isBundle;
            set => _isBundle = SetValue("is_bundle", _isBundle, value);
        }

        /// <summary>
        /// Gets or sets the maximum quantity that can be ordered in a single request.
        /// </summary>
        [XurrentField("max_quantity")]
        public int? MaxQuantity
        {
            get => _maxQuantity;
            set => _maxQuantity = SetValue("max_quantity", _maxQuantity, value);
        }

        /// <summary>
        /// Gets or sets the name of the shop article.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the URI of the image associated with the shop article.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the price charged per ordered unit.
        /// </summary>
        [XurrentField("price")]
        public decimal? Price
        {
            get => _price;
            set => _price = SetValue("price", _price, value);
        }

        /// <summary>
        /// Gets or sets the currency of the price.
        /// </summary>
        [XurrentField("price_currency")]
        public Currency? PriceCurrency
        {
            get => _priceCurrency;
            set => _priceCurrency = SetValue("price_currency", _priceCurrency, value);
        }

        /// <summary>
        /// Gets or sets the product associated with the shop article.
        /// </summary>
        [XurrentField("product")]
        public Product? Product
        {
            get => _product;
            set => _product = SetValue("product", _product, value);
        }

        /// <summary>
        /// Gets or sets the recurring period of the shop article.
        /// </summary>
        [XurrentField("recurring_period")]
        public ShopArticleRecurringPeriod? RecurringPeriod
        {
            get => _recurringPeriod;
            set => _recurringPeriod = SetValue("recurring_period", _recurringPeriod, value);
        }

        /// <summary>
        /// Gets or sets the recurring price of the shop article.
        /// </summary>
        [XurrentField("recurring_price")]
        public decimal? RecurringPrice
        {
            get => _recurringPrice;
            set => _recurringPrice = SetValue("recurring_price", _recurringPrice, value);
        }

        /// <summary>
        /// Gets or sets the currency of the recurring price.
        /// </summary>
        [XurrentField("recurring_price_currency")]
        public Currency? RecurringPriceCurrency
        {
            get => _recurringPriceCurrency;
            set => _recurringPriceCurrency = SetValue("recurring_price_currency", _recurringPriceCurrency, value);
        }

        /// <summary>
        /// Gets or sets the reference of the shop article.
        /// </summary>
        [XurrentField("reference")]
        public string? Reference
        {
            get => _reference;
            set => _reference = SetValue("reference", _reference, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether shipping is required for the shop article.
        /// </summary>
        [XurrentField("requires_shipping")]
        public bool? RequiresShipping
        {
            get => _requiresShipping;
            set => _requiresShipping = SetValue("requires_shipping", _requiresShipping, value);
        }

        /// <summary>
        /// Gets or sets the short description of the shop article.
        /// </summary>
        [XurrentField("short_description")]
        public string? ShortDescription
        {
            get => _shortDescription;
            set => _shortDescription = SetValue("short_description", _shortDescription, value);
        }

        /// <summary>
        /// Gets or sets the source of the shop article.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the source associated with the shop article.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the date and time when the shop article becomes enabled.
        /// </summary>
        [XurrentField("start_at")]
        public DateTime? StartAt
        {
            get => _startAt;
            set => _startAt = SetValue("start_at", _startAt, value);
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the shop article.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets or sets the UI extension associated with the shop article.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            set => _uiExtension = SetValue("ui_extension", _uiExtension, value);
        }

        /// <summary>
        /// Gets the date and time when the shop article was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new shop article instance.
        /// </summary>
        public ShopArticle()
        {
        }

        /// <summary>
        /// Creates a new shop article instance.
        /// </summary>
        /// <param name="id">The unique identifier of the shop article.</param>
        public ShopArticle(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new shop article instance.
        /// </summary>
        /// <param name="calendar">The calendar of the shop article.</param>
        /// <param name="fulfillmentTemplate">The fulfillment template of the shop article.</param>
        /// <param name="name">The name of the shop article.</param>
        /// <param name="reference">The reference of the shop article.</param>
        /// <param name="timeZone">The time zone of the shop article.</param>
        public ShopArticle(Calendar calendar, RequestTemplate fulfillmentTemplate, string name, string reference, string timeZone)
        {
            _calendar = SetValue("calendar", calendar);
            _fulfillmentTemplate = SetValue("fulfillment_template", fulfillmentTemplate);
            _name = SetValue("name", name);
            _reference = SetValue("reference", reference);
            _timeZone = SetValue("time_zone", timeZone);
        }

        private void OnFullDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "full_description_attachments");
        }
    }
}
