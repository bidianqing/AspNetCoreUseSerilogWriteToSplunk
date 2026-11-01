using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreUseSerilogWriteToSplunk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IHttpClientFactory httpClientFactory, ILogger<WeatherForecastController> logger) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var client = httpClientFactory.CreateClient();
            await client.GetAsync("https://www.baidu.com");


            logger.LogInformation("Test logging");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
