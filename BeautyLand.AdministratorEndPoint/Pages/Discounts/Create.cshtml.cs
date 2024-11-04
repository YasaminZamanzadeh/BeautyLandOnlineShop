using BeautyLand.AdministratorEndPoint.ModelBinders.DiscountModelBinder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BeautyLand.Application.Services.Administrator.Discounts.GetDiscount;

namespace BeautyLand.AdministratorEndPoint.Pages.Discounts
{
    public class CreateModel : PageModel
    {
        private readonly IDiscountService _discountService;
        public CreateModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [ModelBinder(typeof(DiscountModelBinder))]
        [BindProperty]
        public DiscountDto Model { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            _discountService.GetDiscount(Model);
        }
    }
}
