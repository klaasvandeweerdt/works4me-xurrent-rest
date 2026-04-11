using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent broadcast object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Broadcast : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Broadcast"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The customers field.
            /// </summary>
            [XurrentEnum("customers")]
            Customers,

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
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The message field.
            /// </summary>
            [XurrentEnum("message")]
            Message,

            /// <summary>
            /// The message type field.
            /// </summary>
            [XurrentEnum("message_type")]
            MessageType,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The organizations field.
            /// </summary>
            [XurrentEnum("organizations")]
            Organizations,

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
            /// The request field.
            /// </summary>
            [XurrentEnum("request")]
            Request,

            /// <summary>
            /// The service instances field.
            /// </summary>
            [XurrentEnum("service_instances")]
            ServiceInstances,

            /// <summary>
            /// The sites field.
            /// </summary>
            [XurrentEnum("sites")]
            Sites,

            /// <summary>
            /// The skill pools field.
            /// </summary>
            [XurrentEnum("skill_pools")]
            SkillPools,

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
            /// The teams field.
            /// </summary>
            [XurrentEnum("teams")]
            Teams,

            /// <summary>
            /// The time zone field.
            /// </summary>
            [XurrentEnum("time_zone")]
            TimeZone,

            /// <summary>
            /// The translations field.
            /// </summary>
            [XurrentEnum("translations")]
            Translations,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The visibility field.
            /// </summary>
            [XurrentEnum("visibility")]
            Visibility
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Broadcast"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters broadcasts by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters broadcasts by end date and time.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

            /// <summary>
            /// Filters broadcasts by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters broadcasts by message type.
            /// </summary>
            [XurrentEnum("message_type")]
            MessageType,

            /// <summary>
            /// Filters broadcasts by identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters broadcasts by start date and time.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// Filters broadcasts by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Broadcast"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all active broadcasts.
            /// </summary>
            [XurrentEnum("active")]
            Active,

            /// <summary>
            /// Lists all inactive broadcasts.
            /// </summary>
            [XurrentEnum("inactive")]
            Inactive
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Broadcast"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts broadcasts by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts broadcasts by the end date and time.
            /// </summary>
            [XurrentEnum("end_at")]
            EndAt,

            /// <summary>
            /// Sorts broadcasts by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts broadcasts by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts broadcasts by the start date and time.
            /// </summary>
            [XurrentEnum("start_at")]
            StartAt,

            /// <summary>
            /// Sorts broadcasts by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private DateTime? _createdAt;
        private ObservableCollection<Organization>? _customers;
        private bool? _disabled;
        private DateTime? _endAt;
        private string? _message;
        private BroadcastMessageType? _messageType;
        private ObservableCollection<Organization>? _organizations;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private Request? _request;
        private ObservableCollection<ServiceInstance>? _serviceInstances;
        private ObservableCollection<Site>? _sites;
        private ObservableCollection<SkillPool>? _skillPools;
        private string? _source;
        private string? _sourceID;
        private DateTime? _startAt;
        private ObservableCollection<Team>? _teams;
        private string? _timeZone;
        private ObservableCollection<BroadcastTranslation>? _translations;
        private DateTime? _updatedAt;
        private BroadcastVisibility? _visibility;

        /// <summary>
        /// Gets the date and time at which the broadcast was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the customer organizations used to target specialists handling requests from those customers.<br />
        /// This property is applicable only when the visibility is set to specialists in requests from the specified customers.
        /// </summary>
        [XurrentField("customers")]
        public ObservableCollection<Organization> Customers
        {
            get => GetCollection(ref _customers, OnCustomersChanged);
            set => SetCollection(ref _customers, "customers", value, OnCustomersChanged);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the broadcast is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the date and time at which the broadcast ends.<br />
        /// If not set, the broadcast remains active until it is disabled.
        /// </summary>
        [XurrentField("end_at")]
        public DateTime? EndAt
        {
            get => _endAt;
            set => _endAt = SetValue("end_at", _endAt, value);
        }

        /// <summary>
        /// Gets or sets the message content that is broadcasted.
        /// </summary>
        [XurrentField("message")]
        public string? Message
        {
            get => _message;
            set => _message = SetValue("message", _message, value);
        }

        /// <summary>
        /// Gets or sets the type of the broadcast message.<br />
        /// The selected type determines the icon displayed with the message.
        /// </summary>
        [XurrentField("message_type")]
        public BroadcastMessageType? MessageType
        {
            get => _messageType;
            set => _messageType = SetValue("message_type", _messageType, value);
        }

        /// <summary>
        /// Gets or sets the organizations whose members should see the broadcast.
        /// </summary>
        [XurrentField("organizations")]
        public ObservableCollection<Organization> Organizations
        {
            get => GetCollection(ref _organizations, OnOrganizationsChanged);
            set => SetCollection(ref _organizations, "organizations", value, OnOrganizationsChanged);
        }

        /// <summary>
        /// Gets or sets additional remarks for the broadcast.
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
        /// Gets or sets the request group to which end users can subscribe when affected by the broadcasted issue.
        /// </summary>
        [XurrentField("request")]
        public Request? Request
        {
            get => _request;
            set => _request = SetValue("request", _request, value);
        }

        /// <summary>
        /// Gets or sets the service instances used to target people covered by an active SLA.<br />
        /// This property is applicable only when the visibility is set to covered service instances.
        /// </summary>
        [XurrentField("service_instances")]
        public ObservableCollection<ServiceInstance> ServiceInstances
        {
            get => GetCollection(ref _serviceInstances, OnServiceInstancesChanged);
            set => SetCollection(ref _serviceInstances, "service_instances", value, OnServiceInstancesChanged);
        }

        /// <summary>
        /// Gets or sets the sites whose associated people should see the broadcast.
        /// </summary>
        [XurrentField("sites")]
        public ObservableCollection<Site> Sites
        {
            get => GetCollection(ref _sites, OnSitesChanged);
            set => SetCollection(ref _sites, "sites", value, OnSitesChanged);
        }

        /// <summary>
        /// Gets or sets the skill pools whose members should see the broadcast.
        /// </summary>
        [XurrentField("skill_pools")]
        public ObservableCollection<SkillPool> SkillPools
        {
            get => GetCollection(ref _skillPools, OnSkillPoolsChanged);
            set => SetCollection(ref _skillPools, "skill_pools", value, OnSkillPoolsChanged);
        }

        /// <summary>
        /// Gets or sets the external source identifier for the broadcast.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the broadcast in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the date and time at which the broadcast starts.<br />
        /// If not specified, the current date and time in the user's time zone is used.
        /// </summary>
        [XurrentField("start_at")]
        public DateTime? StartAt
        {
            get => _startAt;
            set => _startAt = SetValue("start_at", _startAt, value);
        }

        /// <summary>
        /// Gets or sets the teams whose members should see the broadcast.<br />
        /// This property is applicable only when the visibility is set to members of specific teams.
        /// </summary>
        [XurrentField("teams")]
        public ObservableCollection<Team> Teams
        {
            get => GetCollection(ref _teams, OnTeamsChanged);
            set => SetCollection(ref _teams, "teams", value, OnTeamsChanged);
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the start and end dates and times of the broadcast.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets or sets the translations of the broadcast message.
        /// </summary>
        [XurrentField("translations")]
        public ObservableCollection<BroadcastTranslation> Translations
        {
            get => GetCollection(ref _translations, OnTranslationsChanged);
            set => SetCollection(ref _translations, "translations", value, OnTranslationsChanged);
        }

        /// <summary>
        /// Gets the date and time of the last update of the broadcast.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the visibility that defines the target audience of the broadcast.
        /// </summary>
        [XurrentField("visibility")]
        public BroadcastVisibility? Visibility
        {
            get => _visibility;
            set => _visibility = SetValue("visibility", _visibility, value);
        }

        /// <summary>
        /// Creates a new broadcast instance.
        /// </summary>
        public Broadcast()
        {
        }

        /// <summary>
        /// Creates a new broadcast instance.
        /// </summary>
        /// <param name="id">The unique identifier of the broadcast.</param>
        public Broadcast(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new broadcast instance.
        /// </summary>
        /// <param name="message">The message of the broadcast.</param>
        /// <param name="messageType">The message type of the broadcast.</param>
        public Broadcast(string message, BroadcastMessageType messageType)
        {
            _message = SetValue("message", message);
            _messageType = SetValue("message_type", messageType);
        }

        private void OnCustomersChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<Organization> collection)
                MarkCollectionChanged(collection, "customers");
        }

        private void OnOrganizationsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<Organization> collection)
                MarkCollectionChanged(collection, "organizations");
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }

        private void OnServiceInstancesChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<ServiceInstance> collection)
                MarkCollectionChanged(collection, "service_instances");
        }

        private void OnSitesChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<Site> collection)
                MarkCollectionChanged(collection, "sites");
        }

        private void OnSkillPoolsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<SkillPool> collection)
                MarkCollectionChanged(collection, "skill_pools");
        }

        private void OnTeamsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<Team> collection)
                MarkCollectionChanged(collection, "teams");
        }

        private void OnTranslationsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<BroadcastTranslation> collection)
                MarkCollectionChanged(collection, "translations");
        }
    }
}
