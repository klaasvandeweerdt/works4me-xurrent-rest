using System;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Timesheet"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/timesheets/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed partial class TimesheetClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimesheetClient"/> class.
        /// </summary>
        internal TimesheetClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "timesheets/"))
        {
        }
    }
}
