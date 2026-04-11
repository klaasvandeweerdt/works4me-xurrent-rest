using System;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="AttachmentStorage"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/general/data_types/#attachments/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed partial class AttachmentStorageClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentStorageClient"/> class.
        /// </summary>
        internal AttachmentStorageClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "attachments/storage/"))
        {
        }
    }
}
