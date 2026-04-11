using System;
using System.Collections.Generic;
using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Serialization
{
    public class SerializationConfigurationTests
    {
        [Fact]
        public void CreateJsonOptions_AddsConverterFactory()
        {
            JsonSerializerOptions options = SerializationConfiguration.CreateJsonOptions();

            Assert.Contains(options.Converters, c => c is XurrentJsonConverterFactory);
        }

        [Fact]
        public void CreateJsonOptions_WithTypeAndFields_AddsConverterFactoryWithTypeAndFields()
        {
            Type type = typeof(string);
            HashSet<string> fields = new() { "field1", "field2" };

            JsonSerializerOptions options = SerializationConfiguration.CreateJsonOptions();

            XurrentJsonConverterFactory? factory = Assert.Single(
                options.Converters, c => c is XurrentJsonConverterFactory) as XurrentJsonConverterFactory;

            Assert.NotNull(factory);
        }

        [Fact]
        public void CreateJsonOptions_Returns_ClonedOptions()
        {
            JsonSerializerOptions first = SerializationConfiguration.CreateJsonOptions();
            JsonSerializerOptions second = SerializationConfiguration.CreateJsonOptions();

            Assert.NotSame(first, second);
        }
    }
}
