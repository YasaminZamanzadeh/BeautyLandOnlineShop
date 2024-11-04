using AutoMapper;
using BeautyLand.AdministratorEndPoint.Models.ViewModels.Catalogs.Types;
using BeautyLand.Application.Services.Administrator.Catalogs.Types;
using BeautyLand.Application.Services.Administrator.Catalogs.Types.Dtos.TypeDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautyLand.AdministratorEndPoint.Pages.Catalogs.Types
{
    public class CreateModel : PageModel
    {
        private readonly ITypeService _typeService;
        private readonly IMapper _mapper;
        public CreateModel(ITypeService typeService, IMapper mapper)
        {
            _typeService = typeService;
            _mapper = mapper;
        }
        [BindProperty]
        public TypeViewModel Model { get; set; } = new TypeViewModel();
        public IEnumerable<string> Messages { get; set; } = new List<string>();
        public async Task<IActionResult> OnGetAsync(int? parentId)
        {
            Model.ParentId = parentId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var type = new TypeDto
            {
                Id = Model.Id,
                Name = Model.Name,
                ParentId = Model.ParentId,
            };

            var result = _typeService.Create(type);

            if (result.IsSuccess)
            {
                return RedirectToPage("index", new { parentId = result.Model.ParentId });
            }
            Messages = result.Messages;
            return Page();
        }
    }
}