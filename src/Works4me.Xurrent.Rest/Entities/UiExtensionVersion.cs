using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent UI extension version object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class UiExtensionVersion : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="UiExtensionVersion"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The activated at field.
            /// </summary>
            [XurrentEnum("activated_at")]
            ActivatedAt,

            /// <summary>
            /// The archived at field.
            /// </summary>
            [XurrentEnum("archived_at")]
            ArchivedAt,

            /// <summary>
            /// The compiled css field.
            /// </summary>
            [XurrentEnum("compiled_css", IgnoreInFieldSelection = true)]
            CompiledCss,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The css field.
            /// </summary>
            [XurrentEnum("css")]
            Css,

            /// <summary>
            /// The dark mode safe field.
            /// </summary>
            [XurrentEnum("dark_mode_safe")]
            DarkModeSafe,

            /// <summary>
            /// The form definition field.
            /// </summary>
            [XurrentEnum("form_definition", IgnoreInFieldSelection = true)]
            FormDefinition,

            /// <summary>
            /// The form definition react field.
            /// </summary>
            [XurrentEnum("form_definition_react")]
            FormDefinitionReact,

            /// <summary>
            /// The hide note field.
            /// </summary>
            [XurrentEnum("hide_note")]
            HideNote,

            /// <summary>
            /// The html field.
            /// </summary>
            [XurrentEnum("html")]
            Html,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The javascript field.
            /// </summary>
            [XurrentEnum("javascript")]
            Javascript,

            /// <summary>
            /// The localized html field.
            /// </summary>
            [XurrentEnum("localized_html", IgnoreInFieldSelection = true)]
            LocalizedHtml,

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
            /// The phrases field.
            /// </summary>
            [XurrentEnum("phrases")]
            Phrases,

            /// <summary>
            /// The status field.
            /// </summary>
            [XurrentEnum("status")]
            Status,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt,

            /// <summary>
            /// The use designer field.
            /// </summary>
            [XurrentEnum("use_designer")]
            UseDesigner,

            /// <summary>
            /// The version nr field.
            /// </summary>
            [XurrentEnum("version_nr")]
            VersionNr,

            /// <summary>
            /// The view audit path field.
            /// </summary>
            [XurrentEnum("view_audit_path", IgnoreInFieldSelection = true)]
            ViewAuditPath
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

        private DateTime? _activatedAt;
        private DateTime? _archivedAt;
        private string? _compiledCss;
        private DateTime? _createdAt;
        private string? _css;
        private bool? _darkModeSafe;
        private JsonElement? _formDefinition;
        private JsonElement? _formDefinitionReact;
        private bool? _hideNote;
        private string? _html;
        private string? _javascript;
        private string? _localizedHtml;
        private string? _name;
        private List<string>? _phrases;
        private UiExtensionVersionStatus? _status;
        private DateTime? _updatedAt;
        private bool? _useDesigner;
        private int? _versionNr;
        private Uri? _viewAuditPath;

        /// <summary>
        /// Gets the date and time at which this version of the UI extension was activated.
        /// </summary>
        [XurrentField("activated_at")]
        public DateTime? ActivatedAt
        {
            get => _activatedAt;
            internal set => _activatedAt = value;
        }

        /// <summary>
        /// Gets the date and time at which this version of the UI extension was archived.
        /// </summary>
        [XurrentField("archived_at")]
        public DateTime? ArchivedAt
        {
            get => _archivedAt;
            internal set => _archivedAt = value;
        }

        /// <summary>
        /// Gets the compiled CSS stylesheet.<br />
        /// This property is available only when a single version is retrieved.
        /// </summary>
        [XurrentField("compiled_css")]
        public string? CompiledCss
        {
            get => _compiledCss;
            internal set => _compiledCss = value;
        }

        /// <summary>
        /// Gets the date and time at which this version of the UI extension was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the CSS stylesheet.
        /// </summary>
        [XurrentField("css")]
        public string? Css
        {
            get => _css;
            internal set => _css = value;
        }

        /// <summary>
        /// Gets a value indicating whether the UI extension supports dark mode.<br />
        /// If <see langword="false"/>, the UI extension is always displayed in light mode.
        /// </summary>
        [XurrentField("dark_mode_safe")]
        public bool? DarkModeSafe
        {
            get => _darkModeSafe;
            internal set => _darkModeSafe = value;
        }

        /// <summary>
        /// Gets the form definition used by the UI extension designer.<br />
        /// This property is available only when a single version is retrieved.
        /// </summary>
        [XurrentField("form_definition")]
        public JsonElement? FormDefinition
        {
            get => _formDefinition;
            internal set => _formDefinition = value;
        }

        /// <summary>
        /// Gets the react form definition used by the UI extension designer.<br />
        /// This property is available only when a single version is retrieved.
        /// </summary>
        [XurrentField("form_definition_react")]
        public JsonElement? FormDefinitionReact
        {
            get => _formDefinitionReact;
            internal set => _formDefinitionReact = value;
        }

        /// <summary>
        /// Gets a value indicating whether the note is hidden when using the UI extension.
        /// </summary>
        [XurrentField("hide_note")]
        public bool? HideNote
        {
            get => _hideNote;
            internal set => _hideNote = value;
        }

        /// <summary>
        /// Gets the HTML code.
        /// </summary>
        [XurrentField("html")]
        public string? Html
        {
            get => _html;
            internal set => _html = value;
        }

        /// <summary>
        /// Gets the JavaScript code.
        /// </summary>
        [XurrentField("javascript")]
        public string? Javascript
        {
            get => _javascript;
            internal set => _javascript = value;
        }

        /// <summary>
        /// Gets the HTML code with all phrases translated in the current user's locale.<br />
        /// This property is available only when a single version is retrieved.
        /// </summary>
        [XurrentField("localized_html")]
        public string? LocalizedHtml
        {
            get => _localizedHtml;
            internal set => _localizedHtml = value;
        }

        /// <summary>
        /// Gets the name of the UI extension at the time this version was created.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            internal set => _name = value;
        }

        [XurrentField("phrases")]
        internal List<string>? PhrasesCollection
        {
            get => _phrases;
            set => _phrases = value;
        }

        /// <summary>
        /// Gets the translatable phrases found in the HTML code.
        /// </summary>
        public ReadOnlyCollection<string>? Phrases
        {
            get => _phrases is null ? null : new ReadOnlyCollection<string>(_phrases);
        }

        /// <summary>
        /// Gets the life-cycle status of this UI extension version.
        /// </summary>
        [XurrentField("status")]
        public UiExtensionVersionStatus? Status
        {
            get => _status;
            internal set => _status = value;
        }

        /// <summary>
        /// Gets the date and time of the last update of this UI extension version.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Gets a value indicating whether the UI extension uses the UI extension designer.
        /// </summary>
        [XurrentField("use_designer")]
        public bool? UseDesigner
        {
            get => _useDesigner;
            internal set => _useDesigner = value;
        }

        /// <summary>
        /// Gets the version number of this UI extension version.
        /// </summary>
        [XurrentField("version_nr")]
        public int? VersionNr
        {
            get => _versionNr;
            internal set => _versionNr = value;
        }

        /// <summary>
        /// Gets the URI to the audit lines of this UI extension version.<br />
        /// This property is available only when a single version is retrieved.
        /// </summary>
        [XurrentField("view_audit_path")]
        public Uri? ViewAuditPath
        {
            get => _viewAuditPath;
            internal set => _viewAuditPath = value;
        }

        /// <summary>
        /// Creates a new user interface extension version instance.
        /// </summary>
        public UiExtensionVersion()
        {
        }

        /// <summary>
        /// Creates a new user interface extension version instance.
        /// </summary>
        /// <param name="id">The unique identifier of the user interface extension version.</param>
        public UiExtensionVersion(long id)
        {
            Id = id;
        }
    }
}
