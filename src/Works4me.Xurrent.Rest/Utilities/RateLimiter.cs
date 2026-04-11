using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Works4me.Xurrent.Rest.Utilities
{
    /// <summary>
    /// A singleton rate limiter that manages multiple tokens and their respective rate limits.
    /// </summary>
    internal sealed class RateLimiter
    {
        private readonly ConcurrentDictionary<int, Queue<long>> _tokenRequestQueues;
        private readonly int _maxRequestsPerToken;
        private readonly TimeSpan _window;
        private readonly TimeSpan _minimumWaitingTime = TimeSpan.FromMilliseconds(20);

        private readonly Stopwatch _stopwatch;

        private static Lazy<RateLimiter> _instance = new(() => new RateLimiter(19, TimeSpan.FromSeconds(2)));
        private static readonly object _syncRoot = new();

        /// <summary>
        /// Gets the singleton instance of the <see cref="RateLimiter"/> class.
        /// </summary>
        public static RateLimiter Instance => _instance.Value;

        /// <summary>
        /// Configures the singleton instance with custom rate limits.
        /// </summary>
        /// <param name="maxRequestsPerToken">Maximum number of requests per token.</param>
        /// <param name="window">Time window for rate limiting.</param>
        public static void Configure(int maxRequestsPerToken, TimeSpan window)
        {
            if (maxRequestsPerToken <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxRequestsPerToken), "Maximum requests must be greater than zero.");

            if (window <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(nameof(window), "Time window must be greater than zero.");

            lock (_syncRoot)
            {
                _instance = new Lazy<RateLimiter>(() => new RateLimiter(maxRequestsPerToken, window));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RateLimiter"/> class.
        /// This constructor is private to enforce the singleton pattern.
        /// </summary>
        /// <param name="maxRequestsPerToken">The maximum number of requests allowed per token within the rate-limiting window.</param>
        /// <param name="window">The time window during which the rate limit applies.</param>
        /// <remarks>
        /// This constructor is invoked only internally by the <see cref="Lazy{T}"/> instance to initialize the singleton.
        /// </remarks>
        private RateLimiter(int maxRequestsPerToken, TimeSpan window)
        {
            _maxRequestsPerToken = maxRequestsPerToken;
            _window = window;
            _tokenRequestQueues = new ConcurrentDictionary<int, Queue<long>>();
            _stopwatch = Stopwatch.StartNew();
        }

        /// <summary>
        /// Asynchronously waits for a permit for the given token.
        /// </summary>
        /// <param name="token">The authentication token to be rate-limited.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>A task that completes when the rate limit allows the request to proceed.</returns>
        public async Task WaitForToken(AuthenticationToken token, CancellationToken cancellationToken)
        {
            if (token is null)
                throw new ArgumentNullException(nameof(token), "The authentication token cannot be null.");

            DateTimeOffset now = DateTimeOffset.UtcNow;
            TimeSpan waitTime = TimeSpan.Zero;

            if (token.RetryAfter.HasValue && token.RetryAfter.Value > now)
            {
                waitTime = token.RetryAfter.Value - now + TimeSpan.FromSeconds(1);
                try
                {
                    await Task.Delay(waitTime, cancellationToken).ConfigureAwait(false);
                }
                catch (TaskCanceledException)
                {
                    throw new OperationCanceledException("The rate limiter wait was canceled.", cancellationToken);
                }
            }

            Queue<long> queue = _tokenRequestQueues.GetOrAdd(token.Id, _ => new Queue<long>());

            while (true)
            {
                long nowTicks = _stopwatch.ElapsedTicks;
                waitTime = TimeSpan.Zero;

                lock (queue)
                {
                    while (queue.Count > 0 && new TimeSpan(nowTicks - queue.Peek()) > _window)
                        queue.Dequeue();

                    if (queue.Count < _maxRequestsPerToken)
                    {
                        queue.Enqueue(nowTicks);
                        return;
                    }

                    long earliest = queue.Peek();
                    TimeSpan untilAllowed = new(earliest + _window.Ticks - nowTicks);
                    waitTime = untilAllowed + TimeSpan.FromMilliseconds(100);
                }

                if (waitTime < _minimumWaitingTime)
                    waitTime = _minimumWaitingTime;

                if (waitTime > TimeSpan.Zero)
                {
                    try
                    {
                        await Task.Delay(waitTime, cancellationToken).ConfigureAwait(false);
                    }
                    catch (TaskCanceledException)
                    {
                        throw new OperationCanceledException("The rate limiter wait was canceled.", cancellationToken);
                    }
                }
                else
                {
                    await Task.Delay(_minimumWaitingTime, cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}
