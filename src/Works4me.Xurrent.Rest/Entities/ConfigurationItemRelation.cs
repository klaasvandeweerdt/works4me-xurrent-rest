using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent configuration item relation object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ConfigurationItemRelation : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ConfigurationItemRelation"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The configuration item field.
            /// </summary>
            [XurrentEnum("ci")]
            ConfigurationItem,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The relation type field.
            /// </summary>
            [XurrentEnum("relation_type")]
            RelationType
        }

        /// <summary>
        /// Represents the absence of supported filters for a query.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Specifies that no filtering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
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
        /// Represents the absence of supported ordering fields for a query.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Specifies that no ordering is applied.
            /// </summary>
            [XurrentEnum("")]
            None
        }

        private ConfigurationItem? _configurationItem;
        private ConfigurationItemRelationType? _relationType;

        /// <summary>
        /// Gets or sets the related configuration item.
        /// </summary>
        [XurrentField("ci")]
        public ConfigurationItem? ConfigurationItem
        {
            get => _configurationItem;
            set => _configurationItem = SetValue("related_ci", _configurationItem, value);
        }

        /// <summary>
        /// Gets or sets the relation type of the configuration item relation.
        /// </summary>
        [XurrentField("relation_type")]
        public ConfigurationItemRelationType? RelationType
        {
            get => _relationType;
            set => _relationType = SetValue("relation_type", _relationType, value);
        }

        /// <summary>
        /// Creates a new configuration item relation instance.
        /// </summary>
        public ConfigurationItemRelation()
        {
        }

        /// <summary>
        /// Creates a new configuration item relation instance.
        /// </summary>
        /// <param name="id">The unique identifier of the configuration item relation.</param>
        public ConfigurationItemRelation(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new configuration item relation instance.
        /// </summary>
        /// <param name="configurationItem">The configuration item of the configuration item relation.</param>
        /// <param name="relationType">The relation type of the configuration item relation.</param>
        public ConfigurationItemRelation(ConfigurationItem configurationItem, ConfigurationItemRelationType relationType)
        {
            _configurationItem = SetValue("ci", configurationItem);
            _relationType = SetValue("relation_type", relationType);
        }
    }
}
