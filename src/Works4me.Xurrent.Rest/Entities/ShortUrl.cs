using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent short URL object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ShortUrl : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ShortUrl"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The configuration item field.
            /// </summary>
            [XurrentEnum("ci", IgnoreInFieldSelection = true)]
            ConfigurationItem,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The email body field.
            /// </summary>
            [XurrentEnum("email_body", IgnoreInFieldSelection = true)]
            EmailBody,

            /// <summary>
            /// The email subject field.
            /// </summary>
            [XurrentEnum("email_subject", IgnoreInFieldSelection = true)]
            EmailSubject,

            /// <summary>
            /// The email to field.
            /// </summary>
            [XurrentEnum("email_to", IgnoreInFieldSelection = true)]
            EmailTo,

            /// <summary>
            /// The geo latitude field.
            /// </summary>
            [XurrentEnum("geo_latitude", IgnoreInFieldSelection = true)]
            GeoLatitude,

            /// <summary>
            /// The geo longitude field.
            /// </summary>
            [XurrentEnum("geo_longitude", IgnoreInFieldSelection = true)]
            GeoLongitude,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The knowledge article field.
            /// </summary>
            [XurrentEnum("knowledge_article", IgnoreInFieldSelection = true)]
            KnowledgeArticle,

            /// <summary>
            /// The map address field.
            /// </summary>
            [XurrentEnum("map_address", IgnoreInFieldSelection = true)]
            MapAddress,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The plain text field.
            /// </summary>
            [XurrentEnum("plain_text", IgnoreInFieldSelection = true)]
            PlainText,

            /// <summary>
            /// The request template field.
            /// </summary>
            [XurrentEnum("request_template", IgnoreInFieldSelection = true)]
            RequestTemplate,

            /// <summary>
            /// The shortened url field.
            /// </summary>
            [XurrentEnum("short_url")]
            ShortenedUrl,

            /// <summary>
            /// The skype name field.
            /// </summary>
            [XurrentEnum("skype_name", IgnoreInFieldSelection = true)]
            SkypeName,

            /// <summary>
            /// The sms body field.
            /// </summary>
            [XurrentEnum("sms_body", IgnoreInFieldSelection = true)]
            SmsBody,

            /// <summary>
            /// The sms tel field.
            /// </summary>
            [XurrentEnum("sms_tel", IgnoreInFieldSelection = true)]
            SmsTel,

            /// <summary>
            /// The tel field.
            /// </summary>
            [XurrentEnum("tel", IgnoreInFieldSelection = true)]
            Tel,

            /// <summary>
            /// The tweet field.
            /// </summary>
            [XurrentEnum("tweet", IgnoreInFieldSelection = true)]
            Tweet,

            /// <summary>
            /// The twitter name field.
            /// </summary>
            [XurrentEnum("twitter_name", IgnoreInFieldSelection = true)]
            TwitterName,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The uri field.
            /// </summary>
            [XurrentEnum("uri")]
            Uri,

            /// <summary>
            /// The website url field.
            /// </summary>
            [XurrentEnum("website_url", IgnoreInFieldSelection = true)]
            WebsiteUrl
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="ShortUrl"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters short URLs by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters short URLs by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters short URLs by last update date and time.
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
        /// Represents the fields used to order a <see cref="ShortUrl"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts short URLs by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id
        }

        private ConfigurationItem? _configurationItem;
        private DateTime? _createdAt;
        private string? _emailBody;
        private string? _emailSubject;
        private string? _emailTo;
        private string? _geoLatitude;
        private string? _geoLongitude;
        private KnowledgeArticle? _knowledgeArticle;
        private string? _mapAddress;
        private string? _plainText;
        private RequestTemplate? _requestTemplate;
        private Uri? _shortenedUrl;
        private string? _skypeName;
        private string? _smsBody;
        private string? _smsTel;
        private string? _tel;
        private string? _tweet;
        private string? _twitterName;
        private DateTime? _updatedAt;
        private Uri? _uri;
        private Uri? _websiteUrl;

        /// <summary>
        /// Gets or sets the configuration item for which a request is registered when the short URL is used.
        /// </summary>
        [XurrentField("ci")]
        public ConfigurationItem? ConfigurationItem
        {
            get => _configurationItem;
            set => _configurationItem = SetValue("ci", _configurationItem, value);
        }

        /// <summary>
        /// Gets the date and time when the short URL was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the body of the email that is generated when the short URL is used.
        /// </summary>
        [XurrentField("email_body")]
        public string? EmailBody
        {
            get => _emailBody;
            set => _emailBody = SetValue("email_body", _emailBody, value);
        }

        /// <summary>
        /// Gets or sets the subject of the email that is generated when the short URL is used.
        /// </summary>
        [XurrentField("email_subject")]
        public string? EmailSubject
        {
            get => _emailSubject;
            set => _emailSubject = SetValue("email_subject", _emailSubject, value);
        }

        /// <summary>
        /// Gets or sets the email address of the recipient of the email that is generated when the short URL is used.
        /// </summary>
        [XurrentField("email_to")]
        public string? EmailTo
        {
            get => _emailTo;
            set => _emailTo = SetValue("email_to", _emailTo, value);
        }

        /// <summary>
        /// Gets or sets the latitude coordinate of the location for which a map is opened when the short URL is used.
        /// </summary>
        [XurrentField("geo_latitude")]
        public string? GeoLatitude
        {
            get => _geoLatitude;
            set => _geoLatitude = SetValue("geo_latitude", _geoLatitude, value);
        }

        /// <summary>
        /// Gets or sets the longitude coordinate of the location for which a map is opened when the short URL is used.
        /// </summary>
        [XurrentField("geo_longitude")]
        public string? GeoLongitude
        {
            get => _geoLongitude;
            set => _geoLongitude = SetValue("geo_longitude", _geoLongitude, value);
        }

        /// <summary>
        /// Gets or sets the knowledge article that is applied when the short URL is used.
        /// </summary>
        [XurrentField("knowledge_article")]
        public KnowledgeArticle? KnowledgeArticle
        {
            get => _knowledgeArticle;
            set => _knowledgeArticle = SetValue("knowledge_article", _knowledgeArticle, value);
        }

        /// <summary>
        /// Gets or sets the address for which a map is opened when the short URL is used.
        /// </summary>
        [XurrentField("map_address")]
        public string? MapAddress
        {
            get => _mapAddress;
            set => _mapAddress = SetValue("map_address", _mapAddress, value);
        }

        /// <summary>
        /// Gets or sets the text that is displayed when the short URL is used.
        /// </summary>
        [XurrentField("plain_text")]
        public string? PlainText
        {
            get => _plainText;
            set => _plainText = SetValue("plain_text", _plainText, value);
        }

        /// <summary>
        /// Gets or sets the request template that is applied when the short URL is used.
        /// </summary>
        [XurrentField("request_template")]
        public RequestTemplate? RequestTemplate
        {
            get => _requestTemplate;
            set => _requestTemplate = SetValue("request_template", _requestTemplate, value);
        }

        /// <summary>
        /// Gets the automatically generated short URL.
        /// </summary>
        [XurrentField("short_url")]
        public Uri? ShortenedUrl
        {
            get => _shortenedUrl;
            internal set => _shortenedUrl = value;
        }

        /// <summary>
        /// Gets or sets the Skype username that is called when the short URL is used.
        /// </summary>
        [XurrentField("skype_name")]
        public string? SkypeName
        {
            get => _skypeName;
            set => _skypeName = SetValue("skype_name", _skypeName, value);
        }

        /// <summary>
        /// Gets or sets the text of the SMS message that is generated when the short URL is used.
        /// </summary>
        [XurrentField("sms_body")]
        public string? SmsBody
        {
            get => _smsBody;
            set => _smsBody = SetValue("sms_body", _smsBody, value);
        }

        /// <summary>
        /// Gets or sets the telephone number of the SMS recipient when the short URL is used.
        /// </summary>
        [XurrentField("sms_tel")]
        public string? SmsTel
        {
            get => _smsTel;
            set => _smsTel = SetValue("sms_tel", _smsTel, value);
        }

        /// <summary>
        /// Gets or sets the telephone number that is called when the short URL is used.
        /// </summary>
        [XurrentField("tel")]
        public string? Tel
        {
            get => _tel;
            set => _tel = SetValue("tel", _tel, value);
        }

        /// <summary>
        /// Gets or sets the text of the tweet that is generated when the short URL is used.
        /// </summary>
        [XurrentField("tweet")]
        public string? Tweet
        {
            get => _tweet;
            set => _tweet = SetValue("tweet", _tweet, value);
        }

        /// <summary>
        /// Gets or sets the Twitter username whose feed is opened when the short URL is used.
        /// </summary>
        [XurrentField("twitter_name")]
        public string? TwitterName
        {
            get => _twitterName;
            set => _twitterName = SetValue("twitter_name", _twitterName, value);
        }

        /// <summary>
        /// Gets the date and time when the short URL was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets the URI to which the short URL is forwarded.
        /// </summary>
        [XurrentField("uri")]
        public Uri? Uri
        {
            get => _uri;
            internal set => _uri = value;
        }

        /// <summary>
        /// Gets or sets the website URL to which the short URL is forwarded.
        /// </summary>
        [XurrentField("website_url")]
        public Uri? WebsiteUrl
        {
            get => _websiteUrl;
            set => _websiteUrl = SetValue("website_url", _websiteUrl, value);
        }

        /// <summary>
        /// Creates a new short url instance.
        /// </summary>
        public ShortUrl()
        {
        }

        /// <summary>
        /// Creates a new short url instance.
        /// </summary>
        /// <param name="id">The unique identifier of the short url.</param>
        public ShortUrl(long id)
        {
            Id = id;
        }
    }
}
