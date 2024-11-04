using BeautyLand.Application.Services.Administrator.Catalogs.Items;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.GetBrands;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.GetTypes;
using BeautyLand.Application.Services.Dtos.BaseDto;
using BeautyLand.Infrastructure.Services.Catalogs.Items;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.AdministratorEndPoint.Pages.Catalogs.Items
{
    public class CreateModel : PageModel
    {
        private readonly IItemService _typeCrudService;
        private readonly ITypeGetCatalogService _typeGetCatalogService;
        private readonly IBrandGetCatalogService _brandGetCatalogService;
        private readonly IImageService _itemImageService;

        public CreateModel(
            IItemService typeCrudService,
            ITypeGetCatalogService typeGetCatalogService, 
            IBrandGetCatalogService brandGetCatalogService,
            IImageService itemImageService)
        {
            _typeCrudService = typeCrudService; 
            _typeGetCatalogService = typeGetCatalogService;
            _brandGetCatalogService = brandGetCatalogService; 
            _itemImageService = itemImageService;
        }
		[BindProperty]
		public ItemDto Model { get; set; }
		public SelectList BrandModel { get; set; }
		public SelectList TypeModel { get; set; }
		[BindProperty]
		public List<IFormFile> Files { get; set; }
		public void OnGet()

		{
			TypeModel = new SelectList(_typeGetCatalogService.Execute(), "Id", "Name");
			BrandModel = new SelectList(_brandGetCatalogService.Execute(), "Id", "Name");

		}
        public JsonResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(p => p.Errors);
                return new JsonResult(new BaseDto<int>(0, errors.Select(p => p.ErrorMessage).ToList(), false));
            }

            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                Files.Add(file);
            }

            List<ImageGetCatalogDto> images = new List<ImageGetCatalogDto>();
            if (Files.Count > 0)
            {
                var resultImage = _itemImageService.Execute(Files);
                foreach (var file in resultImage)
                {
                    images.Add(new ImageGetCatalogDto
                    {
                        Source = file,
                    });
                }

            }
            Model.Images = images;
            var resultProduct = _typeCrudService.Create(Model);
            return new JsonResult(resultProduct);
        }
    }
}
