using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Claims.UserClaim
{
    public static class UserClaim
    {
        public static string GetUserId(ClaimsPrincipal user)
        {
            var claimIdentity = user.Identity as ClaimsIdentity;
            string userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
    }
}
 