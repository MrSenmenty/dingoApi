using Entities;
using Metadata;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;

namespace DingoConsoleTest;

public static class Program
{
    public static async Task Main()
    {
        ConfigManager.LoadSettings(new ConfigurationBuilder().Build());

        var services = new ServiceCollection();
        services.AddEntities();
        services.AddRepositories();
        services.AddServices();

        var provider = services.BuildServiceProvider();

        // Config done --------------------------------------------------------
        // TODO: resolve a service from `provider` and run a test script here.
        await Task.CompletedTask;
    }
}
