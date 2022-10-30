using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMyService _myService;

    public WeatherForecastController(IMyService myService)
    {
        _myService = myService;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _myService.GetWeatherForecasts();
    }
}
