using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class SurveyResponseClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetSurveyResponsesAsync()
        {
            ReadOnlyKeyedDataCollection<SurveyResponse> surveyResponses = await _client.SurveyResponses.GetAsync(new SurveyResponseQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(surveyResponses);

            if (surveyResponses.Count > 0)
            {
                SurveyResponse? surveyResponse = await _client.SurveyResponses.GetAsync(surveyResponses.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(surveyResponse);
            }
        }
    }
}
