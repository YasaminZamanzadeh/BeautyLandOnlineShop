using BeautyLand.Application.Services.Databases.MongoDatabase;
using MongoDB.Driver;
using System;
using System.Linq;

namespace BeautyLand.Application.Services.Administrator.GuestUsers.GuestUserOnline
{
    public class GuestUserOnlineService : IGuestUserOnlineService
    {
        private readonly IMongoDatabaseService<Domain.GuestUsers.GuestUserOnline> _context;
        private readonly IMongoCollection<Domain.GuestUsers.GuestUserOnline> _collection;

        public GuestUserOnlineService(IMongoDatabaseService<Domain.GuestUsers.GuestUserOnline> context)
        {
            _context = context;
            _collection = _context.GetCollection();
        }
        public void Connected(string guestUserId)
        {
            var existguestUserId = _collection.AsQueryable().FirstOrDefault(p => p.GuestUserId == guestUserId);
            if (existguestUserId == null)
            {

                _collection.InsertOne(new Domain.GuestUsers.GuestUserOnline
                {
                    GuestUserId = guestUserId,
                    CreateDate = DateTime.Now
                });
            }
        }

        public int Count()
        {
            return _collection.AsQueryable().Count();
        }

        public void Disconnected(string guestUserId)
        {
            _collection.FindOneAndDelete(prop => prop.GuestUserId == guestUserId);
        }
    }
}
