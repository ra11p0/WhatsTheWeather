using System.Text.Json.Serialization;

namespace WhatsTheWeatherLogic.Dtos
{
    public class ForecastRecord
    {
        [JsonPropertyName("main")]
        public WeatherTemperature Temperature { get; set; }
        [JsonPropertyName("weather")]
        public IEnumerable<Weather> WeatherList { get; set; } = new List<Weather>();
        public Weather? DefaultWeather => WeatherList.FirstOrDefault();
        [JsonPropertyName("dt_txt")]
        public string DateTimeString { get; set; }

        //public DateTime? DateTime => DateTime.ParseExact()
    }
}
