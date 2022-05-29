using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WhatsTheWeatherDatabaseAccess.DbModels;

namespace WhatsTheWeatherLogic.Dtos
{
    public class Forecast
    {
        [JsonPropertyName("list")]
        public IEnumerable<ForecastRecord> ForecastRecords { get; set; } = new List<ForecastRecord>();
        public ForecastRecord? DefaultForecast => ForecastRecords.FirstOrDefault();
        [JsonPropertyName("city")]
        public City City { get; set; }
    }
}
