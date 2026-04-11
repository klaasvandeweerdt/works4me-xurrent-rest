using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class PersonClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetPeopleAsync()
        {
            ReadOnlyKeyedDataCollection<Person> people = await _client.People.GetAsync(new PersonQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(people);

            if (people.Count > 0)
            {
                Person? person = await _client.People.GetAsync(people.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(person);
            }
        }
    }
}
