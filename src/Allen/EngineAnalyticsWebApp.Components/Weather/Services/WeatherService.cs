using Blazored.LocalStorage;
using EngineAnalyticsWebApp.Shared.Models.Weather;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace EngineAnalyticsWebApp.Components.Weather.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly string defaultZipCode = "89109";
        private readonly string localStorageZipCode = "weatherZipCode";
        private BehaviorSubject<Current> getCurrentWeatherSource = new(default(Current)!);
        private Subject<string> getCurrentZipCodeSource = new();  //Not using BehaviorSubject because state is managed by localStorage and would conflict
        public IObservable<Current> GetCurrentWeatherStream() => getCurrentWeatherSource.AsObservable();
        public IObservable<string> GetCurrentZipCodeStream() => getCurrentZipCodeSource.AsObservable();

        private readonly ILocalStorageService localStorage;
        
        public WeatherService(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public async Task SetWeatherZipCode(string? zipCode)
        {

            var lastSetWeatherZipCode = await localStorage.GetItemAsync<string>(localStorageZipCode);
            if (string.IsNullOrEmpty(zipCode) && string.IsNullOrEmpty(lastSetWeatherZipCode))
            {
                zipCode = defaultZipCode;
            }

            // Only stream a new zip code if it's different than previously stored in local storage
            if (zipCode != lastSetWeatherZipCode)
            {
                // If no zip code was provided, but there's a value in local storage use it
                if (string.IsNullOrEmpty(zipCode)) { zipCode = lastSetWeatherZipCode; } 
                await localStorage.SetItemAsync(localStorageZipCode, zipCode);
                getCurrentZipCodeSource.OnNext(zipCode);
            }

        }
    }
}
