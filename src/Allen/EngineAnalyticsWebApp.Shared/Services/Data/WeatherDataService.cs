using EngineAnalyticsWebApp.Shared.Models;


namespace EngineAnalyticsWebApp.Shared.Services.Data
{
    public class WeatherDataService : IWeatherDataService
    {
        public Task<IEnumerable<WeatherCurrent>> GetCurrentWeather(string zipCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherFuture>> GetFutureWeather()
        {
            throw new NotImplementedException();
        }
    }
}
