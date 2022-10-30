namespace DemoApp.Client.E2ETests.Pages;

public class IndexTests: IClassFixture<WebApplicationFactoryFixture>
{
    public IndexTests(WebApplicationFactoryFixture fixture)
    {
        fixture.CreateDefaultClient(); // Trick to make the server available
    }

    [Fact]
    public async Task TestIndex()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            // Headless = false,
            // SlowMo = 1000
        });
        var context = await browser.NewContextAsync();
        // Open new page
        var page = await context.NewPageAsync();

        await page.GotoAsync(WebApplicationFactoryFixture.AppUrl);
        // Click text=Counter
        await page.ClickAsync("text=Counter");
        Assert.Equal("/counter", new Uri(page.Url).PathAndQuery);

        await page.ClickAsync("text=Current count: 0");

        await page.ClickAsync("text=Click me");

        var innerHtml = await page.Locator("#status").InnerHTMLAsync();
        Assert.Equal("Current count: 1", innerHtml);
    }
}