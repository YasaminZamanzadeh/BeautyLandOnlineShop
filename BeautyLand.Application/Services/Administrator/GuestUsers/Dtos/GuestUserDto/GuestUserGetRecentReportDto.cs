using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BeautyLand.Application.Services.Administrator.GuestUsers.GuestUserReport
{
    public class GuestUserGetRecentReportDto
    {
        public string Id { get; set; }
        public string GuestUserId { get; set; }
        public string Ip { get; set; }
        public string ActiveUrl { get; set; }
        public string SourceUrl { get; set; }
        public string Path { get; set; }
        public string System { get; set; }
        public string Browser { get; set; }
        public string OperatingSytem { get; set; }
        public bool IsSpider { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }

    }
}

