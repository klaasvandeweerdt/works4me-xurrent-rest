using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent service object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Service : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Service"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The availability manager field.
            /// </summary>
            [XurrentEnum("availability_manager")]
            AvailabilityManager,

            /// <summary>
            /// The capacity manager field.
            /// </summary>
            [XurrentEnum("capacity_manager")]
            CapacityManager,

            /// <summary>
            /// The change manager field.
            /// </summary>
            [XurrentEnum("change_manager")]
            ChangeManager,

            /// <summary>
            /// The continuity manager field.
            /// </summary>
            [XurrentEnum("continuity_manager")]
            ContinuityManager,

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
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The impact field.
            /// </summary>
            [XurrentEnum("impact")]
            Impact,

            /// <summary>
            /// The keywords field.
            /// </summary>
            [XurrentEnum("keywords")]
            Keywords,

            /// <summary>
            /// The knowledge manager field.
            /// </summary>
            [XurrentEnum("knowledge_manager")]
            KnowledgeManager,

            /// <summary>
            /// The localized description field.
            /// </summary>
            [XurrentEnum("localized_description", IgnoreInFieldSelection = true)]
            LocalizedDescription,

            /// <summary>
            /// The localized keywords field.
            /// </summary>
            [XurrentEnum("localized_keywords", IgnoreInFieldSelection = true)]
            LocalizedKeywords,

            /// <summary>
            /// The localized name field.
            /// </summary>
            [XurrentEnum("localized_name", IgnoreInFieldSelection = true)]
            LocalizedName,

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
            /// The problem manager field.
            /// </summary>
            [XurrentEnum("problem_manager")]
            ProblemManager,

            /// <summary>
            /// The provider field.
            /// </summary>
            [XurrentEnum("provider")]
            Provider,

            /// <summary>
            /// The release manager field.
            /// </summary>
            [XurrentEnum("release_manager")]
            ReleaseManager,

            /// <summary>
            /// The service owner field.
            /// </summary>
            [XurrentEnum("service_owner")]
            ServiceOwner,

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
            /// The support team field.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// The survey field.
            /// </summary>
            [XurrentEnum("survey")]
            Survey,

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
        /// Represents the filterable fields of a <see cref="Service"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters services by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters services by disabled status.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters services by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters services by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters services by provider.
            /// </summary>
            [XurrentEnum("provider")]
            Provider,

            /// <summary>
            /// Filters services by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters services by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters services by support team.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// Filters services by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Service"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled services.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled services.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Service"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts services by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts services by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts services by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts services by provider.
            /// </summary>
            [XurrentEnum("provider")]
            Provider,

            /// <summary>
            /// Sorts services by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts services by support team.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// Sorts services by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private Person? _availabilityManager;
        private Person? _capacityManager;
        private Person? _changeManager;
        private Person? _continuityManager;
        private DateTime? _createdAt;
        private string? _description;
        private ObservableCollection<AttachmentReference>? _descriptionAttachments;
        private AttachmentReferenceWriter? _descriptionAttachmentsWriter;
        private bool? _disabled;
        private RequestImpact? _impact;
        private string? _keywords;
        private Person? _knowledgeManager;
        private string? _localizedDescription;
        private string? _localizedKeywords;
        private string? _localizedName;
        private string? _name;
        private Uri? _pictureUri;
        private Person? _problemManager;
        private Organization? _provider;
        private Person? _releaseManager;
        private Person? _serviceOwner;
        private string? _source;
        private string? _sourceID;
        private Team? _supportTeam;
        private Survey? _survey;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the service.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the person responsible for ensuring that the availability targets specified in the active SLAs for the service are met.
        /// </summary>
        [XurrentField("availability_manager")]
        public Person? AvailabilityManager
        {
            get => _availabilityManager;
            set => _availabilityManager = SetValue("availability_manager", _availabilityManager, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for ensuring that the service is not affected by incidents caused by capacity shortages.
        /// </summary>
        [XurrentField("capacity_manager")]
        public Person? CapacityManager
        {
            get => _capacityManager;
            set => _capacityManager = SetValue("capacity_manager", _capacityManager, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for coordinating changes of the service.
        /// </summary>
        [XurrentField("change_manager")]
        public Person? ChangeManager
        {
            get => _changeManager;
            set => _changeManager = SetValue("change_manager", _changeManager, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for creating and maintaining continuity plans for service instances with an active SLA that has a continuity target.
        /// </summary>
        [XurrentField("continuity_manager")]
        public Person? ContinuityManager
        {
            get => _continuityManager;
            set => _continuityManager = SetValue("continuity_manager", _continuityManager, value);
        }

        /// <summary>
        /// Gets the date and time at which the service was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a high level description of the service core functionality.
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
        /// Gets or sets a value indicating whether the service can no longer be related to other records.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets the impact based on the highest impact of the affected SLAs for which the current user has read access.
        /// </summary>
        [XurrentField("impact")]
        public RequestImpact? Impact
        {
            get => _impact;
            internal set => _impact = value;
        }

        /// <summary>
        /// Gets or sets a comma separated list of keywords that can be used to find the service via search.
        /// </summary>
        [XurrentField("keywords")]
        public string? Keywords
        {
            get => _keywords;
            set => _keywords = SetValue("keywords", _keywords, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for the quality of the knowledge articles for the service.
        /// </summary>
        [XurrentField("knowledge_manager")]
        public Person? KnowledgeManager
        {
            get => _knowledgeManager;
            set => _knowledgeManager = SetValue("knowledge_manager", _knowledgeManager, value);
        }

        /// <summary>
        /// Gets the translated description in the current language.<br />
        /// Defaults to the description value when no translation is provided.
        /// </summary>
        [XurrentField("localized_description")]
        public string? LocalizedDescription
        {
            get => _localizedDescription;
            internal set => _localizedDescription = value;
        }

        /// <summary>
        /// Gets the translated keywords in the current language.<br />
        /// Defaults to the keywords value when no translation is provided.
        /// </summary>
        [XurrentField("localized_keywords")]
        public string? LocalizedKeywords
        {
            get => _localizedKeywords;
            internal set => _localizedKeywords = value;
        }

        /// <summary>
        /// Gets the translated name in the current language.<br />
        /// Defaults to the name value when no translation is provided.
        /// </summary>
        [XurrentField("localized_name")]
        public string? LocalizedName
        {
            get => _localizedName;
            internal set => _localizedName = value;
        }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the service.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for coordinating problems that directly affect the service.
        /// </summary>
        [XurrentField("problem_manager")]
        public Person? ProblemManager
        {
            get => _problemManager;
            set => _problemManager = SetValue("problem_manager", _problemManager, value);
        }

        /// <summary>
        /// Gets or sets the organization that provides the service.
        /// </summary>
        [XurrentField("provider")]
        public Organization? Provider
        {
            get => _provider;
            set => _provider = SetValue("provider", _provider, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for coordinating releases of the service.
        /// </summary>
        [XurrentField("release_manager")]
        public Person? ReleaseManager
        {
            get => _releaseManager;
            set => _releaseManager = SetValue("release_manager", _releaseManager, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for ensuring that the service level targets specified in the SLAs are met.
        /// </summary>
        [XurrentField("service_owner")]
        public Person? ServiceOwner
        {
            get => _serviceOwner;
            set => _serviceOwner = SetValue("service_owner", _serviceOwner, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier for the service.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the service in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the default support team for the service.
        /// </summary>
        [XurrentField("support_team")]
        public Team? SupportTeam
        {
            get => _supportTeam;
            set => _supportTeam = SetValue("support_team", _supportTeam, value);
        }

        /// <summary>
        /// Gets or sets the survey that is presented to users to rate the service.
        /// </summary>
        [XurrentField("survey")]
        public Survey? Survey
        {
            get => _survey;
            set => _survey = SetValue("survey", _survey, value);
        }

        /// <summary>
        /// Gets the UI extension that is applied to the service.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the service.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new service instance.
        /// </summary>
        public Service()
        {
        }

        /// <summary>
        /// Creates a new service instance.
        /// </summary>
        /// <param name="id">The unique identifier of the service.</param>
        public Service(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new service instance.
        /// </summary>
        /// <param name="name">The name of the service.</param>
        /// <param name="provider">The provider of the service.</param>
        public Service(string name, Organization provider)
        {
            _name = SetValue("name", name);
            _provider = SetValue("provider", provider);
        }

        private void OnDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "description_attachments");
        }
    }
}
