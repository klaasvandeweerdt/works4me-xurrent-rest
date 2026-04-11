using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class SurveyClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetSurveysAsync()
        {
            ReadOnlyKeyedDataCollection<Survey> surveys = await _client.Surveys.GetAsync(new SurveyQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(surveys);

            if (surveys.Count > 0)
            {
                Survey? survey = await _client.Surveys.GetAsync(surveys.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(survey);
            }
        }
    }
}
