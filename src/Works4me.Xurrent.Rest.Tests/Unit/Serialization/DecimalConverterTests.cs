using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public sealed class DecimalConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public DecimalConverterTests()
        {
            _options = new();
            _options.Converters.Add(new DecimalConverter());
        }

        [Fact]
        public void Read_ShouldParseDecimalFromString()
        {
            string json = "\"12.34\"";

            decimal result = JsonSerializer.Deserialize<decimal>(json, _options);

            Assert.Equal(12.34m, result);
        }

        [Fact]
        public void Write_ShouldSerializeDecimalAsString()
        {
            decimal value = 12.34m;

            string json = JsonSerializer.Serialize(value, _options);

            Assert.Equal("\"12.34\"", json);
        }
    }
}
