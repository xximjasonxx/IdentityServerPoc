using System.Collections.Generic;
using System.Linq;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServerWeb
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
            {
                new ApiResource("dataApi", "Data Api")
                {
                    Scopes =
                    {
                        "read"
                    },
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
            {
                new ApiScope("read", "Read Data")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ImplicitAndClientCredentials,
                    ClientName = "DataClient",
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        "read"
                    },
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44370/Login/Callback"
                    }
                }
            };
    }
}