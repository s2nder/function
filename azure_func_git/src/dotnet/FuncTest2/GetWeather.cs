public static class WeatherFunction
{
    [FunctionName("GetWeather")]
    public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "weather/{city}")] HttpRequestMessage req,
        string city,
        ILogger log)
    {
        string apiKey = "<Your_OpenWeather_API_Key>";
        string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(apiUrl);
            var weatherData = JsonConvert.DeserializeObject<dynamic>(response);

            if (weatherData.cod != 200)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "City not found");
            }

            var weather = new
            {
                city = city,
                temperature = weatherData.main.temp,
                description = weatherData.weather[0].description
            };

            return req.CreateResponse(HttpStatusCode.OK, weather);
        }
    }
}
