namespace DemoApp.Client.E2ETests;

public class WebApplicationFactoryFixture : WebApplicationFactory<Program>
{
    public static string AppUrl => "https://localhost:7049";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseUrls(AppUrl);
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        // need to create a plain host that we can return.
        var dummyHost = builder.Build();

        // configure and start the actual host.
        builder.ConfigureWebHost(webHostBuilder => webHostBuilder.UseKestrel());

        var host = builder.Build();
        host.Start();
            
        return dummyHost;
    }
}