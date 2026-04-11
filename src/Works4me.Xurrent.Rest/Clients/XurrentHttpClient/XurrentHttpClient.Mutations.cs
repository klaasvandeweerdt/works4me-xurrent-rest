using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    partial class XurrentHttpClient
    {
        /// <summary>
        /// Creates a new entity by issuing a POST request.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="item">The entity to create.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The created entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        internal async Task<TEntity> PostItemAsync<TEntity>(TEntity item, CancellationToken ct)
            where TEntity : RecordItem
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, null, null, null, null);
            return await Mutation<TEntity, TEntity>(uri, AccountId, HttpMethod.Post, item, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new entity using a custom path segment.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="item">The entity to create.</param>
        /// <param name="pathSegmentToAppend">The path segment appended to the request URL.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The created entity.</returns>
        internal async Task<TEntity> PostItemAsync<TEntity>(TEntity item, string pathSegmentToAppend, CancellationToken ct)
            where TEntity : RecordItem
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, item.Id, pathSegmentToAppend, null, null);
            return await Mutation<TEntity, TEntity>(uri, AccountId, HttpMethod.Post, item, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new child entity under a specified parent.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="item">The entity to create.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The created entity.</returns>
        internal async Task<TEntity> PostItemAsync<TEntity>(long parentId, string parentPath, TEntity item, CancellationToken ct)
            where TEntity : ObservableItem
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, null, null, parentId, parentPath);
            return await Mutation<TEntity, TEntity>(uri, AccountId, HttpMethod.Post, item, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new child entity under a specified parent.
        /// </summary>
        /// <typeparam name="TInputEntity">The input entity type.</typeparam>
        /// <typeparam name="TOutputEntity">The output entity type.</typeparam>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="item">The entity to create.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The created entity.</returns>
        internal async Task<TOutputEntity> PostItemAsync<TOutputEntity, TInputEntity>(long parentId, string parentPath, TInputEntity item, CancellationToken ct)
            where TInputEntity : ObservableItem
            where TOutputEntity : ObservableItem
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, null, null, parentId, parentPath);
            return await Mutation<TOutputEntity, TInputEntity>(uri, AccountId, HttpMethod.Post, item, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates an association between two entities.
        /// </summary>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="id">The entity identifier.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        internal async Task<bool> PostItemAsync(long parentId, string parentPath, long id, CancellationToken ct)
        {
            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, id, null, parentId, parentPath);
            return await Mutation(uri, AccountId, HttpMethod.Post, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a POST request to the specified path segment with query string parameters.
        /// </summary>
        /// <param name="pathSegment">The path segment to append to the endpoint URL.</param>
        /// <param name="parameters">The query string parameters to include in the request.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        internal async Task<bool> PostItemAsync(string pathSegment, Dictionary<string, string> parameters, CancellationToken ct)
        {
            UriBuilder uriBuilder = new(EndpointUrl);
            uriBuilder.Path = uriBuilder.Path.TrimEnd('/') + "/" + pathSegment.TrimStart('/') + "/";

            if (parameters.Count > 0)
                uriBuilder.Query = string.Join("&", parameters.Select(static p => Uri.EscapeDataString(p.Key) + "=" + Uri.EscapeDataString(p.Value)));

            return await Mutation(uriBuilder.Uri, AccountId, HttpMethod.Post, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="item">The entity to update.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The updated entity.</returns>
        internal async Task<TEntity> PatchItemAsync<TEntity>(TEntity item, CancellationToken ct)
            where TEntity : RecordItem
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, item.Id, null, null, null);
            return await Mutation<TEntity, TEntity>(uri, AccountId, HttpPatch, item, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates a child entity under a specified parent.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="item">The entity to update.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The updated entity.</returns>
        internal async Task<TEntity> PatchItemAsync<TEntity>(long parentId, string parentPath, TEntity item, CancellationToken ct)
            where TEntity : ObservableItem
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, item is IRecord record ? record.Id : null, null, parentId, parentPath);
            return await Mutation<TEntity, TEntity>(uri, AccountId, HttpPatch, item, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates a child entity under a specified parent.
        /// </summary>
        /// <typeparam name="TInputEntity">The input entity type.</typeparam>
        /// <typeparam name="TOutputEntity">The output entity type.</typeparam>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="item">The entity to update.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The updated entity.</returns>
        internal async Task<TOutputEntity> PatchItemAsync<TOutputEntity, TInputEntity>(long parentId, string parentPath, TInputEntity item, CancellationToken ct)
            where TInputEntity : ObservableItem
            where TOutputEntity : ObservableItem
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, item is IRecord record ? record.Id : null, null, parentId, parentPath);
            return await Mutation<TOutputEntity, TInputEntity>(uri, AccountId, HttpPatch, item, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes an entity by identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns><see langword="true"/> if the deletion succeeds.</returns>
        internal async Task<bool> DeleteItemAsync(long id, CancellationToken ct)
        {
            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, id, null, null, null);
            return await Mutation(uri, AccountId, HttpMethod.Delete, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes an entity under a specified parent.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="item">The entity to delete.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns><see langword="true"/> if the deletion succeeds.</returns>
        internal async Task<bool> DeleteItemAsync<TEntity>(long parentId, string parentPath, TEntity item, CancellationToken ct)
            where TEntity : ObservableItem
        {
            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, item is IRecord record ? record.Id : null, null, parentId, parentPath);
            return await Mutation(uri, AccountId, HttpMethod.Delete, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes an entity by identifier.
        /// </summary>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="id">The entity identifier.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns><see langword="true"/> if the deletion succeeds.</returns>
        internal async Task<bool> DeleteItemAsync(long parentId, string parentPath, long id, CancellationToken ct)
        {
            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, id, null, parentId, parentPath);
            return await Mutation(uri, AccountId, HttpMethod.Delete, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a DELETE request to the specified path segment with query string parameters.
        /// </summary>
        /// <param name="pathSegment">The path segment to append to the endpoint URL.</param>
        /// <param name="parameters">The query string parameters to include in the request.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        internal async Task<bool> DeleteItemAsync(string pathSegment, Dictionary<string, string> parameters, CancellationToken ct)
        {
            UriBuilder uriBuilder = new(EndpointUrl);
            uriBuilder.Path = uriBuilder.Path.TrimEnd('/') + "/" + pathSegment.TrimStart('/') + "/";

            if (parameters.Count > 0)
                uriBuilder.Query = string.Join("&", parameters.Select(static p => Uri.EscapeDataString(p.Key) + "=" + Uri.EscapeDataString(p.Value)));

            return await Mutation(uriBuilder.Uri, AccountId, HttpMethod.Delete, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes all entities under a specified parent.
        /// </summary>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns><see langword="true"/> if the deletion succeeds.</returns>
        internal async Task<bool> DeleteAllItemsAsync(long parentId, string parentPath, CancellationToken ct)
        {
            Uri uri = QueryBuilder.BuildMutation(EndpointUrl, null, null, parentId, parentPath);
            return await Mutation(uri, AccountId, HttpMethod.Delete, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes a mutation request that sends and receives an entity payload.
        /// </summary>
        /// <typeparam name="TInputEntity">The input entity type.</typeparam>
        /// <typeparam name="TOutputEntity">The output entity type.</typeparam>
        /// <param name="url">The mutation URL.</param>
        /// <param name="accountId">The account identifier header value.</param>
        /// <param name="method">The HTTP method to use.</param>
        /// <param name="item">The entity payload.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The returned entity, if any.</returns>
        private async Task<TOutputEntity> Mutation<TOutputEntity, TInputEntity>(Uri url, string accountId, HttpMethod method, TInputEntity item, CancellationToken ct)
            where TInputEntity : ObservableItem
            where TOutputEntity : ObservableItem
        {
            AuthenticationToken token = await GetAuthenticationTokenAsync(ct).ConfigureAwait(false);
            using (HttpRequestMessage requestMessage = CreateHttpRequest(method, url, accountId, token))
            {
                string content = item.GetHttpRequestBody(_jsonOptions);

                using (HttpResponseMessage responseMessage = await SendHttpRequestAsync(requestMessage, content, token, true, ct).ConfigureAwait(false))
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

                            if (root.ValueKind == JsonValueKind.Object && root.Deserialize<TOutputEntity>(_jsonOptions) is TOutputEntity result)
                            {
                                return result;
                            }
                        }
                    }
                }
            }
            throw new XurrentException($"Unexpected response content. Unable to deserialize the HTTP response body into {typeof(TOutputEntity).FullName}.");
        }

        /// <summary>
        /// Executes a mutation request without an entity payload.
        /// </summary>
        /// <param name="url">The mutation URL.</param>
        /// <param name="accountId">The account identifier header value.</param>
        /// <param name="method">The HTTP method to use.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns><see langword="true"/> if the request succeeds.</returns>
        private async Task<bool> Mutation(Uri url, string accountId, HttpMethod method, CancellationToken ct)
        {
            AuthenticationToken token = await GetAuthenticationTokenAsync(ct).ConfigureAwait(false);
            using (HttpRequestMessage requestMessage = CreateHttpRequest(method, url, accountId, token))
            {
                using (HttpResponseMessage responseMessage = await SendHttpRequestAsync(requestMessage, null, token, true, ct).ConfigureAwait(false))
                {
                    return true;
                }
            }
        }
    }
}
