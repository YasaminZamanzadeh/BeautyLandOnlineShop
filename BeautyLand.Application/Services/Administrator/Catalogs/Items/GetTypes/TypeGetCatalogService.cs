using AutoMapper;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Administrator.Catalogs.Items.GetTypes
{
    public class TypeGetCatalogService : ITypeGetCatalogService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IMapper _mapper;
        public TypeGetCatalogService(ISQLDatabaseService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<TypeGetCatalogDto> Execute()
        {
            var types = _context.Types
               .Include(p => p.Parent)
               .Include(p => p.Parent)
               .ThenInclude(p => p.Parent.Parent)
               .Include(p => p.Child)
               .Where(p => p.Parent != null)
               .Where(p => p.Child.Count == 0)
               .Select(p => new { p.Id, p.Name, p.Parent, p.Child })
               .ToList()
               .Select(p => new TypeGetCatalogDto
               {
                   Id = p.Id,
                   Name = $"{p?.Name ?? " "}"
               })
               .ToList();
            var model = _mapper.Map<List<TypeGetCatalogDto>>(types);
            return model;
        }
    }
}
