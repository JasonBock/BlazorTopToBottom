using System.ComponentModel.DataAnnotations;

namespace EngineAnalyticsWebApp.Shared.Models.Engine
{
    public class Automobile
    {
        [Required]
        public int? Year { get; set; }
        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        [ValidateComplexType]
        public Horsepower? Horsepower { get; set; }
        public Displacement? Displacement { get; set; }
        public Torque? Torque { get; set; }
        [ValidateComplexType]
        public EngineAnalytics? EngineAnalytics { get; set; }
    }
}
