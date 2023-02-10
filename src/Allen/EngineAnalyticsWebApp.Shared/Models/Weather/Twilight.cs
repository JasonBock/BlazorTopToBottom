using System.Text.Json.Serialization;

namespace EngineAnalyticsWebApp.Shared.Models.Weather
{
    public class Twilight
    {
        [JsonPropertyName("type")]
        public double Type { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("sunrise")]
        public double Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public double Sunset { get; set; }
    }
}
