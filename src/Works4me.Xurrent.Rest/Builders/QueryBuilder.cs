using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Works4me.Xurrent.Rest.Builders
{
    /// <summary>
    /// Builds REST query and mutation URIs for the Xurrent API. <br />
    /// Encapsulates path, filter, paging, sorting, and parent-child resource composition logic.
    /// </summary>
    internal static class QueryBuilder
    {
        /// <summary>
        /// Builds a query URI for the specified endpoint and query definition.
        /// </summary>
        /// <param name="endpointUrl">The base endpoint URL.</param>
        /// <param name="query">The query definition.</param>
        /// <param name="defaultItemPerRequest">The default number of items per page.</param>
        /// <returns>A fully composed query <see cref="Uri"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="endpointUrl"/> or <paramref name="query"/> is null.</exception>
        public static Uri BuildQuery<TEntity>(Uri endpointUrl, IQuery query, int defaultItemPerRequest)
        {
            return BuildQuery<TEntity>(endpointUrl, null, null, query, defaultItemPerRequest);
        }

        /// <summary>
        /// Builds a query URI for the specified endpoint and query definition.
        /// </summary>
        /// <param name="endpointUrl">The base endpoint URL.</param>
        /// <param name="pathSegmentToAppend">An optional path segment appended after endpoint URL.</param>
        /// <param name="query">The query definition.</param>
        /// <param name="defaultItemPerRequest">The default number of items per page.</param>
        /// <returns>A fully composed query <see cref="Uri"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="endpointUrl"/> or <paramref name="query"/> is null.</exception>
        public static Uri BuildQuery<TEntity>(Uri endpointUrl, string pathSegmentToAppend, IQuery query, int defaultItemPerRequest)
        {
            return BuildQuery<TEntity>(new Uri(endpointUrl, pathSegmentToAppend), null, null, query, defaultItemPerRequest);
        }

        /// <summary>
        /// Builds a query URI for a scoped resource, including optional parent and filtering information.
        /// </summary>
        /// <param name="endpointUrl">The base endpoint URL.</param>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <param name="query">The query definition.</param>
        /// <param name="defaultItemPerRequest">The default number of items per page.</param>
        /// <returns>A fully composed query <see cref="Uri"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="endpointUrl"/> or <paramref name="query"/> is null.</exception>
        /// <exception cref="XurrentQueryException">Thrown when parent parameters are inconsistently specified.</exception>
        public static Uri BuildQuery<TEntity>(Uri endpointUrl, long? parentId, string? parentPath, IQuery query, int defaultItemPerRequest)
        {
            if (endpointUrl is null)
                throw new ArgumentNullException(nameof(endpointUrl));

            if (query is null)
                throw new ArgumentNullException(nameof(query));

            if ((parentId is null && parentPath is not null) || (parentId is not null && parentPath is null))
                throw new XurrentQueryException($"Both {nameof(parentId)} and {nameof(parentPath)} must be set together.");

            StringBuilder result = new();

            if (parentId is not null && parentPath is not null)
            {
                result.Append($"{parentId.Value}/{parentPath}/");
            }

            if (query.Id is not null)
            {
                result.Append($"{query.Id}/");
            }
            else
            {
                if (!string.IsNullOrEmpty(query.PredefinedFilter))
                {
                    result.Append($"{query.PredefinedFilter}/");
                }

                if (string.IsNullOrEmpty(endpointUrl.Query))
                    result.Append('?');
                else
                    result.Append($"{endpointUrl.Query}&");

                if (typeof(IRecord).IsAssignableFrom(typeof(TEntity)))
                {
                    if (query.ItemsPerRequest is not null)
                    {
                        result.Append($"per_page={query.ItemsPerRequest}&");
                    }
                    else
                    {
                        result.Append($"per_page={defaultItemPerRequest}&");
                    }
                }

                if (query.Fields is not null && query.Fields.Count > 0)
                {
                    result.Append($"fields={string.Join(",", query.Fields)}&");
                }

                if (query.Filters is not null && query.Filters.Count > 0)
                {
                    HashSet<string> filters = new(query.Filters.Where(x => !string.IsNullOrEmpty(x)));
                    if (filters.Count > 0 )
                        result.Append($"{string.Join("&", filters)}&");
                }

                if (query.OrderBy is not null && query.OrderBy.Count > 0)
                {
                    HashSet<string> orderBy = new(query.OrderBy.Where(x => !string.IsNullOrEmpty(x)));
                    if (orderBy.Count > 0)
                        result.Append($"sort={string.Join(",", query.OrderBy)}&");
                }
            }

            return new Uri(endpointUrl, result.ToString().TrimEnd('&', '?'));
        }

        /// <summary>
        /// Builds a mutation URI for create, update, or delete operations.
        /// </summary>
        /// <param name="endpointUrl">The base endpoint URL.</param>
        /// <param name="id">The entity identifier.</param>
        /// <param name="pathSegmentToAppend">An optional path segment appended after the entity identifier.</param>
        /// <param name="parentId">The parent entity identifier.</param>
        /// <param name="parentPath">The parent path segment.</param>
        /// <returns>A fully composed mutation <see cref="Uri"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="endpointUrl"/> is null.</exception>
        /// <exception cref="XurrentQueryException">Thrown when parent parameters or path arguments are invalid.</exception>
        public static Uri BuildMutation(Uri endpointUrl, long? id, string? pathSegmentToAppend, long? parentId, string? parentPath)
        {
            if (endpointUrl is null)
                throw new ArgumentNullException(nameof(endpointUrl));

            if ((parentId is null && parentPath is not null) || (parentId is not null && parentPath is null))
                throw new XurrentQueryException($"Both {nameof(parentId)} and {nameof(parentPath)} must be set together.");

            if (pathSegmentToAppend is not null && id is null)
                throw new XurrentQueryException($"{nameof(id)} must be provided when {nameof(pathSegmentToAppend)} is specified.");

            StringBuilder result = new();

            if (parentId is not null && parentPath is not null)
                result.Append($"{parentId.Value}/{parentPath}/");

            if (id is not null)
                result.Append($"{id}/");

            if (pathSegmentToAppend is not null)
                result.Append($"{pathSegmentToAppend}/");

            return new Uri(endpointUrl, result.ToString());
        }
    }
}
