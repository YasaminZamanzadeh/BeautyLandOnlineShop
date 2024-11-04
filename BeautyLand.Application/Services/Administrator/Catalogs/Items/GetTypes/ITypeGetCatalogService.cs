using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using System.Collections.Generic;

namespace BeautyLand.Application.Services.Administrator.Catalogs.Items.GetTypes
{
    public interface ITypeGetCatalogService
    {
        List<TypeGetCatalogDto> Execute();
    }
}

