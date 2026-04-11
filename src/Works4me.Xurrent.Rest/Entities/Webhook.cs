using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent webhook object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Webhook : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Webhook"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The app offering references field.
            /// </summary>
            [XurrentEnum("app_offering_references")]
            AppOfferingReferences,

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
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

            /// <summary>
            /// The description attachments field.
            /// </summary>
            [XurrentEnum("description_attachments", IgnoreInFieldSelection = true)]
            DescriptionAttachments,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The event field.
            /// </summary>
            [XurrentEnum("event")]
            Event,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The mail exceptions to field.
            /// </summary>
            [XurrentEnum("mail_exceptions_to")]
            MailExceptionsTo,

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
            /// The openid connect discovery field.
            /// </summary>
            [XurrentEnum("openid_connect_discovery")]
            OpenidConnectDiscovery,

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
            /// The webhook policy field.
            /// </summary>
            [XurrentEnum("webhook_policy")]
            WebhookPolicy
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
        /// Represents the predefined filters of a <see cref="Webhook"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// List all disabled webhooks.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// List all enabled webhooks.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
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

        private ObservableCollection<string>? _appOfferingReferences;
        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private string? _description;
        private ObservableCollection<AttachmentReference>? _descriptionAttachments;
        private AttachmentReferenceWriter? _descriptionAttachmentsWriter;
        private bool? _disabled;
        private string? _event;
        private string? _mailExceptionsTo;
        private string? _name;
        private bool? _openidConnectDiscovery;
        private string? _source;
        private string? _sourceID;
        private DateTime? _updatedAt;
        private Uri? _uri;
        private WebhookPolicy? _webhookPolicy;

        /// <summary>
        /// Gets or sets the app offering references that limit when the webhook is triggered.
        /// </summary>
        [XurrentField("app_offering_references")]
        public ObservableCollection<string> AppOfferingReferences
        {
            get => GetCollection(ref _appOfferingReferences, OnAppOfferingReferencesChanged);
            set => SetCollection(ref _appOfferingReferences, "app_offering_references", value, OnAppOfferingReferencesChanged);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments of the webhook.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the webhook was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the description of the webhook.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        [XurrentField("description_attachments")]
        internal ObservableCollection<AttachmentReference> DescriptionAttachmentsCollection
        {
            get => GetCollection(ref _descriptionAttachments, OnDescriptionAttachmentsChanged);
            set => SetCollection(ref _descriptionAttachments, "description_attachments", value, OnDescriptionAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the description field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter DescriptionAttachments
        {
            get
            {
                _descriptionAttachmentsWriter ??= new AttachmentReferenceWriter(() => DescriptionAttachmentsCollection, c => DescriptionAttachmentsCollection = c);
                return _descriptionAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the webhook is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the event type that triggers the webhook.<br />
        /// For more details, see <see href="https://developer.xurrent.com/v1/webhooks/events/#events">Xurrent Developer Documentation</see>.
        /// </summary>
        [XurrentField("event")]
        public string? Event
        {
            get => _event;
            set => _event = SetValue("event", _event, value);
        }

        /// <summary>
        /// Gets or sets the email addresses that receive notifications when webhook execution fails.
        /// </summary>
        [XurrentField("mail_exceptions_to")]
        public string? MailExceptionsTo
        {
            get => _mailExceptionsTo;
            set => _mailExceptionsTo = SetValue("mail_exceptions_to", _mailExceptionsTo, value);
        }

        /// <summary>
        /// Gets or sets the name of the webhook.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets if this webhook uses OpenID Connect Discovery to allow retrieval of the policy's public key via a JWKS endpoint.
        /// </summary>
        [XurrentField("openid_connect_discovery")]
        public bool? OpenidConnectDiscovery
        {
            get => _openidConnectDiscovery;
            set => _openidConnectDiscovery = SetValue("openid_connect_discovery", _openidConnectDiscovery, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier of the webhook.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the webhook in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the webhook.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the publicly accessible URI used to receive webhook requests.
        /// </summary>
        [XurrentField("uri")]
        public Uri? Uri
        {
            get => _uri;
            set => _uri = SetValue("uri", _uri, value);
        }

        /// <summary>
        /// Gets or sets the webhook policy used to sign webhook messages.
        /// </summary>
        [XurrentField("webhook_policy")]
        public WebhookPolicy? WebhookPolicy
        {
            get => _webhookPolicy;
            set => _webhookPolicy = SetValue("webhook_policy", _webhookPolicy, value);
        }

        /// <summary>
        /// Creates a new webhook instance.
        /// </summary>
        public Webhook()
        {
        }

        /// <summary>
        /// Creates a new webhook instance.
        /// </summary>
        /// <param name="id">The unique identifier of the webhook.</param>
        public Webhook(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new webhook instance.
        /// </summary>
        /// <param name="uri">The uri of the webhook.</param>
        public Webhook(Uri uri)
        {
            _uri = SetValue("uri", uri);
        }

        private void OnAppOfferingReferencesChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<string> collection)
                MarkCollectionChanged(collection, "app_offering_references");
        }

        private void OnDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "description_attachments");
        }
    }
}
