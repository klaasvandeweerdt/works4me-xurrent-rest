namespace Works4me.Xurrent.Rest.Interfaces
{
    /// <summary>
    /// Provides access to lazily created and cached Xurrent client instances.
    /// </summary>
    /// <remarks>
    /// Implementations are responsible for managing the lifetime and thread-safe creation of client instances scoped to a single root client context.
    /// </remarks>
    internal interface IXurrentClientProvider
    {
        /// <summary>
        /// Gets a cached instance of the specified client type, creating it if necessary.
        /// </summary>
        /// <typeparam name="TClient">The client type to retrieve.</typeparam>
        /// <returns>A singleton instance of <typeparamref name="TClient"/> associated with the current client context.</returns>
        TClient GetClient<TClient>() where TClient : class;
    }
}
