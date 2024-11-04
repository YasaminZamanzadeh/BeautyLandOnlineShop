using AutoMapper;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Dtos.PaginationDto;
using BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto;
using BeautyLand.Application.Services.Site.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Subscription.DistributedCaches;
using BeautyLand.Subscription.Paginations;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyLand.Application.Services.Site.Catalogs.Items
{
    public class ItemGetCatalogService : IItemGetCatalogService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        public ItemGetCatalogService(ISQLDatabaseService context, IMapper mapper, IDistributedCache distributedCache)
        {
            _context = context;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }
        public PaginationDto<ItemsDto> Execute(FilteringDetailItemDto filter)
        {

            var distributedGetCache = _distributedCache.GetAsync(KeyDistributedCacheExtention<string>.ItemKeyGenerate<FilteringDetailItemDto>(filter)).Result;
            if (distributedGetCache != null)
            {
                var modelDeserialize = System.Text.Json.JsonSerializer.Deserialize<PaginationDto<ItemsDto>>(distributedGetCache);
                return modelDeserialize;
            }

            int rowCount = 0;
            var query = _context.Items
                .Include(p => p.Images)
                .AsQueryable();

            if (filter.BrandId != null)
            {
                query = query.Where(p => filter.BrandId.Any(x => x == p.BrandId));
            }

            if (filter.TypeId != null)
            {
                query = query.Where(p => p.TypeId == filter.TypeId);
            }

            if (!string.IsNullOrEmpty(filter.Term))
            {
                query = query.Where(p => p.Name.Contains(filter.Term) || p.Description.Contains(filter.Term));
            }

            if (filter.AvailableStock == true)
            {
                query = query.Where(p => p.AvailableStock > 0);
            }

            if (filter.SortType == SortType.BestSelling)
            {
                query = query.Include(p => p.OrderItems)
                 .OrderByDescending(p => p.OrderItems.Count);
            }


            var items = query.PagedResult(filter.PageIndex, filter.PageSize, out rowCount).ToList();
            var model = _mapper.Map<List<ItemsDto>>(items);
            var result = new PaginationDto<ItemsDto>(filter.PageIndex, filter.PageSize, rowCount, model);
            var modelSerialize = System.Text.Json.JsonSerializer.Serialize(result);
            byte[] encodeJson = Encoding.UTF8.GetBytes(modelSerialize);
            var option = new DistributedCacheEntryOptions().SetSlidingExpiration(KeyDistributedCacheExtention<string>.Duration);
            _distributedCache.SetAsync(KeyDistributedCacheExtention<string>.ItemKeyGenerate<FilteringDetailItemDto>(filter), encodeJson, option);

            return result;
        }
    }
}
