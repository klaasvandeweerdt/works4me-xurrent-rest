using System;
using System.Collections.Generic;
using Works4me.Xurrent.Rest.Utilities;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Utilities
{
    public sealed class ConstantsTests
    {
        [Fact]
        public void Constants_Values_AreStable()
        {
            Assert.Equal("x-xurrent-account", Constants.AccountHeader);
            Assert.Equal("application/json", Constants.ApplicationJsonMediaType);
            Assert.Equal("yyyy-MM-dd'T'HH:mm:ssK", Constants.DateTimeFormat);
        }

        [Fact]
        public void Constants_DefaultFields_AreStable()
        {
            HashSet<string> expected = new HashSet<string>(StringComparer.Ordinal)
            {
                "account",
                "id",
                "nodeID"
            };

            Assert.NotNull(Constants.DefaultFields);
            Assert.Equal(expected, Constants.DefaultFields);
        }
    }
}
