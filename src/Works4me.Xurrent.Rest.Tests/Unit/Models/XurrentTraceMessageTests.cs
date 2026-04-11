using System;
using System.Net;
using System.Text.Json;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Models
{
    public sealed class XurrentTraceMessageTests
    {
        [Fact]
        public void Serialize_UsesExpectedJsonPropertyNames()
        {
            XurrentTraceMessage message = new()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Method = "POST",
                Uri = new Uri("https://example.test/api/people"),
                Content = "{\"name\":\"john\"}",
                AccountId = "acc-1",
                ResponseCode = (HttpStatusCode)429,
                RetryAfterInMilliseconds = 1500,
                ResponseTimeInMilliseconds = 250
            };

            string json = JsonSerializer.Serialize(message);

            Assert.Contains("\"id\":\"11111111-1111-1111-1111-111111111111\"", json, StringComparison.Ordinal);
            Assert.Contains("\"method\":\"POST\"", json, StringComparison.Ordinal);
            Assert.Contains("\"uri\":\"https://example.test/api/people\"", json, StringComparison.Ordinal);
            Assert.Contains("\"content\":\"{\\u0022name\\u0022:\\u0022john\\u0022}\"", json, StringComparison.Ordinal);
            Assert.Contains("\"account_id\":\"acc-1\"", json, StringComparison.Ordinal);
            Assert.Contains("\"response_code\":429", json, StringComparison.Ordinal);
            Assert.Contains("\"retry_after_in_ms\":1500", json, StringComparison.Ordinal);
            Assert.Contains("\"response_time_in_ms\":250", json, StringComparison.Ordinal);
        }

        [Fact]
        public void Deserialize_PopulatesAllProperties()
        {
            string json =
                "{" +
                "\"id\":\"11111111-1111-1111-1111-111111111111\"," +
                "\"method\":\"GET\"," +
                "\"uri\":\"https://example.test/api/people\"," +
                "\"content\":\"payload\"," +
                "\"account_id\":\"acc-2\"," +
                "\"response_code\":200," +
                "\"retry_after_in_ms\":null," +
                "\"response_time_in_ms\":100" +
                "}";

            XurrentTraceMessage message =
                JsonSerializer.Deserialize<XurrentTraceMessage>(json)!;

            Assert.Equal(Guid.Parse("11111111-1111-1111-1111-111111111111"), message.Id);
            Assert.Equal("GET", message.Method);
            Assert.Equal(new Uri("https://example.test/api/people"), message.Uri);
            Assert.Equal("payload", message.Content);
            Assert.Equal("acc-2", message.AccountId);
            Assert.Equal(HttpStatusCode.OK, message.ResponseCode);
            Assert.Null(message.RetryAfterInMilliseconds);
            Assert.Equal(100, message.ResponseTimeInMilliseconds);
        }

        [Fact]
        public void Serialize_WithNullProperties_EmitsNullValues()
        {
            XurrentTraceMessage message = new();

            string json = JsonSerializer.Serialize(message);

            Assert.Contains("\"id\":null", json, StringComparison.Ordinal);
            Assert.Contains("\"method\":null", json, StringComparison.Ordinal);
            Assert.Contains("\"uri\":null", json, StringComparison.Ordinal);
            Assert.Contains("\"content\":null", json, StringComparison.Ordinal);
            Assert.Contains("\"account_id\":null", json, StringComparison.Ordinal);
            Assert.Contains("\"response_code\":null", json, StringComparison.Ordinal);
            Assert.Contains("\"retry_after_in_ms\":null", json, StringComparison.Ordinal);
            Assert.Contains("\"response_time_in_ms\":null", json, StringComparison.Ordinal);
        }
    }
}
