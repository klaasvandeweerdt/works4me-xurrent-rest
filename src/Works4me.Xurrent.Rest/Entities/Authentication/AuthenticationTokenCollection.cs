using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// A thread-safe collection of <see cref="AuthenticationToken"/> instances that selects the best token based on weighted request limits.
    /// </summary>
    public sealed class AuthenticationTokenCollection : IEnumerable<AuthenticationToken>, IDisposable
    {
        private readonly List<AuthenticationToken> _tokens = new();
        private readonly ReaderWriterLockSlim _lock = new();
        private readonly object _disposeLock = new();
        private bool _disposedValue;

        /// <summary>
        /// Initializes a new instance containing no access tokens or OAuth2 client credentials.
        /// </summary>
        public AuthenticationTokenCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance containing the specified <see cref="AuthenticationToken"/>.
        /// </summary>
        /// <param name="authenticationToken">The token instance to add.</param>
        public AuthenticationTokenCollection(AuthenticationToken authenticationToken)
        {
            Add(authenticationToken);
        }

        /// <summary>
        /// Gets the best available token based on the remaining request limits.
        /// Throws if no tokens are present or if all tokens have exhausted their quotas.
        /// </summary>
        /// <returns>The <see cref="AuthenticationToken"/> with the highest computed score.</returns>
        /// <exception cref="XurrentException">Thrown if the collection is empty or if all tokens have exhausted their quotas.</exception>
        public AuthenticationToken Get()
        {
            List<AuthenticationToken> snapshot;

            _lock.EnterReadLock();
            try
            {
                if (_tokens.Count == 0)
                    throw new XurrentException("The collection does not contain any token.");

                snapshot = new List<AuthenticationToken>(_tokens);
            }
            finally
            {
                _lock.ExitReadLock();
            }

            AuthenticationToken? bestToken = null;
            double bestScore = double.MinValue;

            for (int i = 0; i < snapshot.Count; i++)
            {
                AuthenticationToken token = snapshot[i];
                AuthenticationTokenLimit requestLimit = token.RequestLimit;

                if (requestLimit.Limit <= 0 || requestLimit.Remaining <= 0)
                    continue;

                double score = (double)requestLimit.Remaining / requestLimit.Limit;
                if (bestToken is null || score > bestScore)
                {
                    bestToken = token;
                    bestScore = score;
                    continue;
                }

                if (Math.Abs(score - bestScore) < double.Epsilon)
                {
                    DateTimeOffset tokenRetryAfter = token.RetryAfter ?? DateTimeOffset.MinValue;
                    DateTimeOffset bestTokenRetryAfter = bestToken.RetryAfter ?? DateTimeOffset.MinValue;

                    if (tokenRetryAfter < bestTokenRetryAfter)
                    {
                        bestToken = token;
                    }
                }
            }

            if (bestToken is null)
                throw new XurrentException("All authentication tokens have been exhausted.");

            if (bestToken.RequestLimit.Remaining < 1 && bestToken.RequestLimit.Reset > DateTimeOffset.UtcNow)
                throw new XurrentException("All authentication tokens have been exhausted.");

             return bestToken;
        }

        /// <summary>
        /// Adds the specified <see cref="AuthenticationToken"/> to the collection if it is not already present.
        /// </summary>
        /// <param name="authenticationToken">The token to add.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="authenticationToken"/> is null.</exception>
        /// <exception cref="XurrentException">If both the token string and client credentials are missing or whitespace.</exception>
        public void Add(AuthenticationToken authenticationToken)
        {
            if (authenticationToken is null)
                throw new ArgumentNullException(nameof(authenticationToken));

            _lock.EnterWriteLock();
            try
            {
                if (string.IsNullOrWhiteSpace(authenticationToken.Token) && (string.IsNullOrWhiteSpace(authenticationToken.ClientId) || string.IsNullOrWhiteSpace(authenticationToken.ClientSecret)))
                {
                    throw new XurrentException("Missing Client Id and Client Secret, or Personal Access Token.");
                }

                if (!_tokens.Any(t => t.Id == authenticationToken.Id))
                {
                    _tokens.Add(authenticationToken);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Removes the specified <see cref="AuthenticationToken"/> from the collection.
        /// </summary>
        /// <param name="authenticationToken">The token instance to remove.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="authenticationToken"/> is null.</exception>
        public void Remove(AuthenticationToken authenticationToken)
        {
            if (authenticationToken is null)
                throw new ArgumentNullException(nameof(authenticationToken));

            _lock.EnterWriteLock();
            try
            {
                _tokens.RemoveAll(t => t.Id == authenticationToken.Id);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Removes all tokens from the collection.
        /// </summary>
        public void Clear()
        {
            _lock.EnterWriteLock();
            try
            {
                _tokens.Clear();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a thread-safe snapshot of the collection.
        /// </summary>
        /// <returns>An enumerator over the current tokens.</returns>
        public IEnumerator<AuthenticationToken> GetEnumerator()
        {
            List<AuthenticationToken> snapshot;
            _lock.EnterReadLock();
            try
            {
                snapshot = new List<AuthenticationToken>(_tokens);
            }
            finally
            {
                _lock.ExitReadLock();
            }
            return snapshot.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Releases the resources used by this <see cref="AuthenticationTokenCollection"/>.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                if (_disposedValue)
                    throw new ObjectDisposedException(nameof(AuthenticationTokenCollection));

                if (!_disposedValue)
                {
                    if (disposing)
                    {
                        _lock?.Dispose();
                    }

                    _disposedValue = true;
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// Disposes this instance and suppresses finalization.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
