using AutoMapper;
using BeautyLand.Application.Services.Site.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Infrastructure.Configurations.Mappers.BrandMappers
{
  public class BrandMapper: Profile
    {
        public BrandMapper()
        {
            CreateMap<Domain.Catalogs.Brands.Brand, BrandGetCatalogDto>()
                .ReverseMap();
        }
    }
}
