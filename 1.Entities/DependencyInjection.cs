using Entities.Contexts;
using Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entities;

public static class DependencyInjection
{
    public static IServiceCollection AddEntities(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(ConfigManager.AppSettings?["ConnectionStrings:DataContext"]));

        return services;
    }
}
