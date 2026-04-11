using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent team object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class Team : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Team"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The agile board field.
            /// </summary>
            [XurrentEnum("agile_board")]
            AgileBoard,

            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The auto assign field.
            /// </summary>
            [XurrentEnum("auto_assign")]
            AutoAssign,

            /// <summary>
            /// The configuration manager field.
            /// </summary>
            [XurrentEnum("configuration_manager")]
            ConfigurationManager,

            /// <summary>
            /// The coordinator field.
            /// </summary>
            [XurrentEnum("coordinator")]
            Coordinator,

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
            /// The inbound email local part field.
            /// </summary>
            [XurrentEnum("inbound_email_local_part")]
            InboundEmailLocalPart,

            /// <summary>
            /// The manager field.
            /// </summary>
            [XurrentEnum("manager")]
            Manager,

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
            /// The scrum workspace field.
            /// </summary>
            [XurrentEnum("scrum_workspace")]
            ScrumWorkspace,

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
            UpdatedAt,

            /// <summary>
            /// The work hours field.
            /// </summary>
            [XurrentEnum("work_hours")]
            WorkHours
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="Team"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters teams by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters teams by disabled status.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters teams by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters teams by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters teams by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters teams by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters teams by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="Team"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled teams.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled teams.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="Team"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts teams by creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts teams by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts teams by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts teams by source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts teams by last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private AgileBoard? _agileBoard;
        private List<Attachment>? _attachments;
        private bool? _autoAssign;
        private Person? _configurationManager;
        private Person? _coordinator;
        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _inboundEmailLocalPart;
        private Person? _manager;
        private string? _name;
        private Uri? _pictureUri;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private ScrumWorkspace? _scrumWorkspace;
        private string? _source;
        private string? _sourceID;
        private string? _timeZone;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;
        private Calendar? _workHours;

        /// <summary>
        /// Gets or sets the agile board that records are automatically linked to when they are assigned to the team.
        /// </summary>
        [XurrentField("agile_board")]
        public AgileBoard? AgileBoard
        {
            get => _agileBoard;
            set => _agileBoard = SetValue("agile_board", _agileBoard, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the team.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets a value indicating whether requests are automatically assigned to a team member.
        /// </summary>
        [XurrentField("auto_assign")]
        public bool? AutoAssign
        {
            get => _autoAssign;
            set => _autoAssign = SetValue("auto_assign", _autoAssign, value);
        }

        /// <summary>
        /// Gets or sets the person responsible for maintaining the configuration items supported by the team.
        /// </summary>
        [XurrentField("configuration_manager")]
        public Person? ConfigurationManager
        {
            get => _configurationManager;
            set => _configurationManager = SetValue("configuration_manager", _configurationManager, value);
        }

        /// <summary>
        /// Gets or sets the coordinator of the team.<br />
        /// Only members of the team can be selected.
        /// </summary>
        [XurrentField("coordinator")]
        public Person? Coordinator
        {
            get => _coordinator;
            set => _coordinator = SetValue("coordinator", _coordinator, value);
        }

        /// <summary>
        /// Gets the date and time at which the team was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the team is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the local part of the inbound email address used to create requests for the team.<br />
        /// Emails sent to this address generate new requests assigned to the team.
        /// </summary>
        [XurrentField("inbound_email_local_part")]
        public string? InboundEmailLocalPart
        {
            get => _inboundEmailLocalPart;
            set => _inboundEmailLocalPart = SetValue("inbound_email_local_part", _inboundEmailLocalPart, value);
        }

        /// <summary>
        /// Gets or sets the manager or supervisor responsible for maintaining the team.<br />
        /// The manager does not need to be a member of the team.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the team.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets additional information about the team.
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
        /// Gets the scrum workspace used by the team to plan their work.
        /// </summary>
        [XurrentField("scrum_workspace")]
        public ScrumWorkspace? ScrumWorkspace
        {
            get => _scrumWorkspace;
            internal set => _scrumWorkspace = value;
        }

        /// <summary>
        /// Gets or sets the external source identifier for the team.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the team in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the time zone that applies to the selected work hours of the team.
        /// </summary>
        [XurrentField("time_zone")]
        public string? TimeZone
        {
            get => _timeZone;
            set => _timeZone = SetValue("time_zone", _timeZone, value);
        }

        /// <summary>
        /// Gets the UI extension applied to the team.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            internal set => _uiExtension = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the team.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the calendar that defines the work hours during which the team is available.
        /// </summary>
        [XurrentField("work_hours")]
        public Calendar? WorkHours
        {
            get => _workHours;
            set => _workHours = SetValue("work_hours", _workHours, value);
        }

        /// <summary>
        /// Creates a new team instance.
        /// </summary>
        public Team()
        {
        }

        /// <summary>
        /// Creates a new team instance.
        /// </summary>
        /// <param name="id">The unique identifier of the team.</param>
        public Team(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new team instance.
        /// </summary>
        /// <param name="name">The name of the team.</param>
        public Team(string name)
        {
            _name = SetValue("name", name);
        }

        private void OnRemarksAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "remarks_attachments");
        }
    }
}
