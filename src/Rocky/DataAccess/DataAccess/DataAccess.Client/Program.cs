using DataAccess;
using DataAccess.Client;
using DataAccess.Dal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<RenderModeProvider>();
builder.Services.AddScoped<ActiveCircuitState>();

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<IDataAccess, HttpDataAccess>();

await builder.Build().RunAsync();
