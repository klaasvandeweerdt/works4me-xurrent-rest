using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public sealed class DecimalNullableConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public DecimalNullableConverterTests()
        {
            _options = new();
            _options.Converters.Add(new DecimalNullableConverter());
        }

        [Fact]
        public void Read_ShouldReturnNull_WhenJsonIsNull()
        {
            string json = "null";

            decimal? result = JsonSerializer.Deserialize<decimal?>(json, _options);

            Assert.Null(result);
        }

        [Fact]
        public void Write_ShouldSerializeNullAsJsonNull()
        {
            decimal? value = null;

            string json = JsonSerializer.Serialize(value, _options);

            Assert.Equal("null", json);
        }
    }
}
