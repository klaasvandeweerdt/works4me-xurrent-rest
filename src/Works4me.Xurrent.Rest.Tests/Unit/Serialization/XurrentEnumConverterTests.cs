using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public class XurrentEnumConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public XurrentEnumConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new XurrentEnumConverter<ConfigurationItemStatus>());
        }

        [Theory]
        [InlineData("\"in_stock\"", ConfigurationItemStatus.InStock)]
        [InlineData("\"in_production\"", ConfigurationItemStatus.InProduction)]
        public void Read_Parses_ValidEnumStrings(string json, ConfigurationItemStatus expected)
        {
            ConfigurationItemStatus result = JsonSerializer.Deserialize<ConfigurationItemStatus>(json, _options);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(ConfigurationItemStatus.InStock, "\"in_stock\"")]
        [InlineData(ConfigurationItemStatus.InProduction, "\"in_production\"")]
        public void Write_Serializes_EnumToString(ConfigurationItemStatus value, string expectedJson)
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
        public void Read_ThrowsOnNull()
        {
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<EnumWithoutXurrentEnumAttribute>("null", _options));
        }

        private enum EnumWithoutXurrentEnumAttribute
        {
            Value1 = 1
        }
    }
}
