using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public static class TimeFunction
{
    [FunctionName("GetTimeInCity")]
    public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "time/{city}")] HttpRequestMessage req,
        string city,
        ILogger log)
    {
        var timeZones = new Dictionary<string, string>
        {
            { "newyork", "Eastern Standard Time" },
            { "london", "GMT Standard Time" },
            { "tokyo", "Tokyo Standard Time" }
        };

        if (!timeZones.ContainsKey(city.ToLower()))
        {
            return req.CreateResponse(HttpStatusCode.BadRequest, "City not supported");
        }

        var timeZone = timeZones[city.ToLower()];
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
        DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tz);

        return req.CreateResponse(HttpStatusCode.OK, new { city = city, time = currentTime });
    }
}