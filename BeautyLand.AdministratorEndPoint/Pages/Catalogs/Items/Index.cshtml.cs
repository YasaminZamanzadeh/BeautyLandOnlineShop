using AutoMapper;
using BeautyLand.Application.Services.Administrator.Catalogs.Items;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Application.Services.Dtos.PaginationDto;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyLand.AdministratorEndPoint.Pages.Catalogs.Items
{
    public class IndexModel : PageModel
    {
        private readonly IItemService _itemCrudService;
        private readonly IMapper _mapper;

        public IndexModel(IItemService itemCrudService, IMapper mapper)
        {
            _itemCrudService = itemCrudService;
            _mapper = mapper;
        }
        public PaginationDto<ItemGetCatalogDto> Model { get; set; }

        public void OnGet(int? parentId, int pageIndex = 1, int pageSize = 100, int totalPage = 100)
        {
            Model = _itemCrudService.Index(parentId,pageIndex, pageSize);
        }
    }
}