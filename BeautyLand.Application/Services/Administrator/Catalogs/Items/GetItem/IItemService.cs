using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Application.Services.Dtos.BaseDto;
using BeautyLand.Application.Services.Dtos.PaginationDto;
using BeautyLand.Domain.Catalogs.Brands;

namespace BeautyLand.Application.Services.Administrator.Catalogs.Items
{
    public interface IItemService
    {
        BaseDto<int> Create(ItemDto item);
        PaginationDto<ItemGetCatalogDto> Index(int? parentId, int pageIndex, int pageSize);
    }
}
