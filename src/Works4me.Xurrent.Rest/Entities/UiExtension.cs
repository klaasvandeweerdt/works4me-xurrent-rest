using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent UI extension object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class UiExtension : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of an <see cref="UiExtension"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The activate field.
            /// </summary>
            [XurrentEnum("activate")]
            Activate,

            /// <summary>
            /// The active version field.
            /// </summary>
            [XurrentEnum("active_version")]
            ActiveVersion,

            /// <summary>
            /// The category field.
            /// </summary>
            [XurrentEnum("category")]
            Category,

            /// <summary>
            /// The compiled css field.
            /// </summary>
            [XurrentEnum("compiled_css")]
            CompiledCss,

            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The created by field.
            /// </summary>
            [XurrentEnum("created_by")]
            CreatedBy,

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
            /// The description field.
            /// </summary>
            [XurrentEnum("description")]
            Description,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The form definition json field.
            /// </summary>
            [XurrentEnum("form_definition_json")]
            FormDefinitionJson,

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
            [XurrentEnum("localized_html")]
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
            /// The prepared version field.
            /// </summary>
            [XurrentEnum("prepared_version")]
            PreparedVersion,

            /// <summary>
            /// The show on complete field.
            /// </summary>
            [XurrentEnum("show_on_complete")]
            ShowOnComplete,

            /// <summary>
            /// The source field.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// The source identifier field.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// The title field.
            /// </summary>
            [XurrentEnum("title")]
            Title,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of an <see cref="UiExtension"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters UI extensions by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters UI extensions by whether they are disabled.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters UI extensions by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters UI extensions by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters UI extensions by their external source identifier.
            /// </summary>
            [XurrentEnum("source")]
            Source,

            /// <summary>
            /// Filters UI extensions by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Filters UI extensions by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
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
        /// Represents the fields used to order an <see cref="UiExtension"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts UI extensions by the date and time at which they were created.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts UI extensions by their unique identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Sorts UI extensions by their name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Sorts UI extensions by their identifier in the external source.
            /// </summary>
            [XurrentEnum("sourceID")]
            SourceID,

            /// <summary>
            /// Sorts UI extensions by the date and time of their last update.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private bool? _activate;
        private UiExtensionVersion? _activeVersion;
        private UiExtensionCategory? _category;
        private string? _compiledCss;
        private DateTime? _createdAt;
        private Person? _createdBy;
        private string? _css;
        private bool? _darkModeSafe;
        private string? _description;
        private bool? _disabled;
        private string? _formDefinitionJson;
        private bool? _hideNote;
        private string? _html;
        private string? _javascript;
        private string? _localizedHtml;
        private string? _name;
        private List<string>? _phrases;
        private UiExtensionVersion? _preparedVersion;
        private bool? _showOnComplete;
        private string? _source;
        private string? _sourceID;
        private string? _title;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets or sets a value indicating whether the prepared version is promoted to the active version.<br />
        /// If an active version exists, it is archived.
        /// </summary>
        [XurrentField("activate")]
        public bool? Activate
        {
            get => _activate;
            set => _activate = SetValue("activate", _activate, value);
        }

        /// <summary>
        /// Gets the version of the UI extension with status active.
        /// </summary>
        [XurrentField("active_version")]
        public UiExtensionVersion? ActiveVersion
        {
            get => _activeVersion;
            internal set => _activeVersion = value;
        }

        /// <summary>
        /// Gets or sets the category that defines the type of record to which the UI extension applies.
        /// </summary>
        [XurrentField("category")]
        public UiExtensionCategory? Category
        {
            get => _category;
            set => _category = SetValue("category", _category, value);
        }

        /// <summary>
        /// Gets the compiled CSS stylesheet of the active version, if available.
        /// </summary>
        [XurrentField("compiled_css")]
        public string? CompiledCss
        {
            get => _compiledCss;
            internal set => _compiledCss = value;
        }

        /// <summary>
        /// Gets the date and time at which the UI extension was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets the person who created the UI extension.
        /// </summary>
        [XurrentField("created_by")]
        public Person? CreatedBy
        {
            get => _createdBy;
            internal set => _createdBy = value;
        }

        /// <summary>
        /// Gets or sets the CSS stylesheet.<br />
        /// On retrieval, this returns the CSS of the active version.<br />
        /// On update, this sets the CSS of the prepared version.
        /// </summary>
        [XurrentField("css")]
        public string? Css
        {
            get => _css;
            set => _css = SetValue("css", _css, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the UI extension supports dark mode.<br />
        /// If <see langword="false"/>, the UI extension is always displayed in light mode.
        /// </summary>
        [XurrentField("dark_mode_safe")]
        public bool? DarkModeSafe
        {
            get => _darkModeSafe;
            set => _darkModeSafe = SetValue("dark_mode_safe", _darkModeSafe, value);
        }

        /// <summary>
        /// Gets or sets the description of the UI extension.
        /// </summary>
        [XurrentField("description")]
        public string? Description
        {
            get => _description;
            set => _description = SetValue("description", _description, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the UI extension is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the form definition of the UI extension as an escaped JSON string.
        /// </summary>
        [XurrentField("form_definition_json")]
        public string? FormDefinitionJson
        {
            get => _formDefinitionJson;
            set => _formDefinitionJson = SetValue("form_definition_json", _formDefinitionJson, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the note is hidden when using the UI extension.
        /// </summary>
        [XurrentField("hide_note")]
        public bool? HideNote
        {
            get => _hideNote;
            set => _hideNote = SetValue("hide_note", _hideNote, value);
        }

        /// <summary>
        /// Gets or sets the HTML code.<br />
        /// On retrieval, this returns the HTML of the active version.<br />
        /// On update, this sets the HTML of the prepared version.
        /// </summary>
        [XurrentField("html")]
        public string? Html
        {
            get => _html;
            set => _html = SetValue("html", _html, value);
        }

        /// <summary>
        /// Gets or sets the JavaScript code.<br />
        /// On retrieval, this returns the JavaScript of the active version.<br />
        /// On update, this sets the JavaScript of the prepared version.
        /// </summary>
        [XurrentField("javascript")]
        public string? Javascript
        {
            get => _javascript;
            set => _javascript = SetValue("javascript", _javascript, value);
        }

        /// <summary>
        /// Gets the HTML code of the active version with all phrases translated in the current user's locale, if available.
        /// </summary>
        [XurrentField("localized_html")]
        public string? LocalizedHtml
        {
            get => _localizedHtml;
            internal set => _localizedHtml = value;
        }

        /// <summary>
        /// Gets or sets the name of the UI extension.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            set => _name = SetValue("name", _name, value);
        }

        [XurrentField("phrases")]
        internal List<string>? PhrasesCollection
        {
            get => _phrases;
            set => _phrases = value;
        }

        /// <summary>
        /// Gets the translatable phrases used in the active version of the UI extension.
        /// </summary>
        public ReadOnlyCollection<string>? Phrases
        {
            get => _phrases is null ? null : new ReadOnlyCollection<string>(_phrases);
        }

        /// <summary>
        /// Gets the version of the UI extension that is currently being prepared.
        /// </summary>
        [XurrentField("prepared_version")]
        public UiExtensionVersion? PreparedVersion
        {
            get => _preparedVersion;
            internal set => _preparedVersion = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the UI extension is displayed when an assignment is completed.
        /// </summary>
        [XurrentField("show_on_complete")]
        public bool? ShowOnComplete
        {
            get => _showOnComplete;
            set => _showOnComplete = SetValue("show_on_complete", _showOnComplete, value);
        }

        /// <summary>
        /// Gets or sets the external source identifier for the UI extension.
        /// </summary>
        [XurrentField("source")]
        public string? Source
        {
            get => _source;
            set => _source = SetValue("source", _source, value);
        }

        /// <summary>
        /// Gets or sets the identifier of the UI extension in the external source.
        /// </summary>
        [XurrentField("sourceID")]
        public string? SourceID
        {
            get => _sourceID;
            set => _sourceID = SetValue("sourceID", _sourceID, value);
        }

        /// <summary>
        /// Gets or sets the title displayed as the section header above the UI extension when presented within a form.
        /// </summary>
        [XurrentField("title")]
        public string? Title
        {
            get => _title;
            set => _title = SetValue("title", _title, value);
        }

        /// <summary>
        /// Gets the date and time of the last update of the UI extension.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new user interface extension instance.
        /// </summary>
        public UiExtension()
        {
        }

        /// <summary>
        /// Creates a new user interface extension instance.
        /// </summary>
        /// <param name="id">The unique identifier of the user interface extension.</param>
        public UiExtension(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new user interface extension instance.
        /// </summary>
        /// <param name="category">The category of the user interface extension.</param>
        /// <param name="name">The name of the user interface extension.</param>
        public UiExtension(UiExtensionCategory category, string name)
        {
            _category = SetValue("category", category);
            _name = SetValue("name", name);
        }
    }
}
