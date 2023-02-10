using System.Text.Json.Serialization;

namespace EngineAnalyticsWebApp.Shared.Models.Weather
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public double Deg { get; set; }
    }
}
