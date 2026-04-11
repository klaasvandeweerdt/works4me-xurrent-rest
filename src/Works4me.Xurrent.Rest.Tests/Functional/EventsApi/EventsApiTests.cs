using System;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional.EventsApi
{
    public sealed class EventsApiTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task CreateUpdateAndComplete()
        {
            RequestEventCreateInput requestCreate = new RequestEventCreateInput()
                .Category(RequestCategory.Incident)
                .Note("An event note")
                .Subject($"SDK Test - {Guid.NewGuid():N}")
                .Source("Works4me.Xurrent.Rest")
                .SourceID("1")
                .ServiceInstance(Convert.ToInt32(Client.GetConfigValue("EventApi.ServiceInstance")))
                .Impact(RequestImpact.Medium)
                .ConfigurationItem(Convert.ToInt32(Client.GetConfigValue("EventApi.ConfigurationItem")))
                .Team(Convert.ToInt32(Client.GetConfigValue("EventApi.Team")));

            Request request = await _client.CreateEventAsync(requestCreate, TestContext.Current.CancellationToken);

            Assert.NotNull(request);

            NoteCreate note = await _client.Requests.Notes.CreateAsync(request, new NoteCreate()
            {
                Text = $"A note for the event created on {DateTime.Now:T}",
                Internal = true,
            }, TestContext.Current.CancellationToken);

            Assert.NotNull(note);

            request.Note = "Request completed.";
            request.Status = RequestStatus.Completed;
            request.CompletionReason = RequestCompletionReason.Solved;

            request = await _client.Requests.UpdateAsync(request, TestContext.Current.CancellationToken);
            
            Assert.NotNull(request);
            Assert.Equal(RequestStatus.Completed, request.Status);
        }
    }
}
