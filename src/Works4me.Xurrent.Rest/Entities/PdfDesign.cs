using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent PDF design object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class PdfDesign : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="PdfDesign"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The category field.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The css field.
            /// </summary>
            [XurrentEnum("css")]
            Css,

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
            /// The html field.
            /// </summary>
            [XurrentEnum("html")]
            Html,

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
        /// Represents the filterable fields of a <see cref="PdfDesign"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters pdf designs by its category.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// Filters pdf designs by its disabled state.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters pdf designs by its identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters pdf designs by its name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters pdf designs by its source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters pdf designs by its source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID
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
        /// Represents the fields used to order a <see cref="PdfDesign"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts pdf designs by its creation date.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts pdf designs by its identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts pdf designs by its name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts pdf designs by its source identifier.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts pdf designs by its last update date.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private PdfDesignCategory? _category;
        private DateTime? _createdAt;
        private string? _css;
        private string? _description;
        private ObservableCollection<AttachmentReference>? _descriptionAttachments;
        private AttachmentReferenceWriter? _descriptionAttachmentsWriter;
        private bool? _disabled;
        private string? _html;
        private string? _name;
        private string? _source;
        private string? _sourceID;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets the design category of the PDF design.
        /// </summary>
        [XurrentField("category")]
        public PdfDesignCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets the date and time when the PDF design was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the CSS code of the PDF design.
        /// </summary>
        [XurrentField("css")]
        public string? Css
        {
            get => _css;
            set => _css = SetValue("css", _css, value);
        }

        /// <summary>
        /// Gets or sets the description of the object.
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
        /// Gets or sets a value indicating whether the object may no longer be related to other records.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the HTML code of the PDF design.
        /// </summary>
        [XurrentField("html")]
        public string? Html
        {
            get => _html;
            set => _html = SetValue("html", _html, value);
        }

        /// <summary>
        /// Gets or sets the name of the PDF design.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the source value of the PDF design.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the source identifier of the PDF design.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets the date and time when the PDF design was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new pdf design instance.
        /// </summary>
        public PdfDesign()
        {
        }

        /// <summary>
        /// Creates a new pdf design instance.
        /// </summary>
        /// <param name="id">The unique identifier of the pdf design.</param>
        public PdfDesign(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new pdf design instance.
        /// </summary>
        /// <param name="category">The category of the pdf design.</param>
        /// <param name="name">The name of the pdf design.</param>
        public PdfDesign(PdfDesignCategory category, string name)
        {
            _category = SetValue("category", category);
            _name = SetValue("name", name);
        }

        private void OnDescriptionAttachmentsChanged(object? sender, EventArgs e)
        {
            if (sender is ObservableCollection<AttachmentReference> collection)
                MarkCollectionChanged(collection, "description_attachments");
        }
    }
}
