using System;
using System.Globalization;
using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Works4me.Xurrent.Rest.Utilities;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public class ISO8601TimestampConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public ISO8601TimestampConverterTests()
        {
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new ISO8601TimestampConverter());
        }

        [Fact]
        public void Read_Parses_StandardISO8601Timestamp()
        {
            DateTime expected = new(2024, 05, 01, 14, 30, 00);
            string json = $"\"{expected.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture)}\"";

            DateTime result = JsonSerializer.Deserialize<DateTime>(json, _options);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("best_effort", nameof(SpecialTimestamps.BestEffort))]
        [InlineData("no_target", nameof(SpecialTimestamps.NoTarget))]
        [InlineData("clock_stopped", nameof(SpecialTimestamps.ClockStopped))]
        public void Read_Parses_SpecialTimestamps(string input, string expectedProperty)
        {
            string json = $"\"{input}\"";

            DateTime expected = expectedProperty switch
            {
                nameof(SpecialTimestamps.BestEffort) => SpecialTimestamps.BestEffort.Value,
                nameof(SpecialTimestamps.NoTarget) => SpecialTimestamps.NoTarget.Value,
                nameof(SpecialTimestamps.ClockStopped) => SpecialTimestamps.ClockStopped.Value,
                _ => throw new InvalidOperationException()
            };

            DateTime result = JsonSerializer.Deserialize<DateTime>(json, _options);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Read_Throws_ForUnknownToken()
        {
            string json = "\"unknown_token\"";

            JsonException exception = Assert.Throws<JsonException>(() =>
                JsonSerializer.Deserialize<DateTime>(json, _options));

            Assert.Contains("Unrecognized timestamp token", exception.Message);
        }

        [Fact]
        public void Write_Serializes_StandardTimestamp()
        {
            DateTime dt = new(2024, 05, 01, 14, 30, 00);

            string json = JsonSerializer.Serialize(dt, _options);

            DateTime result = JsonSerializer.Deserialize<DateTime>(json, _options);

            Assert.Equal(dt, result);
        }

        [Theory]
        [InlineData(nameof(SpecialTimestamps.BestEffort), "best_effort")]
        [InlineData(nameof(SpecialTimestamps.NoTarget), "no_target")]
        [InlineData(nameof(SpecialTimestamps.ClockStopped), "clock_stopped")]
        public void Write_Serializes_SpecialTimestamps(string specialProperty, string expectedText)
        {
            DateTime dt = specialProperty switch
            {
                nameof(SpecialTimestamps.BestEffort) => SpecialTimestamps.BestEffort.Value,
                nameof(SpecialTimestamps.NoTarget) => SpecialTimestamps.NoTarget.Value,
                nameof(SpecialTimestamps.ClockStopped) => SpecialTimestamps.ClockStopped.Value,
                _ => throw new InvalidOperationException()
            };

            string json = JsonSerializer.Serialize(dt, _options);

            Assert.Equal($"\"{expectedText}\"", json);
        }
    }
}
