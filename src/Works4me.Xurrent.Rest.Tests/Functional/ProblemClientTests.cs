using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ProblemClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetProblemsAsync()
        {
            ReadOnlyKeyedDataCollection<Problem> problems = await _client.Problems.GetAsync(new ProblemQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(problems);

            if (problems.Count > 0)
            {
                Problem? problem = await _client.Problems.GetAsync(problems.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(problem);
            }
        }
    }
}
