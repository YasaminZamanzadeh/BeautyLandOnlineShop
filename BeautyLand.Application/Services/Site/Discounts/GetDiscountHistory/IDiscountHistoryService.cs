using BeautyLand.Application.Services.Dtos.PaginationDto;
using BeautyLand.Domain.Discounts;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Discounts.GetDiscountHistory
{
    public interface IDiscountHistoryService
    {
        void CreateDiscountHistory(int discountId, int orderId);
        DiscountHistory GetDiscountHistory(int discountHistoryId);
        PaginationDto<DiscountHistory> GetCatalogDiscountHistory(int? discountId, string? userId, int pageIndex, int pageSize);
    }
}
