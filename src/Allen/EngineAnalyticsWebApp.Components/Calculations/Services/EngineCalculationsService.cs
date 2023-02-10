using EngineAnalyticsWebApp.Shared.Models.Engine;

namespace EngineAnalyticsWebApp.Components.Calculations.Services
{
    public class EngineCalculationsService : IEngineCalculationsService
    {
        // Allen, 1 service per component, or not needed? Thinking of tree shaking, componenets on an island.... Maybe too much
        // fragmentation and keep in mind YAGNI. Keep in mind every single .NET pattern and practice is NOT the focus of this
        // workshop; it's conveying Blazor and how to get going
        public EngineAnalytics CalculateEngineHorsepower(Horsepower horsepower)
        {
            var rwHorsepower = 0.0;

            var hpCalc = horsepower.EstimatedTime / 5.825;
            if (hpCalc.HasValue && horsepower.Weight.HasValue)
            {
                double hp = hpCalc.Value;
                double weight = horsepower.Weight.Value;
                rwHorsepower = Math.Round(weight / Math.Pow(hp, 3));
            }

            //15 percent drivetrain loss on wheel and increase at flywheel (engine horsepower)
            var flywheelHP = (rwHorsepower * 1.146);
            var fwHorsepower = Math.Round(flywheelHP);

            EngineAnalytics hpCalcs = new EngineAnalytics
            {
                RearWheelHorsepower = rwHorsepower,
                FlywheelHorsepower = fwHorsepower
            };

            return hpCalcs;
        }

        public EngineAnalytics CalculateEngineDisplacement(Displacement displacement)
        {
            var radius = (displacement.BoreSize / 2);
            EngineAnalytics displacementCalcs = new EngineAnalytics
            {
                Displacement = Math.Round(Math.Pow(radius, 2) * Math.PI * displacement.CrankshaftStrokeLength * displacement.Cylinders)
            };

            return displacementCalcs;
        }

        public EngineAnalytics CalculateEngineTorque(Torque torque)
        {
            EngineAnalytics torqueCalcs = new EngineAnalytics
            {
                Torque = Math.Round((torque.Horsepower * 5252) / torque.EngineRPM)
            };

            return torqueCalcs;
        }
    }
}
