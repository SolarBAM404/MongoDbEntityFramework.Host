using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDbEntityFramework.Settings;

namespace MongoDbEntityFramework.Host;

public static class HostingExtensions
{
    public static IServiceCollection AddMongoDbContext<TContext>(this IServiceCollection services, DbSettings dbSettings)
        where TContext : DbContext
    {
        services.AddSingleton(new MongoClient(dbSettings.ConnString));
        services.AddScoped<TContext>(sp =>
        {
            MongoClient client = sp.GetRequiredService<MongoClient>();
            return (TContext)Activator.CreateInstance(typeof(TContext), client, dbSettings)!;
        });
        return services;
    }
    
}