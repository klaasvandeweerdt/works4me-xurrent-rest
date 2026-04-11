namespace Works4me.Xurrent.Rest
{
    partial class XurrentClient
    {
        /// <summary>
        /// Gets the client for bulk operations.
        /// </summary>
        public XurrentBulkClient Bulk
        {
            get => GetInternalClient<XurrentBulkClient>();
        }

        /// <summary>
        /// Gets the client to access the details of the currently authenticated person.
        /// </summary>
        /// <remarks>
        /// See the <see href="https://developer.xurrent.com/v1/people/me/">Xurrent developer documentation</see> for details.
        /// </remarks>
        public MeClient Me
        {
            get => GetInternalClient<MeClient>();
        }
    }
}
