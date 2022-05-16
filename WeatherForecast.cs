using Swashbuckle.AspNetCore.Annotations;

namespace WebApiDocumentationExample;

/// <summary>
/// Weather Forecast model 
/// </summary>
[SwaggerSchema(Required = new []{ "TemperatureC", "Summary" })]
public class WeatherForecast
{
    [SwaggerSchema(
        Title = "Datetime",
        Description = "When the forecast was made",
        Format = "date-time")]
    public DateTime Date { get; set; }

    [SwaggerSchema(
        Title = "Temperature (C)",
        Description = "Temperature in degrees Celsius",
        Format = "int")]
    public int TemperatureC { get; set; }

    [SwaggerSchema(
        Title = "Temperature (F)",
        Description = "Weird format that no-one should use",
        Format = "int")]
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

    [SwaggerSchema(
        Title = "Summary",
        Description = "Short summary of the forecast",
        Format = "string")]
    public string? Summary { get; set; }
}