using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class OrganizationClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetOrganizationsAsync()
        {
            ReadOnlyKeyedDataCollection<Organization> organizations = await _client.Organizations.GetAsync(new OrganizationQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(organizations);

            if (organizations.Count > 0)
            {
                Organization? organization = await _client.Organizations.GetAsync(organizations.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(organization);
            }
        }
    }
}
