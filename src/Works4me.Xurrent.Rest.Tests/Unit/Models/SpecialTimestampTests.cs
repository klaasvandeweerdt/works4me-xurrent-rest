using System;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Models
{
    public sealed class SpecialTimestampTests
    {
        [Fact]
        public void Constructor_Sets_Properties()
        {
            DateTime dt = new(2024, 5, 1, 12, 0, 0);
            SpecialTimestamp st = new("example", dt);

            Assert.Equal("example", st.Text);
            Assert.Equal(dt, st.Value);
        }

        [Fact]
        public void Equals_ReturnsTrue_ForEqualInstances()
        {
            DateTime dt = DateTime.UtcNow;
            SpecialTimestamp st1 = new("token", dt);
            SpecialTimestamp st2 = new("token", dt);

            Assert.True(st1.Equals(st2));
            Assert.True(st1 == st2);
            Assert.False(st1 != st2);
            Assert.True(st1.Equals((object)st2));
            Assert.Equal(st1.GetHashCode(), st2.GetHashCode());
        }

        [Fact]
        public void Equals_ReturnsFalse_ForDifferentInstances()
        {
            SpecialTimestamp st1 = new("token1", new DateTime(2024, 1, 1));
            SpecialTimestamp st2 = new("token2", new DateTime(2024, 1, 1));
            SpecialTimestamp st3 = new("token1", new DateTime(2023, 1, 1));

            Assert.False(st1.Equals(st2));
            Assert.False(st1.Equals(st3));
            Assert.False(st1 == st2);
            Assert.True(st1 != st2);
        }

        [Fact]
        public void SpecialTimestamps_Values_AreCorrect()
        {
            Assert.Contains(SpecialTimestamps.BestEffort, SpecialTimestamps.Values);
            Assert.Contains(SpecialTimestamps.NoTarget, SpecialTimestamps.Values);
            Assert.Contains(SpecialTimestamps.ClockStopped, SpecialTimestamps.Values);
            Assert.Equal(3, SpecialTimestamps.Values.Count);
        }

        [Fact]
        public void SpecialTimestamps_TextToValue_Matches()
        {
            Assert.True(SpecialTimestamps.TextToValue.TryGetValue("best_effort", out DateTime bestEffort));
            Assert.Equal(SpecialTimestamps.BestEffort.Value, bestEffort);

            Assert.True(SpecialTimestamps.TextToValue.TryGetValue("no_target", out DateTime noTarget));
            Assert.Equal(SpecialTimestamps.NoTarget.Value, noTarget);

            Assert.True(SpecialTimestamps.TextToValue.TryGetValue("clock_stopped", out DateTime clockStopped));
            Assert.Equal(SpecialTimestamps.ClockStopped.Value, clockStopped);
        }

        [Fact]
        public void SpecialTimestamps_ValueToText_Matches()
        {
            Assert.True(SpecialTimestamps.ValueToText.TryGetValue(SpecialTimestamps.BestEffort.Value, out string? text1));
            Assert.Equal("best_effort", text1);

            Assert.True(SpecialTimestamps.ValueToText.TryGetValue(SpecialTimestamps.NoTarget.Value, out string? text2));
            Assert.Equal("no_target", text2);

            Assert.True(SpecialTimestamps.ValueToText.TryGetValue(SpecialTimestamps.ClockStopped.Value, out string? text3));
            Assert.Equal("clock_stopped", text3);
        }
    }
}
