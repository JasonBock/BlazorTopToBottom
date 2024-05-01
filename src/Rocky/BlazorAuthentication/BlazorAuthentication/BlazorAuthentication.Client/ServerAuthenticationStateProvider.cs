using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace BlazorAuthentication.Client
{
    public class ServerAuthenticationStateProvider(HttpClient HttpClient) : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity;

            var response = await HttpClient.GetFromJsonAsync<IdentityData>("api/identity");
            if (response == null || string.IsNullOrEmpty(response.AuthenticationType))
                identity = new ClaimsIdentity();
            else
                identity = new ClaimsIdentity(
                    response.Claims?.Select(c => new Claim(c.Name, c.Value, c?.ValueType)),
                    response.AuthenticationType);

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
