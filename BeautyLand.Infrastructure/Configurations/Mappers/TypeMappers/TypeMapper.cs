using AutoMapper;
using BeautyLand.Domain.Catalogs.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Infrastructure.Configurations.Mappers.TypeMappers
{
    public class TypeMapper : Profile
    {
        public TypeMapper()
        {
            CreateMap<Domain.Catalogs.Type.Type, Application.Services.Administrator.Catalogs.Types.Dtos.TypeDto.TypeDto>().ReverseMap();

            CreateMap<Domain.Catalogs.Type.Type, Application.Services.Administrator.Catalogs.Types.Dtos.TypeDto.TypeGetCatalogDto>()
                .ForMember(memberOptions => memberOptions.ChildCount,
                destinationMember => destinationMember.MapFrom(p => p.Child.Count));

            CreateMap<Domain.Catalogs.Type.Type, Application.Services.Administrator.Catalogs.Types.Dtos.TypeDto.TypeGetCatalogDto>().ReverseMap()
                .ForMember(memberOptions => memberOptions.Child,
                destinationMember => destinationMember.MapFrom(p => p.ChildCount));

            CreateMap<Domain.Catalogs.Type.Type, Application.Services.Site.Catalogs.Dtos.TypeDto.TypeGetCatalogDto>().ReverseMap();


        }
    }
}
