
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BeautyLand.Domain.Roles;
using BeautyLand.Domain.Users;
using System;

namespace BeautyLand.Infrastructure.Configurations.Databases.IdentitySQLDatabase
{
   public static class IdentitySQLDatabase
    {
        public static IServiceCollection AddIdentitySQLDatabaseConfige(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Connections:ConnectionString"];
            services.AddDbContext<Persistence.Databases.IdentitySQLDatabase.IdentitySQLDatabase>(configureOptions =>
            {
                configureOptions.UseSqlServer(connectionString);
            });
            services.AddIdentity<User, Role>()
                .AddUserManager<UserManager<User>>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddEntityFrameworkStores<Persistence.Databases.IdentitySQLDatabase.IdentitySQLDatabase>()
                .AddErrorDescriber<IdentityErrorDescriberSQLDatabase>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(configureOptions =>
            {
                configureOptions.Password.RequireDigit = false;
                configureOptions.Password.RequireLowercase = false;
                configureOptions.Password.RequireUppercase = false;
                configureOptions.Password.RequiredUniqueChars = 1;
                configureOptions.Password.RequiredLength = 5;
                configureOptions.User.RequireUniqueEmail = true;
                configureOptions.Lockout.MaxFailedAccessAttempts = 5;
                configureOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(45);

            });
            return services;
        }
    }
}
