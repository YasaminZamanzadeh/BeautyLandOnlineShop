using AutoMapper;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Domain.Catalogs.Brands;
using BeautyLand.Domain.Catalogs.Features;
using BeautyLand.Domain.Catalogs.Images;
using BeautyLand.Domain.Catalogs.Items;
using BeautyLand.Domain.Catalogs.Type;
using System.Linq;

namespace BeautyLand.Infrastructure.Configurations.Mappers.ItemMappers
{

    public class ItemMapper : Profile
    {
        public ItemMapper()
        {
           // CreateMap<Item, ItemDto>()
           //.ForMember(destinationMember => destinationMember.Features, 
           //memberOptions => memberOptions.MapFrom(sourceMember =>
           //sourceMember.Features.Select(f => new Feature
           //    {
           //        Key = f.Key,
           //        Value = f.Value,
           //        Group = f.Group
           //    })))
           //.ForMember(destinationMember => destinationMember.Images,
           //memberOptions => memberOptions.MapFrom(sourceMember =>
           //    sourceMember.Images.Select(i => new Image
           //    {
           //        Source = i.Source
           //    })));

           // CreateMap<Feature, ItemFeatureDto>()
           //      .ReverseMap();
           // CreateMap<Image, ImageGetCatalogDto>()
           // .ReverseMap();


            CreateMap<Item, Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto.ItemGetCatalogDto>()
                .ForMember(destinationMember => destinationMember.Brand,
                memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Brand.Name))
                .ForMember(destinationMember => destinationMember.Type,
                memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Type.Name))
                .ForMember(destinationMember => destinationMember.Image,
                memberOptions => memberOptions.MapFrom<ImageValueResolver<Item, ItemGetCatalogDto>>())
                .ReverseMap();

            CreateMap<Item, Application.Services.Site.Catalogs.Items.Dtos.ItemDto.ItemsDto>()
                .ForMember(destinationMember => destinationMember.Image,
                memberOptions => memberOptions.MapFrom<ImageValueResolver<Item, Application.Services.Site.Catalogs.Items.Dtos.ItemDto.ItemsDto>>())
                .ReverseMap();


            //CreateMap<Item, ItemGetDetailDto>()
            //    .ForMember(destinationMember => destinationMember.Images, memberOptions => memberOptions.MapFrom<ImagesValueResolver>())
            //    .ForMember(destinationMember=> destinationMember.Features, memberOptions=> memberOptions.MapFrom(sourceMember => sourceMember.Features
            //    .Select(keySelector => new FeatureGetCatalogDto
            //   {
            //       Group = keySelector.Group,
            //       Key = keySelector.Key,
            //       Value = keySelector.Value
            //   })
            //    .GroupBy(keySelector => new FeatureGetCatalogDto
            //    { 
            //    Group = keySelector.Group
            //    })
            //    .ToList()))
            //    .ForMember(destinationMember => destinationMember.SimilarItem, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Name
            //    .Select(keySelector=> new ItemGetSimilarItemDto
            //    {
            //     //  there is not SimilarItme on database
            //    })))
            //    .ForMember(destinationMember => destinationMember.Type, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Type.Name))
            //    .ForMember(destinationMember => destinationMember.Brand, opt => opt.MapFrom(sourceMember => sourceMember.Brand.Name))
            //    .ReverseMap();
            //CreateMap<Item, ItemGetSimilarItemDto>()
            //        .ForMember(destinationMember => destinationMember.Image, memberOptions => memberOptions.MapFrom<ImageValueResolver<Item, ItemGetSimilarItemDto>>())
            //        .ReverseMap();
            //    CreateMap<Feature, FeatureGetCatalogDto>()
            //        .ReverseMap();



            CreateMap<Type, TypeGetCatalogDto>()
                .ReverseMap();

            CreateMap<Brand, BrandGetCatalogDto>()
                .ReverseMap();


        }
    }
}
