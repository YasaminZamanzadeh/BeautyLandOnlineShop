using BeautyLand.Application.Services.Site.Catalogs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Models.ViewComponents.Catalogs.Brands
{
    public class BrandsViewComponent:ViewComponent
    {
        private readonly IBrandGetCatalogService _brandGetCatalogService;
        public BrandsViewComponent(IBrandGetCatalogService brandGetCatalogService)
        {
            _brandGetCatalogService = brandGetCatalogService;
        }

        public IViewComponentResult Invoke()
        {
            var brands = _brandGetCatalogService.Execute();
            return View("BrandsComponent", brands);
        }
    }
}
