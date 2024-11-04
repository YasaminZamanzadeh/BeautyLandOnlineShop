using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using System.Collections.Generic;

namespace BeautyLand.Application.Services.Administrator.Catalogs.Items.GetBrands
{
    public interface IBrandGetCatalogService
    {
        List<BrandGetCatalogDto> Execute();
    }
}

