using System;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Utilities;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Utilities
{
    public class RateLimiterTests
    {
        [Fact]
        public void Configure_Throws_WhenMaxRequestsIsZero()
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                RateLimiter.Configure(0, TimeSpan.FromSeconds(1)));

            Assert.Equal("maxRequestsPerToken", exception.ParamName);
        }

        [Fact]
        public void Configure_Throws_WhenWindowIsZero()
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                RateLimiter.Configure(1, TimeSpan.Zero));

            Assert.Equal("window", exception.ParamName);
        }

        [Fact]
        public async Task WaitForToken_Throws_WhenTokenIsNull()
        {
            CancellationTokenSource cts = new();

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                RateLimiter.Instance.WaitForToken(null, cts.Token));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [Fact]
        public async Task WaitForToken_AllowsFirstRequestImmediately()
        {
            AuthenticationToken token = new("my-token#1");
            CancellationTokenSource cts = new();

            await RateLimiter.Instance.WaitForToken(token, cts.Token);

            Assert.True(true);
        }

        [Fact]
        public async Task WaitForToken_RespectsRetryAfter()
        {
            AuthenticationToken token = new("my-token#2");
            token.UpdateRetryAfter(1);

            CancellationTokenSource cts = new();
            DateTimeOffset start = DateTimeOffset.UtcNow;

            await RateLimiter.Instance.WaitForToken(token, cts.Token);

            TimeSpan elapsed = DateTimeOffset.UtcNow - start;
            Assert.True(elapsed >= TimeSpan.FromSeconds(1), $"Elapsed: {elapsed.TotalMilliseconds}ms, expected at least 1000ms.");
        }

        [Fact]
        public async Task WaitForToken_RespectsCancellation_WhenRetryAfterIsSet()
        {
            AuthenticationToken token = new("my-token#3");
            token.UpdateRetryAfter(5); 

            CancellationTokenSource cts = new();
            cts.Cancel();

            await Assert.ThrowsAsync<OperationCanceledException>(() =>
                RateLimiter.Instance.WaitForToken(token, cts.Token));
        }
    }
}
