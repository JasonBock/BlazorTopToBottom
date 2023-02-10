using System.ComponentModel.DataAnnotations;

namespace EngineAnalyticsWebApp.Shared.Models.Engine
{
    public class Horsepower
    {
        [Required]
        [Range(1, 10000)]
        public double? Weight { get; set; }
        [Required]
        [Range(3, 25)]
        public double? EstimatedTime { get; set; }
    }
}
