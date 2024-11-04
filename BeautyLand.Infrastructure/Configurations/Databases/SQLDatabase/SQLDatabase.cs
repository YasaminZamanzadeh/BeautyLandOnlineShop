using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Infrastructure.Configurations.Databases.SQLDatabase
{
   public static class SQLDatabase
    {
        public static IServiceCollection AddSQLDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Connections:ConnectionString"];
            services.AddDbContext<Persistence.Databases.SQLDatabase.SQLDatabase>(configureOptions =>
            {
                configureOptions.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
