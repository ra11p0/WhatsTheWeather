﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WhatsTheWeatherLogic.Dtos
{
    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("main")]
        public string CityName { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
