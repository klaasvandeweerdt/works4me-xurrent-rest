using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Models
{
    public sealed class ReadOnlyKeyedDataCollectionTests
    {
        [Fact]
        public void Ctor_WhenInnerIsNull_Throws()
        {
            ArgumentNullException exception =
                Assert.Throws<ArgumentNullException>(() => new ReadOnlyKeyedDataCollection<Person>(null!));

            Assert.Equal("dataList", exception.ParamName);
        }

        [Fact]
        public void Indexer_ReturnsItemFromInner()
        {
            KeyedDataCollection<Person> inner = new();
            Person person = new(123);

            inner.Add(person);

            ReadOnlyKeyedDataCollection<Person> readOnly = new(inner);

            Person actual = readOnly[123];

            Assert.Same(person, actual);
        }

        [Fact]
        public void Count_ReturnsInnerCount()
        {
            KeyedDataCollection<Person> inner = new()
            {
                new Person(1),
                new Person(2)
            };

            ReadOnlyKeyedDataCollection<Person> readOnly = new(inner);

            Assert.Equal(2, readOnly.Count);
        }

        [Fact]
        public void Contains_DelegatesToInner()
        {
            KeyedDataCollection<Person> inner = new()
            {
                new Person(1)
            };

            ReadOnlyKeyedDataCollection<Person> readOnly = new(inner);

            Assert.True(readOnly.Contains(1));
            Assert.False(readOnly.Contains(2));
        }

        [Fact]
        public void GetEnumerator_EnumeratesInnerItems()
        {
            KeyedDataCollection<Person> inner = new();
            Person person1 = new(1);
            Person person2 = new(2);

            inner.Add(person1);
            inner.Add(person2);

            ReadOnlyKeyedDataCollection<Person> readOnly = new(inner);

            List<Person> items = readOnly.ToList();

            Assert.Equal(2, items.Count);
            Assert.Same(person1, items[0]);
            Assert.Same(person2, items[1]);
        }
    }
}
