using AutoMapper;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Administrator.Catalogs.Items.GetBrands
{
    public class BrandGetCatalogService : IBrandGetCatalogService
    {

        private readonly ISQLDatabaseService _context;
        private readonly IMapper _mapper;
        public BrandGetCatalogService(ISQLDatabaseService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<BrandGetCatalogDto> Execute()
        {
            var brands = _context.Brands
                .OrderByDescending(p => p.Id)
                .ToList();
            var model = _mapper.Map<List<BrandGetCatalogDto>>(brands);
            return model;
        }
    }
}

