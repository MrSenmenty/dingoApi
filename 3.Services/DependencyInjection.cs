using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // TODO: register services here, e.g.
        // services.AddScoped<IFooService, FooService>();

        return services;
    }
}
