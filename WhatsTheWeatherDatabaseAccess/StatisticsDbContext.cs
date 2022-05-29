using Microsoft.EntityFrameworkCore;
using WhatsTheWeatherDatabaseAccess.DbModels;

namespace WhatsTheWeatherDatabaseAccess
{
    public class StatisticsDbContext : DbContext
    {
        public DbSet<LocationVisits> LocationVisits { get; set; }
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options) : base(options)
        {

        }
    }
}
