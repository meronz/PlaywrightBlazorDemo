using Microsoft.Extensions.DependencyInjection;

namespace DemoApp.Server.IntegrationTests;

public class WebApplicationFactoryFixture : WebApplicationFactory<Program>
{
    public static string AppUrl => "https://localhost:7048";
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseUrls(AppUrl);
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureWebHost(b => b
            .ConfigureServices(s => 
                s.AddSingleton<IMyService, MyTestService>()));

        var host = builder.Build();
        host.Start();
        return host;
    }
}