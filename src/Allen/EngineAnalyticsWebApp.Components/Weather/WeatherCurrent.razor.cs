using EngineAnalyticsWebApp.Components.Weather.Services;
using EngineAnalyticsWebApp.Shared.Models.Weather;
using EngineAnalyticsWebApp.Shared.Services.Data;
using Microsoft.AspNetCore.Components;
using System.Reactive.Linq;

namespace EngineAnalyticsWebApp.Components.Weather
{
    public partial class WeatherCurrent
    {
        [Inject]
        private IWeatherService weatherService { get; set; } = default!;
        [Inject]
        private IWeatherDataService weatherDataService { get; set; } = default!;
        private Current currentWeatherData = new();
        private IDisposable? subscription;
        protected override void OnInitialized()
        {
            subscription = weatherService.GetCurrentZipCodeStream()
                .Subscribe(async data => await OnZipCodeDataLoaded(data));
        }

        private async Task OnZipCodeDataLoaded(string zipCode)
        {
            currentWeatherData = await weatherDataService.GetCurrentWeather(zipCode);
            StateHasChanged(); // required as the async nature post-await not updating the UI until next action
        }

        public void Dispose()
        {
            subscription?.Dispose();
        }
    }
}
