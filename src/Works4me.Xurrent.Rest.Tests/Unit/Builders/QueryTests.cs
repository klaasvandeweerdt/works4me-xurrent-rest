using System;
using System.Collections.Generic;
using System.Globalization;
using Works4me.Xurrent.Rest.Builders;
using Works4me.Xurrent.Rest.Utilities;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Builders
{
    public sealed class QueryTests
    {
        [Fact]
        public void WithId_WhenCalledTwice_Throws()
        {
            PersonQuery query = new();

            query.WithId(1);

            XurrentQueryException exception = Assert.Throws<XurrentQueryException>(() => query.WithId(2));
            Assert.Contains("may only be called once", exception.Message, StringComparison.Ordinal);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WithId_WhenInvalid_Throws(long id)
        {
            PersonQuery query = new();

            XurrentQueryException exception = Assert.Throws<XurrentQueryException>(() => query.WithId(id));
            Assert.Contains("must be greater than zero", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public void ItemsPerRequest_WhenOutOfRange_Throws()
        {
            PersonQuery query = new();

            Assert.Throws<XurrentQueryException>(() => query.ItemsPerRequest(0));
            Assert.Throws<XurrentQueryException>(() => query.ItemsPerRequest(101));
        }

        [Fact]
        public void ItemsPerRequest_WhenValid_SetsValue()
        {
            PersonQuery query = new();

            query.ItemsPerRequest(25);

            IQuery asQuery = query;
            Assert.Equal(25, asQuery.ItemsPerRequest);
        }

        [Fact]
        public void PredefinedFilter_Enum_WhenCalledTwice_Throws()
        {
            PersonQuery query = new();

            query.PredefinedFilter(Person.PredefinedFilter.Enabled);

            XurrentQueryException exception = Assert.Throws<XurrentQueryException>(() => query.PredefinedFilter(Person.PredefinedFilter.Enabled));
            Assert.Contains("may only be called once", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public void PredefinedFilter_String_WhenCalledTwice_Throws()
        {
            PersonQuery query = new();

            query.PredefinedFilter("enabled");

            XurrentQueryException exception = Assert.Throws<XurrentQueryException>(() => query.PredefinedFilter("enabled"));
            Assert.Contains("may only be called once", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public void OrderBy_Enum_Ascending_AddsField()
        {
            PersonQuery query = new();

            query.OrderBy(Person.OrderField.Name, SortOrder.Ascending);

            IQuery asQuery = query;
            Assert.Contains("name", asQuery.OrderBy);
        }

        [Fact]
        public void OrderBy_Enum_Descending_PrefixesMinus()
        {
            PersonQuery query = new();

            query.OrderBy(Person.OrderField.Name, SortOrder.Descending);

            IQuery asQuery = query;
            Assert.Contains("-name", asQuery.OrderBy);
        }

        [Fact]
        public void OrderBy_String_InvalidField_Throws()
        {
            PersonQuery query = new();

            Assert.Throws<XurrentQueryException>(() => query.OrderBy("does_not_exist", SortOrder.Ascending));
        }

        [Fact]
        public void Where_StringValue_EscapesValue()
        {
            PersonQuery query = new();

            query.Where(Person.FilterField.Name, FilterOperator.Equality, "a b");

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("name=a%20b", filters);
        }

        [Fact]
        public void Where_DateTime_UsesInvariantAndEscapes()
        {
            PersonQuery query = new();
            DateTime value = new(2020, 01, 02, 03, 04, 05, DateTimeKind.Utc);

            query.Where(Person.FilterField.CreatedAt, FilterOperator.Equality, value);

            string formatted = value.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture);
            string expected = "created_at=" + Uri.EscapeDataString(formatted);

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains(expected, filters);
        }

        [Fact]
        public void Where_DateTimeRange_GreaterThanAndLessThan_FormatsCorrectly()
        {
            PersonQuery query = new();
            DateTime value1 = new(2020, 01, 01, 0, 0, 0, DateTimeKind.Utc);
            DateTime value2 = new(2020, 01, 02, 0, 0, 0, DateTimeKind.Utc);

            query.Where(Person.FilterField.CreatedAt, FilterOperator.GreaterThanAndLessThan, value1, value2);

            string v1 = Uri.EscapeDataString(value1.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture));
            string v2 = Uri.EscapeDataString(value2.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture));

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("created_at=>" + v1 + "<" + v2, filters);
        }

        [Fact]
        public void Where_Record_WhenNull_Throws()
        {
            PersonQuery query = new();

            Assert.Throws<ArgumentNullException>(() => query.Where(Person.FilterField.Manager, FilterOperator.Equality, (IRecord)null!));
        }

        [Fact]
        public void Where_Record_UsesRecordId()
        {
            PersonQuery query = new();
            Person record = new(123);

            query.Where(Person.FilterField.Manager, FilterOperator.Equality, record);

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("manager=123", filters);
        }

        [Fact]
        public void Where_Bool_UsesLowercaseTrueFalse()
        {
            PersonQuery query = new();

            query.Where(Person.FilterField.Disabled, FilterOperator.Equality, true);
            query.Where(Person.FilterField.Disabled, FilterOperator.Equality, false);

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("disabled=true", filters);
            Assert.Contains("disabled=false", filters);
        }

        [Fact]
        public void Where_In_WithIntegers_JoinsWithComma()
        {
            PersonQuery query = new();

            query.Where(Person.FilterField.Id, FilterOperator.In, 1, 2, 3);

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("id=1,2,3", filters);
        }

        [Fact]
        public void Where_NotIn_WithLongs_PrefixesBangAndJoins()
        {
            PersonQuery query = new();

            query.Where(Person.FilterField.Id, FilterOperator.NotIn, 10L, 11L);

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("id=!10,11", filters);
        }

        [Fact]
        public void Where_Negation_FormatsAsEqualsBangValue()
        {
            PersonQuery query = new();

            query.Where(Person.FilterField.Name, FilterOperator.Negation, "john");

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("name=!john", filters);
        }

        [Fact]
        public void Where_Present_FormatsAsEqualsBang()
        {
            PersonQuery query = new();

            query.Where(Person.FilterField.PrimaryEmail, FilterOperator.Present);

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("primary_email=!", filters);
        }

        [Fact]
        public void Where_Empty_FormatsAsTrailingEquals()
        {
            PersonQuery query = new();

            query.Where(Person.FilterField.PrimaryEmail, FilterOperator.Empty);

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("primary_email=", filters);
        }

        [Fact]
        public void Where_FieldIsEmptyString_Throws()
        {
            PersonQuery query = new();

            Assert.Throws<XurrentQueryException>(() => query.Where(string.Empty, FilterOperator.Equality, "x"));
        }

        [Fact]
        public void Where_OperatorCardinalityMismatch_Throws()
        {
            PersonQuery query = new();

            Assert.Throws<XurrentQueryException>(() => query.Where(Person.FilterField.Name, FilterOperator.GreaterThan));
        }

        [Fact]
        public void Where_EnumValues_In_AddsSerializedEnumValues()
        {
            PersonQuery query = new();

            query.Where(Person.FilterField.Roles, FilterOperator.In, Person.PredefinedFilter.Disabled, Person.PredefinedFilter.Enabled);

            IReadOnlyList<string> filters = query.Filters;
            Assert.Contains("roles=disabled,enabled", filters);
        }

        [Fact]
        public void Select_Enum_AddsSerializedValue()
        {
            PersonQuery query = new();

            query.Select(Person.Field.Name);

            IQuery asQuery = query;
            Assert.Contains("name", asQuery.Fields);
        }

        [Fact]
        public void Select_Enum_IgnoredField_IsNotAdded()
        {
            PersonQuery query = new();

            query.Select(Person.Field.InformationAttachments);

            IQuery asQuery = query;
            Assert.DoesNotContain("information_attachments", asQuery.Fields);
        }

        [Fact]
        public void Select_String_ValidField_AddsRawFieldName()
        {
            PersonQuery query = new();

            query.Select("name");

            IQuery asQuery = query;
            Assert.Contains("name", asQuery.Fields);
        }

        [Fact]
        public void Select_String_IgnoredField_IsNotAdded()
        {
            PersonQuery query = new();

            query.Select("information_attachments");

            IQuery asQuery = query;
            Assert.DoesNotContain("information_attachments", asQuery.Fields);
        }

        [Fact]
        public void Select_String_InvalidField_Throws()
        {
            PersonQuery query = new();

            Assert.Throws<XurrentQueryException>(() => query.Select("does_not_exist"));
        }

        [Fact]
        public void Select_Enum_WhenEnumValueHasNoXurrentEnumAttribute_Throws()
        {
            BadFieldQuery query = new();

            Assert.Throws<XurrentQueryException>(() => query.Select(EnumWithoutXurrentEnumAttribute.Value1));
        }

        [Fact]
        public void SelectAll_IncludesNonIgnored_ExcludesIgnored()
        {
            PersonQuery query = new();

            query.SelectAll();

            IQuery asQuery = query;

            Assert.Contains("name", asQuery.Fields);
            Assert.DoesNotContain("information_attachments", asQuery.Fields);
            Assert.DoesNotContain("nodeID", asQuery.Fields);
        }

        private enum EnumWithoutXurrentEnumAttribute
        {
            Value1 = 1
        }

        private sealed class BadFieldQuery : Query<BadFieldQuery, Person.PredefinedFilter, EnumWithoutXurrentEnumAttribute, Person.FilterField, Person.OrderField>
        {
        }
    }
}
