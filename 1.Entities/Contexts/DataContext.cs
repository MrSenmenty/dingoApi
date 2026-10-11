using Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Entities.Contexts;

// Used by the database migration process.
// Commands: Go to the Entities folder :           cd 1.Entities
//           Download EF tools if needed :          dotnet tool install --global dotnet-ef
//           Create a migration plan :              dotnet ef migrations add MigrationName --context=DataContext
//           Update your database:                  dotnet ef database update --context=DataContext
//                 -> In DEBUG, database update is automatically performed when the app starts
public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        ConfigManager.LoadSettings(new ConfigurationBuilder().Build());
        return new DataContext();
    }
}

public class DataContext : DbContext
{
    private readonly string connectionString;

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DataContext()
    {
    }

    public DataContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        var connection = connectionString
                         ?? ConfigManager.AppSettings?["ConnectionStrings:DataContext"];

        optionsBuilder.UseSqlServer(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TODO: register entity configurations here.
    }
}
