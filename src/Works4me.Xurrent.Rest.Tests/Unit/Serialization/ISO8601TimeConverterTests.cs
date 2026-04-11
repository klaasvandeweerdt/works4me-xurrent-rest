using System;
using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public class ISO8601TimeConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public ISO8601TimeConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new ISO8601TimeConverter());
        }

        [Theory]
        [InlineData("00:00", 0, 0)]
        [InlineData("02:30", 2, 30)]
        [InlineData("12:45", 12, 45)]
        [InlineData("24:00", 24, 0)]
        public void Read_ParsesValid_Format(string jsonTime, int expectedHours, int expectedMinutes)
        {
            string json = $"\"{jsonTime}\"";

            TimeSpan result = JsonSerializer.Deserialize<TimeSpan>(json, _options);

            Assert.Equal(TimeSpan.FromHours(expectedHours).Add(TimeSpan.FromMinutes(expectedMinutes)), result);
        }

        [Fact]
        public void Read_ParsesFull_ISO8601Format()
        {
            TimeSpan expected = new(5, 15, 30);
            string json = $"\"{expected:c}\"";

            TimeSpan result = JsonSerializer.Deserialize<TimeSpan>(json, _options);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Read_Throws_WhenTokenTypeIsNotString()
        {
            byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(123);

            Utf8JsonReader reader = new(jsonBytes);

            reader.Read();

            ISO8601TimeConverter converter = new();

            try
            {
                converter.Read(ref reader, typeof(TimeSpan), _options);
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
        public void Write_SerializesTimeSpan(string hours, string minutes, string expectedJsonTime)
        {
            TimeSpan time = new(int.Parse(hours), int.Parse(minutes), 0);

            string json = JsonSerializer.Serialize(time, _options);

            Assert.Equal(expectedJsonTime, json);
        }
    }
}
