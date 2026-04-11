using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents and app offering automation rule object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AppOfferingAutomationRule : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AppOfferingAutomationRule"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The actions field.
            /// </summary>
            [XurrentEnum("actions")]
            Actions,

            /// <summary>
            /// The actions html field.
            /// </summary>
            [XurrentEnum("actions_html")]
            ActionsHtml,

            /// <summary>
            /// The app offering field.
            /// </summary>
            [XurrentEnum("app_offering")]
            AppOffering,

            /// <summary>
            /// The condition field.
            /// </summary>
            [XurrentEnum("condition")]
            Condition,

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
            /// The description html field.
            /// </summary>
            [XurrentEnum("description_html")]
            DescriptionHtml,

            /// <summary>
            /// The expressions field.
            /// </summary>
            [XurrentEnum("expressions")]
            Expressions,

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
            /// The position field.
            /// </summary>
            [XurrentEnum("position")]
            Position,

            /// <summary>
            /// The rulable type field.
            /// </summary>
            [XurrentEnum("rulable_type")]
            RulableType,

            /// <summary>
            /// The trigger field.
            /// </summary>
            [XurrentEnum("trigger")]
            Trigger,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="AppOfferingAutomationRule"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters app offering automation rules by app offering.
            /// </summary>
            [XurrentEnum("app_offering")]
            AppOffering,

            /// <summary>
            /// Filters app offering automation rules by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters app offering automation rules by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters app offering automation rules by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of an <see cref="AppOfferingAutomationRule"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all app offering automation rules for configuration items.
            /// </summary>
            [XurrentEnum("for_cis")]
            ForCis,

            /// <summary>
            /// Lists all app offering automation rules for problems.
            /// </summary>
            [XurrentEnum("for_problems")]
            ForProblems,

            /// <summary>
            /// Lists all app offering automation rules for requests.
            /// </summary>
            [XurrentEnum("for_requests")]
            ForRequests,

            /// <summary>
            /// Lists all app offering automation rules for tasks.
            /// </summary>
            [XurrentEnum("for_tasks")]
            ForTasks
        }

        /// <summary>
        /// Represents the fields used to order an <see cref="AppOfferingAutomationRule"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts app offering automation rules by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts app offering automation rules by their position.
            /// </summary>
            [XurrentEnum("position")]
            Position
        }

        private string? _actions;
        private string? _actionsHtml;
        private AppOffering? _appOffering;
        private string? _condition;
        private DateTime? _createdAt;
        private string? _description;
        private string? _descriptionHtml;
        private string? _expressions;
        private string? _name;
        private int? _position;
        private RulableType? _rulableType;
        private string? _trigger;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets the actions that are executed when the condition of the app offering automation rule is met.
        /// </summary>
        [XurrentField("actions")]
        public string? Actions
        {
            get => _actions;
            set => _actions = SetValue("actions", _actions, value);
        }

        /// <summary>
        /// Gets the actions of the app offering automation rule converted to HTML.
        /// </summary>
        [XurrentField("actions_html")]
        public string? ActionsHtml
        {
            get => _actionsHtml;
            internal set => _actionsHtml = value;
        }

        /// <summary>
        /// Gets or sets the app offering that the app offering automation rule belongs to.
        /// </summary>
        [XurrentField("app_offering")]
        public AppOffering? AppOffering
        {
            get => _appOffering;
            set => _appOffering = SetValue("app_offering", _appOffering, value);
        }

        /// <summary>
        /// Gets or sets the condition that must be met for the app offering automation rule to be applied.
        /// </summary>
        [XurrentField("condition")]
        public string? Condition
        {
            get => _condition;
            set => _condition = SetValue("condition", _condition, value);
        }

        /// <summary>
        /// Gets the date and time at which the app offering automation rule was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets the description of the app offering automation rule.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        /// <summary>
        /// Gets the description of the app offering automation rule converted to HTML.
        /// </summary>
        [XurrentField("description_html")]
        public string? DescriptionHtml
        {
            get => _descriptionHtml;
            internal set => _descriptionHtml = value;
        }

        /// <summary>
        /// Gets or sets the expressions used by the app offering automation rule.
        /// </summary>
        [XurrentField("expressions")]
        public string? Expressions
        {
            get => _expressions;
            set => _expressions = SetValue("expressions", _expressions, value);
        }

        /// <summary>
        /// Gets or sets the name of the app offering automation rule.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        /// <summary>
        /// Gets or sets the execution order position of the app offering automation rule.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            set => _position = SetValue("position", _position, value);
        }

        /// <summary>
        /// Gets or sets the record type that the app offering automation rule applies to.
        /// </summary>
        [XurrentField("rulable_type")]
        public RulableType? RulableType
        {
            get => _rulableType;
            set => _rulableType = SetValue("rulable_type", _rulableType, value);
        }

        /// <summary>
        /// Gets or sets the trigger that determines when the app offering automation rule is evaluated.
        /// </summary>
        [XurrentField("trigger")]
        public string? Trigger
        {
            get => _trigger;
            set => _trigger = SetValue("trigger", _trigger, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the app offering automation rule.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new app offering automation rule instance.
        /// </summary>
        public AppOfferingAutomationRule()
        {
        }

        /// <summary>
        /// Creates a new app offering automation rule instance.
        /// </summary>
        /// <param name="id">The unique identifier of the app offering automation rule.</param>
        public AppOfferingAutomationRule(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new app offering automation rule instance.
        /// </summary>
        /// <param name="appOffering">The app offering of the app offering automation rule.</param>
        /// <param name="name">The name of the app offering automation rule.</param>
        /// <param name="rulableType">The rulable type of the app offering automation rule.</param>
        /// <param name="trigger">The trigger of the app offering automation rule.</param>
        public AppOfferingAutomationRule(AppOffering appOffering, string name, RulableType rulableType, string trigger)
        {
            _appOffering = SetValue("app_offering", appOffering);
            _name = SetValue("name", name);
            _rulableType = SetValue("rulable_type", rulableType);
            _trigger = SetValue("trigger", trigger);
        }
    }
}
