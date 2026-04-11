using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Shared
{
    internal sealed class Client
    {
        private static readonly IConfigurationProvider _secretProvider;
        private static readonly XurrentClient _client;
        private static readonly AuthenticationToken? _authenticationToken;

        public static XurrentClient Get()
        {
            return _client;
        }

        public static string GetConfigValue(string key)
        {
            return _secretProvider.TryGet(key, out string? value) && value is not null ? value : throw new ApplicationException("Unknown configuration value, or null value.");
        }

        static Client()
        {
            _secretProvider = new ConfigurationBuilder().AddUserSecrets<ConnectionSecret>().Build().Providers.First();

            if (!_secretProvider.TryGet("Account", out string? account) || !_secretProvider.TryGet("Token", out string? token) || !_secretProvider.TryGet("ClientId", out string? clientId) || !_secretProvider.TryGet("ClientSecret", out string? clientSecret))
            {
                Assert.Fail("Missing information in the user secret file");
                return;
            }

            if (account is null)
            {
                Assert.Fail("No account value found in the secret file.");
                return;
            }

            if (token is null && (clientId is null || clientSecret is null))
            {
                Assert.Fail("No authentication values found in the secret file.");
                return;
            }

            if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrWhiteSpace(clientSecret))
            {
                _authenticationToken = new AuthenticationToken(clientId!, clientSecret!);
                _client = new(_authenticationToken, account, EnvironmentType.Quality, EnvironmentRegion.EU)
                {
                    MaximumRequestsPerQuery = 5,
                    DefaultItemsPerRequest = 100
                };
            }
            else if (!string.IsNullOrEmpty(token))
            {
                _authenticationToken = new AuthenticationToken(token!);
                _client = new(_authenticationToken, account, EnvironmentType.Quality, EnvironmentRegion.EU)
                {
                    MaximumRequestsPerQuery = 5,
                    DefaultItemsPerRequest = 100
                };
            }
            else
            {
                Assert.Fail("Invalid information in the user secret file");
            }
        }
    }
}
