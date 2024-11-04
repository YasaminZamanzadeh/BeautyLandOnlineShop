using BeautyLand.Application.Services.Dtos.PaginationDto;
using BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto;
using BeautyLand.Application.Services.Site.Catalogs.Items;
using BeautyLand.Application.Services.Site.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Application.Services.Site.Catalogs.Items.GetDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyLand.SiteEndPoint.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemGetCatalogService _itemGetCatalogService;
        private readonly IItemDetailService _itemGetDetailService;
        private readonly IDistributedCache _distributedCache;

        public ItemController(IItemGetCatalogService itemGetCatalogService, IItemDetailService itemGetDetailService, IDistributedCache distributedCache)
        {
            _itemGetCatalogService = itemGetCatalogService;
            _itemGetDetailService = itemGetDetailService;
            _distributedCache = distributedCache;
        }
        public IActionResult Index(FilteringDetailItemDto filter)
        {
            var model = _itemGetCatalogService.Execute(filter);
            return View(model);
        }
        public IActionResult Detail(int id)
        {

            var model = _itemGetDetailService.Execute(id);
            return View(model);
        }
    }
}
