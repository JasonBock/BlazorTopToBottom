using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using EngineAnalyticsWebApp.Components.Calculations.Services;
using EngineAnalyticsWebApp.Components.Weather.Services;
using EngineAnalyticsWebApp.Shared.Services.Data;
using EngineAnalyticsWebApp.Shared.Services.Factories;
using EngineAnalyticsWebApp.UI;
using EngineAnalyticsWebApp.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
// This is the glue that adds our Blazor app to the DOM in the location with id="app" in index.html
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddScoped<IEngineCalculationsService, EngineCalculationsService>();
builder.Services.AddScoped<IAutomobileDataService, AutomobileLocalStorageService>();
// Using a singleton here purposely because the WeatherService holds state and using a scoped service won't allow that to persist
builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddHttpClient<IWeatherDataService, WeatherDataService>(client => client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/"));
builder.Services.AddBlazorise(options =>
{
    options.Immediate = true;
})
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

// Lazy loaded assemblies must reply on factories for service instantiation
builder.Services.AddScoped<IMessageServiceFactory, MessageServiceFactory>();

await builder.Build().RunAsync();
