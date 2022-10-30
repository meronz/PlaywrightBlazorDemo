namespace DemoApp.Server.IntegrationTests;

public class IntegrationTests: IClassFixture<WebApplicationFactoryFixture>
{
    private readonly WebApplicationFactoryFixture _fixture;

    public IntegrationTests(WebApplicationFactoryFixture fixture)
    {
        _fixture = fixture;
    }


    [Fact]
    public async Task TestWeatherForecast()
    {
        var c = _fixture.CreateClient();

        var response = await c.GetAsync("/WeatherForecast");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<WeatherForecast[]>(content);
        
        // The Test service must return an empty list
        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(result);
        Assert.Empty(result!);
    }
}