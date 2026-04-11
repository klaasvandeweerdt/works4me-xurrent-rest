using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the results of an import operation.
    /// </summary>
    public sealed class ImportResults
    {
        /// <summary>
        /// Gets or sets the number of created items.
        /// </summary>
        [XurrentField("created")]
        public int Created { get; set; }

        /// <summary>
        /// Gets or sets the number of updated items.
        /// </summary>
        [XurrentField("updated")]
        public int Updated { get; set; }

        /// <summary>
        /// Gets or sets the number of deleted items.
        /// </summary>
        [XurrentField("deleted")]
        public int Deleted { get; set; }

        /// <summary>
        /// Gets or sets the number of unchanged items.
        /// </summary>
        [XurrentField("unchanged")]
        public int Unchanged { get; set; }

        /// <summary>
        /// Gets or sets the number of failures.
        /// </summary>
        [XurrentField("failures")]
        public int Failures { get; set; }

        /// <summary>
        /// Gets or sets the number of errors.
        /// </summary>
        [XurrentField("errors")]
        public int Errors { get; set; }
    }
}
