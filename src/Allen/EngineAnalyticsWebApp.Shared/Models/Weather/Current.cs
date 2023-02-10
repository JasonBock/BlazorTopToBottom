
using System.Text.Json.Serialization;

namespace EngineAnalyticsWebApp.Shared.Models.Weather
{
    public class Current
    {
        [JsonPropertyName("coord")]
        public Coord? Coord { get; set; }

        [JsonPropertyName("weather")]
        public Overview[]? Weather { get; set; }

        [JsonPropertyName("base")]
        public string? @Base { get; set; }

        [JsonPropertyName("main")]
        public Main? Main { get; set; }

        [JsonPropertyName("visibility")]
        public double Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind? Wind { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds? Clouds { get; set; }

        [JsonPropertyName("dt")]
        public double Dt { get; set; }

        [JsonPropertyName("sys")]
        public Twilight? Twilight { get; set; }

        [JsonPropertyName("timezone")]
        public double Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("cod")]
        public double Cod { get; set; }
    }
}
