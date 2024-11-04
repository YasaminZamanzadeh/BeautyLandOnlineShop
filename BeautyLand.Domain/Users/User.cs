using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Discounts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Users
{
    [AudiTable]
    public class User: IdentityUser
    {
        //public ICollection<Discount> Discounts { get; set; }

    }
}
