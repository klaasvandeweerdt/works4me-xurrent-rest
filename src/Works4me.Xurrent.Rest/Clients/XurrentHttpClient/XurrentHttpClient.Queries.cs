using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Builders;
using Works4me.Xurrent.Rest.Extensions;

namespace Works4me.Xurrent.Rest
{
    partial class XurrentHttpClient
    {
        /// <summary>
        /// Executes a query and returns the first matching entity, if any.
        /// </summary>
        /// <typeparam name="TEntity">The entity type returned by the query.</typeparam>
        /// <param name="query">The query definition.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The first matching entity or <see langword="null"/>.</returns>
        internal async Task<TEntity?> GetItemAsync<TEntity>(IQuery query, CancellationToken ct)
            where TEntity : ObservableItem
        {
            ReadOnlyKeyedDataCollection<TEntity> result = await GetListAsync<TEntity>(query, ct).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Executes a scoped query and returns the first matching entity, if any.
        /// </summary>
        /// <typeparam name="TEntity">The entity type returned by the query.</typeparam>
        /// <param name="id">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="query">The query definition.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The first matching entity or <see langword="null"/>.</returns>
        internal async Task<TEntity?> GetItemAsync<TEntity>(long id, string parentPath, IQuery query, CancellationToken ct)
            where TEntity : ObservableItem
        {
            ReadOnlyKeyedDataCollection<TEntity> result = await GetListAsync<TEntity>(id, parentPath, query, ct).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Executes a query and returns all matching entities as a read-only collection.
        /// </summary>
        /// <typeparam name="TEntity">The entity type returned by the query.</typeparam>
        /// <param name="query">The query definition.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>A read-only collection containing all matching entities.</returns>
        internal async Task<ReadOnlyKeyedDataCollection<TEntity>> GetListAsync<TEntity>(IQuery query, CancellationToken ct)
            where TEntity : ObservableItem
        {
            Uri uri = QueryBuilder.BuildQuery<TEntity>(EndpointUrl, query, DefaultItemsPerRequest);
            return await GetAsync<TEntity>(uri, null, AccountId, MaximumRequestsPerQuery, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes a query and returns all matching entities as a read-only collection.
        /// </summary>
        /// <typeparam name="TEntity">The entity type returned by the query.</typeparam>
        /// <param name="query">The query definition.</param>
        /// <param name="pathSegmentToAppend">The path segment appended to the request URL.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>A read-only collection containing all matching entities.</returns>
        internal async Task<ReadOnlyKeyedDataCollection<TEntity>> GetListAsync<TEntity>(IQuery query, string pathSegmentToAppend, CancellationToken ct)
            where TEntity : ObservableItem
        {
            Uri uri = QueryBuilder.BuildQuery<TEntity>(EndpointUrl, pathSegmentToAppend, query, DefaultItemsPerRequest);
            return await GetAsync<TEntity>(uri, null, AccountId, MaximumRequestsPerQuery, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes a scoped query and returns all matching entities as a read-only collection.
        /// </summary>
        /// <typeparam name="TEntity">The entity type returned by the query.</typeparam>
        /// <param name="id">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="query">The query definition.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>A read-only collection containing all matching entities.</returns>
        internal async Task<ReadOnlyKeyedDataCollection<TEntity>> GetListAsync<TEntity>(long id, string parentPath, IQuery query, CancellationToken ct)
            where TEntity : ObservableItem
        {
            Uri uri = QueryBuilder.BuildQuery<TEntity>(EndpointUrl, id, parentPath, query, DefaultItemsPerRequest);
            return await GetAsync<TEntity>(uri, null, AccountId, MaximumRequestsPerQuery, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Streams query results asynchronously across paginated responses.
        /// </summary>
        /// <typeparam name="TEntity">The entity type returned by the query.</typeparam>
        /// <param name="query">The query definition.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An async stream of entities.</returns>
        internal IAsyncEnumerable<TEntity> StreamListAsync<TEntity>(IQuery query, CancellationToken ct)
            where TEntity : ObservableItem
        {
            Uri uri = QueryBuilder.BuildQuery<TEntity>(EndpointUrl, query, DefaultItemsPerRequest);
            return StreamListAsync<TEntity>(uri, null, AccountId, MaximumRequestsPerQuery, ct);
        }

        /// <summary>
        /// Streams scoped query results asynchronously across paginated responses.
        /// </summary>
        /// <typeparam name="TEntity">The entity type returned by the query.</typeparam>
        /// <param name="id">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="query">The query definition.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An async stream of entities.</returns>
        internal IAsyncEnumerable<TEntity> StreamListAsync<TEntity>(long id, string parentPath, IQuery query, CancellationToken ct)
            where TEntity : ObservableItem
        {
            Uri uri = QueryBuilder.BuildQuery<TEntity>(EndpointUrl, id, parentPath, query, DefaultItemsPerRequest);
            return StreamListAsync<TEntity>(uri, null, AccountId, MaximumRequestsPerQuery, ct);
        }

        /// <summary>
        /// Sends a GET request with query string parameters and returns the response content parsed as a JSON document.
        /// </summary>
        /// <param name="pathSegment">The relative API path identifying the resource to request.</param>
        /// <param name="parameters">The query string parameters to append to the request URL.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>A <see cref="JsonDocument"/> representing the parsed JSON response content.</returns>
        internal async Task<JsonDocument> GetJsonDocumentAsync(string pathSegment, Dictionary<string, string> parameters, CancellationToken ct)
        {
            UriBuilder uriBuilder = new(EndpointUrl);
            uriBuilder.Path = uriBuilder.Path.TrimEnd('/') + "/" + pathSegment.TrimStart('/') + "/";

            if (parameters.Count > 0)
                uriBuilder.Query = string.Join("&", parameters.Select(static p => Uri.EscapeDataString(p.Key) + "=" + Uri.EscapeDataString(p.Value)));

            AuthenticationToken token = await GetAuthenticationTokenAsync(ct).ConfigureAwait(false);

            using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Get, uriBuilder.Uri, AccountId, token))
            {
                using (HttpResponseMessage responseMessage = await SendHttpRequestAsync(requestMessage, null, token, true, ct).ConfigureAwait(false))
                {
#if NET5_0_OR_GREATER
                    using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync(ct).ConfigureAwait(false))
#else
                    using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
#endif
                    {
                        return await JsonDocument.ParseAsync(responseStream, cancellationToken: ct).ConfigureAwait(false);
                    }
                }
            }
        }

        /// <summary>
        /// Sends paginated GET requests and aggregates all returned entities.
        /// </summary>
        /// <typeparam name="TEntity">The entity type returned by the request.</typeparam>
        /// <param name="url">The initial request URL.</param>
        /// <param name="nextPageUrl">The continuation URL, if any.</param>
        /// <param name="accountId">The account identifier header value.</param>
        /// <param name="maxRequests">The maximum number of requests to issue.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>A read-only collection containing all retrieved entities.</returns>
        private async Task<ReadOnlyKeyedDataCollection<TEntity>> GetAsync<TEntity>(Uri url, Uri? nextPageUrl, string accountId, int maxRequests, CancellationToken ct)
            where TEntity : ObservableItem
        {
            KeyedDataCollection<TEntity> results = new();
            Uri? currentPageUrl = nextPageUrl ?? url;

            while (maxRequests > 0 && currentPageUrl is not null)
            {
                AuthenticationToken token = await GetAuthenticationTokenAsync(ct).ConfigureAwait(false);

                using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Get, currentPageUrl, accountId, token))
                {
                    using (HttpResponseMessage responseMessage = await SendHttpRequestAsync(requestMessage, null, token, true, ct).ConfigureAwait(false))
                    {
#if NET5_0_OR_GREATER
                        using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync(ct).ConfigureAwait(false))
#else
                        using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
#endif
                        {
                            using (JsonDocument document = await JsonDocument.ParseAsync(responseStream, default, ct).ConfigureAwait(false))
                            {
                                JsonElement root = document.RootElement;

                                if (root.ValueKind == JsonValueKind.Array && root.Deserialize<KeyedDataCollection<TEntity>>(_jsonOptions) is KeyedDataCollection<TEntity> items)
                                {
                                    results.AddRange(items);
                                }
                                else if (root.ValueKind == JsonValueKind.Object && root.Deserialize<TEntity>(_jsonOptions) is TEntity item)
                                {
                                    results.Add(item);
                                }
                            }

                            HttpPaginationLinks paginationLinks = responseMessage.Headers.GetPaginationLinks();
                            if (paginationLinks.NextLink is null)
                            {
                                break;
                            }
                            else
                            {
                                currentPageUrl = new Uri(paginationLinks.NextLink, UriKind.Absolute);
                            }
                        }
                    }
                }

                maxRequests--;
            }

            return new ReadOnlyKeyedDataCollection<TEntity>(results);
        }

        /// <summary>
        /// Streams paginated GET responses and yields entities as they are received.
        /// </summary>
        /// <typeparam name="TEntity">The entity type returned by the request.</typeparam>
        /// <param name="url">The initial request URL.</param>
        /// <param name="nextPageUrl">The continuation URL, if any.</param>
        /// <param name="accountId">The account identifier header value.</param>
        /// <param name="maxRequests">The maximum number of requests to issue.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An async stream of entities.</returns>
        private async IAsyncEnumerable<TEntity> StreamListAsync<TEntity>(Uri url, Uri? nextPageUrl, string accountId, int maxRequests, [EnumeratorCancellation] CancellationToken ct)
            where TEntity : ObservableItem
        {
            Uri? currentPageUrl = nextPageUrl ?? url;

            while (maxRequests > 0 && currentPageUrl is not null)
            {
                AuthenticationToken token = await GetAuthenticationTokenAsync(ct).ConfigureAwait(false);

                using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Get, currentPageUrl, accountId, token))
                {
                    using (HttpResponseMessage responseMessage = await SendHttpRequestAsync(requestMessage, null, token, true, ct).ConfigureAwait(false))
                    {
#if NET5_0_OR_GREATER
                        using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync(ct).ConfigureAwait(false))
#else
                        using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
#endif
                        {
                            using (JsonDocument document = await JsonDocument.ParseAsync(responseStream, default, ct).ConfigureAwait(false))
                            {
                                JsonElement root = document.RootElement;

                                if (root.ValueKind == JsonValueKind.Array && root.Deserialize<KeyedDataCollection<TEntity>>(_jsonOptions) is KeyedDataCollection<TEntity> items)
                                {
                                    foreach (TEntity item in items)
                                        yield return item;
                                }
                                else if (root.ValueKind == JsonValueKind.Object && root.Deserialize<TEntity>(_jsonOptions) is TEntity item)
                                {
                                    yield return item;
                                }
                            }
                        }

                        HttpPaginationLinks paginationLinks = responseMessage.Headers.GetPaginationLinks();
                        if (paginationLinks.NextLink is null)
                        {
                            yield break;
                        }
                        else
                        {
                            currentPageUrl = new Uri(paginationLinks.NextLink, UriKind.Absolute);
                        }
                    }
                }

                maxRequests--;
            }
        }
    }
}
