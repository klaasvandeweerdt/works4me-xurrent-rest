using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class NoteClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetNotesAsync()
        {
            ReadOnlyKeyedDataCollection<Note> notes = await _client.Notes.GetAsync(new NoteQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(notes);

            if (notes.Count > 0)
            {
                Note? note = await _client.Notes.GetAsync(notes.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(note);
            }
        }
    }
}
