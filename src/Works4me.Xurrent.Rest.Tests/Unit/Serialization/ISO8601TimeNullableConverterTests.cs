using System;
using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public class ISO8601TimeNullableConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public ISO8601TimeNullableConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new ISO8601TimeNullableConverter());
        }

        [Fact]
        public void Read_ReturnsNull_WhenTokenTypeIsNull()
        {
            string json = "null";

            TimeSpan? result = JsonSerializer.Deserialize<TimeSpan?>(json, _options);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("00:00", 0, 0)]
        [InlineData("02:30", 2, 30)]
        [InlineData("12:45", 12, 45)]
        [InlineData("24:00", 24, 0)]
        public void Read_ParsesValid_Format(string jsonTime, int expectedHours, int expectedMinutes)
        {
            string json = $"\"{jsonTime}\"";

            TimeSpan? result = JsonSerializer.Deserialize<TimeSpan?>(json, _options);

            Assert.NotNull(result);
            Assert.Equal(
                TimeSpan.FromHours(expectedHours).Add(TimeSpan.FromMinutes(expectedMinutes)),
                result.Value);
        }

        [Fact]
        public void Read_ParsesFull_ISO8601Format()
        {
            TimeSpan expected = new(5, 15, 30);
            string json = $"\"{expected:c}\"";

            TimeSpan? result = JsonSerializer.Deserialize<TimeSpan?>(json, _options);

            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void Read_Throws_WhenTokenTypeIsNotStringOrNull()
        {
            byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(123);
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read();
            var converter = new ISO8601TimeNullableConverter();

            try
            {
                converter.Read(ref reader, typeof(TimeSpan?), _options);
                Assert.Fail("Expected JsonException was not thrown.");
            }
            catch (JsonException ex)
            {
                Assert.Contains("Expected string for TimeSpan", ex.Message);
            }
        }

        [Theory]
        [InlineData("0", "0", "\"00:00\"")]
        [InlineData("2", "5", "\"02:05\"")]
        [InlineData("12", "45", "\"12:45\"")]
        [InlineData("23", "60", "\"24:00\"")]
        public void Write_Serializes_TimeSpan(string hours, string minutes, string expectedJsonTime)
        {
            TimeSpan? time = new(int.Parse(hours), int.Parse(minutes), 0);

            string json = JsonSerializer.Serialize(time, _options);

            Assert.Equal(expectedJsonTime, json);
        }

        [Fact]
        public void Write_WritesNull_WhenValueIsNull()
        {
            TimeSpan? time = null;

            string json = JsonSerializer.Serialize(time, _options);

            Assert.Equal("null", json);
        }
    }
}
