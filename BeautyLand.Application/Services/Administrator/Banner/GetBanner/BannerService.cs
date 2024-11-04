using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Subscription.DistributedCaches;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Administrator.Banner.GetBanner
{
    public class BannerService: IBannerService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IDistributedCache _distributedCache;
        public BannerService(ISQLDatabaseService context, IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;
        }

        public void Create(BannerDto banner)
        {
            _context.Banners.Add(new Domain.Banner.Banner
            {
            Name = banner.Name,
            Image = banner.Image,
            Link = banner.Link,
            IsActive = banner.IsActive,
            Priority = banner.Priority,
            BannerPosition = banner.BannerPosition
            });
            _context.SaveChanges();
        }

        public List<BannerDto> Index()
        {
            var banners = _context.Banners
                 .OrderBy(p => p.Priority)
                 .OrderByDescending(p => p.Id)
                 .Select(p => new BannerDto
                 {
                     Name = p.Name,
                     Image = p.Image,
                     Link = p.Link,
                     IsActive = p.IsActive,
                     Priority = p.Priority,
                     BannerPosition = p.BannerPosition
                 }).ToList();

            _distributedCache.Remove(KeyDistributedCacheExtention<string>.HomeKeyGenerate());
            return banners;
        }
    }
}
