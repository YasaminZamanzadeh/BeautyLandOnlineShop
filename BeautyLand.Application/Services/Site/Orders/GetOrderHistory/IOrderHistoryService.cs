using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Orders.GetOrderDetail
{
    public interface IOrderHistoryService
    {
        List<OrderHistoryDto> Execute(string userId);
    }

}
