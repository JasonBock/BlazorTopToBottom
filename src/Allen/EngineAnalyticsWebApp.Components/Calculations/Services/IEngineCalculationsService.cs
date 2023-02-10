using EngineAnalyticsWebApp.Shared.Models.Engine;

namespace EngineAnalyticsWebApp.Components.Calculations.Services
{
    public interface IEngineCalculationsService
    {
        EngineAnalytics CalculateEngineHorsepower(Horsepower horsepower);

        EngineAnalytics CalculateEngineDisplacement(Displacement displacement);

        EngineAnalytics CalculateEngineTorque(Torque torque);
    }
}
