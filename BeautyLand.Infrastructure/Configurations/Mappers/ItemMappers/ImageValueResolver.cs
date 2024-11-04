using AutoMapper;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Domain.Catalogs.Images;
using BeautyLand.Domain.Catalogs.Items;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Infrastructure.Configurations.Mappers.ItemMappers
{
    public class ImageValueResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, string>
    {
        private readonly IURIComposerService _uriComposerService;

        public ImageValueResolver(IURIComposerService uriComposerService)
        {
            _uriComposerService = uriComposerService;
        }

        public string Resolve(TSource source, TDestination destination, string destMember, ResolutionContext context)
        {
            var image = typeof(TSource).GetProperty("Images");
            var images = image?.GetValue(source) as IEnumerable<Image>;

            if (images == null || !images.Any())
            {
                return null;
            }

            return _uriComposerService.Execute(images.FirstOrDefault().Source);

        }
    }
}