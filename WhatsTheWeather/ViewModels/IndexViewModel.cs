
using WhatsTheWeatherLogic.Dtos;

namespace WhatsTheWeather.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<WeatherResponse?> WeatherResponses { get; set; } = new List<WeatherResponse?>();
    }
}
