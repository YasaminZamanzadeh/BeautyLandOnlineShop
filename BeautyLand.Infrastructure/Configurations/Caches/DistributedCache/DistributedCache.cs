using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace BeautyLand.Infrastructure.Configurations.Caches.DistributedCache
{
  public static class DistributedCache
    {
        public static IServiceCollection AddDistributedCacheConfige(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Connections:ConnectionString"];

            services.AddDistributedSqlServerCache(configureOptions =>
            {
                configureOptions.ConnectionString = connectionString;
                configureOptions.SchemaName = "dbo";
                configureOptions.TableName = "DistributedCache";
            });

            return services;
        }
    }
}
