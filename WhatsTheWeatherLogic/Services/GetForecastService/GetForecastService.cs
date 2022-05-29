using System.Text.Json;
using WeatherAccess;
using WhatsTheWeatherDatabaseAccess;
using WhatsTheWeatherLogic.Dtos;

namespace WhatsTheWeatherLogic.Services.GetForecastService
{
    public class GetForecastService
    {
        private readonly ForecastService _forecastService;
        private readonly StatisticsDbContext _context;

        public GetForecastService(ForecastService forecastService, StatisticsDbContext context)
        {
            _context = context;
            _forecastService = forecastService;
        }

        public async Task<Forecast?> GetForecast(string cityName)
        {
            var response = await _forecastService.Get(cityName);
            var result = JsonSerializer.Deserialize<Forecast>(await response.Content.ReadAsStringAsync());
            new AddOrIncrementVisitedService.AddOrIncrementVisitedService(_context).AddOrIncrement(result!.City);
            return result;
        }
    }
}
