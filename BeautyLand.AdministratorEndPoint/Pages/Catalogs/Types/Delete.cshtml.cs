using BeautyLand.AdministratorEndPoint.Models.ViewModels.Catalogs.Types;
using BeautyLand.Application.Services.Administrator.Catalogs.Types;
using BeautyLand.Application.Services.Administrator.Catalogs.Types.Dtos.TypeDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautyLand.AdministratorEndPoint.Pages.Catalogs.Types
{
    public class DeleteModel : PageModel
    {
        private readonly ITypeService _typeService;
        public DeleteModel(ITypeService typeService)
        {
            _typeService = typeService;
        }
        [BindProperty]
        public TypeViewModel Model { get; set; } = new TypeViewModel();
        public IEnumerable<string> Messages { get; set; } = new List<string>();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var type = _typeService.Find(id);
            if (type == null)
            {
                return NotFound();
            }
            Model = new TypeViewModel
            {
                Id = id,
                Name = type.Model.Name,
                ParentId = type.Model.ParentId,
            };
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var type = new TypeDto
            {
                Id = Model.Id,
                Name = Model.Name,
                ParentId = Model.ParentId
            };
            var result = _typeService.Delete(type.Id);
            if (result.IsSuccess)
            {
                return RedirectToPage("index");
            }
            Messages = result.Messages;

            return Page();
        }
    }
}
