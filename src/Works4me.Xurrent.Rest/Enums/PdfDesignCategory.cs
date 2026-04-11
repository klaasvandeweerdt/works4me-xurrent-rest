using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various PDF design categories.
    /// </summary>
    public enum PdfDesignCategory
    {
        /// <summary>
        /// Indicates that the PDF design is intended for workflow summaries.
        /// </summary>
        [XurrentEnum("workflow_summary")]
        WorkflowSummary,

        /// <summary>
        /// Indicates that the PDF design is intended for project summaries.
        /// </summary>
        [XurrentEnum("project_summary")]
        ProjectSummary,

        /// <summary>
        /// Indicates that the PDF design is intended for dashboards.
        /// </summary>
        [XurrentEnum("dashboard")]
        Dashboard
    }
}
