using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent product category object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ProductCategory : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ProductCategory"/> object.
        /// </summary>
        public enum Field
        {
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
            /// The group field.
            /// </summary>
            [XurrentEnum("group")]
            Group,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The localized group field.
            /// </summary>
            [XurrentEnum("localized_group", IgnoreInFieldSelection = true)]
            LocalizedGroup,

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
            /// The reference field.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// The rule set field.
            /// </summary>
            [XurrentEnum("rule_set")]
            RuleSet,

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
        /// Represents the filterable fields of a <see cref="ProductCategory"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters product categories by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters product categories by whether they are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters product categories by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters product categories by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters product categories by reference.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Filters product categories by rule set.
            /// </summary>
            [XurrentEnum("rule_set")]
            RuleSet,

            /// <summary>
            /// Filters product categories by source.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters product categories by identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters product categories by last update date and time.
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
        /// Represents the fields used to order a <see cref="ProductCategory"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts product categories by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts product categories by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts product categories by their reference.
            /// </summary>
            [XurrentEnum("reference")]
            Reference,

            /// <summary>
            /// Sorts product categories by their rule set.
            /// </summary>
            [XurrentEnum("rule_set")]
            RuleSet,

            /// <summary>
            /// Sorts product categories by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts product categories by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private DateTime? _createdAt;
        private bool? _disabled;
        private string? _group;
        private string? _localizedGroup;
        private string? _name;
        private Uri? _pictureUri;
        private string? _reference;
        private ProductCategoryRuleSet? _ruleSet;
        private string? _source;
        private string? _sourceID;
        private UiExtension? _uiExtension;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time at which the product category was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the product category is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the group to which the product category belongs.
        /// </summary>
        [XurrentField("group")]
        public string? Group
        {
            get => _group;
            set => _group = SetValue("group", _group, value);
        }

        /// <summary>
        /// Gets the translated group name in the current language.
        /// </summary>
        [XurrentField("localized_group")]
        public string? LocalizedGroup
        {
            get => _localizedGroup;
            internal set => _localizedGroup = value;
        }

        /// <summary>
        /// Gets or sets the name of the product category.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the URI of the image file for the product category.<br />
        /// A data URL can be used to supply the image directly.
        /// </summary>
        [XurrentField("picture_uri")]
        public Uri? PictureUri
        {
            get => _pictureUri;
            set => _pictureUri = SetValue("picture_uri", _pictureUri, value);
        }

        /// <summary>
        /// Gets the reference of the product category.
        /// </summary>
        [XurrentField("reference")]
        public string? Reference
        {
            get => _reference;
            internal set => _reference = value;
        }

        /// <summary>
        /// Gets or sets the rule set that applies to the product category.
        /// </summary>
        [XurrentField("rule_set")]
        public ProductCategoryRuleSet? RuleSet
        {
            get => _ruleSet;
            set => _ruleSet = SetValue("rule_set", _ruleSet, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier of the product category.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the product category in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the UI extension associated with the product category.
        /// </summary>
        [XurrentField("ui_extension")]
        public UiExtension? UiExtension
        {
            get => _uiExtension;
            set => _uiExtension = SetValue("ui_extension", _uiExtension, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the product category.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new product category instance.
        /// </summary>
        public ProductCategory()
        {
        }

        /// <summary>
        /// Creates a new product category instance.
        /// </summary>
        /// <param name="id">The unique identifier of the product category.</param>
        public ProductCategory(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new product category instance.
        /// </summary>
        /// <param name="ruleSet">The rule set of the product category.</param>
        public ProductCategory(ProductCategoryRuleSet ruleSet)
        {
            _ruleSet = SetValue("rule_set", ruleSet);
        }
    }
}
