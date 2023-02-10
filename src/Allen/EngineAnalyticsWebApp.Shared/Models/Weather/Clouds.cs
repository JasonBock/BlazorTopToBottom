using System.Text.Json.Serialization;

namespace EngineAnalyticsWebApp.Shared.Models.Weather
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public double All { get; set; }
    }
}
