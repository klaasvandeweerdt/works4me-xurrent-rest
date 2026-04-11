using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent agile board column object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class AgileBoardColumn : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="AgileBoardColumn"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The action type field.
            /// </summary>
            [XurrentEnum("action_type")]
            ActionType,

            /// <summary>
            /// The clear member field.
            /// </summary>
            [XurrentEnum("clear_member")]
            ClearMember,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The deleted field.
            /// </summary>
            [XurrentEnum("deleted")]
            Deleted,

            /// <summary>
            /// The dialog type field.
            /// </summary>
            [XurrentEnum("dialog_type")]
            DialogType,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The member field.
            /// </summary>
            [XurrentEnum("member")]
            Member,

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
            /// The remove after field.
            /// </summary>
            [XurrentEnum("remove_after")]
            RemoveAfter,

            /// <summary>
            /// The team field.
            /// </summary>
            [XurrentEnum("team")]
            Team,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The wip limit field.
            /// </summary>
            [XurrentEnum("wip_limit")]
            WipLimit
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

        private AgileBoardColumnAction? _actionType;
        private bool? _clearMember;
        private DateTime? _createdAt;
        private bool? _deleted;
        private AgileBoardColumnDialog? _dialogType;
        private Person? _member;
        private string? _name;
        private int? _position;
        private int? _removeAfter;
        private Team? _team;
        private DateTime? _updatedAt;
        private int? _wipLimit;

        /// <summary>
        /// Gets or sets the action type performed when an item is moved into the column.
        /// </summary>
        [XurrentField("action_type")]
        public AgileBoardColumnAction? ActionType
        {
            get => _actionType;
            set => _actionType = SetValue("action_type", _actionType, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the member is cleared when an item is moved into the column.
        /// </summary>
        [XurrentField("clear_member")]
        public bool? ClearMember
        {
            get => _clearMember;
            set => _clearMember = SetValue("clear_member", _clearMember, value);
        }

        /// <summary>
        /// Gets the date and time at which the agile board column was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the column is marked as deleted.
        /// </summary>
        [XurrentField("deleted")]
        public bool? Deleted
        {
            get => _deleted;
            set => _deleted = SetValue("deleted", _deleted, value);
        }

        /// <summary>
        /// Gets or sets the dialog type shown when an item is moved into the column.
        /// </summary>
        [XurrentField("dialog_type")]
        public AgileBoardColumnDialog? DialogType
        {
            get => _dialogType;
            set => _dialogType = SetValue("dialog_type", _dialogType, value);
        }

        /// <summary>
        /// Gets or sets the member assigned when an item is moved into the column.
        /// </summary>
        [XurrentField("member")]
        public Person? Member
        {
            get => _member;
            set => _member = SetValue("member", _member, value);
        }

        /// <summary>
        /// Gets the name of the agile board column.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            internal set => _name = value;
        }

        /// <summary>
        /// Gets or sets the position of the column relative to other columns of the agile board.
        /// </summary>
        [XurrentField("position")]
        public int? Position
        {
            get => _position;
            set => _position = SetValue("position", _position, value);
        }

        /// <summary>
        /// Gets or sets the number of days after which items are removed from the column.
        /// </summary>
        [XurrentField("remove_after")]
        public int? RemoveAfter
        {
            get => _removeAfter;
            set => _removeAfter = SetValue("remove_after", _removeAfter, value);
        }

        /// <summary>
        /// Gets or sets the team to which an item is assigned when it is moved into the column.
        /// </summary>
        [XurrentField("team")]
        public Team? Team
        {
            get => _team;
            set => _team = SetValue("team", _team, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the agile board column.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets or sets the work in progress limit for the column.
        /// </summary>
        [XurrentField("wip_limit")]
        public int? WipLimit
        {
            get => _wipLimit;
            set => _wipLimit = SetValue("wip_limit", _wipLimit, value);
        }

        /// <summary>
        /// Creates a new agile board column instance.
        /// </summary>
        public AgileBoardColumn()
        {
        }

        /// <summary>
        /// Creates a new agile board column instance.
        /// </summary>
        /// <param name="id">The unique identifier of the agile board column.</param>
        public AgileBoardColumn(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new agile board column instance.
        /// </summary>
        /// <param name="actionType">The action type of the agile board column.</param>
        /// <param name="dialogType">The dialog type of the agile board column.</param>
        public AgileBoardColumn(AgileBoardColumnAction actionType, AgileBoardColumnDialog dialogType)
        {
            _actionType = SetValue("action_type", actionType);
            _dialogType = SetValue("dialog_type", dialogType);
        }
    }
}
