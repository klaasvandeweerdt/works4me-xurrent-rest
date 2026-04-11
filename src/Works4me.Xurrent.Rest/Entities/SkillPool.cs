using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent skill pool object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class SkillPool : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="SkillPool"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The attachments field.
            /// </summary>
            [XurrentEnum("attachments")]
            Attachments,

            /// <summary>
            /// The cost per hour field.
            /// </summary>
            [XurrentEnum("cost_per_hour")]
            CostPerHour,

            /// <summary>
            /// The cost per hour currency field.
            /// </summary>
            [XurrentEnum("cost_per_hour_currency")]
            CostPerHourCurrency,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

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
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="SkillPool"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters skill pools by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters skill pools by whether they are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters skill pools by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters skill pools by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters skill pools by their external source identifier.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters skill pools by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters skill pools by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="SkillPool"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled skill pools.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled skill pools.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="SkillPool"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts skill pools by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts skill pools by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts skill pools by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts skill pools by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts skill pools by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private decimal? _costPerHour;
        private Currency? _costPerHourCurrency;
        private DateTime? _createdAt;
        private bool? _disabled;
        private Person? _manager;
        private string? _name;
        private Uri? _pictureUri;
        private string? _remarks;
        private ObservableCollection<AttachmentReference>? _remarksAttachments;
        private AttachmentReferenceWriter? _remarksAttachmentsWriter;
        private string? _source;
        private string? _sourceID;
        private DateTime? _updatedAt;

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the aggregated attachments associated with the skill pool.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets or sets the estimated total cost per work hour for the service provider organization.
        /// </summary>
        [XurrentField("cost_per_hour")]
        public decimal? CostPerHour
        {
            get => _costPerHour;
            set => _costPerHour = SetValue("cost_per_hour", _costPerHour, value);
        }

        /// <summary>
        /// Gets or sets the currency of the cost per hour value.
        /// </summary>
        [XurrentField("cost_per_hour_currency")]
        public Currency? CostPerHourCurrency
        {
            get => _costPerHourCurrency;
            set => _costPerHourCurrency = SetValue("cost_per_hour_currency", _costPerHourCurrency, value);
        }

        /// <summary>
        /// Gets the date and time at which the skill pool was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the skill pool is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the manager or supervisor responsible for maintaining the skill pool.<br />
        /// The manager does not need to be a member of the skill pool.
        /// </summary>
        [XurrentField("manager")]
        public Person? Manager
        {
            get => _manager;
            set => _manager = SetValue("manager", _manager, value);
        }

        /// <summary>
        /// Gets or sets the name of the skill pool.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the hyperlink to the image file for the skill pool.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets or sets the remarks of the skill pool.
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
        /// Gets or sets the external source identifier for the skill pool.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the skill pool in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the skill pool.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new skill pool instance.
        /// </summary>
        public SkillPool()
        {
        }

        /// <summary>
        /// Creates a new skill pool instance.
        /// </summary>
        /// <param name="id">The unique identifier of the skill pool.</param>
        public SkillPool(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new skill pool instance.
        /// </summary>
        /// <param name="name">The name of the skill pool.</param>
        public SkillPool(string name)
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
