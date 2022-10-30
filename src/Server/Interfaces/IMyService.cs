namespace DemoApp.Server.Interfaces;

public interface IMyService
{
    IEnumerable<WeatherForecast> GetWeatherForecasts();
}