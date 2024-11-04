using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Databases.MongoDatabase
{
    public interface IMongoDatabaseService<TValue>
    {
        public IMongoCollection<TValue> GetCollection();
    }
}
