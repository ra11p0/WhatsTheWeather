using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using WeatherAccess;
using WhatsTheWeatherDatabaseAccess;
using WhatsTheWeatherLogic.Dtos;

namespace WhatsTheWeatherLogic.Services.GetMostPopularLocationsService
{
    public class GetMostPopularLocationsService
    {
        private readonly StatisticsDbContext _context;
        private readonly WeatherService _weatherService;

        public GetMostPopularLocationsService(StatisticsDbContext context, WeatherService weatherService)
        {
            _context = context;
            _weatherService = weatherService;
        }

        public async IAsyncEnumerable<WeatherResponse?> GetMostPopularLocations()
        {
            var locations = _context.LocationVisits.Include(e=>e.City).OrderBy(e => e.VisitsCounter).Take(5);
            foreach (var locationVisits in locations)
            {
                var response = await _weatherService.Get(locationVisits.City.Name);
                var deserializedResponse = JsonSerializer.Deserialize<WeatherResponse>(await response.Content.ReadAsStringAsync());
                deserializedResponse!.HowManyChecked = locationVisits.VisitsCounter;
                yield return deserializedResponse;
            }
        }
    }
}
