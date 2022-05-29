using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WhatsTheWeatherLogic.Dtos
{
    public class WeatherResponse : ForecastRecord
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public int HowManyChecked { get; set; }
    }
}
