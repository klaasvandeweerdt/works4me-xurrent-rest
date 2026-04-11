using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Models
{
    public sealed class KeyedDataCollectionTests
    {
        [Fact]
        public void Keys_ReturnsKeysInItemOrder()
        {
            KeyedDataCollection<Person> collection = new();

            collection.Add(new Person(10));
            collection.Add(new Person(20));
            collection.Add(new Person(30));

            List<long> keys = collection.Keys.ToList();

            Assert.Equal(new List<long> { 10, 20, 30 }, keys);
        }

        [Fact]
        public void Add_WhenKeyIsNew_AddsItem()
        {
            KeyedDataCollection<Person> collection = new();
            Person person = new(1);

            collection.Add(person);

            Assert.Single(collection);
            Assert.Same(person, collection[1]);
        }

        [Fact]
        public void Add_WhenKeyExists_ReplacesItemInPlace_AndDoesNotChangeOrder()
        {
            KeyedDataCollection<Person> collection = new();

            Person person1a = new(1);
            Person person2 = new(2);
            Person person1b = new(1);

            collection.Add(person1a);
            collection.Add(person2);

            collection.Add(person1b);

            Assert.Equal(2, collection.Count);

            Assert.Same(person1b, collection[1]);
            Assert.Same(person2, collection[2]);

            List<long> keys = collection.Keys.ToList();
            Assert.Equal(new List<long> { 1, 2 }, keys);
        }

        [Fact]
        public void Insert_WhenKeyIsNew_InsertsAtRequestedIndex()
        {
            KeyedDataCollection<Person> collection = new()
            {
                new Person(1),
                new Person(3)
            };

            collection.Insert(1, new Person(2));

            List<long> keys = collection.Keys.ToList();
            Assert.Equal(new List<long> { 1, 2, 3 }, keys);
        }

        [Fact]
        public void Insert_WhenKeyExists_ReplacesExistingItem_AndIgnoresRequestedIndex()
        {
            KeyedDataCollection<Person> collection = new();

            Person person1a = new(1);
            Person person2 = new(2);
            Person person3 = new(3);
            Person person2b = new(2);

            collection.Add(person1a);
            collection.Add(person2);
            collection.Add(person3);

            collection.Insert(0, person2b);

            Assert.Equal(3, collection.Count);

            Assert.Same(person1a, collection[1]);
            Assert.Same(person2b, collection[2]);
            Assert.Same(person3, collection[3]);

            List<long> keys = collection.Keys.ToList();
            Assert.Equal(new List<long> { 1, 2, 3 }, keys);
        }

        [Fact]
        public void AddRange_WhenNull_DoesNothing()
        {
            KeyedDataCollection<Person> collection = new();

            collection.AddRange(null);

            Assert.Empty(collection);
        }

        [Fact]
        public void AddRange_MergesByKey_ReplacingExistingItems()
        {
            KeyedDataCollection<Person> collection = new();

            Person person1a = new(1);
            Person person2a = new(2);

            collection.Add(person1a);
            collection.Add(person2a);

            Person person2b = new(2);
            Person person3 = new(3);

            List<Person> incoming = new() { person2b, person3 };

            collection.AddRange(incoming);

            Assert.Equal(3, collection.Count);
            Assert.Same(person1a, collection[1]);
            Assert.Same(person2b, collection[2]);
            Assert.Same(person3, collection[3]);

            List<long> keys = collection.Keys.ToList();
            Assert.Equal(new List<long> { 1, 2, 3 }, keys);
        }

        [Fact]
        public void ContainsKey_ReturnsTrueWhenKeyExists()
        {
            KeyedDataCollection<Person> collection = new()
            {
                new Person(5)
            };

            Assert.True(collection.ContainsKey(5));
            Assert.False(collection.ContainsKey(6));
        }

        [Fact]
        public void Ctor_WithEnumerable_AddsItemsAndMergesByKey()
        {
            Person person1a = new(1);
            Person person2a = new(2);
            Person person1b = new(1);

            List<Person> input = new() { person1a, person2a, person1b };

            KeyedDataCollection<Person> collection = new(input);

            Assert.Equal(2, collection.Count);

            Assert.Same(person1b, collection[1]);
            Assert.Same(person2a, collection[2]);

            List<long> keys = collection.Keys.ToList();
            Assert.Equal(new List<long> { 1, 2 }, keys);
        }
    }
}
