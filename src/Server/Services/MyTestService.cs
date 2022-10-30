namespace DemoApp.Server.Services;

public class MyTestService: IMyService
{
    public IEnumerable<WeatherForecast> GetWeatherForecasts()
    {
        return Array.Empty<WeatherForecast>();
    }
}