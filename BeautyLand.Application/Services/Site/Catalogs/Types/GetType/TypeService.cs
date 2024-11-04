using AutoMapper;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Catalogs.Types
{
    public class TypeService : ITypeService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IMapper _mapper;
        public TypeService(ISQLDatabaseService context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;   
        }
        public List<Dtos.TypeDto.TypeGetCatalogDto> Execute()
        {
            var types = _context.Types
                 .Include(p => p.Parent)
                 .ToList();
            var model = _mapper.Map<List<Dtos.TypeDto.TypeGetCatalogDto>>(types);
            return model;  
        }
    }
}
