using System.Collections.Generic;

namespace BeautyLand.Application.Services.Administrator.GuestUsers.GuestUserReport
{
    public class GuestUserReportDto
    {
        public GuestUserGetCatalogReportDto TotalReport { get; set; }
        public GuestUserGetCurrentReportDto SingleReport { get; set; }
        public IEnumerable<GuestUserGetRecentReportDto> RecentReport { get; set; }
    }
}
