using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.GuestUsers
{
    public class GuestUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string GuestUserId { get; set; }
        public string Ip { get; set; }
        public string ActiveUrl { get; set; }
        public string SourceUrl { get; set; }
        public string HttpMethod { get; set; }
        public string HttpProtocol { get; set; }
        public string Path { get; set; }
        public GuestUserSystem System { get; set; }
        public GuestUserSystemProfile Browser { get; set; }
        public GuestUserSystemProfile OperatingSystem { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
