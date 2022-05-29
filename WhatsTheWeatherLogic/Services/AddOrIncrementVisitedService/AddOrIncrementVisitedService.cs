using Microsoft.EntityFrameworkCore;
using WhatsTheWeatherDatabaseAccess;
using WhatsTheWeatherDatabaseAccess.DbModels;

namespace WhatsTheWeatherLogic.Services.AddOrIncrementVisitedService
{
    internal class AddOrIncrementVisitedService
    {
        private readonly StatisticsDbContext _context;

        public AddOrIncrementVisitedService(StatisticsDbContext context)
        {
            _context = context;
        }

        public int AddOrIncrement(City city)
        {
            var entity = _context.LocationVisits.Include(e=>e.City).FirstOrDefault(e => e.City.Name == city.Name) ?? new LocationVisits() { City = city };
            if(entity.LocationVisitsId == 0)_context.LocationVisits.Add(entity);
            entity.VisitsCounter++;
            _context.SaveChanges();
            return entity.VisitsCounter;
        }
    }
}
