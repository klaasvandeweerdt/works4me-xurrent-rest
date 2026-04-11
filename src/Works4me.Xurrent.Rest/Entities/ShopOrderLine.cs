using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent shop order line object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ShopOrderLine : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ShopOrderLine"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The completed at field.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

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
            /// The delivery address field.
            /// </summary>
            [XurrentEnum("delivery_address")]
            DeliveryAddress,

            /// <summary>
            /// The delivery city field.
            /// </summary>
            [XurrentEnum("delivery_city")]
            DeliveryCity,

            /// <summary>
            /// The delivery country field.
            /// </summary>
            [XurrentEnum("delivery_country")]
            DeliveryCountry,

            /// <summary>
            /// The delivery state field.
            /// </summary>
            [XurrentEnum("delivery_state")]
            DeliveryState,

            /// <summary>
            /// The delivery zip field.
            /// </summary>
            [XurrentEnum("delivery_zip")]
            DeliveryZip,

            /// <summary>
            /// The fulfillment request field.
            /// </summary>
            [XurrentEnum("fulfillment_request")]
            FulfillmentRequest,

            /// <summary>
            /// The fulfillment task field.
            /// </summary>
            [XurrentEnum("fulfillment_task")]
            FulfillmentTask,

            /// <summary>
            /// The fulfillment template field.
            /// </summary>
            [XurrentEnum("fulfillment_template")]
            FulfillmentTemplate,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

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
            /// The order field.
            /// </summary>
            [XurrentEnum("order")]
            Order,

            /// <summary>
            /// The ordered at field.
            /// </summary>
            [XurrentEnum("ordered_at")]
            OrderedAt,

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
            /// The provider ordered at field.
            /// </summary>
            [XurrentEnum("provider_ordered_at")]
            ProviderOrderedAt,

            /// <summary>
            /// The provider price field.
            /// </summary>
            [XurrentEnum("provider_price")]
            ProviderPrice,

            /// <summary>
            /// The provider price currency field.
            /// </summary>
            [XurrentEnum("provider_price_currency")]
            ProviderPriceCurrency,

            /// <summary>
            /// The provider recurring period field.
            /// </summary>
            [XurrentEnum("provider_recurring_period")]
            ProviderRecurringPeriod,

            /// <summary>
            /// The provider recurring price field.
            /// </summary>
            [XurrentEnum("provider_recurring_price")]
            ProviderRecurringPrice,

            /// <summary>
            /// The provider recurring price currency field.
            /// </summary>
            [XurrentEnum("provider_recurring_price_currency")]
            ProviderRecurringPriceCurrency,

            /// <summary>
            /// The provider total price field.
            /// </summary>
            [XurrentEnum("provider_total_price")]
            ProviderTotalPrice,

            /// <summary>
            /// The provider total recurring price field.
            /// </summary>
            [XurrentEnum("provider_total_recurring_price")]
            ProviderTotalRecurringPrice,

            /// <summary>
            /// The quantity field.
            /// </summary>
            [XurrentEnum("quantity")]
            Quantity,

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
            /// The requested by field.
            /// </summary>
            [XurrentEnum("requested_by")]
            RequestedBy,

            /// <summary>
            /// The requested for field.
            /// </summary>
            [XurrentEnum("requested_for")]
            RequestedFor,

            /// <summary>
            /// The shop article field.
            /// </summary>
            [XurrentEnum("shop_article")]
            ShopArticle,

            /// <summary>
            /// The shop article identifier field.
            /// </summary>
            [XurrentEnum("shop_article_id", IgnoreInFieldSelection = true)]
            ShopArticleId,

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
            /// The total price field.
            /// </summary>
            [XurrentEnum("total_price")]
            TotalPrice,

            /// <summary>
            /// The total recurring price field.
            /// </summary>
            [XurrentEnum("total_recurring_price")]
            TotalRecurringPrice,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ShopOrderLine"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters shop order lines by completion date and time.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Filters shop order lines by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters shop order lines by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters shop order lines by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters shop order lines by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters shop order lines by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters shop order lines by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ShopOrderLine"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all shop order lines that are canceled.
            /// </summary>
            [XurrentEnum("canceled")]
            Canceled,

            /// <summary>
            /// Lists all shop order lines that are completed.
            /// </summary>
            [XurrentEnum("completed")]
            Completed,

            /// <summary>
            /// Lists all shop order lines that are not completed.
            /// </summary>
            [XurrentEnum("open")]
            Open,

            /// <summary>
            /// Lists all shop order lines that are requested by the current user.
            /// </summary>
            [XurrentEnum("personal")]
            Personal
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ShopOrderLine"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts shop order lines by completion date and time.
            /// </summary>
            [XurrentEnum("completed_at")]
            CompletedAt,

            /// <summary>
            /// Sorts shop order lines by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts shop order lines by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts shop order lines by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts shop order lines by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts shop order lines by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private DateTime? _completedAt;
        private DateTime? _createdAt;
        private string? _deliveryAddress;
        private string? _deliveryCity;
        private string? _deliveryCountry;
        private string? _deliveryState;
        private string? _deliveryZip;
        private Request? _fulfillmentRequest;
        private WorkflowTask? _fulfillmentTask;
        private Request? _fulfillmentTemplate;
        private string? _name;
        private Request? _order;
        private DateTime? _orderedAt;
        private decimal? _price;
        private Currency? _priceCurrency;
        private DateTime? _providerOrderedAt;
        private decimal? _providerPrice;
        private Currency? _providerPriceCurrency;
        private ShopArticleRecurringPeriod? _providerRecurringPeriod;
        private decimal? _providerRecurringPrice;
        private Currency? _providerRecurringPriceCurrency;
        private decimal? _providerTotalPrice;
        private Currency? _providerTotalRecurringPrice;
        private int? _quantity;
        private ShopArticleRecurringPeriod? _recurringPeriod;
        private decimal? _recurringPrice;
        private Currency? _recurringPriceCurrency;
        private Person? _requestedBy;
        private Person? _requestedFor;
        private string? _shopArticle;
        private long? _shopArticleId;
        private string? _source;
        private string? _sourceID;
        private ShopOrderLineStatus? _status;
        private decimal? _totalPrice;
        private Currency? _totalRecurringPrice;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time when the shop order line was completed.
        /// </summary>
        [XurrentField("completed_at")]
        public DateTime? CompletedAt
        {
            get => _completedAt;
            internal set => _completedAt = value;
        }

        /// <summary>
        /// Gets the date and time when the shop order line was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the delivery address lines.
        /// </summary>
        [XurrentField("delivery_address")]
        public string? DeliveryAddress
        {
            get => _deliveryAddress;
            internal set => _deliveryAddress = value;
        }

        /// <summary>
        /// Gets the delivery city name.
        /// </summary>
        [XurrentField("delivery_city")]
        public string? DeliveryCity
        {
            get => _deliveryCity;
            internal set => _deliveryCity = value;
        }

        /// <summary>
        /// Gets the delivery country name.
        /// </summary>
        [XurrentField("delivery_country")]
        public string? DeliveryCountry
        {
            get => _deliveryCountry;
            internal set => _deliveryCountry = value;
        }

        /// <summary>
        /// Gets the delivery state name.
        /// </summary>
        [XurrentField("delivery_state")]
        public string? DeliveryState
        {
            get => _deliveryState;
            internal set => _deliveryState = value;
        }

        /// <summary>
        /// Gets the delivery zip code.
        /// </summary>
        [XurrentField("delivery_zip")]
        public string? DeliveryZip
        {
            get => _deliveryZip;
            internal set => _deliveryZip = value;
        }

        /// <summary>
        /// Gets the request generated for the fulfillment of this shop order line.
        /// </summary>
        [XurrentField("fulfillment_request")]
        public Request? FulfillmentRequest
        {
            get => _fulfillmentRequest;
            internal set => _fulfillmentRequest = value;
        }

        /// <summary>
        /// Gets the fulfillment task in the order workflow related to this shop order line.
        /// </summary>
        [XurrentField("fulfillment_task")]
        public WorkflowTask? FulfillmentTask
        {
            get => _fulfillmentTask;
            internal set => _fulfillmentTask = value;
        }

        /// <summary>
        /// Gets the request template used to generate the fulfillment request.
        /// </summary>
        [XurrentField("fulfillment_template")]
        public Request? FulfillmentTemplate
        {
            get => _fulfillmentTemplate;
            internal set => _fulfillmentTemplate = value;
        }

        /// <summary>
        /// Gets the name of the shop order line.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            internal set => _name = value;
        }

        /// <summary>
        /// Gets the order request related to this shop order line.
        /// </summary>
        [XurrentField("order")]
        public Request? Order
        {
            get => _order;
            internal set => _order = value;
        }

        /// <summary>
        /// Gets the date and time when the shop order line was ordered.
        /// </summary>
        [XurrentField("ordered_at")]
        public DateTime? OrderedAt
        {
            get => _orderedAt;
            internal set => _orderedAt = value;
        }

        /// <summary>
        /// Gets the price per unit of the shop order line.
        /// </summary>
        [XurrentField("price")]
        public decimal? Price
        {
            get => _price;
            internal set => _price = value;
        }

        /// <summary>
        /// Gets the currency of the price.
        /// </summary>
        [XurrentField("price_currency")]
        public Currency? PriceCurrency
        {
            get => _priceCurrency;
            internal set => _priceCurrency = value;
        }

        /// <summary>
        /// Gets the date and time when the shop article was ordered at the provider.
        /// </summary>
        [XurrentField("provider_ordered_at")]
        public DateTime? ProviderOrderedAt
        {
            get => _providerOrderedAt;
            internal set => _providerOrderedAt = value;
        }

        /// <summary>
        /// Gets the provider price per unit at the time the shop article was ordered.
        /// </summary>
        [XurrentField("provider_price")]
        public decimal? ProviderPrice
        {
            get => _providerPrice;
            internal set => _providerPrice = value;
        }

        /// <summary>
        /// Gets the currency of the provider price.
        /// </summary>
        [XurrentField("provider_price_currency")]
        public Currency? ProviderPriceCurrency
        {
            get => _providerPriceCurrency;
            internal set => _providerPriceCurrency = value;
        }

        /// <summary>
        /// Gets the recurring period of the provider recurring price.
        /// </summary>
        [XurrentField("provider_recurring_period")]
        public ShopArticleRecurringPeriod? ProviderRecurringPeriod
        {
            get => _providerRecurringPeriod;
            internal set => _providerRecurringPeriod = value;
        }

        /// <summary>
        /// Gets the recurring price charged by the provider per unit.
        /// </summary>
        [XurrentField("provider_recurring_price")]
        public decimal? ProviderRecurringPrice
        {
            get => _providerRecurringPrice;
            internal set => _providerRecurringPrice = value;
        }

        /// <summary>
        /// Gets the currency of the provider recurring price.
        /// </summary>
        [XurrentField("provider_recurring_price_currency")]
        public Currency? ProviderRecurringPriceCurrency
        {
            get => _providerRecurringPriceCurrency;
            internal set => _providerRecurringPriceCurrency = value;
        }

        /// <summary>
        /// Gets the total non-recurring provider price for all units combined.
        /// </summary>
        [XurrentField("provider_total_price")]
        public decimal? ProviderTotalPrice
        {
            get => _providerTotalPrice;
            internal set => _providerTotalPrice = value;
        }

        /// <summary>
        /// Gets the total yearly recurring provider price for all units combined.
        /// </summary>
        [XurrentField("provider_total_recurring_price")]
        public Currency? ProviderTotalRecurringPrice
        {
            get => _providerTotalRecurringPrice;
            internal set => _providerTotalRecurringPrice = value;
        }

        /// <summary>
        /// Gets or sets the quantity of shop article units ordered.
        /// </summary>
        [XurrentField("quantity")]
        public int? Quantity
        {
            get => _quantity;
            set => _quantity = SetValue("quantity", _quantity, value);
        }

        /// <summary>
        /// Gets the recurring period of the shop order line.
        /// </summary>
        [XurrentField("recurring_period")]
        public ShopArticleRecurringPeriod? RecurringPeriod
        {
            get => _recurringPeriod;
            internal set => _recurringPeriod = value;
        }

        /// <summary>
        /// Gets the recurring price of the shop order line.
        /// </summary>
        [XurrentField("recurring_price")]
        public decimal? RecurringPrice
        {
            get => _recurringPrice;
            internal set => _recurringPrice = value;
        }

        /// <summary>
        /// Gets the currency of the recurring price.
        /// </summary>
        [XurrentField("recurring_price_currency")]
        public Currency? RecurringPriceCurrency
        {
            get => _recurringPriceCurrency;
            internal set => _recurringPriceCurrency = value;
        }

        /// <summary>
        /// Gets the person who requested the shop order line.
        /// </summary>
        [XurrentField("requested_by")]
        public Person? RequestedBy
        {
            get => _requestedBy;
            internal set => _requestedBy = value;
        }

        /// <summary>
        /// Gets or sets the person for whom the shop articles are ordered.
        /// </summary>
        [XurrentField("requested_for")]
        public Person? RequestedFor
        {
            get => _requestedFor;
            set => _requestedFor = SetValue("requested_for", _requestedFor, value);
        }

        /// <summary>
        /// Gets the reference to the shop article associated with the shop order line.
        /// </summary>
        [XurrentField("shop_article")]
        public string? ShopArticle
        {
            get => _shopArticle;
            internal set => _shopArticle = value;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the shop article that is being ordered.<br />
        /// This property is write-only and can only be used during creation of a new shop article order line.
        /// </summary>
        [XurrentField("shop_article_id")]
        public long? ShopArticleId
        {
            get => _shopArticleId;
            set => _shopArticleId = SetValue("shop_article_id", _shopArticleId, value);
        }

        /// <summary>
        /// Gets or sets the source of the shop order line.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the source associated with the shop order line.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the status of the shop order line.
        /// </summary>
        [XurrentField("status")]
        public ShopOrderLineStatus? Status
        {
            get => _status;
            internal set => _status = value;
        }

        /// <summary>
        /// Gets the total non-recurring price of the shop order line.
        /// </summary>
        [XurrentField("total_price")]
        public decimal? TotalPrice
        {
            get => _totalPrice;
            internal set => _totalPrice = value;
        }

        /// <summary>
        /// Gets the total recurring price of the shop order line.
        /// </summary>
        [XurrentField("total_recurring_price")]
        public Currency? TotalRecurringPrice
        {
            get => _totalRecurringPrice;
            internal set => _totalRecurringPrice = value;
        }

        /// <summary>
        /// Gets the date and time when the shop order line was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new shop order line instance.
        /// </summary>
        public ShopOrderLine()
        {
        }

        /// <summary>
        /// Creates a new shop order line instance.
        /// </summary>
        /// <param name="id">The unique identifier of the shop order line.</param>
        public ShopOrderLine(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new shop order line instance.
        /// </summary>
        /// <param name="quantity">The quantity of the shop order line.</param>
        /// <param name="requestedFor">The requested for of the shop order line.</param>
        /// <param name="shopArticleId">The shop article identifier of the shop order line.</param>
        public ShopOrderLine(int quantity, Person requestedFor, long shopArticleId)
        {
            _quantity = SetValue("quantity", quantity);
            _requestedFor = SetValue("requested_for", requestedFor);
            _shopArticleId = SetValue("shop_article_id", shopArticleId);
        }
    }
}
