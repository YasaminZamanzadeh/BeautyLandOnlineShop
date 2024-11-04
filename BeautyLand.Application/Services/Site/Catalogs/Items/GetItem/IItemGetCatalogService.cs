using BeautyLand.Application.Services.Dtos.PaginationDto;
using BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto;
using BeautyLand.Application.Services.Site.Catalogs.Items.Dtos.ItemDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Catalogs.Items
{
    public interface IItemGetCatalogService
    {
        PaginationDto<ItemsDto> Execute(FilteringDetailItemDto filter);
    }
}
