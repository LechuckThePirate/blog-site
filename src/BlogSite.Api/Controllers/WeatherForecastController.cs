using BlogSite.Domain.Contracts;
using BlogSite.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IActionRepository _actionRepository;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IActionRepository actionRepository, ILogger<WeatherForecastController> logger)
    {
        _actionRepository = actionRepository;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        _logger.LogInformation("Getting weather forecast");
        await _actionRepository.LogAction(new AppAction
        {
            Action = "GetWeatherForecast",
            Data = "No data sent",
            CreatedBy = "WeatherForecastController",
            CreatedAt = DateTime.UtcNow
        });
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}