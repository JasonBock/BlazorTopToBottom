using EngineAnalyticsWebApp.Shared.Models.Weather;
using System.Net.Http.Json;

namespace EngineAnalyticsWebApp.Shared.Services.Data
{
    public class WeatherDataService : IWeatherDataService
    {

        private readonly HttpClient http;
        public WeatherDataService(HttpClient http)
        {
            this.http = http;
        }
        public async Task<Current> GetCurrentWeather(string zipCode)
        {
            try
            {

                // Build out query string parameters for Open Weather API
                var requesturi = $"weather?zip={zipCode}&units=imperial&appid=e6ffd5da204bed35e83db04a083b382b";
                
                var results = await http.GetFromJsonAsync<Current>(requesturi);
                return results ?? new Current();
            }
            catch
            {
                return new Current();
            }
        }

        public Task<IEnumerable<Future>> GetFutureWeather()
        {
            throw new NotImplementedException();
        }

    }
}
