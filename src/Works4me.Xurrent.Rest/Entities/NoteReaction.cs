using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent note reaction object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class NoteReaction : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="NoteReaction"/> object.
        /// </summary>
        public enum Field
        {
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
            /// The note field.
            /// </summary>
            [XurrentEnum("note", IgnoreInFieldSelection = true)]
            Note,

            /// <summary>
            /// The person field.
            /// </summary>
            [XurrentEnum("person")]
            Person,

            /// <summary>
            /// The reaction field.
            /// </summary>
            [XurrentEnum("reaction")]
            Reaction
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

        private Note? _note;
        private Person? _person;
        private NoteReactionEmoji? _reaction;

        /// <summary>
        /// Sets the note reference.<br />
        /// This property is write-only.
        /// </summary>
        [XurrentField("note")]
        internal Note? Note
        {
            get => _note;
            set => _note = SetValue("note", _note, value);
        }

        /// <summary>
        /// Gets the person reference.
        /// </summary>
        [XurrentField("person")]
        public Person? Person
        {
            get => _person;
            internal set => _person = value;
        }

        /// <summary>
        /// Gets or sets the reaction type.
        /// </summary>
        [XurrentField("reaction")]
        public NoteReactionEmoji? Reaction
        {
            get => _reaction;
            set => _reaction = SetValue("reaction", _reaction, value);
        }

        /// <summary>
        /// Creates a new note reaction instance.
        /// </summary>
        public NoteReaction()
        {
        }

        /// <summary>
        /// Creates a new note reaction instance.
        /// </summary>
        /// <param name="id">The unique identifier of the note reaction.</param>
        public NoteReaction(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new note reaction instance.
        /// </summary>
        /// <param name="reaction">The reaction of the note reaction.</param>
        public NoteReaction(NoteReactionEmoji reaction)
        {
            _reaction = SetValue("reaction", reaction);
        }
    }
}
