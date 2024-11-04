using AutoMapper;
using BeautyLand.Application.Services.Site.User;
using BeautyLand.Application.Services.Site.UserAddress;
using BeautyLand.Domain.Order;
using BeautyLand.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Infrastructure.Configurations.Mappers.UserAddressMappers
{
    public class UserAddressMapper : Profile
    {
        public UserAddressMapper()
        {
            CreateMap<UserAddress, UserAddressDto>()
                .ReverseMap();

            CreateMap<UserAddress, NewUserAddressDto>()
              .ReverseMap();

            CreateMap<UserAddress, Address>()
           .ReverseMap();
        }
    }
}
