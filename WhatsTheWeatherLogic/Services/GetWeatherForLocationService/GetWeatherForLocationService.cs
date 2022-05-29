using System.Text.Json;
using WeatherAccess;
using WhatsTheWeatherDatabaseAccess;
using WhatsTheWeatherLogic.Dtos;

namespace WhatsTheWeatherLogic.Services.GetWeatherForLocationService
{
    public class GetWeatherForLocationService
    {
        private readonly StatisticsDbContext _context;
        private readonly WeatherService _weatherService;

        public GetWeatherForLocationService(StatisticsDbContext context, WeatherService weatherService)
        {
            _context = context;
            _weatherService = weatherService;
        }

        public async Task<WeatherResponse?> GetWeatherForLocation(string cityName)
        {
            var response = await _weatherService.Get(cityName);
            var deserializedResponse = JsonSerializer.Deserialize<WeatherResponse>(await response.Content.ReadAsStringAsync());
            return deserializedResponse;
        }
    }
}
