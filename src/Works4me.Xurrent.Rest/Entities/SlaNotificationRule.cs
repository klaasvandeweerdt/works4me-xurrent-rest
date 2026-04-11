using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent service level agreement notification rule object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class SlaNotificationRule : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="SlaNotificationRule"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

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
            /// The notify current assignee field.
            /// </summary>
            [XurrentEnum("notify_current_assignee")]
            NotifyCurrentAssignee,

            /// <summary>
            /// The notify first line team coordinator field.
            /// </summary>
            [XurrentEnum("notify_first_line_team_coordinator")]
            NotifyFirstLineTeamCoordinator,

            /// <summary>
            /// The notify first line team manager field.
            /// </summary>
            [XurrentEnum("notify_first_line_team_manager")]
            NotifyFirstLineTeamManager,

            /// <summary>
            /// The notify service owner field.
            /// </summary>
            [XurrentEnum("notify_service_owner")]
            NotifyServiceOwner,

            /// <summary>
            /// The notify support team coordinator field.
            /// </summary>
            [XurrentEnum("notify_support_team_coordinator")]
            NotifySupportTeamCoordinator,

            /// <summary>
            /// The notify support team manager field.
            /// </summary>
            [XurrentEnum("notify_support_team_manager")]
            NotifySupportTeamManager,

            /// <summary>
            /// The threshold percentage field.
            /// </summary>
            [XurrentEnum("threshold_percentage")]
            ThresholdPercentage,

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

        private DateTime? _createdAt;
        private bool? _notifyCurrentAssignee;
        private bool? _notifyFirstLineTeamCoordinator;
        private bool? _notifyFirstLineTeamManager;
        private bool? _notifyServiceOwner;
        private bool? _notifySupportTeamCoordinator;
        private bool? _notifySupportTeamManager;
        private int? _thresholdPercentage;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time when the SLA notification rule was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current assignee is notified.
        /// </summary>
        [XurrentField("notify_current_assignee")]
        public bool? NotifyCurrentAssignee
        {
            get => _notifyCurrentAssignee;
            set => _notifyCurrentAssignee = SetValue("notify_current_assignee", _notifyCurrentAssignee, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the first line team coordinator is notified.
        /// </summary>
        [XurrentField("notify_first_line_team_coordinator")]
        public bool? NotifyFirstLineTeamCoordinator
        {
            get => _notifyFirstLineTeamCoordinator;
            set => _notifyFirstLineTeamCoordinator = SetValue("notify_first_line_team_coordinator", _notifyFirstLineTeamCoordinator, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the first line team manager is notified.
        /// </summary>
        [XurrentField("notify_first_line_team_manager")]
        public bool? NotifyFirstLineTeamManager
        {
            get => _notifyFirstLineTeamManager;
            set => _notifyFirstLineTeamManager = SetValue("notify_first_line_team_manager", _notifyFirstLineTeamManager, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the service owner is notified.
        /// </summary>
        [XurrentField("notify_service_owner")]
        public bool? NotifyServiceOwner
        {
            get => _notifyServiceOwner;
            set => _notifyServiceOwner = SetValue("notify_service_owner", _notifyServiceOwner, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the support team coordinator is notified.
        /// </summary>
        [XurrentField("notify_support_team_coordinator")]
        public bool? NotifySupportTeamCoordinator
        {
            get => _notifySupportTeamCoordinator;
            set => _notifySupportTeamCoordinator = SetValue("notify_support_team_coordinator", _notifySupportTeamCoordinator, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the support team manager is notified.
        /// </summary>
        [XurrentField("notify_support_team_manager")]
        public bool? NotifySupportTeamManager
        {
            get => _notifySupportTeamManager;
            set => _notifySupportTeamManager = SetValue("notify_support_team_manager", _notifySupportTeamManager, value);
        }

        /// <summary>
        /// Gets or sets the percentage of the resolution target duration at which a notification is generated.
        /// </summary>
        [XurrentField("threshold_percentage")]
        public int? ThresholdPercentage
        {
            get => _thresholdPercentage;
            set => _thresholdPercentage = SetValue("threshold_percentage", _thresholdPercentage, value);
        }

        /// <summary>
        /// Gets the date and time when the SLA notification rule was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new service level agreement notification rule instance.
        /// </summary>
        public SlaNotificationRule()
        {
        }

        /// <summary>
        /// Creates a new service level agreement notification rule instance.
        /// </summary>
        /// <param name="id">The unique identifier of the service level agreement notification rule.</param>
        public SlaNotificationRule(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new service level agreement notification rule instance.
        /// </summary>
        /// <param name="thresholdPercentage">The threshold percentage of the service level agreement notification rule.</param>
        public SlaNotificationRule(int thresholdPercentage)
        {
            _thresholdPercentage = SetValue("threshold_percentage", thresholdPercentage);
        }
    }
}
