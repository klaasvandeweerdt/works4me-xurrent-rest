using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ProjectCategoryClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetProjectCategoriesAsync()
        {
            ReadOnlyKeyedDataCollection<ProjectCategory> projectCategories = await _client.ProjectCategories.GetAsync(new ProjectCategoryQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(projectCategories);

            if (projectCategories.Count > 0)
            {
                ProjectCategory? projectCategory = await _client.ProjectCategories.GetAsync(projectCategories.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(projectCategory);
            }
        }
    }
}
