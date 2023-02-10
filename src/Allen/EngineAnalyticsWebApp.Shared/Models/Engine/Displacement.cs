using System.ComponentModel.DataAnnotations;

namespace EngineAnalyticsWebApp.Shared.Models.Engine
{
    public class Displacement
    {
        [Required]
        public double BoreSize { get; set; }

        [Required]
        public double CrankshaftStrokeLength { get; set; }

        [Required]
        public int Cylinders { get; set; }
    }
}
