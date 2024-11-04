using System.Collections.Generic;

namespace BeautyLand.Application.Services.Site.Catalogs
{
    public interface IBrandGetCatalogService
    {
        List<BrandGetCatalogDto> Execute();

    }
}
