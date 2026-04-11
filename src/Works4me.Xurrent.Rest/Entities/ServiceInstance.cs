using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent service instance object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ServiceInstance : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ServiceInstance"/> object.
        /// </summary>
        public enum Field
        {
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
            /// The first line team field.
            /// </summary>
            [XurrentEnum("first_line_team")]
            FirstLineTeam,

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
            /// The maintenance window field.
            /// </summary>
            [XurrentEnum("maintenance_window", IgnoreInFieldSelection = true)]
            MaintenanceWindow,

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
            /// The status field.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// The support team field.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

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
        /// Represents the filterable fields of a <see cref="ServiceInstance"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters service instances by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters service instances by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters service instances by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters service instances by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Filters service instances by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters service instances by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters service instances by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Filters service instances by support team.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// Filters service instances by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="ServiceInstance"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all active service instances.
            /// </summary>
            [XurrentEnum("active")]
            Active,

            /// <summary>
            /// Lists all inactive service instances.
            /// </summary>
            [XurrentEnum("inactive")]
            Inactive
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="ServiceInstance"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts service instances by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts service instances by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts service instances by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts service instances by service.
            /// </summary>
            [XurrentEnum("service")]
            Service,

            /// <summary>
            /// Sorts service instances by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts service instances by status.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// Sorts service instances by support team.
            /// </summary>
            [XurrentEnum("support_team")]
            SupportTeam,

            /// <summary>
            /// Sorts service instances by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private Team? _firstLineTeam;
        private RequestImpact? _impact;
        private Calendar? _maintenanceWindow;
        private string? _name;
        private Uri? _pictureUri;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private Service? _service;
        private string? _source;
        private string? _sourceID;
        private ServiceInstanceStatus? _status;
        private Team? _supportTeam;
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
        /// Gets the aggregated attachments associated with the service instance.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the service instance was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the team that is automatically selected for requests linked to the service instance after submission.
        /// </summary>
        [XurrentField("first_line_team")]
        public Team? FirstLineTeam
        {
            get => _firstLineTeam;
            set => _firstLineTeam = SetValue("first_line_team", _firstLineTeam, value);
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
        /// Gets or sets the calendar that defines periods in which workflow tasks related to the service instance may be implemented.
        /// </summary>
        [XurrentField("maintenance_window")]
        public Calendar? MaintenanceWindow
        {
            get => _maintenanceWindow;
            set => _maintenanceWindow = SetValue("maintenance_window", _maintenanceWindow, value);
        }

        /// <summary>
        /// Gets or sets the name of the service instance.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the service instance.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets remarks for the service instance.
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
        /// Gets or sets the service whose functionality the service instance provides.
        /// </summary>
        [XurrentField("service")]
        public Service? Service
        {
            get => _service;
            set => _service = SetValue("service", _service, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier for the service instance.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the service instance in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the current status of the service instance.
        /// </summary>
        [XurrentField("status")]
        public ServiceInstanceStatus? Status
        {
            get => _status;
            set => _status = SetValue("status", _status, value);
        }

        /// <summary>
        /// Gets or sets the default support team for requests when the service instance is manually selected.
        /// </summary>
        [XurrentField("support_team")]
        public Team? SupportTeam
        {
            get => _supportTeam;
            set => _supportTeam = SetValue("support_team", _supportTeam, value);
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the selected maintenance window.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the UI extension that is applied to the service instance.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the service instance.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new service instance instance.
        /// </summary>
        public ServiceInstance()
        {
        }

        /// <summary>
        /// Creates a new service instance instance.
        /// </summary>
        /// <param name="id">The unique identifier of the service instance.</param>
        public ServiceInstance(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new service instance instance.
        /// </summary>
        /// <param name="name">The name of the service instance.</param>
        /// <param name="service">The service of the service instance.</param>
        public ServiceInstance(string name, Service service)
        {
            _name = SetValue("name", name);
            _service = SetValue("service", service);
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }
    }
}
