using System;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for currently authenticated person details in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/people/me/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class MeClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonClient"/> class.
        /// </summary>
        internal MeClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "me/"))
        {
        }
        /// <summary>
        /// Retrieves the details of the currently authenticated person.
        /// </summary>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The details of the currently authenticated person, or null if the request fails.</returns>
        public async Task<Person?> GetAsync(CancellationToken ct = default)
        {
            return await GetItemAsync<Person>(new PersonQuery().Select("id"), ct).ConfigureAwait(false);
        }
    }
}
