using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApiDocumentationExample.Controllers;

/// <summary>
/// Weather Forecasts
/// </summary>
[ApiController]
[Route("[controller]")]
[SwaggerTag("Weather Forecasts tag example")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    /// <inheritdoc />
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get Weather Forecasts
    /// </summary>
    /// <remarks>This is a remark comment</remarks>
    /// <returns>Returns 5 random weather forecasts</returns>
    /// <response code="200">Returns the weather forecasts</response>
    [HttpGet(Name = "GetWeatherForecast")]
    [SwaggerOperation(Summary = "Get weather forecasts",
        Description = "Returns 5 random weather forecasts",
        OperationId = "GET",
        Tags = new []{"WeatherForecast"})]
    [SwaggerResponse(StatusCodes.Status200OK, "Random weather forecasts", typeof(WeatherForecast[]))]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    /// <summary>
    /// Create Weather Record
    /// </summary>
    /// <remarks>This is a remark comment</remarks>
    /// <returns>Weather record</returns>
    /// <response code="200">Returns the weather record</response>
    [HttpPost(Name = "AddWeather")]
    [SwaggerOperation(Summary = "Add a new weather record",
        Description = "Add a new weather record",
        OperationId = "AddWeather",
        Tags = new []{"Weather"})]
    [SwaggerResponse(StatusCodes.Status200OK, "Weather record", typeof(Weather))]
    public ActionResult<Weather> AddWeather(
        [FromBody, SwaggerRequestBody("The weather payload", Required = true)]Weather weather)
    {
        return Ok(weather);
    }
}


/// <summary>
/// Weather record
/// </summary>
/// <param name="Id">Weather internal id</param>
/// <param name="Name">Weather city name</param>
/// <param name="Description">Optional weather description</param>
public record struct Weather(int Id, string Name, string? Description);