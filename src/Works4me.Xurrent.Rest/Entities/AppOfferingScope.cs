using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent app offering scope object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AppOfferingScope : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AppOfferingScope"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The actions field.
            /// </summary>
            [XurrentEnum("actions")]
            Actions,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The effect field.
            /// </summary>
            [XurrentEnum("effect")]
            Effect,

            /// <summary>
            /// The grant type field.
            /// </summary>
            [XurrentEnum("grant_type")]
            GrantType,

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
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
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

        private List<string>? _actions;
        private DateTime? _createdAt;
        private ScopeEffect? _effect;
        private AppOfferingScopeGrant? _grantType;
        private DateTime? _updatedAt;

        [XurrentField("actions")]
        internal List<string>? ActionsCollection
        {
            get => _actions;
            set => _actions = value;
        }

        /// <summary>
        /// Gets the actions to which this app offering scope applies.
        /// </summary>
        public ReadOnlyCollection<string>? Actions
        {
            get => _actions is null ? null : new ReadOnlyCollection<string>(_actions);
        }

        /// <summary>
        /// Gets the date and time at which the app offering scope was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the effect of the app offering scope.
        /// </summary>
        [XurrentField("effect")]
        public ScopeEffect? Effect
        {
            get => _effect;
            internal set => _effect = value;
        }

        /// <summary>
        /// Gets the grant type of the app offering scope.
        /// </summary>
        [XurrentField("grant_type")]
        public AppOfferingScopeGrant? GrantType
        {
            get => _grantType;
            internal set => _grantType = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of the app offering scope.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new app offering scope instance.
        /// </summary>
        public AppOfferingScope()
        {
        }

        /// <summary>
        /// Creates a new app offering scope instance.
        /// </summary>
        /// <param name="id">The unique identifier of the app offering scope.</param>
        public AppOfferingScope(long id)
        {
            Id = id;
        }
    }
}
