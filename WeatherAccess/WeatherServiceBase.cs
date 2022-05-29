namespace WeatherAccess
{
    public abstract class WeatherServiceBase
    {
        private readonly string _weatherApi;
        private readonly string _apiKey;
        private readonly string _lang;
        private readonly string _units;

        protected WeatherServiceBase(string apiUrl, string apiKey, string lang = "en", string units = "metric")
        {
            _weatherApi = apiUrl;
            _apiKey = apiKey;
            _lang = lang;
            _units = units;
        }

        protected async Task<HttpResponseMessage> ExecuteGet(string request)
        {
            HttpClient client = new HttpClient();
            return await client.GetAsync(_weatherApi + request + $"&appid={_apiKey}&lang={_lang}&units={_units}");
        }

        public abstract Task<HttpResponseMessage> Get(string request);
    }
}