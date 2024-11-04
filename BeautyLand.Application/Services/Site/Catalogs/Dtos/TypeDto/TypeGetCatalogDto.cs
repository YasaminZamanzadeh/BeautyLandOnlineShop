using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Catalogs.Dtos.TypeDto
{
    public class TypeGetCatalogDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public List<TypeGetCatalogDto> Child { get; set; } = new List<TypeGetCatalogDto>();

    }
}
