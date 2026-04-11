using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent parent service instance object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ParentServiceInstance : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="ParentServiceInstance"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The impact relation field.
            /// </summary>
            [XurrentEnum("impact_relation", IgnoreInFieldSelection = true)]
            ImpactRelation,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The service instance field.
            /// </summary>
            [XurrentEnum("service_instance", IgnoreInFieldSelection = true)]
            ServiceInstance
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

        private ParentServiceInstanceImpactRelation? _impactRelation;
        private ServiceInstance? _serviceInstance;

        /// <summary>
        /// Gets or sets the impact relation of the parent service instance.
        /// </summary>
        [XurrentField("impact_relation")]
        public ParentServiceInstanceImpactRelation? ImpactRelation
        {
            get => _impactRelation;
            set => _impactRelation = SetValue("impact_relation", _impactRelation, value);
        }

        /// <summary>
        /// Gets or sets the linked service instance.
        /// </summary>
        [XurrentField("service_instance")]
        public ServiceInstance? ServiceInstance
        {
            get => _serviceInstance;
            set => _serviceInstance = SetValue("service_instance", _serviceInstance, value);
        }

        /// <summary>
        /// Creates a new parent service instance instance.
        /// </summary>
        public ParentServiceInstance()
        {
        }

        /// <summary>
        /// Creates a new parent service instance instance.
        /// </summary>
        /// <param name="id">The unique identifier of the parent service instance.</param>
        public ParentServiceInstance(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new parent service instance instance.
        /// </summary>
        /// <param name="impactRelation">The impact relation of the parent service instance.</param>
        /// <param name="serviceInstance">The service instance of the parent service instance.</param>
        public ParentServiceInstance(ParentServiceInstanceImpactRelation impactRelation, ServiceInstance serviceInstance)
        {
            _impactRelation = SetValue("impact_relation", impactRelation);
            _serviceInstance = SetValue("service_instance", serviceInstance);
        }
    }
}
