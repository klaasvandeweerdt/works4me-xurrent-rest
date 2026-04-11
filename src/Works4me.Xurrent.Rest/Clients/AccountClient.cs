using System;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Account"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/account/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed partial class AccountClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountClient"/> class.
        /// </summary>
        internal AccountClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "account/"))
        {
        }

        /// <summary>
        /// Retrieves a single <see cref="Account"/> using the specified <see cref="AccountQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which account to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Account"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Account?> GetAsync(AccountQuery query, CancellationToken ct = default)
        {
            return await GetItemAsync<Account>(query, ct).ConfigureAwait(false);
        }
    }
}
