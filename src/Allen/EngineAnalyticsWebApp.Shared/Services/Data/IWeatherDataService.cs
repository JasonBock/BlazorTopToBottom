using EngineAnalyticsWebApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineAnalyticsWebApp.Shared.Services.Data
{
    public interface IWeatherDataService
    {
        Task<IEnumerable<WeatherCurrent>> GetCurrentWeather(string zipCode);

        Task<IEnumerable<WeatherFuture>> GetFutureWeather();
    }
}
