using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Works4me.Xurrent.Rest;
using Works4me.Xurrent.Rest.Serialization;
using Xunit;

namespace Works4me.Xurrent.GraphQL.Tests.Unit.Serialization
{
    public class XurrentJsonConverterFactorySpecs
    {
        [Fact]
        public void CanConvert_ReturnsTrue_ForDateTimeAndTimeSpan()
        {
            XurrentJsonConverterFactory factory = new();

            Assert.True(factory.CanConvert(typeof(DateTime)));
            Assert.True(factory.CanConvert(typeof(DateTime?)));
            Assert.True(factory.CanConvert(typeof(TimeSpan)));
            Assert.True(factory.CanConvert(typeof(TimeSpan?)));
        }

        [Fact]
        public void CanConvert_ReturnsTrue_ForDecimals()
        {
            XurrentJsonConverterFactory factory = new();

            Assert.True(factory.CanConvert(typeof(decimal)));
            Assert.True(factory.CanConvert(typeof(decimal?)));
        }

        [Fact]
        public void CanConvert_ReturnsTrue_ForEnums()
        {
            XurrentJsonConverterFactory factory = new();

            Assert.True(factory.CanConvert(typeof(ConfigurationItemStatus)));
            Assert.True(factory.CanConvert(typeof(ConfigurationItemStatus?)));
        }

        [Fact]
        public void CanConvert_ReturnsTrue_ForClassesWithXurrentFields()
        {
            XurrentJsonConverterFactory factory = new();

            Assert.True(factory.CanConvert(typeof(ConfigurationItem)));
        }

        [Fact]
        public void CanConvert_ReturnsFalse_ForOtherTypes()
        {
            XurrentJsonConverterFactory factory = new();

            Assert.False(factory.CanConvert(typeof(string)));
            Assert.False(factory.CanConvert(typeof(int)));
        }

        [Fact]
        public void CreateConverter_ReturnsExpectedConverters()
        {
            XurrentJsonConverterFactory defaultFactory = new();

            Assert.IsType<AuditLineConverter>(defaultFactory.CreateConverter(typeof(AuditLine), new JsonSerializerOptions()));
            Assert.IsType<AutomationRuleConverter>(defaultFactory.CreateConverter(typeof(AutomationRule), new JsonSerializerOptions()));
            Assert.IsType<DecimalConverter>(defaultFactory.CreateConverter(typeof(decimal), new JsonSerializerOptions()));
            Assert.IsType<DecimalNullableConverter>(defaultFactory.CreateConverter(typeof(decimal?), new JsonSerializerOptions()));
            Assert.IsType<ISO8601TimestampConverter>(defaultFactory.CreateConverter(typeof(DateTime), new JsonSerializerOptions()));
            Assert.IsType<ISO8601TimestampNullableConverter>(defaultFactory.CreateConverter(typeof(DateTime?), new JsonSerializerOptions()));
            Assert.IsType<ISO8601TimeConverter>(defaultFactory.CreateConverter(typeof(TimeSpan), new JsonSerializerOptions()));
            Assert.IsType<ISO8601TimeNullableConverter>(defaultFactory.CreateConverter(typeof(TimeSpan?), new JsonSerializerOptions()));

            JsonConverter enumConv = defaultFactory.CreateConverter(typeof(ConfigurationItemStatus), new JsonSerializerOptions());
            Assert.Equal(typeof(XurrentEnumConverter<ConfigurationItemStatus>), enumConv.GetType());

            JsonConverter nullableEnumConv = defaultFactory.CreateConverter(typeof(ConfigurationItemStatus?), new JsonSerializerOptions());
            Assert.Equal(typeof(XurrentEnumNullableConverter<ConfigurationItemStatus>), nullableEnumConv.GetType());

            JsonConverter objectConv = defaultFactory.CreateConverter(typeof(ConfigurationItem), new JsonSerializerOptions());
            Assert.Equal(typeof(XurrentObjectConverter<ConfigurationItem>), objectConv.GetType());
        }

        [Fact]
        public void CreateConverter_Throws_ForUnsupportedType()
        {
            XurrentJsonConverterFactory factory = new();

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                factory.CreateConverter(typeof(string), new JsonSerializerOptions()));

            Assert.Contains("violates the constraint", ex.Message);
        }
    }
}
