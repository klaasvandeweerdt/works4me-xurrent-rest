using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent app instance object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AppInstance : RecordItemWithCustomFields
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AppInstance"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The app offering field.
            /// </summary>
            [XurrentEnum("app_offering")]
            AppOffering,

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
            /// The custom fields field.
            /// </summary>
            [XurrentEnum("custom_fields")]
            CustomFields,

            /// <summary>
            /// The customer account field.
            /// </summary>
            [XurrentEnum("customer_account")]
            CustomerAccount,

            /// <summary>
            /// The customer representative field.
            /// </summary>
            [XurrentEnum("customer_representative")]
            CustomerRepresentative,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The enabled by customer field.
            /// </summary>
            [XurrentEnum("enabled_by_customer")]
            EnabledByCustomer,

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
            /// The suspended field.
            /// </summary>
            [XurrentEnum("suspended")]
            Suspended,

            /// <summary>
            /// The suspension comment field.
            /// </summary>
            [XurrentEnum("suspension_comment")]
            SuspensionComment,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The webhook field.
            /// </summary>
            [XurrentEnum("webhook")]
            Webhook,

            /// <summary>
            /// The webhook policy field.
            /// </summary>
            [XurrentEnum("webhook_policy")]
            WebhookPolicy
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="AppInstance"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters app instances by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters app instances by whether they are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters app instances by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters app instances by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of an <see cref="AppInstance"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled app instances.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled app instances.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order an <see cref="AppInstance"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts app instances by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts app instances by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts app instances by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private AppOffering? _appOffering;
        private List<Attachment>? _attachments;
        private DateTime? _createdAt;
        private Account? _customerAccount;
        private Person? _customerRepresentative;
        private bool? _disabled;
        private bool? _enabledByCustomer;
        private bool? _suspended;
        private string? _suspensionComment;
        private DateTime? _updatedAt;
        private Webhook? _webhook;
        private WebhookPolicy? _webhookPolicy;

        /// <summary>
        /// Gets or sets the app offering associated with the app instance.
        /// </summary>
        [XurrentField("app_offering")]
        public AppOffering? AppOffering
        {
            get => _appOffering;
            set => _appOffering = SetValue("app_offering", _appOffering, value);
        }

        [XurrentField("attachments")]
        internal List<Attachment>? AttachmentsCollection
        {
            get => _attachments;
            set => _attachments = value;
        }

        /// <summary>
        /// Gets the attachments associated with the app instance.
        /// </summary>
        public ReadOnlyCollection<Attachment>? Attachments
        {
            get => _attachments is null ? null : new ReadOnlyCollection<Attachment>(_attachments);
        }

        /// <summary>
        /// Gets the date and time at which the app instance was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the customer account associated with the app instance.
        /// </summary>
        [XurrentField("customer_account")]
        public Account? CustomerAccount
        {
            get => _customerAccount;
            internal set => _customerAccount = value;
        }

        /// <summary>
        /// Gets or sets the customer representative associated with the app instance.
        /// </summary>
        [XurrentField("customer_representative")]
        public Person? CustomerRepresentative
        {
            get => _customerRepresentative;
            set => _customerRepresentative = SetValue("customer_representative", _customerRepresentative, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the app instance is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the app instance is enabled by the customer.
        /// </summary>
        [XurrentField("enabled_by_customer")]
        public bool? EnabledByCustomer
        {
            get => _enabledByCustomer;
            set => _enabledByCustomer = SetValue("enabled_by_customer", _enabledByCustomer, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the app instance is suspended.
        /// </summary>
        [XurrentField("suspended")]
        public bool? Suspended
        {
            get => _suspended;
            set => _suspended = SetValue("suspended", _suspended, value);
        }

        /// <summary>
        /// Gets or sets the suspension comment of the app instance.
        /// </summary>
        [XurrentField("suspension_comment")]
        public string? SuspensionComment
        {
            get => _suspensionComment;
            set => _suspensionComment = SetValue("suspension_comment", _suspensionComment, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the app instance.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets the webhook associated with the app instance.
        /// </summary>
        [XurrentField("webhook")]
        public Webhook? Webhook
        {
            get => _webhook;
            internal set => _webhook = value;
        }

        /// <summary>
        /// Gets the webhook policy associated with the app instance.
        /// </summary>
        [XurrentField("webhook_policy")]
        public WebhookPolicy? WebhookPolicy
        {
            get => _webhookPolicy;
            internal set => _webhookPolicy = value;
        }

        /// <summary>
        /// Creates a new app instance instance.
        /// </summary>
        public AppInstance()
        {
        }

        /// <summary>
        /// Creates a new app instance instance.
        /// </summary>
        /// <param name="id">The unique identifier of the app instance.</param>
        public AppInstance(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new app instance instance.
        /// </summary>
        /// <param name="appOffering">The app offering of the app instance.</param>
        public AppInstance(AppOffering appOffering)
        {
            _appOffering = SetValue("app_offering", appOffering);
        }
    }
}
