using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AnimalsFriends.Configuration
{
    public static class InMemoryConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
          new List<IdentityResource>
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile()
          };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "testClient",
                    ClientSecrets = new [] { new Secret("test".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "AnimalsFriends"
                    },
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                }
            };
       

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("AnimalsFriends", "Login API")
                {
                    ApiSecrets = { new Secret("testSecret".Sha512()) }
                }
            };
        }
    }
}
