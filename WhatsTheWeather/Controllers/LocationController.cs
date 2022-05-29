using Microsoft.AspNetCore.Mvc;
using WeatherAccess;
using WhatsTheWeather.ViewModels.Location;
using WhatsTheWeatherDatabaseAccess;
using WhatsTheWeatherLogic.Services.GetForecastService;
using WhatsTheWeatherLogic.Services.GetWeatherForLocationService;

namespace WhatsTheWeather.Controllers
{
    public class LocationController : Controller
    {
        private readonly WeatherService _weatherService;
        private readonly StatisticsDbContext _context;
        private readonly ForecastService _forecastService;

        public LocationController(WeatherService weatherService, ForecastService forecastService, StatisticsDbContext context)
        {
            _weatherService = weatherService;
            _forecastService = forecastService;
            _context = context;
        }
        public async Task<IActionResult> Index(string cityName)
        {
            var weatherResponse = await new GetWeatherForLocationService(_context, _weatherService).GetWeatherForLocation(cityName);
            var forecastResponse = await new GetForecastService(_forecastService, _context).GetForecast(cityName);
            forecastResponse!.ForecastRecords = forecastResponse.ForecastRecords.Where((e, o) => o % 8 == 0);
            return View(new LocationViewModel()
            {
                WeatherResponse = weatherResponse!,
                Forecast = forecastResponse
            });
        }
    }
}
