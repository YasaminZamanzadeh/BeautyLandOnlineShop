using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto;
using BeautyLand.Domain.Catalogs.Items;
using BeautyLand.Subscription.ExceptionExtentions;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Catalogs.Items.GetDetails
{

    public class ItemDetailService : IItemDetailService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IURIComposerService _uriComposerService;

        public ItemDetailService(ISQLDatabaseService context, IURIComposerService uriComposerService)
        {
            _context = context;
            _uriComposerService = uriComposerService;
        }
        public DetailItemDto Execute(int id)
        {
            var items = _context.Items
                 .Include(p => p.Features)
                 .Include(p => p.Images)
                 .Include(p => p.Type)
                 .Include(p => p.Brand)
                 .Include(p => p.Discounts)
                 .SingleOrDefault(p => p.Id == id);

            if (items == null)
            {
                throw new NotFoundExceptionExtention<Item, int>(items, id);
            }


            items.Viwes += 1;
            _context.SaveChanges();

            var features = _context.Features
                .Select(p => new FeatureItemDto
                { 
                Group = p.Group,
                Key = p.Key,
                Value = p.Value
                }).ToList()
                .GroupBy(p=> p.Group);

            var similarItem = _context.Items
                .Include(p => p.Images)
                .Where(p => p.TypeId == items.Type.Id)
                .Take(10)
                .Select(p => new SimilarItemsDto
                { 
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.Images.FirstOrDefault() != null ? _uriComposerService.Execute(p.Images.FirstOrDefault().Source) : null,
                }).ToList();


            return new DetailItemDto
            {
                Id = items.Id,
                Name = items.Name,
                Type = items.Type.Name,
                Brand = items.Brand.Name,
                Description = items.Description,
                Price = items.Price,
                AvailableStock = items.AvailableStock,
                OldPrice = items.OldPrice,
                DiscountPercentage = items.DiscountPercentage,
                Images = items.Images
                .Select(p=> _uriComposerService.Execute(p.Source))
                .ToList(),
                Features = features,
                SimilarItem = similarItem, 
            };
        }
    }
}
