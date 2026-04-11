using System;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent request feedback entry object.
    /// </summary>
    public sealed class RequestFeedbackEntry : ObservableItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="RequestFeedbackEntry"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The dissatisfied url field.
            /// </summary>
            [XurrentEnum("dissatisfied_url")]
            DissatisfiedUrl,

            /// <summary>
            /// The satisfied url field.
            /// </summary>
            [XurrentEnum("satisfied_url")]
            SatisfiedUrl
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

        private Uri? _dissatisfiedUrl;
        private Uri? _satisfiedUrl;

        /// <summary>
        /// Gets the URL used to provide dissatisfied feedback.
        /// </summary>
        [XurrentField("dissatisfied_url")]
        public Uri? DissatisfiedUrl
        {
            get => _dissatisfiedUrl;
            internal set => _dissatisfiedUrl = value;
        }

        /// <summary>
        /// Gets the URL used to provide satisfied feedback.
        /// </summary>
        [XurrentField("satisfied_url")]
        public Uri? SatisfiedUrl
        {
            get => _satisfiedUrl;
            internal set => _satisfiedUrl = value;
        }
    }
}
