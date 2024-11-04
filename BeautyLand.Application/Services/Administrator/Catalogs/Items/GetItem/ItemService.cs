using AutoMapper;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Dtos.BaseDto;
using BeautyLand.Application.Services.Dtos.PaginationDto;
using BeautyLand.Domain.Catalogs.Features;
using BeautyLand.Domain.Catalogs.Images;
using BeautyLand.Domain.Catalogs.Items;
using BeautyLand.Subscription.Paginations;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace BeautyLand.Application.Services.Administrator.Catalogs.Items
{

    public class ItemService : IItemService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IMapper _mapper;
        public ItemService(ISQLDatabaseService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BaseDto<int> Create(ItemDto item)
        {
  
            var model =MappingItem(item);
            _context.Items.Add(model);
            _context.SaveChanges();
            return new BaseDto<int>(model.Id, new List<string> { "ایجاد شد" }, true);
        }

        public PaginationDto<ItemGetCatalogDto> Index(int? parentId, int pageIndex, int pageSize)

        {
            int rowCount = 0;
            var items = _context.Items
                .Include(p => p.Images)
                .Include(p=> p.Brand)
                .Include(p=> p.Type)
                .OrderByDescending(p => p.Id)
                .PagedResult(pageIndex, pageSize, out rowCount)
               .ToList();

            var model = _mapper.Map<List<ItemGetCatalogDto>>(items);
            return new PaginationDto<ItemGetCatalogDto>(pageIndex, pageSize, rowCount, model);
        }


        private Item MappingItem(ItemDto item)
        {
            Item model = new Item  
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                TypeId = item.TypeId,
                BrandId = item.BrandId,
                AvailableStock = item.AvailableStock,
                RestockThreshold = item.RestockThreshold,
                MaxStockThreshold = item.MaxStockThreshold,
                Features = MappingFeatures(item.Features),
                Images = MappingImages(item.Images)
            };

            return model;
        }

        private List<Feature> MappingFeatures(List<ItemFeatureDto> feature)
        {
            return feature.Select(p => new Feature
            {
                Key = p.Key,
                Value = p.Value,
                Group = p.Group
            }).ToList();
        }

        private List<Image> MappingImages(List<ImageGetCatalogDto> imageDtos)
        {
            return imageDtos.Select(p => new Image
            {
                Source = p.Source
            }).ToList();
        }
    }
}