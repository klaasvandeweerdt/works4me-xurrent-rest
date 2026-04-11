using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent permission object.
    /// </summary>
    public sealed class Permission : ObservableItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="Permission"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The account field.
            /// </summary>
            [XurrentEnum("account")]
            Account,

            /// <summary>
            /// The roles field.
            /// </summary>
            [XurrentEnum("roles")]
            Roles
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

        private Account? _account;
        private ObservableCollection<PermissionRole>? _roles;

        /// <summary>
        /// Gets or sets the account to which the permission applies.
        /// </summary>
        [XurrentField("account")]
        public Account? Account
        {
            get => _account;
            set => _account = SetValue("account", _account, value);
        }

        /// <summary>
        /// Gets or sets the roles assigned by the permission.
        /// </summary>
        [XurrentField("roles")]
        public ObservableCollection<PermissionRole> Roles
        {
            get => GetCollection(ref _roles, OnRolesChanged);
            set => SetCollection(ref _roles, "roles", value, OnRolesChanged);
        }

        private void OnRolesChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<PermissionRole> collection)
                MarkCollectionChanged(collection, "roles");
        }
    }
}
