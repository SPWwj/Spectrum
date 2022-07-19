using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spectrum.Shared;
using System.Text;
using System.Text.Json;

namespace Spectrum.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            IEnumerable<WeatherForecast> result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            await Sendmail();
            return Ok(result);
        }

        public async Task Sendmail()
        {
            // requires using System.Net.Http;
            // requires using System.Net.Http;
            var client = new HttpClient();
            // requires using System.Text.Json;
            var jsonData = JsonSerializer.Serialize(new
            {
                email = "wwjweiwenjie@gmail.com",
                due = "4/1/2020",
                task = "My new task!"
            });

            HttpResponseMessage result = await client.PostAsync(
                // Requires DI configuration to access app settings. See https://docs.microsoft.com/azure/app-service/configure-language-dotnetcore#access-environment-variables
                "https://prod-23.eastasia.logic.azure.com:443/workflows/cbfa5786d6e34b07ac2927c4d0fe6840/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=AMZ8-rizuuMc3Vw2BQ7MKIi9KwyA9TfAJMoqox3BQAg",
                new StringContent(jsonData, Encoding.UTF8, "application/json"));

            var statusCode = result.StatusCode.ToString();
        }
    }
}