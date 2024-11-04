using BeautyLand.Application.Services.Databases.IdentitySQLDatabase;
using BeautyLand.Domain.Roles;
using BeautyLand.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Persistence.Databases.IdentitySQLDatabase
{
   public class IdentitySQLDatabase: IdentityDbContext<User, Role, string>, IIdentitySQLDatabase
    {
        public IdentitySQLDatabase(DbContextOptions<IdentitySQLDatabase> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            var modifiedIdentityTable = new (Type entityName, string tableName, string schemaName)[]
            {
                (typeof(IdentityUser<string>),"User", "identity"),
                (typeof(IdentityRole<string>),"Role","identity"),
                (typeof(IdentityUserClaim<string>), "UserClaim","identity"),
                (typeof(IdentityUserRole<string>), "UserRole","identity"),
                (typeof(IdentityUserLogin<string>), "UserLogin","identity"),
                (typeof(IdentityRoleClaim<string>), "RoleClaim","identity"),
                (typeof(IdentityUserToken<string>), "UserToken","identity")

            };


            foreach (var (entityName, tableName, schemaName) in modifiedIdentityTable)
            {
                builder.Entity(entityName).ToTable(tableName, schemaName);
            }

            builder.Entity<IdentityUserLogin<string>>().HasKey(configureOptions => new { configureOptions.LoginProvider, configureOptions.ProviderKey });
            builder.Entity<IdentityUserRole<string>>().HasKey(configureOptions => new { configureOptions.UserId, configureOptions.RoleId });
            builder.Entity<IdentityUserToken<string>>().HasKey(configureOptions => new { configureOptions.UserId, configureOptions.LoginProvider, configureOptions.Name });
        }
    }
}


