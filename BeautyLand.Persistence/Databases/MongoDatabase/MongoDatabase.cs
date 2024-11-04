using BeautyLand.Application.Services.Databases.MongoDatabase;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Persistence.Databases.MongoDatabase
{
    public class MongoDatabase<TValue> : IMongoDatabaseService<TValue>
    {
        private readonly IMongoDatabase _context;
        private readonly IMongoCollection<TValue> _collection;
        public MongoDatabase()
        {
            var client = new MongoClient();
            _context = client.GetDatabase("BeautyLand");
            _collection = _context.GetCollection<TValue>(typeof(TValue).Name);

        }
        public IMongoCollection<TValue> GetCollection()
        {
            return _collection;
        }
    }
}