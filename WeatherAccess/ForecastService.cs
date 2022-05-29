namespace WeatherAccess
{
    public class ForecastService : WeatherServiceBase
    {
        public ForecastService(string apiKey, string lang = "en", string units = "metric", string apiUrl = "https://api.openweathermap.org/data/2.5/forecast") : base(apiUrl, apiKey, lang, units)
        {
        }

        public override Task<HttpResponseMessage> Get(string cityName)
        {
            return this.ExecuteGet($"?q={cityName}");
        }
    }
}
