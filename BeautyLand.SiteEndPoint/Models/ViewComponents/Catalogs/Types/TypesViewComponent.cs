using BeautyLand.Application.Services.Site.Catalogs.Types;
using Microsoft.AspNetCore.Mvc;

namespace BeautyLand.SiteEndPoint.Models.ViewComponents.Catalogs.Types.TypeMenu
{
    public class TypesViewComponent : ViewComponent
    {
        private readonly ITypeService _typeMenuService;
        public TypesViewComponent(ITypeService typeMenuService)
        {
            _typeMenuService = typeMenuService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _typeMenuService.Execute();
            return View("TypesComponent", model);
        }
    }
}
