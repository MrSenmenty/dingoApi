namespace Metadata;

public static class ConfigManager
{
    public static IConfiguration AppSettings { get; private set; }

    private static bool loaded;

    public static void LoadSettings(IConfiguration configuration)
    {
        if (loaded)
            return;

        var configurationBuilder = new ConfigurationBuilder()
            .AddConfiguration(configuration);

        var exists = true;

        var basePath = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
        if (basePath == null)
            exists = false;

        exists = exists && File.Exists(Path.Combine(basePath!, "appsettings.json"));

        if (exists)
        {
            configurationBuilder = configurationBuilder
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false, true);
        }

        AppSettings = configurationBuilder.Build();

        loaded = true;
    }

    public static void LoadSettings(IConfigurationManager configuration)
    {
        if (loaded)
            return;

        var configurationBuilder = new ConfigurationBuilder()
            .AddConfiguration(configuration);

        var exists = true;

        var basePath = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
        if (basePath == null)
            exists = false;

        exists = exists && File.Exists(Path.Combine(basePath!, "appsettings.json"));

        if (exists)
        {
            configurationBuilder = configurationBuilder
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false, true);
        }

        AppSettings = configurationBuilder.Build();

        loaded = true;
    }
}
