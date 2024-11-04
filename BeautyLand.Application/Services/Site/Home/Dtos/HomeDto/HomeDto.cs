using BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto;
using BeautyLand.Application.Services.Site.Catalogs.Items.Dtos.ItemDto;
using System.Collections.Generic;

namespace BeautyLand.Application.Services.Site.Home.GetHome
{
    public class HomeDto
    {
        public List<BannerDto> Banners { get; set; }
        public List<ItemsDto> MostPopulars { get; set; }
        public List<ItemsDto> BestSellers { get; set; }
        public List<StupendousItemsDto> StupendousItems { get; set; }
      
    }
}
