using Microsoft.Extensions.DependencyInjection;

namespace Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // TODO: register repositories here, e.g.
        // services.AddScoped<IFooRepository, FooRepository>();

        return services;
    }
}
