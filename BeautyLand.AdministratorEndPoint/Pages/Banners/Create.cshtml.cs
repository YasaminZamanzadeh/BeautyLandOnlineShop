using BeautyLand.Application.Services.Administrator.Banner.GetBanner;
using BeautyLand.Infrastructure.Services.Catalogs.Items;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.AdministratorEndPoint.Pages.Banners
{
    public class CreateModel : PageModel
    {
        private readonly IBannerService _bannerService;
        private readonly IImageService _imageService;

        public CreateModel(IBannerService bannerService, IImageService imageService)
        {
            _bannerService = bannerService;
            _imageService = imageService;
        }
        [BindProperty]
        public BannerDto Model { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var model = _imageService.Execute(new List<IFormFile>
            {
               Image
            });

            if (model.Count > 0)
            {
                Model.Image = model.FirstOrDefault();
                _bannerService.Create(Model);
            }

            return Redirect("Index");

        }
    }
}
