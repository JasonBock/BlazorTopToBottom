using BlazorAuthentication.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

await builder.Build().RunAsync();
