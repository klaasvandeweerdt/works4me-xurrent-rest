using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class AccountClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetAccountAsync()
        {
            Account? account = await _client.Account.GetAsync(new AccountQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(account);
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Name);
        }
    }
}
