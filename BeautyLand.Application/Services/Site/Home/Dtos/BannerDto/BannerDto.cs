using BeautyLand.Domain.Banner;

namespace BeautyLand.Application.Services.Site.Home.GetHome
{
    public class BannerDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public BannerPosition BannerPosition { get; set; }

    }
}
