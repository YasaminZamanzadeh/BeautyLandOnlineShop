using BeautyLand.Application.Services.Site.UserAddress;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.User
{
    public interface IUserAddressService
    {
        List<UserAddressDto> GetUserAddresse(string userId);
        void CreateUserAddress(NewUserAddressDto userAddress);

    }
}
