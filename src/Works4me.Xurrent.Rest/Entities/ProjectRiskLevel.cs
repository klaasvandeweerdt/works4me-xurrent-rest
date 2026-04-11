using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent project risk level object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ProjectRiskLevel : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ProjectRiskLevel"/> object.
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
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

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
        /// Represents the filterable fields of a <see cref="ProjectRiskLevel"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters by whether the project risk level is disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters by reference.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Filters by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters by the last update date.
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
        /// Represents the fields used to order a <see cref="ProjectRiskLevel"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts by the creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts by the identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts by position.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// Sorts by reference.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Sorts by the source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts by the last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private string? _description;
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
        /// Gets the aggregated attachments associated with the project risk level.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time when the project risk level was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the description of the project risk level.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the project risk level is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the information of the project risk level.
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
        /// Gets or sets the name of the project risk level.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the position of the project risk level.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            set => _position = SetValue("position", _position, value);
        }

        /// <summary>
        /// Gets the reference of the project risk level.
        /// </summary>
        [XurrentField("reference")]
        public string? Reference
        {
            get => _reference;
            internal set => _reference = value;
        }

        /// <summary>
        /// Gets or sets the source of the project risk level.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the project risk level.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time when the project risk level was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new project risk level instance.
        /// </summary>
        public ProjectRiskLevel()
        {
        }

        /// <summary>
        /// Creates a new project risk level instance.
        /// </summary>
        /// <param name="id">The unique identifier of the project risk level.</param>
        public ProjectRiskLevel(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new project risk level instance.
        /// </summary>
        /// <param name="name">The name of the project risk level.</param>
        public ProjectRiskLevel(string name)
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
