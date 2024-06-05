using CarModel.Entities;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Reflection;
namespace CarModel.Service.Database;

public class DatabaseService : DbContext
{
    public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
    {
    }
    public DbSet<CarMake> CarModels { get; set; }

    public void Migrate()
    {
        Policy
            .Handle<Exception>()
            .WaitAndRetry(3, r => TimeSpan.FromSeconds(5))
            .Execute(() => Database.Migrate());
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}