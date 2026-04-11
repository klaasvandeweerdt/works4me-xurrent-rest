using System;
using System.Text.Json;
using Works4me.Xurrent.Rest;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.GraphQL.Tests.Unit.Serialization
{
    public class XurrentObjectConverterSpecs
    {
        private readonly JsonSerializerOptions _options;

        public XurrentObjectConverterSpecs()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new XurrentObjectConverter<ConfigurationItem>());
        }

        [Fact]
        public void Read_MapsJson_ToProperties()
        {
            string json = "{ \"name\": \"test\", \"nr_of_cores\": 24 }";

            ConfigurationItem? result = JsonSerializer.Deserialize<ConfigurationItem>(json, _options);

            Assert.Equal("test", result?.Name);
            Assert.Equal(24, result?.NrOfCores);
        }

        [Fact]
        public void Read_Ignores_UnmappedProperties()
        {
            string json = "{ \"name\": \"test\", \"unknown\": true }";

            ConfigurationItem? result = JsonSerializer.Deserialize<ConfigurationItem>(json, _options);

            Assert.Equal("test", result?.Name);
            Assert.Null(result?.NrOfCores);
        }

        [Fact]
        public void Write_Serializes_MappedProperties()
        {
            ConfigurationItem obj = new()
            {
                Name = "hello",
                NrOfCores = 24
            };

            string json = JsonSerializer.Serialize(obj, _options);

            Assert.Contains("\"name\":\"hello\"", json);
            Assert.Contains("\"nr_of_cores\":24", json);
        }

        [Fact]
        public void Constructor_Throws_WhenNoMappedProperties()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                new XurrentObjectConverter<MockInvalidEntity>());

            Assert.Contains("[XurrentField]", ex.Message);
        }

        private class MockInvalidEntity
        {
            public string? WithoutXurrentField { get; set; }
        }
    }
}
