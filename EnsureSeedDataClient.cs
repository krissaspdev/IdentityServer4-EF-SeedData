using SerwerTozsamosci.Configuration;
using System;
using System.Linq;
using TwentyTwenty.IdentityServer4.EntityFrameworkCore.Entities;

namespace SerwerTozsamosci.Extensions
{
    public static class ContextExtensions
    {
        public static void EnsureSeedScopeData(this ScopeConfigurationContext context)
        {
            if (!context.Scopes.Any())
            {
                var scopes = Scopes.Get();
                foreach (var item in scopes)
                {
                    var newscope = new Scope<System.Guid>
                    {
                        Id = Guid.NewGuid(),
                        AllowUnrestrictedIntrospection = item.AllowUnrestrictedIntrospection,
                        ClaimsRule = item.ClaimsRule,
                        Description = item.Description,
                        DisplayName = item.DisplayName,
                        Emphasize = item.Emphasize,
                        Enabled = item.Enabled,
                        IncludeAllClaimsForUser = item.IncludeAllClaimsForUser,
                        Name = item.Name,
                        Required = item.Required,
                        ShowInDiscoveryDocument = item.ShowInDiscoveryDocument,
                        Type = (int)item.Type,
                        ScopeClaims = item.Claims.Select(x => new ScopeClaim<Guid> {Id = Guid.NewGuid(), Name = x.Name, Description = x.Description, AlwaysIncludeInIdToken = x.AlwaysIncludeInIdToken }).ToList(),
                        ScopeSecrets = item.ScopeSecrets.Select(x => new ScopeSecret<Guid> {Id = Guid.NewGuid(), Description = x.Description, Type = x.Type, Value = x.Value }).ToList()
                    };

                    context.Scopes.Add(newscope);
                    context.SaveChanges();
                }
            }
        }

        public static void EnsureSeedClientData(this ClientConfigurationContext context)
        {
            if (!context.Clients.Any())
            {
                var clients = Clients.Get();
                foreach (var item in clients)
                {
                    var newclient = new Client<System.Guid>
                    {
                        Id = Guid.NewGuid(),
                        AbsoluteRefreshTokenLifetime = item.AbsoluteRefreshTokenLifetime,
                        AccessTokenLifetime = item.AccessTokenLifetime,
                        AccessTokenType = item.AccessTokenType,
                        AllowAccessToAllScopes = item.AllowAccessToAllScopes,
                        AllowAccessTokensViaBrowser = item.AllowAccessTokensViaBrowser,
                        ClientName = string.IsNullOrEmpty(item.ClientName) ? item.ClientId : item.ClientName,
                        LogoUri = item.LogoUri,
                        AlwaysSendClientClaims = item.AlwaysSendClientClaims,
                        RequireConsent = item.RequireConsent,
                        UpdateAccessTokenOnRefresh = item.UpdateAccessTokenClaimsOnRefresh,
                        SlidingRefreshTokenLifetime = item.SlidingRefreshTokenLifetime,
                        RefreshTokenExpiration = item.RefreshTokenExpiration,
                        PrefixClientClaims = item.PrefixClientClaims,
                        Enabled = item.Enabled,
                        RefreshTokenUsage = item.RefreshTokenUsage,
                        LogoutUri = item.LogoutUri,
                        AllowPromptNone = item.AllowPromptNone,
                        AllowRememberConsent = item.AllowRememberConsent,
                        AuthorizationCodeLifetime = item.AuthorizationCodeLifetime,
                        IdentityTokenLifetime = item.IdentityTokenLifetime,
                        ClientId = item.ClientId,
                        ClientUri = item.ClientUri,
                        EnableLocalLogin = item.EnableLocalLogin,
                        IncludeJwtId = item.IncludeJwtId,
                        LogoutSessionRequired = item.LogoutSessionRequired,
                        AllowedCorsOrigins = item.AllowedCorsOrigins.Select(x => new ClientCorsOrigin<Guid> { Id = Guid.NewGuid(), Origin = x }).ToList(),
                        AllowedGrantTypes = item.AllowedGrantTypes.Select(x => new ClientGrantType<Guid> { Id = Guid.NewGuid(), GrantType = x}).ToList(),
                        AllowedScopes = item.AllowedScopes.Select(x => new ClientScope<Guid> { Id = Guid.NewGuid(), Scope = x }).ToList(),
                        Claims = item.Claims.Select(x => new ClientClaim<Guid> { Id = Guid.NewGuid(), Type = x.Type, Value = x.Value }).ToList(),
                        ClientSecrets = item.ClientSecrets.Select(x => new ClientSecret<Guid> { Id = Guid.NewGuid(), Type = x.Type, Value = x.Value, Description = x.Description }).ToList(),
                        IdentityProviderRestrictions = item.IdentityProviderRestrictions.Select(x => new ClientProviderRestriction<Guid> { Id = Guid.NewGuid(), Provider = x }).ToList(),
                        PostLogoutRedirectUris = item.PostLogoutRedirectUris.Select(x => new ClientPostLogoutRedirectUri<Guid> { Id = Guid.NewGuid(), Uri = x}).ToList(),
                        RedirectUris = item.RedirectUris.Select(x => new ClientRedirectUri<Guid> { Id = Guid.NewGuid(), Uri = x }).ToList()
                    };

                    context.Clients.Add(newclient);
                    context.SaveChanges();
                }
            }
        }
    }
}
