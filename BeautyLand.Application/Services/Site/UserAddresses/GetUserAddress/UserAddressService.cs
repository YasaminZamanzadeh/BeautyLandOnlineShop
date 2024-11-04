using AutoMapper;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Site.UserAddress;
using BeautyLand.Domain.Users;
using BeautyLand.Subscription.ExceptionExtentions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Site.User
{
    public class UserAddressService : IUserAddressService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IMapper _mapper;
        public UserAddressService(ISQLDatabaseService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateUserAddress(NewUserAddressDto userAddress)
        {
            var model = _mapper.Map<Domain.Users.UserAddress>(userAddress);
            _context.UserAddresses.Add(model);
            _context.SaveChanges();
        }

        public List<UserAddressDto> GetUserAddresse(string userId)
        {
            var userAddress = _context.UserAddresses.Where(p => p.UserId == userId);

            if (userAddress == null)
            {
                throw new NotFoundExceptionExtention<IQueryable<Domain.Users.UserAddress>, string>(userAddress, userId);
            }

            var model = _mapper.Map<List<UserAddressDto>>(userAddress);
            return model;
        }

      
    }
}
