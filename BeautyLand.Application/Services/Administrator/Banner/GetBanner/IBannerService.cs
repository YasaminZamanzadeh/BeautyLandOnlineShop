using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Administrator.Banner.GetBanner
{
    public interface IBannerService
    {
        void Create(BannerDto banner);
        List<BannerDto> Index();
    }
}
