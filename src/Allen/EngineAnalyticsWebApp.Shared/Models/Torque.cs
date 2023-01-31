using System.ComponentModel.DataAnnotations;

namespace EngineAnalyticsWebApp.Shared.Models
{
    public class Torque
    {
        [Required]
        public double Horsepower { get; set; }
        [Required]
        public double EngineRPM { get; set; }
    }
}
