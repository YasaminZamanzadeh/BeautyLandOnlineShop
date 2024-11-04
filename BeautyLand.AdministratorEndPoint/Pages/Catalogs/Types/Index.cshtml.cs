using BeautyLand.Application.Services.Administrator.Catalogs.Types;
using BeautyLand.Application.Services.Administrator.Catalogs.Types.Dtos.TypeDto;
using BeautyLand.Application.Services.Dtos.PaginationDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BeautyLand.AdministratorEndPoint.Pages.Catalogs.Types
{
    public class IndexModel : PageModel
    {
        private readonly ITypeService _typeService;
        public IndexModel(ITypeService typeService)
        {
            this._typeService = typeService;
        }
        public PaginationDto<TypeGetCatalogDto> Model { get; set; }
        public async Task<IActionResult> OnGet(int? parentId, int pageIndex = 1, int pageSize = 2)
        {
            Model = _typeService.Index(parentId, pageIndex, pageSize);
            return Page();
        }
    }
}
