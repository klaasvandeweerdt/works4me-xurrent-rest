using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent application offering object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AppOffering : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AppOffering"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The card description field.
            /// </summary>
            [XurrentEnum("card_description")]
            CardDescription,

            /// <summary>
            /// The compliance field.
            /// </summary>
            [XurrentEnum("compliance")]
            Compliance,

            /// <summary>
            /// The compliance attachments field.
            /// </summary>
            [XurrentEnum("compliance_attachments", IgnoreInFieldSelection = true)]
            ComplianceAttachments,

            /// <summary>
            /// The configuration uri template field.
            /// </summary>
            [XurrentEnum("configuration_uri_template")]
            ConfigurationUriTemplate,

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
            /// The features field.
            /// </summary>
            [XurrentEnum("features")]
            Features,

            /// <summary>
            /// The features attachments field.
            /// </summary>
            [XurrentEnum("features_attachments", IgnoreInFieldSelection = true)]
            FeaturesAttachments,

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
            /// The openid connect discovery field.
            /// </summary>
            [XurrentEnum("openid_connect_discovery")]
            OpenidConnectDiscovery,

            /// <summary>
            /// The picture uri field.
            /// </summary>
            [XurrentEnum("picture_uri")]
            PictureUri,

            /// <summary>
            /// The policy jwt alg field.
            /// </summary>
            [XurrentEnum("policy_jwt_alg")]
            PolicyJwtAlg,

            /// <summary>
            /// The policy jwt audience field.
            /// </summary>
            [XurrentEnum("policy_jwt_audience")]
            PolicyJwtAudience,

            /// <summary>
            /// The policy jwt claim expires in field.
            /// </summary>
            [XurrentEnum("policy_jwt_claim_expires_in")]
            PolicyJwtClaimExpiresIn,

            /// <summary>
            /// The reference field.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// The requires enabled oauth person field.
            /// </summary>
            [XurrentEnum("requires_enabled_oauth_person")]
            RequiresEnabledOauthPerson,

            /// <summary>
            /// The service instance field.
            /// </summary>
            [XurrentEnum("service_instance")]
            ServiceInstance,

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
            /// The user interface extension version field.
            /// </summary>
            [XurrentEnum("ui_extension_version")]
            UiExtensionVersion,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The webhook uri template field.
            /// </summary>
            [XurrentEnum("webhook_uri_template")]
            WebhookUriTemplate
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="AppOffering"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters app offerings by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters app offerings by disabled state.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters app offerings by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters app offerings by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters app offerings by reference.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Filters app offerings by external source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters app offerings by external source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters app offerings by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of an <see cref="AppOffering"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists the latest version of each app offering published by the current account and its trusted accounts.
            /// </summary>
            [XurrentEnum("all_latest_published")]
            AllLatestPublished,

            /// <summary>
            /// Lists all app offerings installed in the current account.
            /// </summary>
            [XurrentEnum("consumed")]
            Consumed,

            /// <summary>
            /// Lists all draft app offerings in the current account.
            /// </summary>
            [XurrentEnum("latest_internal")]
            LatestInternal,

            /// <summary>
            /// Lists the latest version of each app offering published by the current account.
            /// </summary>
            [XurrentEnum("latest_published")]
            LatestPublished
        }

        /// <summary>
        /// Represents the fields used to order an <see cref="AppOffering"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts app offerings by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts app offerings by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts app offerings by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts app offerings by external source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts app offerings by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private string? _cardDescription;
        private string? _compliance;
        private ObservableCollection<AttachmentReference>? _complianceAttachments;
        private AttachmentReferenceWriter? _complianceAttachmentsWriter;
        private Uri? _configurationUriTemplate;
        private DateTime? _createdAt;
        private string? _description;
        private ObservableCollection<AttachmentReference>? _descriptionAttachments;
        private AttachmentReferenceWriter? _descriptionAttachmentsWriter;
        private bool? _disabled;
        private string? _features;
        private ObservableCollection<AttachmentReference>? _featuresAttachments;
        private AttachmentReferenceWriter? _featuresAttachmentsWriter;
        private string? _name;
        private bool? _openidConnectDiscovery;
        private Uri? _pictureUri;
        private JwtAlgorithm? _policyJwtAlg;
        private string? _policyJwtAudience;
        private int? _policyJwtClaimExpiresIn;
        private string? _reference;
        private bool? _requiresEnabledOauthPerson;
        private ServiceInstance? _serviceInstance;
        private string? _source;
        private string? _sourceID;
        private UiExtensionVersion? _uiExtensionVersion;
        private DateTime? _updatedAt;
        private Uri? _webhookUriTemplate;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments of the app offering.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the short description shown on the app offering card.
        /// </summary>
        [XurrentField("card_description")]
        public string? CardDescription
        {
            get => _cardDescription;
            set => _cardDescription = SetValue("card_description", _cardDescription, value);
        }

        /// <summary>
        /// Gets or sets the compliance statement for the app offering.
        /// </summary>
        [XurrentField("compliance")]
        public string? Compliance
        {
            get => _compliance;
            set => _compliance = SetValue("compliance", _compliance, value);
        }

        [XurrentField("compliance_attachments")]
        internal ObservableCollection<AttachmentReference> ComplianceAttachmentsCollection
        {
            get => GetCollection(ref _complianceAttachments, OnComplianceAttachmentsChanged);
            set => SetCollection(ref _complianceAttachments, "compliance_attachments", value, OnComplianceAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the compliance field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter ComplianceAttachments
        {
            get
            {
                _complianceAttachmentsWriter ??= new AttachmentReferenceWriter(() => ComplianceAttachmentsCollection, c => ComplianceAttachmentsCollection = c);
                return _complianceAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the URI template where the app can be configured.
        /// </summary>
        [XurrentField("configuration_uri_template")]
        public Uri? ConfigurationUriTemplate
        {
            get => _configurationUriTemplate;
            set => _configurationUriTemplate = SetValue("configuration_uri_template", _configurationUriTemplate, value);
        }

        /// <summary>
        /// Gets the date and time at which the app offering was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the description of the app offering.
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
        /// Gets or sets a value indicating whether the app offering is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the features description of the app offering.
        /// </summary>
        [XurrentField("features")]
        public string? Features
        {
            get => _features;
            set => _features = SetValue("features", _features, value);
        }

        [XurrentField("features_attachments")]
        internal ObservableCollection<AttachmentReference> FeaturesAttachmentsCollection
        {
            get => GetCollection(ref _featuresAttachments, OnFeaturesAttachmentsChanged);
            set => SetCollection(ref _featuresAttachments, "features_attachments", value, OnFeaturesAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the features field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter FeaturesAttachments
        {
            get
            {
                _featuresAttachmentsWriter ??= new AttachmentReferenceWriter(() => FeaturesAttachmentsCollection, c => FeaturesAttachmentsCollection = c);
                return _featuresAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the name of the app offering.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets if the webhook for this app uses OpenID Connect Discovery to allow retrieval of the policy's public key via a JWKS endpoint.
        /// </summary>
        [XurrentField("openid_connect_discovery")]
        public bool? OpenidConnectDiscovery
        {
            get => _openidConnectDiscovery;
            set => _openidConnectDiscovery = SetValue("openid_connect_discovery", _openidConnectDiscovery, value);
        }

        /// <summary>
        /// Gets or sets the URI of the image file for the app offering.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the JWT algorithm used for generating the webhook policy.
        /// </summary>
        [XurrentField("policy_jwt_alg")]
        public JwtAlgorithm? PolicyJwtAlg
        {
            get => _policyJwtAlg;
            set => _policyJwtAlg = SetValue("policy_jwt_alg", _policyJwtAlg, value);
        }

        /// <summary>
        /// Gets or sets the audience used for the webhook policy.
        /// </summary>
        [XurrentField("policy_jwt_audience")]
        public string? PolicyJwtAudience
        {
            get => _policyJwtAudience;
            set => _policyJwtAudience = SetValue("policy_jwt_audience", _policyJwtAudience, value);
        }

        /// <summary>
        /// Gets or sets the claim expiration time for the webhook policy.
        /// </summary>
        [XurrentField("policy_jwt_claim_expires_in")]
        public int? PolicyJwtClaimExpiresIn
        {
            get => _policyJwtClaimExpiresIn;
            set => _policyJwtClaimExpiresIn = SetValue("policy_jwt_claim_expires_in", _policyJwtClaimExpiresIn, value);
        }

        /// <summary>
        /// Gets or sets the stable reference identifier of the app offering.
        /// </summary>
        [XurrentField("reference")]
        public string? Reference
        {
            get => _reference;
            set => _reference = SetValue("reference", _reference, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the app offering requires an enabled OAuth person.
        /// </summary>
        [XurrentField("requires_enabled_oauth_person")]
        public bool? RequiresEnabledOauthPerson
        {
            get => _requiresEnabledOauthPerson;
            set => _requiresEnabledOauthPerson = SetValue("requires_enabled_oauth_person", _requiresEnabledOauthPerson, value);
        }

        /// <summary>
        /// Gets or sets the service instance used when creating requests for the app offering.
        /// </summary>
        [XurrentField("service_instance")]
        public ServiceInstance? ServiceInstance
        {
            get => _serviceInstance;
            set => _serviceInstance = SetValue("service_instance", _serviceInstance, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier of the app offering.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the app offering in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the UI extension version used for the app offering instances.
        /// </summary>
        [XurrentField("ui_extension_version")]
        public UiExtensionVersion? UiExtensionVersion
        {
            get => _uiExtensionVersion;
            set => _uiExtensionVersion = SetValue("ui_extension_version", _uiExtensionVersion, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the app offering.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the URI template for the app webhook.
        /// </summary>
        [XurrentField("webhook_uri_template")]
        public Uri? WebhookUriTemplate
        {
            get => _webhookUriTemplate;
            set => _webhookUriTemplate = SetValue("webhook_uri_template", _webhookUriTemplate, value);
        }

        /// <summary>
        /// Creates a new app offering instance.
        /// </summary>
        public AppOffering()
        {
        }

        /// <summary>
        /// Creates a new app offering instance.
        /// </summary>
        /// <param name="id">The unique identifier of the app offering.</param>
        public AppOffering(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new app offering instance.
        /// </summary>
        /// <param name="name">The name of the app offering.</param>
        /// <param name="policyJwtAlg">The policy jwt alg of the app offering.</param>
        /// <param name="reference">The reference of the app offering.</param>
        /// <param name="serviceInstance">The service instance of the app offering.</param>
        /// <param name="webhookUriTemplate">The webhook uri template of the app offering.</param>
        public AppOffering(string name, JwtAlgorithm policyJwtAlg, string reference, ServiceInstance serviceInstance, Uri webhookUriTemplate)
        {
            _name = SetValue("name", name);
            _policyJwtAlg = SetValue("policy_jwt_alg", policyJwtAlg);
            _reference = SetValue("reference", reference);
            _serviceInstance = SetValue("service_instance", serviceInstance);
            _webhookUriTemplate = SetValue("webhook_uri_template", webhookUriTemplate);
        }

        private void OnComplianceAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "compliance_attachments");
        }

        private void OnDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "description_attachments");
        }

        private void OnFeaturesAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "features_attachments");
        }
    }
}
