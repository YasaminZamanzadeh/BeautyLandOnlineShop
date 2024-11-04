using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto;
using BeautyLand.Application.Services.Site.Catalogs.Items;
using BeautyLand.Subscription.DistributedCaches;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Linq;
using System.Text;

namespace BeautyLand.Application.Services.Site.Home.GetHome
{
    public class HomeService : IHomeService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IURIComposerService _uriComposerService;
        private readonly IItemGetCatalogService _itemGetCatalogService;
        private readonly IDistributedCache _distributedCache;

        public HomeService(ISQLDatabaseService context, IURIComposerService uriComposerService, IItemGetCatalogService itemGetCatalogService, IDistributedCache distributedCache)
        {
            _context = context;
            _uriComposerService = uriComposerService;
            _itemGetCatalogService = itemGetCatalogService;
            _distributedCache = distributedCache;
        }

        public HomeDto Execute()
        {
            var distributedGetCache = _distributedCache.GetAsync(KeyDistributedCacheExtention<string>.HomeKeyGenerate()).Result;
            if (distributedGetCache != null)
            {
                var modelDeserlize = System.Text.Json.JsonSerializer.Deserialize<HomeDto>(distributedGetCache);
                return modelDeserlize;
            }

            var banners = _context.Banners.Where(p => p.IsActive == true)
                  .OrderBy(p => p.Priority)
                  .ThenByDescending(p => p.Id)
                  .Select(p => new BannerDto
                  {
                      Id = p.Id,
                      Image = _uriComposerService.Execute(p.Image),
                      Link = p.Link,
                      BannerPosition = p.BannerPosition
                  }).ToList();

            var bestSellers = _itemGetCatalogService.Execute(new FilteringDetailItemDto
            {
                AvailableStock = true,
                PageIndex = 1,
                PageSize = 2,
                SortType = SortType.BestSelling
            }).Model.ToList();

            var mostPopulars = _itemGetCatalogService.Execute(new FilteringDetailItemDto
            {
                AvailableStock = true,
                PageIndex = 1,
                PageSize = 2,
                SortType = SortType.MostPopular
            }).Model.ToList();


            var stupendousItems = _context.Items
                .Include(p => p.Discounts)
                .Include(p => p.Images)
                .Where(p => p.DiscountPercentage > 10 && p.AvailableStock > 0)
                .Select(p => new StupendousItemsDto
             {
                 Id = p.Id,
                 Name = p.Name,
                 Image = p.Images != null && p.Images.Any() ? _uriComposerService.Execute(p.Images.FirstOrDefault().Source) : null,
                 Price = p.Price,
                 OldPrice = p.OldPrice?? 0,
                 DiscountPercentage = p.DiscountPercentage,
             }).ToList();


            var result = new HomeDto
            {
                Banners = banners,
                BestSellers = bestSellers,
                MostPopulars = mostPopulars,
                StupendousItems = stupendousItems,

            };
            var modelSerialize = System.Text.Json.JsonSerializer.Serialize(result);
            byte[] encodeJson = Encoding.UTF8.GetBytes(modelSerialize);
            var option = new DistributedCacheEntryOptions().SetSlidingExpiration(KeyDistributedCacheExtention<string>.Duration);
            _distributedCache.SetAsync(KeyDistributedCacheExtention<string>.HomeKeyGenerate(), encodeJson, option);
            return result;


        }
    }
}
