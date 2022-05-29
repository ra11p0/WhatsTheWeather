using WhatsTheWeatherLogic.Dtos;

namespace WhatsTheWeather.ViewModels.Location
{
    public class LocationViewModel
    {
        public WeatherResponse? WeatherResponse { get; set; }
        public Forecast? Forecast { get; set; }
    }
}
