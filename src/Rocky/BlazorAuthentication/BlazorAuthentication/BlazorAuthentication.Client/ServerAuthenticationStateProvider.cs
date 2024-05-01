using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorAuthentication.Client
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
    }
}
