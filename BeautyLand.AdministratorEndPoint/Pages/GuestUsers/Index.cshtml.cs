using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyLand.Application.Services.Administrator.GuestUsers.GuestUserReport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyLand.AdministratorEndPoint.Pages.GuestUsers
{
    public class IndexModel : PageModel
    {
        private readonly IGuestUserReportService _guestUserReportService;
        public IndexModel(IGuestUserReportService guestUserReportService)
        {
            _guestUserReportService = guestUserReportService;
        }
        public GuestUserReportDto Model { get; set; }
        public void OnGet()
        {
            Model = _guestUserReportService.Execute();
        }
    }
}
