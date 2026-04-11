using System;
using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public sealed class AuditLineConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public AuditLineConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new AuditLineConverter());
        }

        [Fact]
        public void Read_ShouldMapAuditedPayloadToData_WhenPayloadAppearsBeforeAuditedProperty()
        {
            string json = "{\"action\":\"update\",\"request\":{\"id\":123,\"subject\":\"Test\"},\"audited\":\"request\"}";

            AuditLine? result = JsonSerializer.Deserialize<AuditLine>(json, _options);

            Assert.NotNull(result);
            Assert.Equal("update", result.Action);
            Assert.Equal("request", result.Audited);

            Assert.True(result.Data.HasValue);

            JsonElement data = result.Data.Value;
            Assert.Equal(123, data.GetProperty("id").GetInt32());
            Assert.Equal("Test", data.GetProperty("subject").GetString());
        }

        [Fact]
        public void Write_ShouldThrowNotSupportedException()
        {
            AuditLine value = new();

            NotSupportedException exception = Assert.Throws<NotSupportedException>(
                delegate
                {
                    JsonSerializer.Serialize(value, _options);
                }
            );

            Assert.Contains("read-only", exception.Message, StringComparison.OrdinalIgnoreCase);
        }
    }
}
