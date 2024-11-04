using BeautyLand.Application.Services.Administrator.Catalogs.Types.Dtos.TypeDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Catalogs.Types
{
    public interface ITypeService
    {
        List<Dtos.TypeDto.TypeGetCatalogDto> Execute();
    }
}
