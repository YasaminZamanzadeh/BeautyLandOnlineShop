using System;

namespace BeautyLand.Application.Services.Site.GuestUsers.GuestUserProfile
{
    public class GuestUserDto
    {

        public string Id { get; set; }
        public string GuestUserId { get; set; }
        public string Ip { get; set; }
        public string ActiveUrl { get; set; }
        public string SourceUrl { get; set; }
        public string HttpMethod { get; set; }
        public string HttpProtocol { get; set; }
        public string Path { get; set; }
        public GuestUserSystemDto System { get; set; }
        public GuestUserSystemProfileDto Browser { get; set; }
        public GuestUserSystemProfileDto OperatingSystem { get; set; }
        public DateTime CreateDate { get; set; }
    }
}