using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDbEntityFramework.Settings;

namespace MongoDbEntityFramework.Host;

public static class HostingExtensions
{
    public static IServiceCollection AddMongoDbContext<TContext>(this IServiceCollection services, DbSettings dbSettings)
        where TContext : DbContext, new()
    {
        services.AddSingleton(new MongoClient(dbSettings.ConnString));
        services.AddSingleton(dbSettings);
        services.AddScoped<TContext>();
        return services;
    }
    
}