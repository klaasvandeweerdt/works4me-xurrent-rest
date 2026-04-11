using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent RFC type object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class RfcType : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="RfcType"/> object.
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
            /// The information field.
            /// </summary>
            [XurrentEnum("information")]
            Information,

            /// <summary>
            /// The information attachments field.
            /// </summary>
            [XurrentEnum("information_attachments", IgnoreInFieldSelection = true)]
            InformationAttachments,

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
            /// The position field.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// The reference field.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

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
        /// Represents the filterable fields of a <see cref="RfcType"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Represents the created_at filter parameter.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Represents the disabled filter parameter.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Represents the id filter parameter.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Represents the name filter parameter.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Represents the reference filter parameter.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Represents the sourceID filter parameter.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Represents the updated_at filter parameter.
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
        /// Represents the fields used to order a <see cref="RfcType"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Represents the created_at sorting parameter.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Represents the id sorting parameter.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Represents the name sorting parameter.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Represents the position sorting parameter.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// Represents the reference sorting parameter.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Represents the sourceID sorting parameter.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Represents the updated_at sorting parameter.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _information;
        private ObservableCollection<AttachmentReference>? _informationAttachments;
        private AttachmentReferenceWriter? _informationAttachmentsWriter;
        private string? _name;
        private int? _position;
        private string? _reference;
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
        /// Gets the aggregated attachments of the RFC type.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the RFC type was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the RFC type may not be related to any more RFCs.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets additional information about the RFC type.
        /// </summary>
        [XurrentField("information")]
        public string? Information
        {
            get => _information;
            set => _information = SetValue("information", _information, value);
        }

        [XurrentField("information_attachments")]
        internal ObservableCollection<AttachmentReference> InformationAttachmentsCollection
        {
            get => GetCollection(ref _informationAttachments, OnInformationAttachmentsChanged);
            set => SetCollection(ref _informationAttachments, "information_attachments", value, OnInformationAttachmentsChanged);
        }

        /// <summary>
        /// Sets the attachments used in the information field.<br />
        /// This property is write-only.
        /// </summary>
        public AttachmentReferenceWriter InformationAttachments
        {
            get
            {
                _informationAttachmentsWriter ??= new AttachmentReferenceWriter(() => InformationAttachmentsCollection, c => InformationAttachmentsCollection = c);
                return _informationAttachmentsWriter;
            }
        }

        /// <summary>
        /// Gets or sets the name of the RFC type.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the position that the RFC type takes when it is displayed in a sorted list.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            set => _position = SetValue("position", _position, value);
        }

        /// <summary>
        /// Gets the reference of the RFC type.<br />
        /// This value is automatically set to the name in lower case with spaces replaced by underscores.
        /// </summary>
        [XurrentField("reference")]
        public string? Reference
        {
            get => _reference;
            internal set => _reference = value;
        }

        /// <summary>
        /// Gets or sets the source of the RFC type.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the RFC type.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the RFC type.<br />
        /// If the RFC type has no updates, this value contains the <see cref="CreatedAt"/> value.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new rfc type instance.
        /// </summary>
        public RfcType()
        {
        }

        /// <summary>
        /// Creates a new rfc type instance.
        /// </summary>
        /// <param name="id">The unique identifier of the rfc type.</param>
        public RfcType(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new rfc type instance.
        /// </summary>
        /// <param name="name">The name of the rfc type.</param>
        public RfcType(string name)
        {
            _name = SetValue("name", name);
        }

        private void OnInformationAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "information_attachments");
        }
    }
}
