// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using Duende.IdentityServer.Models;

namespace Extensions;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("internal.read"),
            new ApiScope("internal.write"),
            new ApiScope("ids.read"),
            new ApiScope("ids.write"),
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new [] {
            new ApiResource("internal")
            {
                Scopes = new List<string> { "internal.read", "internal.write" },
                ApiSecrets = new List<Secret> { new Secret("InternalScopeSecret".Sha256())}
            },
            new ApiResource("ids")
            {
                Scopes = new List<string> { "ids.read", "ids.write" },
                ApiSecrets = new List<Secret> { new Secret("IdsScopeSecret".Sha256())}
            }
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "identity.server.api",
                ClientName = "Identity Server API Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "ids.read", "ids.write" }
            },
            new Client
            {
                ClientId = "internal.api",
                ClientName = "Internal API Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "internal.read", "internal.write" }
            },
            new Client
            {
                ClientId = "internal.ui",
                ClientName = "Internal MVC Client",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    
                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:5444/home/signin" },
                FrontChannelLogoutUri = "https://localhost:5444/home/signout",
                PostLogoutRedirectUris = { "https://localhost:5444/home/callback" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "internal.read" }
            },
        };
}