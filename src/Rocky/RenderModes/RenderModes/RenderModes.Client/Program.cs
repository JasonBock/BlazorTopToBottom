using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<RenderModes.Client.RenderModeProvider>();
builder.Services.AddScoped<RenderModes.ActiveCircuitState>();

await builder.Build().RunAsync();
