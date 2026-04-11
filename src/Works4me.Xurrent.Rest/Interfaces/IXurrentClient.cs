namespace Works4me.Xurrent.Rest
{
    internal interface IXurrentClient
    {
        /// <summary>
        /// Gets or sets the current account identifier.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of consecutive requests the SDK will make to retrieve additional items for a single query.
        /// </summary>
        /// <remarks>
        /// This setting controls how many follow-up requests the SDK is allowed to perform automatically when fetching large result sets that exceed the per-request item limit.<br />
        /// The default value is 1000, which ensures complete data retrieval for most scenarios.<br />
        /// However, when working with very large datasets, it is recommended to lower this value to reduce the risk of exceeding API rate limits when using a single token.<br />
        /// </remarks>
        /// <value>The default value is 1000. Must be between 1 and 1000, inclusive.</value>
        /// <exception cref="XurrentQueryException">Thrown if the value is less than 1 or greater than 1000.</exception>
        int MaximumRequestsPerQuery { get; set; }

        /// <summary>
        /// Gets or sets the default number of items to return per request.
        /// </summary>
        /// <value>The default value is 100. Must be between 1 and 100, inclusive.</value>
        /// <exception cref="XurrentQueryException">Thrown if the value is less than 1 or greater than 100.</exception>
        int DefaultItemsPerRequest { get; set; }
    }
}
