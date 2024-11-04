using BeautyLand.Application.Services.Administrator.Catalogs.Types.Dtos.TypeDto;
using BeautyLand.Application.Services.Dtos.BaseDto;
using BeautyLand.Application.Services.Dtos.PaginationDto;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Administrator.Catalogs.Types
{
    public interface ITypeService
    {
        // trasaction script : it implements just an operation 
        // table module : it implements multiple operation 
        BaseDto<TypeDto> Create(TypeDto type);
        BaseDto<TypeDto> Edit(TypeDto type);
        BaseDto Delete(int id);
        BaseDto<TypeDto> Find(int id);
        PaginationDto<TypeGetCatalogDto> Index(int? parentId, int pageNumber, int pageSize);
    }
}
