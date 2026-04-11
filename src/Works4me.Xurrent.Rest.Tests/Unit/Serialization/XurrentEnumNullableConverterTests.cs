using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public class XurrentEnumNullableConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public XurrentEnumNullableConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new XurrentEnumNullableConverter<ConfigurationItemStatus>());
        }

        [Fact]
        public void Read_ReturnsNull_WhenEnumIsNull()
        {
            string json = "null";

            ConfigurationItemStatus? result = JsonSerializer.Deserialize<ConfigurationItemStatus?>(json, _options);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("\"in_stock\"", ConfigurationItemStatus.InStock)]
        [InlineData("\"in_production\"", ConfigurationItemStatus.InProduction)]
        [InlineData("null", null)]
        public void Read_Parses_ValidEnumStrings(string json, ConfigurationItemStatus? expected)
        {
            ConfigurationItemStatus? result = JsonSerializer.Deserialize<ConfigurationItemStatus?>(json, _options);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(ConfigurationItemStatus.InStock, "\"in_stock\"")]
        [InlineData(ConfigurationItemStatus.InProduction, "\"in_production\"")]
        [InlineData(null, "null")]
        public void Write_Serializes_EnumToString(ConfigurationItemStatus? value, string expectedJson)
        {
            string json = JsonSerializer.Serialize(value, _options);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Read_Throws_OnUnknownString()
        {
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<EnumWithoutXurrentEnumAttribute>("\"unknown_value\"", _options));
        }

        [Fact]
        public void Write_WritesNull_WhenEnumIsNull()
        {
            EnumWithoutXurrentEnumAttribute? @enum = null;

            string json = JsonSerializer.Serialize(@enum, _options);

            Assert.Equal("null", json);
        }

        private enum EnumWithoutXurrentEnumAttribute
        {
            Value1 = 1
        }
    }
}
