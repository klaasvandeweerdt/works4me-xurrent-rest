using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent archived object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class ArchiveItem : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="ArchiveItem"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The archived field.
            /// </summary>
            [XurrentEnum("archived")]
            Archived,

            /// <summary>
            /// The archived by field.
            /// </summary>
            [XurrentEnum("archived_by")]
            ArchivedBy,

            /// <summary>
            /// The configuration item field.
            /// </summary>
            [XurrentEnum("ci", IgnoreInFieldSelection = true)]
            ConfigurationItem,

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
            /// The person field.
            /// </summary>
            [XurrentEnum("person", IgnoreInFieldSelection = true)]
            Person,

            /// <summary>
            /// The problem field.
            /// </summary>
            [XurrentEnum("problem", IgnoreInFieldSelection = true)]
            Problem,

            /// <summary>
            /// The project field.
            /// </summary>
            [XurrentEnum("project", IgnoreInFieldSelection = true)]
            Project,

            /// <summary>
            /// The project task field.
            /// </summary>
            [XurrentEnum("project_task", IgnoreInFieldSelection = true)]
            ProjectTask,

            /// <summary>
            /// The release field.
            /// </summary>
            [XurrentEnum("release", IgnoreInFieldSelection = true)]
            Release,

            /// <summary>
            /// The request field.
            /// </summary>
            [XurrentEnum("request", IgnoreInFieldSelection = true)]
            Request,

            /// <summary>
            /// The reservation field.
            /// </summary>
            [XurrentEnum("reservation", IgnoreInFieldSelection = true)]
            Reservation,

            /// <summary>
            /// The risk field.
            /// </summary>
            [XurrentEnum("risk", IgnoreInFieldSelection = true)]
            Risk,

            /// <summary>
            /// The shop order line field.
            /// </summary>
            [XurrentEnum("shop_order_line", IgnoreInFieldSelection = true)]
            ShopOrderLine,

            /// <summary>
            /// The time entry field.
            /// </summary>
            [XurrentEnum("time_entry", IgnoreInFieldSelection = true)]
            TimeEntry,

            /// <summary>
            /// The workflow field.
            /// </summary>
            [XurrentEnum("workflow", IgnoreInFieldSelection = true)]
            Workflow,

            /// <summary>
            /// The workflow task field.
            /// </summary>
            [XurrentEnum("task", IgnoreInFieldSelection = true)]
            WorkflowTask
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="ArchiveItem"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters archive items by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters archive items by unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id
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
        /// Represents the fields used to order an <see cref="ArchiveItem"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts archive items by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts archive items by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id
        }

        private string? _archived;
        private Person? _archivedBy;
        private ResourceReference? _configurationItem;
        private DateTime? _createdAt;
        private ResourceReference? _person;
        private ResourceReference? _problem;
        private ResourceReference? _project;
        private ResourceReference? _projectTask;
        private ResourceReference? _release;
        private ResourceReference? _request;
        private Reservation? _reservation;
        private ResourceReference? _risk;
        private ShopOrderLine? _shopOrderLine;
        private ResourceReference? _timeEntry;
        private ResourceReference? _workflow;
        private ResourceReference? _workflowTask;

        /// <summary>
        /// Gets the archive status of the item.
        /// </summary>
        [XurrentField("archived")]
        public string? Archived
        {
            get => _archived;
            internal set => _archived = value;
        }

        /// <summary>
        /// Gets the person who archived the item.
        /// </summary>
        [XurrentField("archived_by")]
        public Person? ArchivedBy
        {
            get => _archivedBy;
            internal set => _archivedBy = value;
        }

        /// <summary>
        /// Gets the archived configuration item reference.
        /// </summary>
        [XurrentField("ci")]
        public ResourceReference? ConfigurationItem
        {
            get => _configurationItem;
            internal set => _configurationItem = value;
        }

        /// <summary>
        /// Gets the date and time at which the item was archived.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the archived person reference.
        /// </summary>
        [XurrentField("person")]
        public ResourceReference? Person
        {
            get => _person;
            internal set => _person = value;
        }

        /// <summary>
        /// Gets the archived problem reference.
        /// </summary>
        [XurrentField("problem")]
        public ResourceReference? Problem
        {
            get => _problem;
            internal set => _problem = value;
        }

        /// <summary>
        /// Gets the archived project reference.
        /// </summary>
        [XurrentField("project")]
        public ResourceReference? Project
        {
            get => _project;
            internal set => _project = value;
        }

        /// <summary>
        /// Gets the archived project task reference.
        /// </summary>
        [XurrentField("project_task")]
        public ResourceReference? ProjectTask
        {
            get => _projectTask;
            set => _projectTask = SetValue("project_task", _projectTask, value);
        }

        /// <summary>
        /// Gets the archived release reference.
        /// </summary>
        [XurrentField("release")]
        public ResourceReference? Release
        {
            get => _release;
            internal set => _release = value;
        }

        /// <summary>
        /// Gets the archived request reference.
        /// </summary>
        [XurrentField("request")]
        public ResourceReference? Request
        {
            get => _request;
            internal set => _request = value;
        }

        /// <summary>
        /// Gets the archived reservation reference.
        /// </summary>
        [XurrentField("reservation")]
        public Reservation? Reservation
        {
            get => _reservation;
            internal set => _reservation = value;
        }

        /// <summary>
        /// Gets the archived risk reference.
        /// </summary>
        [XurrentField("risk")]
        public ResourceReference? Risk
        {
            get => _risk;
            internal set => _risk = value;
        }

        /// <summary>
        /// Gets the archived shop order line reference.
        /// </summary>
        [XurrentField("shop_order_line")]
        public ShopOrderLine? ShopOrderLine
        {
            get => _shopOrderLine;
            internal set => _shopOrderLine = value;
        }

        /// <summary>
        /// Gets the archived time entry reference.
        /// </summary>
        [XurrentField("time_entry")]
        public ResourceReference? TimeEntry
        {
            get => _timeEntry;
            internal set => _timeEntry = value;
        }

        /// <summary>
        /// Gets the archived workflow reference.
        /// </summary>
        [XurrentField("workflow")]
        public ResourceReference? Workflow
        {
            get => _workflow;
            internal set => _workflow = value;
        }

        /// <summary>
        /// Gets the archived workflow task reference.
        /// </summary>
        [XurrentField("task")]
        public ResourceReference? WorkflowTask
        {
            get => _workflowTask;
            internal set => _workflowTask = value;
        }

        /// <summary>
        /// Creates a new archive item instance.
        /// </summary>
        public ArchiveItem()
        {
        }

        /// <summary>
        /// Creates a new archive item instance.
        /// </summary>
        /// <param name="id">The unique identifier of the archive item.</param>
        public ArchiveItem(long id)
        {
            Id = id;
        }
    }
}
