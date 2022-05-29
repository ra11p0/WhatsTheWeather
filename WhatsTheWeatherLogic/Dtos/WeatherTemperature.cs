using System.Text.Json.Serialization;

namespace WhatsTheWeatherLogic.Dtos
{
    public class WeatherTemperature
    {
        [JsonPropertyName("temp")]
        public float Temperature { get; set; }
        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }
        [JsonPropertyName("temp_min")]
        public float MinimalTemperature { get; set; }
        [JsonPropertyName("temp_max")]
        public float MaximalTemperature { get; set; }
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}
