using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// The Xurrent export line separators.
    /// </summary>
    public enum ExportLineSeparator
    {
        /// <summary>
        /// Line Feed (ASCII 10, \n)
        /// </summary>
        [XurrentEnum("lf")]
        LineFeed,

        /// <summary>
        /// Carriage Return (ASCII 13, \r) Line Feed (ASCII 10, \n)
        /// </summary>
        [XurrentEnum("crlf")]
        CarriageReturnLineFeed
    }
}
