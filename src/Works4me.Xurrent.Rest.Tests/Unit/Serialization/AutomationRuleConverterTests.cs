using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public sealed class AutomationRuleConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public AutomationRuleConverterTests()
        {
            _options = SerializationConfiguration.CreateJsonOptions();
        }

        [Fact]
        public void Read_MapsKnownFields_SkipsUnknownFields_AndSkipsGenericWhenNotString()
        {
            string json = "{\"name\":\"Rule A\", \"disabled\": true, \"generic\": 123, \"unknown_field\": \"ignored\" }";

            AutomationRule result = JsonSerializer.Deserialize<AutomationRule>(json, _options)!;

            Assert.NotNull(result);
            Assert.Equal("Rule A", result.Name);
            Assert.True(result.Disabled);
            Assert.Null(result.Generic);
        }

        [Fact]
        public void Read_SetsGeneric_WhenGenericIsString()
        {
            string json = "{\"name\": \"Rule B\", \"disabled\": false, \"generic\": \"some-value\"}";

            AutomationRule result = JsonSerializer.Deserialize<AutomationRule>(json, _options)!;

            Assert.NotNull(result);
            Assert.Equal("Rule B", result.Name);
            Assert.False(result.Disabled);
            Assert.Equal("some-value", result.Generic);
        }

        [Fact]
        public void Write_ShouldSerializeMappedFields_AndIncludeNullFields()
        {
            AutomationRule value = new()
            {
                Name = "Rule A",
                Disabled = true,
                Generic = "some-value",
                WorkflowTask = new(123)
            };

            string json = JsonSerializer.Serialize(value, _options);

            using (JsonDocument document = JsonDocument.Parse(json))
            {
                JsonElement root = document.RootElement;

                Assert.Equal(JsonValueKind.Object, root.ValueKind);

                Assert.Equal("Rule A", root.GetProperty("name").GetString());
                Assert.True(root.GetProperty("disabled").GetBoolean());
                Assert.Equal("some-value", root.GetProperty("generic").GetString());

                Assert.True(root.TryGetProperty("position", out JsonElement positionElement));
                Assert.Equal(JsonValueKind.Null, positionElement.ValueKind);

                JsonElement taskTemplateElement = root.GetProperty("task");
                Assert.Equal(123, taskTemplateElement.GetProperty("id").GetInt32());
            }
        }
    }
}
