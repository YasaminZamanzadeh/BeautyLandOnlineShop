using AutoMapper;
using BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto;
using BeautyLand.Domain.Catalogs.Images;
using BeautyLand.Domain.Catalogs.Items;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Infrastructure.Configurations.Mappers.ItemMappers
{
    public class ImagesValueResolver : IValueResolver<Item, DetailItemDto, List<string>>
    {
        private readonly IURIComposerService _uriComposerService;

        public ImagesValueResolver(IURIComposerService uriComposerService)
        {
            _uriComposerService = uriComposerService;
        }

        public List<string> Resolve(Item source, DetailItemDto destination, List<string> destMember, ResolutionContext context)
        {
            return source.Images.Select(image => _uriComposerService.Execute(image.Source)).ToList();
        }
    }
}