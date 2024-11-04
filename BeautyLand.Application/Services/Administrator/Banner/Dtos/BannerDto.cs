using BeautyLand.Domain.Banner;

namespace BeautyLand.Application.Services.Administrator.Banner.GetBanner
{
    public class BannerDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public BannerPosition BannerPosition { get; set; }
    }
}
