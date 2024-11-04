using BeautyLand.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Databases.IdentitySQLDatabase
{
    public interface IIdentitySQLDatabase
    {
        DbSet<User> Users { get; set; }
    }
}
