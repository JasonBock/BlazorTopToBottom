
using EngineAnalyticsWebApp.Components.Weather.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace EngineAnalyticsWebApp.Components.Weather
{
    public partial class WeatherLocation
    {
        private string title = "Track Weather";
        private string? zipCode;

        [Inject]
        private IWeatherService weatherService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await weatherService.SetWeatherZipCode(zipCode);
        }

        public async Task UpdateZipCode(KeyboardEventArgs e)
        {
            if ((e.Code == "Enter" || e.Code == "NumpadEnter") && !string.IsNullOrEmpty(zipCode))
            {
                // Call service to set zip code
                await weatherService.SetWeatherZipCode(zipCode);
            }
        }
    }
}
