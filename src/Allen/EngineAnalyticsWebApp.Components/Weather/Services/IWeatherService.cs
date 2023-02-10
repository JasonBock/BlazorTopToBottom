
using EngineAnalyticsWebApp.Shared.Models.Weather;

namespace EngineAnalyticsWebApp.Components.Weather.Services
{
    public interface IWeatherService
    {
        IObservable<Current> GetCurrentWeatherStream();
        IObservable<string> GetCurrentZipCodeStream();
        Task SetWeatherZipCode(string? zipCode);
    }
}
