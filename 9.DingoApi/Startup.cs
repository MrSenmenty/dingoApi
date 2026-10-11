using Entities;
using Features;
using Metadata;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Repositories;
using Services;

namespace DingoApi;

public class Startup(IConfiguration configuration)
{
    private IConfiguration Configuration { get; } = configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Load appSettings first
        ConfigManager.LoadSettings(Configuration);

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<Startup>();
        });

        // Layered registrations
        services.AddEntities();
        services.AddRepositories();
        services.AddServices();
        FeatureConfiguration.RegisterAllFeatures(services);

        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

        services.AddResponseCompression();
        services.AddHealthChecks();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseResponseCompression();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseHealthChecks("/healthz", new HealthCheckOptions
        {
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(new
                {
                    status = report.Status.ToString(),
                    environment = env.EnvironmentName,
                }, Formatting.Indented);
                await context.Response.WriteAsync(result);
            },
        });
    }
}
