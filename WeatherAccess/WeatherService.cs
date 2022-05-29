namespace WeatherAccess
{
    public class WeatherService : WeatherServiceBase
    {
        public WeatherService(string apiKey, string apiUrl = "https://api.openweathermap.org/data/2.5/weather") : base(apiUrl, apiKey)
        {
        }

        public override async Task<HttpResponseMessage> Get(string cityName)
        {
            return await ExecuteGet($"?q={cityName}");
        }
    }
}
