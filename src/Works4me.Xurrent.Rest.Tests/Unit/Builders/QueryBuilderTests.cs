using System;
using System.Collections.Generic;
using Works4me.Xurrent.Rest.Builders;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Builders
{
    public sealed class QueryBuilderTests
    {
        [Fact]
        public void BuildQuery_WhenEndpointIsNull_Throws()
        {
            PersonQuery query = new();

            ArgumentNullException exception =
                Assert.Throws<ArgumentNullException>(() =>
                    QueryBuilder.BuildQuery<Person>(null!, null, null, query, 10));

            Assert.Equal("endpointUrl", exception.ParamName);
        }

        [Fact]
        public void BuildQuery_WhenQueryIsNull_Throws()
        {
            Uri endpointUrl = new("https://example.test/api/people/");

            ArgumentNullException exception =
                Assert.Throws<ArgumentNullException>(() =>
                    QueryBuilder.BuildQuery<Person>(endpointUrl, null, null, null!, 10));

            Assert.Equal("query", exception.ParamName);
        }

        [Theory]
        [InlineData(null, "parents")]
        [InlineData(123L, null)]
        public void BuildQuery_WhenParentArgumentsAreInconsistent_Throws(long? parentId, string? parentPath)
        {
            Uri endpointUrl = new("https://example.test/api/people/");
            PersonQuery query = new();

            XurrentQueryException exception =
                Assert.Throws<XurrentQueryException>(() =>
                    QueryBuilder.BuildQuery<Person>(endpointUrl, parentId, parentPath, query, 10));

            Assert.Contains("must be set together", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public void BuildQuery_WhenParentSpecified_PrependsParentPath()
        {
            Uri endpointUrl = new("https://example.test/api/people/");
            PersonQuery query = new();

            Uri uri = QueryBuilder.BuildQuery<Person>(endpointUrl, 42, "parents", query, 10);

            Assert.Equal("https://example.test/api/people/42/parents/?per_page=10", uri.ToString());
        }

        [Fact]
        public void BuildQuery_WhenIdSpecified_AppendsIdAndNoQueryString()
        {
            Uri endpointUrl = new("https://example.test/api/people/");
            PersonQuery query = new();

            query.WithId(99);

            Uri uri = QueryBuilder.BuildQuery<Person>(endpointUrl, null, null, query, 10);

            Assert.Equal( "https://example.test/api/people/99/", uri.ToString());
        }

        [Fact]
        public void BuildQuery_WhenPredefinedFilterSpecified_AppendsAsPath()
        {
            Uri endpointUrl = new("https://example.test/api/people/");
            PersonQuery query = new();

            query.PredefinedFilter(Person.PredefinedFilter.Enabled);

            Uri uri = QueryBuilder.BuildQuery<Person>(endpointUrl, null, null, query, 10);

            Assert.StartsWith("https://example.test/api/people/enabled/?per_page=10", uri.ToString(), StringComparison.Ordinal);
        }

        [Fact]
        public void BuildQuery_AddsPerPage_FromQuery()
        {
            Uri endpointUrl = new("https://example.test/api/people/");
            PersonQuery query = new();

            query.ItemsPerRequest(25);

            Uri uri = QueryBuilder.BuildQuery<Person>(endpointUrl, null, null, query, 10);

            Assert.Equal("25", GetQueryParameter(uri, "per_page"));
        }

        [Fact]
        public void BuildQuery_UsesDefaultPerPage_WhenNotSpecified()
        {
            Uri endpointUrl = new("https://example.test/api/people/");
            PersonQuery query = new();

            Uri uri = QueryBuilder.BuildQuery<Person>(endpointUrl, null, null, query, 15);

            Assert.Equal("15", GetQueryParameter(uri, "per_page"));
        }

        [Fact]
        public void BuildQuery_WhenFieldsProvided_AddsFieldsParameter()
        {
            Uri endpointUrl = new("https://example.test/api/people/");
            PersonQuery query = new();

            query.Select(Person.Field.Name);
            query.Select(Person.Field.PrimaryEmail);

            Uri uri = QueryBuilder.BuildQuery<Person>(endpointUrl, null, null, query, 10);

            Assert.Equal("name,primary_email", GetQueryParameter(uri, "fields"));
        }

        [Fact]
        public void BuildQuery_WhenFiltersProvided_Deduplicates()
        {
            Uri endpointUrl = new("https://example.test/api/people/");
            PersonQuery query = new();

            query.Where(Person.FilterField.Name, FilterOperator.Equality, "john");
            query.Where(Person.FilterField.Name, FilterOperator.Equality, "john");
            query.Where(Person.FilterField.Disabled, FilterOperator.Equality, true);

            Uri uri = QueryBuilder.BuildQuery<Person>(endpointUrl, null, null, query, 10);

            Dictionary<string, string> map = ParseQuery(uri);

            Assert.Equal("john", map["name"]);
            Assert.Equal("true", map["disabled"]);
        }

        [Fact]
        public void BuildQuery_WhenNoOrderBy_DoesNotAddSort()
        {
            Uri endpointUrl = new("https://example.test/api/people/");
            PersonQuery query = new();

            Uri uri = QueryBuilder.BuildQuery<Person>(endpointUrl, null, null, query, 10);

            Assert.Null(GetQueryParameter(uri, "sort"));
        }

        [Fact]
        public void BuildMutation_WhenSegment_ComposesCorrectly()
        {
            Uri endpointUrl = new("https://example.test/api/people/");

            Uri uri = QueryBuilder.BuildMutation(endpointUrl, null, null, 42, "parents");

            Assert.Equal("https://example.test/api/people/42/parents/", uri.ToString());
        }

        [Fact]
        public void BuildMutation_WhenParentAndIdAndSegment_ComposesCorrectly()
        {
            Uri endpointUrl = new("https://example.test/api/people/");

            Uri uri = QueryBuilder.BuildMutation(endpointUrl, 10, "disable", 42, "parents");

            Assert.Equal("https://example.test/api/people/42/parents/10/disable/", uri.ToString());
        }

        [Theory]
        [InlineData(null, "parents")]
        [InlineData(123L, null)]
        public void BuildMutation_WhenParentArgumentsAreInconsistent_Throws(long? parentId, string? parentPath)
        {
            Uri endpointUrl = new("https://example.test/api/people/");

            XurrentQueryException exception =
                Assert.Throws<XurrentQueryException>(() =>
                    QueryBuilder.BuildMutation(endpointUrl, null, null, parentId, parentPath));

            Assert.Contains("must be set together", exception.Message, StringComparison.Ordinal);
        }

        private static string? GetQueryParameter(Uri uri, string key)
        {
            Dictionary<string, string> map = ParseQuery(uri);
            return map.TryGetValue(key, out string? value) ? value : null;
        }

        private static Dictionary<string, string> ParseQuery(Uri uri)
        {
            Dictionary<string, string> result = new(StringComparer.Ordinal);
            char[] splitCharacters = new char[] { '&' };

            if (string.IsNullOrEmpty(uri.Query))
                return result;

            string[] parts = uri.Query.TrimStart('?').Split(splitCharacters, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                int idx = parts[i].IndexOf('=');
                if (idx < 0)
                {
                    result[Uri.UnescapeDataString(parts[i])] = string.Empty;
                    continue;
                }

#if NETFRAMEWORK
                string key = Uri.UnescapeDataString(parts[i].Substring(0, idx));
                string value = Uri.UnescapeDataString(parts[i].Substring(idx + 1));
#else
                string key = Uri.UnescapeDataString(parts[i][..idx]);
                string value = Uri.UnescapeDataString(parts[i][(idx + 1)..]);
#endif

                result[key] = value;
            }

            return result;
        }
    }
}
