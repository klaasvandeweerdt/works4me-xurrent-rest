using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ServiceCategoryClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetServiceCategoriesAsync()
        {
            ReadOnlyKeyedDataCollection<ServiceCategory> serviceCategories = await _client.ServiceCategories.GetAsync(new ServiceCategoryQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(serviceCategories);

            if (serviceCategories.Count > 0)
            {
                ServiceCategory? serviceCategory = await _client.ServiceCategories.GetAsync(serviceCategories.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(serviceCategory);
            }
        }
    }
}
