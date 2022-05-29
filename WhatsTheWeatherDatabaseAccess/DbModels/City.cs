using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WhatsTheWeatherDatabaseAccess.DbModels
{
    public class City
    {
        [JsonIgnore]
        public int CityId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;
        [JsonPropertyName("coord")]
        public Coords Coords { get; set; } = new Coords();
    }

    public class Coords
    {
        public int CoordsId { get; set; }
        [JsonPropertyName("lat")]
        public float Latitude { get; set; }
        [JsonPropertyName("lon")]
        public float Longitude { get; set; }
    }
}
