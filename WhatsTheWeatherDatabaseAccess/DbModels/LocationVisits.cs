using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsTheWeatherDatabaseAccess.DbModels
{
    public class LocationVisits
    {
        public int LocationVisitsId { get; set; }
        public City City { get; set; } = new City();
        public int VisitsCounter { get; set; }
    }
}
