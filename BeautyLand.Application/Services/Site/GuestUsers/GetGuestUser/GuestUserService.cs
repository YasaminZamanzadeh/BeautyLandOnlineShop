using AutoMapper;
using BeautyLand.Application.Services.Databases.MongoDatabase;
using BeautyLand.Domain.GuestUsers;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.GuestUsers.GuestUserProfile
{
    public class GuestUserService : IGuestUserService
    {
        private readonly IMongoDatabaseService<GuestUser> _context;
        private readonly IMongoCollection<GuestUser> _collection;
        private readonly IMapper _mapper;

        public GuestUserService(IMongoDatabaseService<GuestUser> context, IMapper mapper)
        {
            _context = context;
            _collection = _context.GetCollection();
            _mapper = mapper;
        }
        public void Execute(GuestUserDto guestUser)
        {
            var model = _mapper.Map<GuestUser>(guestUser);
            _collection.InsertOne(model);
        }
    }
}