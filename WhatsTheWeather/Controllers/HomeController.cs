using Microsoft.AspNetCore.Mvc;
using WeatherAccess;
using WhatsTheWeather.ViewModels;
using WhatsTheWeatherDatabaseAccess;
using WhatsTheWeatherLogic.Dtos;
using WhatsTheWeatherLogic.Services.GetMostPopularLocationsService;

namespace WhatsTheWeather.Controllers
{
    public class HomeController : Controller
    {
        private readonly StatisticsDbContext _context;
        private readonly WeatherService _weatherService;

        public HomeController(StatisticsDbContext context, WeatherService weatherService)
        {
            _context = context;
            _weatherService = weatherService;
        }
        public async Task<IActionResult> Index()
        {
            List<WeatherResponse?> response = await new GetMostPopularLocationsService(_context, _weatherService).GetMostPopularLocations().ToListAsync();
            return View(new IndexViewModel()
            {
                WeatherResponses = response
            });
        }
    }
}
