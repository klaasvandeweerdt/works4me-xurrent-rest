#if !NET5_0_OR_GREATER
using System.Net.Http;
using System.Net;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest.Utilities
{
    /// <summary>
    /// A delegating handler that ensures HTTP connections are recycled after a specified lifetime.
    /// <para>
    /// On each request, sets <see cref="ServicePoint.ConnectionLeaseTimeout"/> for the request's <see cref="ServicePoint"/>, causing the underlying TCP connection to be closed and recreated after the specified duration.<br />
    /// This helps ensure DNS changes are picked up and prevents indefinitely persistent connections.<br />
    /// </para>
    /// </summary>
    public class ServicePointLifetimeHandler : DelegatingHandler
    {
        private readonly TimeSpan _connectionLifetime;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePointLifetimeHandler"/> class.
        /// </summary>
        /// <param name="connectionLifetime">The maximum lifetime for a TCP connection to a remote endpoint. After this duration, the next request will trigger closing the current connection and establishing a new one.</param>
        /// <param name="innerHandler">The inner <see cref="HttpMessageHandler"/> responsible for sending the HTTP requests, typically an instance of <see cref="HttpClientHandler"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="connectionLifetime"/> is less than or equal to <see cref="TimeSpan.Zero"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="innerHandler"/> is <see langword="null"/>.</exception>
        public ServicePointLifetimeHandler(TimeSpan connectionLifetime, HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            if (connectionLifetime <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(nameof(connectionLifetime), "Connection lifetime must be positive.");

            if (innerHandler is null)
                throw new ArgumentNullException(nameof(innerHandler));

            _connectionLifetime = connectionLifetime;
        }

        /// <summary>
        /// Sends an HTTP request asynchronously and sets the <see cref="ServicePoint.ConnectionLeaseTimeout"/> for the request's URI before sending the request.
        /// </summary>
        /// <param name="request">The HTTP request message to send.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, containing the HTTP response message.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="request"/> is <see langword="null"/>.</exception>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            ServicePoint servicePoint = ServicePointManager.FindServicePoint(request.RequestUri);
            servicePoint.ConnectionLeaseTimeout = (int)_connectionLifetime.TotalMilliseconds;
            return base.SendAsync(request, cancellationToken);
        }
    }
}
#endif
